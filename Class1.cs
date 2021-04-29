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
                elementIds = Operation.SelectPipeline(uIDocument, document);
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

            //*****************按顺序录入管道系统,使用连接键，不使用碰撞
            







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





            return Result.Succeeded;
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


        public void GetElementAtConnector(Autodesk.Revit.DB.Connector connector)
        {
            MEPSystem mepSystem = connector.MEPSystem;
            if (null != mepSystem)
            {
                string message = "Connector is owned by: " + connector.Owner.Name;

                if (connector.IsConnected == true)
                {
                    ConnectorSet connectorSet = connector.AllRefs;
                    ConnectorSetIterator csi = connectorSet.ForwardIterator();
                    while (csi.MoveNext())
                    {
                        Connector connected = csi.Current as Connector;
                        if (null != connected)
                        {
                            // look for physical connections
                            if (connected.ConnectorType == ConnectorType.End ||
                                connected.ConnectorType == ConnectorType.Curve ||
                                connected.ConnectorType == ConnectorType.Physical)
                            {
                                message += "\nConnector is connected to: " + connected.Owner.ToString();
                                message += "\nConnection type is: " + connected.ConnectorType;
                            }
                        }
                    }
                }
                else
                {
                    message += "\nConnector is not connected to anything.";
                }

                TaskDialog.Show("Revit", message);
            }
        }

    }
}
