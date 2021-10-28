using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.UI.Selection;
using MySConn;
using MySConn.Tables;

namespace Revit_HyCal
{
    [Transaction(TransactionMode.Manual)]
    public static class UIOperation
    {
        public static UIDocument uIDocument;//每次文件运行的时候，一个revit对应一个uidoc
        //public static Document document;
        //public static List<ElementId> ElementIds = new List<ElementId>();
        public static ConnectorSet GetConnectorSet(Document document, ElementId elementId)
        {
            //from the elementid to get all the connectors
            Element element = document.GetElement(elementId);
            //temporary group is out of consider
            try
            {
                switch (element.Category.Name)
                {
                    case "风管":
                        //Duct duct = element as Duct;
                        return (element as MEPCurve).ConnectorManager.Connectors;
                    case "软风管":
                        //Duct duct = element as Duct;
                        return (element as MEPCurve).ConnectorManager.Connectors;
                    //case "风管管件":
                    //    familyInstance = element as FamilyInstance;
                    //    return familyInstance.MEPModel.ConnectorManager.Connectors;
                    //case "风管末端":
                    //    familyInstance = element as FamilyInstance;
                    //    return familyInstance.MEPModel.ConnectorManager.Connectors;
                    //case "风管附件":
                    //    familyInstance = element as FamilyInstance;
                    //    return familyInstance.MEPModel.ConnectorManager.Connectors;
                    default:
                        FamilyInstance familyInstance = element as FamilyInstance;
                        return familyInstance.MEPModel.ConnectorManager.Connectors;
                }
            }
            catch
            {
                throw new Exception("Cannot Find the Connector!");
            }

        }
        public static List<ElementId> SelectPipeline(UIDocument uIDocument,Document document)
        {
            //选取管道原件，并指定起始端，返回元素id集合，起始端id放最后
            //!!!Causion last one is element_origin
            List<ElementId> elementIds = new List<ElementId>();
            try
            {
                //pickup all the elementids of the pipeline
                IList<Reference> references = uIDocument.Selection.PickObjects(ObjectType.Element);
                foreach (Reference reff in references)
                {
                    elementIds.Add(reff.ElementId);
                }
                //if the elementids contain the group elements , 
                //elementids kick off the group elements and union the groupelementids
                List<ElementId> groupElementIds = new List<ElementId>();
                foreach (ElementId id in elementIds)
                {
                    Group group = document.GetElement(id) as Group;
                    if (group != null) { groupElementIds.Add(id); }
                }//get the groupids
                if (groupElementIds.Count > 0)
                {
                    elementIds = elementIds.Except(groupElementIds).ToList<ElementId>();
                    foreach (ElementId id in groupElementIds)
                    {
                        Group group = document.GetElement(id) as Group;
                        elementIds = elementIds.Union(group.GetMemberIds()).ToList<ElementId>();//causion getmenberids contains elements of not solid elementid
                    }
                }
                TaskDialog.Show("Prompt", "Please Select the Origin of Selection Before!(No Group Element)");

                //pick up the original elementid of the pipeline
                ElementId elementId_origin = null;
                do
                {
                    elementId_origin = uIDocument.Selection.PickObject(ObjectType.Element).ElementId;

                } while ((document.GetElement(elementId_origin) as Group) != null);
                
                elementIds.Add(elementId_origin);
                return elementIds;
            }
            catch
            {
                throw new Exception("HVAC Hydraulic Calculation App Quit");
            }
        }

