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
            UIOperation.uIDocument = commandData.Application.ActiveUIDocument; // 程序开始此项需要设置
            //test
            Test.test(commandData, ref message, elements);
            return Result.Succeeded;
            //test

            MainForm mainForm = new MainForm();
            mainForm.Show();
            return Result.Succeeded;
        }


    }
}
