﻿using System;
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
//using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using MySConn.Tables;

namespace Revit_HyCal
{
    public static class Test
    {
        public static void show_dia(string str)
        {
            TaskDialog.Show("1", str);
        }
        public static void test(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //用于前期测试
            Element element = UIOperation.uIDocument.Document.GetElement(new ElementId(1001970));
            Parameter par = element.get_Parameter(BuiltInParameter.RBS_DUCT_FLOW_PARAM);
            par.Set(11100);
            TaskDialog.Show("1", par.AsValueString());

        }
    }
    
}
