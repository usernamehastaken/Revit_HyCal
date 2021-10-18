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
using System.Windows.Forms;

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
            ///
            //XYZ p1 = new XYZ(0, 0, -1);
            //XYZ p2 = new XYZ(0.61566147532566, 0, 0.788010753606721);
            //TaskDialog.Show("1", (p1.AngleTo(p2) / Math.PI * 180).ToString());
            //return Result.Succeeded;
        }


    }
}
