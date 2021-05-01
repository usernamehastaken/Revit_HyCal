using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.ApplicationServices;
using Revit_FunExtension;
using Autodesk.Revit.DB.Mechanical;

namespace Revit_HyCal
{
    [Transaction(TransactionMode.Manual)]
    class Class1 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            ////test
            //test(commandData, ref message, elements);
            //return Result.Succeeded;
            ////test


            UIApplication uIApplication = commandData.Application;
            UIDocument uIDocument = commandData.Application.ActiveUIDocument;
            Document document = uIDocument.Document;
            //Basic_Funs.SetProjectUnits(document, UnitType.UT_HVAC_Airflow, DisplayUnitType.DUT_CUBIC_METERS_PER_HOUR);

            //*************传统选取元素方法
            IList<ElementId> elementIds = new List<ElementId>();
            try
            {
                elementIds = UIOperation.SelectPipeline(uIDocument, document);
            }
            catch (Exception e)
            {
                TaskDialog.Show("Prompt", e.Message);
                return Result.Failed;
            }
            if (elementIds.Count == 0)
            {
                TaskDialog.Show("Prompt", "HVAC Hydraulic Calculation App Quit!");
                return Result.Failed;
            }
            //*****************按顺序录入管道系统(无组图元，组内非链接键连接则系统将分成两个部分）,使用连接键，不使用碰撞
            List<ElementId> lstPipelineids = new List<ElementId>();
            lstPipelineids.Add(elementIds[elementIds.Count - 1]);
            elementIds.Remove(lstPipelineids[0]);
            elementIds.Remove(elementIds[elementIds.Count - 1]);//elementsids has two origin_elementid
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
            show_dia(lstPipelineids.Count.ToString());
            uIDocument.Selection.SetElementIds(lstPipelineids);
            return Result.Succeeded;

            ////建立碰撞过滤器
            //ElementIntersectsElementFilter filterInsectEl = new ElementIntersectsElementFilter(document.GetElement(elementIds[elementIds.Count - 1]));
            ////建立待过滤图元过滤器
            //elementIds.Remove(elementIds[elementIds.Count - 1]);
            //FilteredElementCollector filterids = new FilteredElementCollector(document, elementIds);
            //while (elementIds.Count > 0)
            //{
            //    //如果碰撞，去除图元，未碰撞
            //    int Count = filterids.WherePasses(filterInsectEl).GetElementCount();
            //    show_dia(Count.ToString());
            //    //if ()
            //    //{

            //    //}
            //    ////未碰撞图元提示或根据距离选择
            //    //else
            //    //{

            //    //}
            //}
        }


        public static void show_dia(string str)
        {
            TaskDialog.Show("1", str);
        }
        public void test(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDocument = commandData.Application.ActiveUIDocument;
            Document document = uIDocument.Document;
            //FilteredElementCollector f1 = new FilteredElementCollector(document);
            //ElementId elementId= uIDocument.Selection.PickObject(ObjectType.Element).ElementId;
            //ElementIntersectsElementFilter f2 = new ElementIntersectsElementFilter(document.GetElement(elementId));
            //FilteredElementCollector f3 = f1.WherePasses(f2);
            //show_dia(f3.GetElementCount().ToString());
            IList<Reference> lstReference = uIDocument.Selection.PickObjects(ObjectType.Element);

            uIDocument.Selection.SetElementIds(new List<ElementId>());
            show_dia("1");
            uIDocument.Selection.PickObjects(ObjectType.Element, new MassSelectionFilter(), "asdf", lstReference);
        }



    }
}
