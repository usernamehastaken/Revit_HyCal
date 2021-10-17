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
//using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;

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
            UIOperation.uIDocument = commandData.Application.ActiveUIDocument;
            //MainForm mainForm = new MainForm();
            //mainForm.Show();

            Reference reference= UIOperation.uIDocument.Selection.PickObject(ObjectType.Element);
            List<XYZ> xYZs = new List<XYZ>();
            Element element = UIOperation.uIDocument.Document.GetElement(reference.ElementId);
            FamilyInstance familyInstance = (FamilyInstance)element;
            List<double> ds = new List<double>();
            List<Connector> connectors = new List<Connector>();
            double theta = 0;
            foreach (Connector connector in (familyInstance.MEPModel.ConnectorManager.Connectors))//读取角度
            {
                ds.Add(connector.Width);//连接件的水力计算直径
                connectors.Add(connector);
            }
            theta = Math.Atan(Math.Abs(ds[0] - ds[1]) / UIOperation.get_DistanceFromConnectors(connectors[0], connectors[1]) / 2) * 2;
            theta = Math.Round(theta / Math.PI * 180, 2);
            TaskDialog.Show("1", theta.ToString());
            
        }
    }
    
}
