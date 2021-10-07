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
    class Test
    {
        public static void show_dia(string str)
        {
            TaskDialog.Show("1", str);
        }
        public static void test(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //用于前期测试

            //MainForm mainForm = new MainForm();
            //mainForm.Show();

            MyClass m = new MyClass();
            m.i = 1;
            m.j = 2;
            m.list.Add("asdf");
            //m.list.Add(new MyClass1() { ii = 11 });
            using (FileStream fileStream=new FileStream ("d://1.txt",FileMode.OpenOrCreate,FileAccess.Write))
            {
                XmlSerializer bf = new  XmlSerializer(m.GetType());
                bf.Serialize(fileStream, m);
            }
            TaskDialog.Show("1", "write");
            using (FileStream fileStream1=new FileStream ("d://1.txt",FileMode.Open,FileAccess.Read))
            {
                XmlSerializer bf = new XmlSerializer(m.GetType());
                //bf.Binder = new UBinder1();
                MyClass m1 = (MyClass)bf.Deserialize(fileStream1);
                TaskDialog.Show("1", m1.list.Count().ToString());;
            }
        }
    }
    [Serializable]
    class MyClass
    {
        public int i { get; set; }
        public int j { get; set; }

        public List<string> list=new List<string> ();

    }
    [Serializable]
    class MyClass1
    {
        public int ii { get; set; }
    }
    public class UBinder1 : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            //Assembly ass = Assembly.GetExecutingAssembly();
            //return ass.GetType("Project.Project");
            return typeof(MyClass);
        }
    }
}
