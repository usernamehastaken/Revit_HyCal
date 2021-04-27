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
            try
            {
                IList<Reference> references = uIDocument.Selection.PickObjects(ObjectType.Element);
                TaskDialog.Show("Prompt", "Please Select the Origin of Selection Before!");
                Reference reference_origin = uIDocument.Selection.PickObject(ObjectType.Element);
            }
            catch
            {
                TaskDialog.Show("Prompt", "HVAC Hydraulic Calculation Quit!");
                return Result.Failed;
            }


            return Result.Succeeded;
        }

    }
}
