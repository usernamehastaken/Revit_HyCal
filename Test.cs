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
    class Test
    {
        public static void show_dia(string str)
        {
            TaskDialog.Show("1", str);
        }
        public static void test(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            FrmProgressBar frmProgressBar = new FrmProgressBar();
            frmProgressBar.Show();
            int i = 0;
            while (true)
            {
                frmProgressBar.labProgressBar.Width -= 1;
                frmProgressBar.labProgressBar.Left += 1;
                frmProgressBar.Refresh();
                System.Windows.Forms.Application.DoEvents();
                if (frmProgressBar.labProgressBar.Width == 0) { break; }
            }
            frmProgressBar.Dispose();

        }
    }
}
