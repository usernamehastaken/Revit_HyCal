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
            UIOperation.uIDocument = commandData.Application.ActiveUIDocument; // 程序开始此项需要设置
            MainForm mainForm = new MainForm();
            mainForm.Show();

            //Reference reference = UIOperation.uIDocument.Selection.PickObject(ObjectType.Element);
            //Element element = UIOperation.uIDocument.Document.GetElement(reference.ElementId);
            //FamilyInstance familyInstance = (FamilyInstance)element;
            //List<XYZ> xYZs = new List<XYZ>();
            //List<Connector> connectors = new List<Connector>();
            //foreach (Connector item in familyInstance.MEPModel.ConnectorManager.Connectors)
            //{
            //    xYZs.Add(UIOperation.get_VectorFromConnector(item, familyInstance.FacingOrientation));
            //    connectors.Add(item);
            //}
            //double dis = UIOperation.get_DistanceFromConnectors(connectors[0], connectors[1]);
            //double angle = UIOperation.get_Angle(xYZs[0], xYZs[1]);
            //MessageBox.Show(dis.ToString());
            //MessageBox.Show(angle.ToString());
            //MessageBox.Show((dis/2 / Math.Sin(angle/2 / 180 * Math.PI)).ToString());

        }
    }
    
}