        public static List<ElementId> SecSelectPipeline(UIDocument uIDocument, Document document,List<ElementId> elementIds)
        {
            //二次选取,输入的eleids有修改，不能传递原始集合
            //选取管道原件，并指定起始端，返回元素id集合，起始端id放最后
            //!!!Causion last one is element_origin
            //List<ElementId> elementIds = new List<ElementId>();
            TaskDialog.Show("Second Selection!", "Second Selection!");
            List<Reference> prereferences = new List<Reference>();
            foreach (ElementId id in elementIds)
            {
                prereferences.Add(new Reference(document.GetElement(id)));
            }
            elementIds.Clear();
            try
            {
                //pickup all the elementids of the pipeline
                IList<Reference> references = uIDocument.Selection.PickObjects(ObjectType.Element,new MassSelectionFilter(),"Second Select", prereferences);
                foreach (Reference reff in references)
                {
                    elementIds.Add(reff.ElementId);
                }
                #region
                //if the elementids contain the group elements , 
                //elementids kick off the group elements and union the groupelementids
                List<ElementId> groupElementIds = new List<ElementId>();
                foreach (ElementId id in elementIds)
                {
                    Group group = document.GetElement(id) as Group;
                    if (group != null) { groupElementIds.Add(id); }
                }//get the groupids
                if (groupElementIds.Count > 0)
                {
                    elementIds = elementIds.Except(groupElementIds).ToList<ElementId>();
                    foreach (ElementId id in groupElementIds)
                    {
                        Group group = document.GetElement(id) as Group;
                        elementIds = elementIds.Union(group.GetMemberIds()).ToList<ElementId>();//causion getmenberids contains elements of not solid elementid
                    }
                }
                TaskDialog.Show("Prompt", "Please Select the Origin of Selection Before!(No Group Element)");
                #endregion
                //pick up the original elementid of the pipeline
                ElementId elementId_origin = null;
                do
                {
                    elementId_origin = uIDocument.Selection.PickObject(ObjectType.Element).ElementId;

                } while ((document.GetElement(elementId_origin) as Group) != null);

                elementIds.Add(elementId_origin);
                //*****************按顺序录入管道系统(无组图元，组内非链接键连接则系统将分成两个部分）,使用连接键，不使用碰撞
                List<ElementId> lstPipelineids = new List<ElementId>();
                ElementId origin_elementid = elementIds[elementIds.Count - 1];
                elementIds.Remove(origin_elementid); elementIds.Remove(origin_elementid);
                try
                {
                    lstPipelineids = UIOperation.GetPipelineElementID(document, elementIds, origin_elementid);
                }
                catch (Exception e)
                {
                    TaskDialog.Show("Prompt", e.Message);
                }
                return lstPipelineids;
            }
            catch
            {
                throw new Exception("HVAC Hydraulic Calculation App Quit");
            }
        }
        public static ElementId GetAnotherIDAtConnector(ElementId ownerID,Connector connector)
        {
            ElementId id = null;
            if (connector.IsConnected)
            {
                //if (connector.AllRefs.Size > 2) { TaskDialog.Show("1", "more then 2"); }
                foreach(Connector c in connector.AllRefs)
                {
                    if (c.Owner.Id != ownerID) 
                    {
                        switch (c.ConnectorType)
                        {
                            case ConnectorType.End:
                                return c.Owner.Id;
                            case ConnectorType.Curve:
                                return c.Owner.Id;
                            case ConnectorType.Physical:
                                return c.Owner.Id;
                        }
                    }
                }
                return id;
            }
            else
            {
                return id;
            }
        }

        public static List<ElementId> GetPipelineElementID(Document document,List<ElementId> elementIds,ElementId origin_elementid)
        {
            //根据传入的id集合及起始端id，根据链接键历遍所有链接管道,elementids 不包含origin_elementid
            List<ElementId> lstPipelineids = new List<ElementId>();
            lstPipelineids.Add(origin_elementid);
            while (elementIds.Count > 0)
            {
                ElementId rootId = lstPipelineids[lstPipelineids.Count - 1];//take the last one of pipeline
                ConnectorSet connectorSet = UIOperation.GetConnectorSet(document, rootId);//get all the connectors of the rootid
                List<ElementId> lstOtherConnectElementIds = new List<ElementId>();
                foreach (Connector c in connectorSet)
                {
                    ElementId id = UIOperation.GetAnotherIDAtConnector(rootId, c);
                    if (elementIds.Contains(id))
                    {
                        lstOtherConnectElementIds.Add(id);
                        lstPipelineids.Add(id);
                        elementIds.Remove(id);
                        break;
                    }
                }
                if (lstOtherConnectElementIds.Count == 0) { break; }
            }
            return lstPipelineids;
        }
    
