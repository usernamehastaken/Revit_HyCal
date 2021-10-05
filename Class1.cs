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
using System.Threading;

namespace Revit_HyCal
{
    [Transaction(TransactionMode.Manual)]
    class Class1 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //test
            Test.test(commandData, ref message, elements);
            return Result.Succeeded;
            //test

            UIApplication uIApplication = commandData.Application;
            UIDocument uIDocument = commandData.Application.ActiveUIDocument;
            Document document = uIDocument.Document;
            //Basic_Funs.SetProjectUnits(document, UnitType.UT_HVAC_Airflow, DisplayUnitType.DUT_CUBIC_METERS_PER_HOUR);

            //*************传统选取元素方法
            List<ElementId> elementIds = new List<ElementId>();
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
            ElementId origin_elementid = elementIds[elementIds.Count - 1];
            elementIds.Remove(origin_elementid); elementIds.Remove(origin_elementid);
            try
            {
                lstPipelineids = UIOperation.GetPipelineElementID(document, elementIds, origin_elementid);
            }
            catch(Exception e)
            {
                TaskDialog.Show("Prompt", e.Message);
                return Result.Failed;
            }

            List<ElementId> ids = new List<ElementId>();
            foreach (ElementId id in lstPipelineids)
            {
                ids.Add(id);
                uIDocument.Selection.SetElementIds(ids);
                TaskDialog.Show("1", "2");
            }
            
            return Result.Succeeded;

        }






    }
}
