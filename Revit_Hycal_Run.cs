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
    public class Revit_Hycal_Run : IExternalCommand 
    {
        //作为程序入口
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Basic_Funs.SetProjectUnits(commandData.Application.ActiveUIDocument.Document, UnitType.UT_HVAC_Airflow, DisplayUnitType.DUT_CUBIC_METERS_PER_HOUR);
            UIOperation.uIDocument = commandData.Application.ActiveUIDocument; // 程序开始此项需要设置
            MainForm mainForm = new MainForm();
            mainForm.Show();
            return Result.Succeeded;
        }
    }
}