        public static string get_Parameters(UIDocument uIDocument,Document document,string par_name,ElementId id)
        {
            Element element = document.GetElement(id);
            ParameterSet parameterSet = element.Parameters;
            foreach (Parameter par in parameterSet)
            {
                if (par.Definition.Name ==par_name)
                {
                    char[] s = { ' '};
                    return par.AsValueString().Split(s)[0];
                }
            }
            throw new Exception("Error: Can not get the parameter of " + par_name);
            //return 0;
        }

        public static List<ElementId> pickPileLine(UIDocument uIDocument,Document document)
        {
            //输入空list<> 返回list<>
            //*************传统选取元素方法
            List<ElementId> elementIds = new List<ElementId>();
            try
            {
                elementIds = UIOperation.SelectPipeline(uIDocument, document);
            }
            catch (Exception e)
            {
                TaskDialog.Show("Prompt", e.Message);
            }
            if (elementIds.Count == 0)
            {
                TaskDialog.Show("Prompt", "HVAC Hydraulic Calculation App Quit!");
            }
            //*****************按顺序录入管道系统(无组图元，组内非链接键连接则系统将分成两个部分）,使用连接键，不使用碰撞
            List<ElementId> lstPipelineids = new List<ElementId>();
            ElementId origin_elementid = elementIds[elementIds.Count - 1];
            elementIds.Remove(origin_elementid); elementIds.Remove(origin_elementid);
            try
            {
                lstPipelineids = UIOperation.GetPipelineElementID(document, elementIds, origin_elementid);
            }
            catch (Exception e)
            {
                TaskDialog.Show("Prompt", e.Message);
            }
            return lstPipelineids;
        }

        public static Project ElementIdsToProject(List<ElementId> ElementIds, Project project)
        {
            //补全project的eleids
            if (project.elementIds.Count==0&& project.dataElements.Count>0)
            {
                foreach (DataElement item in project.dataElements)
                {
                    project.elementIds.Add(new ElementId(item.ID));
                }
            }
            //elementids 是有顺序的
            project.dataElements.Clear();
            for (int i = 0; i < ElementIds.Count; i++)
            {
                Element element = UIOperation.uIDocument.Document.GetElement(ElementIds[i]);
                //不保存remark信息，一律重新改写
                DataElement data = new DataElement();
                data.No = i + 1;
                data.ID = ElementIds[i].IntegerValue;
                try
                {
                    switch (element.Category.Name)
                    {
                        case "风管":
                            data.Remarks = "风管";
                            data.Width = double.Parse(get_Par(ElementIds[i], "宽度"));
                            data.Height = double.Parse(get_Par(ElementIds[i], "高度"));
                            data.Diameter = double.Parse(get_Par(ElementIds[i], "水力直径"));
                            data.Length = double.Parse(get_Par(ElementIds[i], "长度"));
                            data.Airflow = double.Parse(get_Par(ElementIds[i], "流量"));
                            data.R = project.cal_R(data.Diameter, data.V);
                            project.dataElements.Add(data);
                            break;
                        case "软风管":
                            data.Remarks = "风管";
                            data.Width = double.Parse(get_Par(ElementIds[i], "宽度"));
                            data.Height = double.Parse(get_Par(ElementIds[i], "高度"));
                            data.Diameter = double.Parse(get_Par(ElementIds[i], "水力直径"));
                            data.Length = double.Parse(get_Par(ElementIds[i], "长度"));
                            data.Airflow = double.Parse(get_Par(ElementIds[i], "流量"));
                            data.R = project.cal_R(data.Diameter, data.V);
                            project.dataElements.Add(data);
                            break;
                        case "风管管件":
                            FamilyInstance familyInstance = (FamilyInstance)element;
                            MechanicalFitting mechanicalFitting = (MechanicalFitting)familyInstance.MEPModel;
                            switch (mechanicalFitting.PartType)
                            {
                                case PartType.Elbow://默认非变径弯头
                                    #region
                                    data.Remarks = "弯头";
                                    foreach (Connector connector in mechanicalFitting.ConnectorManager.Connectors)
                                    {
                                        if (connector.Shape==ConnectorProfileType.Round)
                                        {
                                            data.Diameter = 2*UnitUtils.Convert(connector.Radius, DisplayUnitType.DUT_DECIMAL_FEET, DisplayUnitType.DUT_MILLIMETERS);
                                        }
                                        else
                                        {
                                            data.Width = UnitUtils.Convert(connector.Width, DisplayUnitType.DUT_DECIMAL_FEET, DisplayUnitType.DUT_MILLIMETERS);
                                            data.Height = UnitUtils.Convert(connector.Height, DisplayUnitType.DUT_DECIMAL_FEET, DisplayUnitType.DUT_MILLIMETERS);
                                            data.Diameter = project.cal_de(data.Width, data.Height);
                                        }
                                        project.dataElements.Add(data);
                                        break;
                                    }
                                    #endregion
                                    break;
                                case PartType.Tee:
                                    data.Remarks = "T型三通";
                                    project.dataElements.Add(data);
                                    break;
                                case PartType.Transition:
                                    data.Remarks = "过渡件";
                                    project.dataElements.Add(data);
                                    break;
                                case PartType.Wye:
                                    data.Remarks = "Y型三通";
                                    project.dataElements.Add(data);
                                    break;
                            }
                            break;
                        case "风道末端":
                            data.Remarks = "风管末端";
                            //data.Width = double.Parse(get_Par(ElementIds[i], "宽度"));
                            //data.Height = double.Parse(get_Par(ElementIds[i], "高度"));
                            //data.Diameter = double.Parse(get_Par(ElementIds[i], "水力直径"));
                            //data.Length = double.Parse(get_Par(ElementIds[i], "长度"));
                            data.Airflow = double.Parse(get_Par(ElementIds[i], "流量"));
                            //data.R = project.cal_R(data.Diameter, data.V);
                            project.dataElements.Add(data);
                            break;
                        default :
                            data.Remarks = "附件";
                            project.dataElements.Add(data);
                            break;
                    }

                }
                catch (Exception e)
                {
                    TaskDialog.Show("Error", e.Message);
                    return project;
                }
            }
            return project;
        }

