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

namespace Revit_HyCal
{
    [Transaction(TransactionMode.Manual)]
    public static class UIOperation
    {
        //存储所有工程文件
        public static List<Project> projects; 
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
            //二次选取
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

        public static void pickPileLine(UIDocument uIDocument,Document document,out List<ElementId> elementIds)
        {
            //输入空list<> 返回list<>
            //*************传统选取元素方法
            elementIds = new List<ElementId>();
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
            elementIds = lstPipelineids;
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
