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

namespace Revit_HyCal
{
    [Transaction(TransactionMode.Manual)]
    class Class1 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uIApplication = commandData.Application;
            UIDocument uIDocument = commandData.Application.ActiveUIDocument;
            Document document = uIDocument.Document;
            //Basic_Funs.SetProjectUnits(document, UnitType.UT_HVAC_Airflow, DisplayUnitType.DUT_CUBIC_METERS_PER_HOUR);
            //==传统选取元素方法
            List<ElementId> elementIds = new List<ElementId>();
            try
            {
                IList<Reference> references = uIDocument.Selection.PickObjects(ObjectType.Element);
                TaskDialog.Show("Prompt", "Please Select the Origin of Selection Before!");
                ElementId elementId_origin = uIDocument.Selection.PickObject(ObjectType.Element).ElementId;
                foreach(Reference reff in references)
                {
                    elementIds.Add(reff.ElementId);
                }
                //TaskDialog.Show("1", elementIds.Count.ToString());
                //如果有组元素，分解组元素并加入references
                IList<ElementId> groupElementIds = new List<ElementId>();
                foreach (ElementId id in elementIds)
                {
                    Group group = document.GetElement(id) as Group;
                    if (group != null) { groupElementIds.Add(id); }
                }
                if (groupElementIds.Count > 0)
                {
                    elementIds = elementIds.Except(groupElementIds).ToList<ElementId>();
                    //TaskDialog.Show("1", elementIds.Count.ToString());
                    foreach(ElementId id in groupElementIds)
                    {
                        Group group = document.GetElement(id) as Group;
                        elementIds = elementIds.Union(group.GetMemberIds()).ToList<ElementId>();//此处还有非实体groupelementid
                    }
                }

            }
            catch
            {
                TaskDialog.Show("Prompt", "HVAC Hydraulic Calculation Quit!");
                return Result.Failed;
            }
            uIDocument.Selection.SetElementIds(elementIds);
            //TaskDialog.Show("1", elementIds.Count.ToString());
            FilteredElementCollector filter = new FilteredElementCollector(document, elementIds);
            TaskDialog.Show("1", filter.GetElementCount().ToString());
            //==按顺序录入管道系统,不使用连接键，使用碰撞

            return Result.Succeeded;
        }

    }
}