        public static string get_Par(ElementId id,string name)
        {
            Element ele = UIOperation.uIDocument.Document.GetElement(id);
            foreach (Parameter parameter in ele.Parameters)
            {
                if (parameter.Definition.Name==name)
                {
                    return parameter.AsValueString().Split(new char[] {' '})[0];
                }
            }
            //throw new Exception("未能找到名称为："+name+"的参数！");
            return "0";
        }

        public static string get_Par(ElementId id, BuiltInParameter builtInParameter)
        {
            Element ele = UIOperation.uIDocument.Document.GetElement(id);
            foreach (Parameter parameter in ele.Parameters)
            {
                InternalDefinition internalDefinition = (InternalDefinition)parameter.Definition;
                if (internalDefinition.BuiltInParameter == builtInParameter)
                {
                    return parameter.AsValueString();
                }
            }
            //throw new Exception("未能找到名称为："+name+"的参数！");
            return null;
        }

        public static double get_Angle(XYZ p1,XYZ p2)
        {
            double angle = Math.Round(p1.AngleTo(p2)/Math.PI*180,2);
            if (angle>90)
            {
                return 180 - angle;
            }
            return angle;
        }

        public static XYZ get_VectorFromConnector(Connector connector,XYZ origin)
        {
            double X = connector.CoordinateSystem.BasisX.X*origin.X + connector.CoordinateSystem.BasisX.Y * origin.Y + connector.CoordinateSystem.BasisX.Z * origin.Z;
            double Y = connector.CoordinateSystem.BasisY.X*origin.X + connector.CoordinateSystem.BasisY.Y * origin.Y + connector.CoordinateSystem.BasisY.Z * origin.Z;
            double Z = connector.CoordinateSystem.BasisZ.X*origin.X + connector.CoordinateSystem.BasisZ.Y * origin.Y + connector.CoordinateSystem.BasisZ.Z * origin.Z;
            return new XYZ(X, Y, Z);
        }

        public static double get_DistanceFromConnectors(Connector connector1,Connector connector2)
        {
            XYZ p1 = connector1.Origin;
            XYZ p2 = connector2.Origin;
            return p1.DistanceTo(p2);
        }


    }
    public class MassSelectionFilter : ISelectionFilter
    {
        public bool AllowElement(Element element)
        {
            return true;
        }

        public bool AllowReference(Reference refer, XYZ point)
        {
            return false;
        }
    }
}
