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
    class Revit_Hycal_Run : IExternalCommand 
    {
        //作为程序入口
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


            
            return Result.Succeeded;

        }






    }
}
