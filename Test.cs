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
using Revit_Hycal_Userform;


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
            //用于前期测试
            //Reference reference = commandData.Application.ActiveUIDocument.Selection.PickObject(ObjectType.Element);
            //Element element = commandData.Application.ActiveUIDocument.Document.GetElement(reference.ElementId);
            //int i = 0;
            //foreach (Parameter p in element.Parameters)
            //{
            //    if (p.Definition.Name=="直径")
            //    {
            //        //new char()
            //        char[] s = { ' ' };
            //        TaskDialog.Show("1", p.AsValueString().Split(s)[0]);
            //        return;
            //    }
            //}
            //throw new Exception("Error:");
            //UIDocument uIDocument = commandData.Application.ActiveUIDocument;
            //Document document = uIDocument.Document;
            //List<ElementId> elementIds = new List<ElementId>();
            //UIOperation.pickPileLine(uIDocument, document,out elementIds);
            //uIDocument.Selection.SetElementIds(elementIds);
            Main_From main_From = new Main_From();
            main_From.ShowDialog();
        }
    }
}
