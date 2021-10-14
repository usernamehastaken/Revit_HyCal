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
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.UI;
using System.Text.RegularExpressions;

namespace Revit_HyCal
{
    public class DataElement
    {
        public int No { get; set; }
        public string Remarks { get; set; } = "";//存储在工程文件，不返回到模型中
        private double airflow = 0;
        public double Airflow
        {
            get
            {
                return airflow;
            }
            set
            {
                airflow = value;
                //MessageBox.Show("a");
                cal_V();
            }
        }
        private double width = 0;
        public double Width 
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
                cal_V();
            }
        }
        private double height = 0;
        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
                cal_V();
            }
        }
        private double diameter = 0;
        public double Diameter
        {
            get
            {
                return diameter;
            }
            set
            {
                diameter = value;
                cal_V();
            }
        }
        private double length = 0;
        public double Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
                cal_Py();
            }
        }
        private double v = 0;
        public double V 
        {
            get
            {
                return v;
            }
            set
            {
                v = value;
                //cal_DPressure();
            }
        }
        private double r = 0;
        public double R
        {
            get
            {
                return r;
            }
            set
            {
                r = value;
                cal_Py();
            }
        }
        private double py = 0;
        public double Py
        {
            get
            {
                return py;
            }
            set
            {
                py = value;
                cal_Total();
            }
        }
        private double ksai = 0;
        public double kSai
        {
            get
            {
                return ksai;
            }
            set
            {
                ksai = value;
                cal_Pj();
            }
        }
        private double dpressure = 0;
        public double DPressure
        {
            get
            {
                return dpressure;
            }
            set
            {
                dpressure = value;
                cal_Pj();
            }
        }
        private double pj = 0;
        public double Pj
        {
            get
            {
                return pj;
            }
            set
            {
                pj = value;
                cal_Total();
            }
        }
        public double TotalPressure { get; set; } = 0;
        public int ID { get; set; }

        private void cal_V()
        {
            if (this.width>0)
            {
                this.v = this.airflow / 3600 / this.width / this.height * 1000000;
            }
            else
            {
                this.v = this.airflow / 3600 * 4 / 3.14 / this.diameter / this.diameter * 1000000;
            }
        }
        private void cal_Py()
        {
            this.py = this.r * this.length/1000;
        }
        private void cal_Pj()
        {
            this.pj = this.ksai * this.dpressure;
        }
        private void cal_Total()
        {
            this.TotalPressure = this.py + this.pj;
        }
    }

    public class Project
    {
        //所有与窗体有关操作的接口都从这出
        //对于一个窗体就是一个工程
        //管道需要一个沿程阻力参数,一个风量参数，管道性质参数放入this，
        public string name="新建工程";
        public string fullpath;
        public string DocumentPathName;//储存相关的revit文件
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
        //[XmlIgnore]public UIDocument uIDocument;
        //[XmlIgnore]public Document document;
        public double cal_R(double de, double V) /*计算沿程阻力系数 de(当量直径) V(流速)*/
        {
            //y=x+2lg(a + bx);
            //y`=1+2b / (a + bx);
            //y``=-2*b^2/(a+bx)^2
            if (this.doubleGBCCDXZXS == 0)
            {
                throw new Exception("Error: 工程未进行基础配置设置");
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

    public class MainForm_Operation
    {
        public static void check_before_close(MainForm mainForm)
        {
            MainForm_Operation.save_project(mainForm);
        }
        public static void new_project(MainForm mainFrom,Project project)
        {
            //Project project = new Project();
            if (project.DocumentPathName==null)
            {
                project.DocumentPathName = UIOperation.uIDocument.Document.PathName;
            }
            if (project.DocumentPathName!=UIOperation.uIDocument.Document.PathName)
            {
                TaskDialog.Show("Warning", "工程计算文件与当前打开的revit文档不一致！可能导致计算文件出错！");
            }
            ProjectForm proForm = new ProjectForm(project);
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
                    MainForm_Operation.new_project(mainForm, project);
                }
            }
        }
        public static void save_project(MainForm mainForm)
        {
            if (mainForm.MdiChildren.Count()==0)
            {
                //TaskDialog.Show("保存", "没有需要保存的工程");
                return;
            }

            ProjectForm projectfrom = (ProjectForm)mainForm.ActiveMdiChild;//注意此处仅对激活窗口操作
            Project project = projectfrom.myproject;
            if (project.fullpath!=null)
            {
                using (FileStream fileStream = new FileStream(project.fullpath, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    XmlSerializer bf = new XmlSerializer(typeof(Project));
                    bf.Serialize(fileStream, project);
                }
                return;
            }
            //新建工程完成以下步骤
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "工程文件|.hvac";
            if (saveFileDialog.ShowDialog()==DialogResult.OK)
            {
                project.fullpath = saveFileDialog.FileName;
                project.name = System.IO.Path.GetFileNameWithoutExtension(project.fullpath);
                projectfrom.Text = project.name;
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
            if (mainForm.MdiChildren.Count()==0)
            {
                return;
            }
            foreach (ProjectForm p in mainForm.MdiChildren)
            {
                p.Activate();
                save_project(mainForm);
            }
        }

        public static void First_Pick(MainForm mainForm)
        {
            if (mainForm.MdiChildren.Count() == 0)
            {
                TaskDialog.Show("Error", "请新建工程");
                return;
            }
            ProjectForm projectForm = (ProjectForm)mainForm.ActiveMdiChild;
            List<ElementId> newIds = UIOperation.pickPileLine(UIOperation.uIDocument,UIOperation.uIDocument.Document);
            if (newIds.Count==0)
            {
                return;
            }
            UIOperation.uIDocument.Selection.SetElementIds(newIds);
            if (MessageBox.Show("是否将选择的管道系统写入（覆盖）工程？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                projectForm.myproject.elementIds = newIds;//赋值eleids
                projectForm.myproject = UIOperation.ElementIdsToProject(newIds,projectForm.myproject);
                projectForm.refresh_datagrid();
                mainForm.Activate();
            }
        }

        public static void Second_Pick(MainForm mainForm)
        {
            if (mainForm.MdiChildren.Count() == 0)
            {
                TaskDialog.Show("Error", "请新建工程");
                return;
            }
            ProjectForm projectForm = (ProjectForm)mainForm.ActiveMdiChild;
            if (projectForm.myproject.dataElements.Count==0)//如果之前未有模型录入
            {
                First_Pick(mainForm);
                return;
            }
            List<ElementId> oldIds = new List<ElementId>();
            foreach (DataElement data in projectForm.myproject.dataElements)
            {
                oldIds.Add(new ElementId(data.ID));
            }
            List<ElementId> newIds = new List<ElementId>();
            newIds = UIOperation.SecSelectPipeline(UIOperation.uIDocument, UIOperation.uIDocument.Document, oldIds);
            if (newIds.Count==0)
            {
                return;
            }
            UIOperation.uIDocument.Selection.SetElementIds(newIds);
            if (MessageBox.Show("是否将选择的管道系统写入（覆盖）工程？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                projectForm.myproject.elementIds = newIds;
                projectForm.myproject = UIOperation.ElementIdsToProject(newIds,projectForm.myproject);
                projectForm.refresh_datagrid();
                mainForm.Activate();
            }
        }

        public static void cal_R(MainForm mainForm)
        {
            if (mainForm.MdiChildren.Count()==0)
            {
                return;
            }

            ProjectForm projectForm = (ProjectForm)mainForm.ActiveMdiChild;
            foreach (DataElement data in projectForm.myproject.dataElements)
            {
                //每一个都校正
                try
                {
                    data.R = projectForm.myproject.cal_R(data.Diameter/1000, data.V);
                    data.DPressure = projectForm.myproject.cal_DPressure(data.V);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return;
                }
                   
            }
            projectForm.refresh_datagrid();
        }

        public static void cal_ksi(MainForm mainForm)
        {
            if (mainForm.MdiChildren.Count()==0)//无打开工程
            {
                return;
            }

            ProjectForm projectForm = (ProjectForm)mainForm.ActiveMdiChild;
            Project project = projectForm.myproject;
            if (project.dataElements.Count==0)//空白工程
            {
                return;
            }

            for (int i = 0; i < project.dataElements.Count(); i++)//按顺序读取
            {
                Element element = UIOperation.uIDocument.Document.GetElement(new ElementId(project.dataElements[i].ID));
                switch (element.Category.Name)
                {
                    case "风管":
                        if (i==0)
                        {
                            project.dataElements[i].kSai = 0.5;//风管作为风口
                        }
                        break;
                    case "风道末端":
                        project.dataElements[i].kSai = 3.3;//回风口
                        break;
                    case "风管管件":
                        ///分弯头，T三通，Y三通，变径//根据给定类型选定数据表，需要定义一个常量表
                        MEPModel mEPModel = ((FamilyInstance)element).MEPModel;
                        switch (((MechanicalFitting)mEPModel).PartType)
                        {
                            case PartType.Undefined:
                                break;
                            case PartType.Normal:
                                break;
                            case PartType.DuctMounted:
                                break;
                            case PartType.JunctionBox:
                                break;
                            case PartType.AttachesTo:
                                break;
                            case PartType.BreaksInto:
                                break;
                            case PartType.Elbow://弯头
                                project.dataElements[i].kSai = 0.38;
                                break;
                            case PartType.Tee://T型三通
                                break;
                            case PartType.Transition://过渡件
                                FamilySymbol familySymbol = ((FamilyInstance)element).Symbol;
                                foreach (Parameter parameter in familySymbol.Parameters)
                                {
                                    if (parameter.Definition.Name=="角度")
                                    {
                                        double theta = double.Parse(Regex.Match(parameter.AsValueString(), @"(\d+.\d+)").Groups[1].Value);
                                    }
                                }

                                foreach (Parameter parameter in familySymbol.Parameters)
                                {
                                    if (parameter.Definition.Name=="尺寸")
                                    {
                                        string[] strvalue = parameter.AsString().Split(new char[] { '-'});
                                        700ø - 300ø;
                                    }
                                }
                                break;
                            case PartType.Cross:
                                break;
                            case PartType.Cap:
                                break;
                            case PartType.TapPerpendicular:
                                break;
                            case PartType.TapAdjustable:
                                break;
                            case PartType.Offset:
                                break;
                            case PartType.Union:
                                break;
                            case PartType.PanelBoard:
                                break;
                            case PartType.Transformer:
                                break;
                            case PartType.SwitchBoard:
                                break;
                            case PartType.OtherPanel:
                                break;
                            case PartType.EquipmentSwitch:
                                break;
                            case PartType.Switch:
                                break;
                            case PartType.ValveBreaksInto:
                                break;
                            case PartType.SpudPerpendicular:
                                break;
                            case PartType.SpudAdjustable:
                                break;
                            case PartType.Damper:
                                break;
                            case PartType.Wye://Y型三通
                                break;
                            case PartType.LateralTee:
                                break;
                            case PartType.LateralCross:
                                break;
                            case PartType.Pants:
                                break;
                            case PartType.MultiPort:
                                break;
                            case PartType.ValveNormal:
                                break;
                            case PartType.JunctionBoxTee:
                                break;
                            case PartType.JunctionBoxCross:
                                break;
                            case PartType.PipeFlange:
                                break;
                            case PartType.JunctionBoxElbow:
                                break;
                            case PartType.ChannelCableTrayElbow:
                                break;
                            case PartType.ChannelCableTrayVerticalElbow:
                                break;
                            case PartType.ChannelCableTrayCross:
                                break;
                            case PartType.ChannelCableTrayTee:
                                break;
                            case PartType.ChannelCableTrayTransition:
                                break;
                            case PartType.ChannelCableTrayUnion:
                                break;
                            case PartType.ChannelCableTrayOffset:
                                break;
                            case PartType.ChannelCableTrayMultiPort:
                                break;
                            case PartType.LadderCableTrayElbow:
                                break;
                            case PartType.LadderCableTrayVerticalElbow:
                                break;
                            case PartType.LadderCableTrayCross:
                                break;
                            case PartType.LadderCableTrayTee:
                                break;
                            case PartType.LadderCableTrayTransition:
                                break;
                            case PartType.LadderCableTrayUnion:
                                break;
                            case PartType.LadderCableTrayOffset:
                                break;
                            case PartType.LadderCableTrayMultiPort:
                                break;
                            case PartType.InlineSensor:
                                break;
                            case PartType.Sensor:
                                break;
                            case PartType.EndCap:
                                break;
                            case PartType.HandrailBracketHardware:
                                break;
                            case PartType.PanelBracketHardware:
                                break;
                            case PartType.TerminationHardware:
                                break;
                            case PartType.Rails:
                                break;
                            case PartType.Handrails:
                                break;
                            case PartType.TopRails:
                                break;
                            case PartType.PipeMechanicalCoupling:
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }   
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
