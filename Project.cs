using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace Revit_HyCal
{
    public class DataElement
    {
        public int No { get; set; }
        public float Airflow { get; set; } = 0;
        public float Width { get; set; } = 0;
        public float Height { get; set; } = 0;
        public float Diameter { get; set; } = 0;
        public float Length { get; set; } = 0;
        public float V { get; set; } = 0;
        public float R { get; set; } = 0;
        public float Py { get; set; } = 0;
        public float kSai { get; set; } = 0;
        public float DPressure { get; set; } = 0;
        public float Pj { get; set; } = 0;
        public float TotalPressure { get; set; } = 0;
        public string ID { get; set; }
    }

    public class Project
    {
        //所有与窗体有关操作的接口都从这出
        //对于一个窗体就是一个工程
        //管道需要一个沿程阻力参数,一个风量参数，管道性质参数放入this，
        public string name="新建工程";
        public string fullpath;
        public  double doubleGBCCDXZXS;
        public  double doubleGBCCD;
        public  double doubleYDND;
        public  double doubleMD;
        //public static double doubleDQYL;
        //public static double doubleWD;
        //public static double doubleXDSD;
        public  double doubleMDXZ = 1;
        public List<DataElement> dataElements = new List<DataElement>();

        [XmlIgnore] public List<ElementId> elementIds=new List<ElementId> ();//保存管道系统id，dataEle的信息由程序读取及计算，局部阻力参数保存到族中
        [XmlIgnore]public UIDocument uIDocument;
        [XmlIgnore]public Document document;
        public double cal_R(double de, double V) /*计算沿程阻力系数 de(当量直径) V(流速)*/
        {
            //y=x+2lg(a + bx);
            //y`=1+2b / (a + bx);
            //y``=-2*b^2/(a+bx)^2
            if (this.doubleGBCCDXZXS == 0)
            {
                throw new Exception("Error: 基础数据未初始化");
                //return 0;
            }
            this.doubleGBCCD = this.doubleGBCCDXZXS * this.doubleGBCCD;
            double a = this.doubleGBCCD / (3.71 * de);
            double Re = V * de / this.doubleYDND;
            double b = 2.51 / Re;
            double lanta = 0, x = 0;/*以0.001步进*/
            while (x + 0.01 + 2 * Math.Log10(a + b * (x + 0.01)) < 0)
            {
                x = x + 0.01;
            }
            x = x + 0.005;
            lanta = Math.Pow(1 / x, 2);
            double R = lanta * V * V * this.doubleMD / de / 2 * this.doubleMDXZ;
            return R;
        }
        public double cal_de(double a, double b)
        {
            double de;
            de = 2 * a * b / (a + b);
            return de;
        }
        public double cal_DPressure(double V)
        {
            return this.doubleMDXZ * this.doubleMD * V * V / 2;
        }
        public void cal_MDXZ(double p, double wd)
        {
            this.doubleMDXZ = 3.47 * p / (273 + wd) / 1000 / this.doubleMD;
        }

    }

    public class Form_Operation
    {
        public static void check_before_close(MainForm mainForm)
        {
            return;
        }
        public static void new_project(MainForm mainFrom,Project project)
        {
            ProjectForm proForm = new ProjectForm(project);
            proForm.Text = proForm.myproject.name;
            proForm.MdiParent = mainFrom;
            proForm.Show();
        }
        public static void open_project(MainForm mainForm)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "工程文件|*.hvac";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog()==DialogResult.OK)
            {
                string fullpath = openFileDialog.FileName;
                string name = System.IO.Path.GetFileNameWithoutExtension(fullpath);
                using (FileStream fileStream=new FileStream(fullpath,FileMode.Open,FileAccess.Read))
                {
                    XmlSerializer xs = new  XmlSerializer(typeof(Project));
                    Project project = (Project)xs.Deserialize(fileStream);
                    Form_Operation.new_project(mainForm, project);
                }
            }
        }
        public static void save_project(MainForm mainForm)
        {
            if (mainForm.MdiChildren.Count()==0)
            {
                TaskDialog.Show("保存", "没有需要保存的工程");
                return;
            }

            ProjectForm projectfrom = (ProjectForm)mainForm.ActiveMdiChild;
            Project project = projectfrom.myproject;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "工程文件|.hvac";
            if (saveFileDialog.ShowDialog()==DialogResult.OK)
            {
                project.fullpath = saveFileDialog.FileName;
                project.name = System.IO.Path.GetFileNameWithoutExtension(project.fullpath);
            }
            else
            {
                return;
            }
            using (FileStream fileStream=new FileStream (project.fullpath,FileMode.OpenOrCreate,FileAccess.Write))
            {
                XmlSerializer bf = new XmlSerializer(typeof(Project));
                bf.Serialize(fileStream,project);
            }

        }
        public static void save_all(MainForm mainForm)
        {
            foreach (ProjectForm p in mainForm.MdiChildren)
            {
                save_project(mainForm);
            }
        }
    }

    public class UBinder : SerializationBinder
    {
        //二进制序列化需要binder
        public override Type BindToType(string assemblyName, string typeName)
        {
            //Assembly ass = Assembly.GetExecutingAssembly();
            //return ass.GetType("Project.Project");
            return typeof(Project);
        }
    }
}
