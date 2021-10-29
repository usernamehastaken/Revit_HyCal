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
using MySConn;
using MySConn.Tables;

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

            ProjectForm projectForm = (ProjectForm)mainForm.ActiveMdiChild;//当前工程
            Project project = projectForm.myproject;//工程数据
            List<double> keys = new List<double>();//存储计算结果用于ksai计算
            List<double> values = new List<double>();
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
                            case PartType.Elbow://弯头三维计算完成
                                #region
                                FamilyInstance familyInstance = (FamilyInstance)element;
                                XYZ face_origin = familyInstance.FacingOrientation;
                                List<XYZ> Evectors = new List<XYZ>();
                                List<Connector> Econnectors = new List<Connector>();
                                foreach (Connector connector in mEPModel.ConnectorManager.Connectors)
                                {
                                    Econnectors.Add(connector);
                                    Evectors.Add(UIOperation.get_VectorFromConnector(connector,face_origin));
                                }
                                double Eangle = UIOperation.get_Angle(Evectors[0], Evectors[1]);
                                //==============================================================
                                MessageBox.Show(project.dataElements[i].Remarks + "  " + Eangle.ToString());
                                //==============================================================
                                double Edis = UIOperation.get_DistanceFromConnectors(Econnectors[0], Econnectors[1]);
                                double qulvbanjing =Edis / 2 / Math.Sin(Eangle / 2 / 180 * Math.PI);
                                qulvbanjing = UnitUtils.Convert(qulvbanjing, DisplayUnitType.DUT_DECIMAL_FEET, DisplayUnitType.DUT_MILLIMETERS);
                                double r_D = qulvbanjing / project.dataElements[i].Diameter;
                                if (Math.Round(Eangle,2)<=90 || Math.Round(Eangle,2)>60)//====>>>>>B_7
                                {
                                    B_7 b_7 = new B_7() { r_D = r_D };
                                    foreach (B_7 item in mainForm.myDbContext.b_7.ToList<B_7>())
                                    {
                                        keys.Add(item.get_distance(b_7));
                                        values.Add(item.ksai);
                                    }
                                    project.dataElements[i].kSai = mainForm.myDbContext.get_ksai_easyway(keys, values);
                                    break;
                                }
                                if (Math.Round(Eangle,2)<=60 || Math.Round(Eangle,2)>45)//====>>>>B_8
                                {
                                    B_8 b_8 = new B_8() { D=project.dataElements[i].Diameter };
                                    foreach (B_8 item in mainForm.myDbContext.b_8.ToList<B_8>())
                                    {
                                        keys.Add(item.get_distance(b_8));
                                        values.Add(item.ksai);
                                    }
                                    project.dataElements[i].kSai = mainForm.myDbContext.get_ksai_easyway(keys, values);
                                    break;
                                }
                                if (Math.Round(Eangle,2)<=45)//====>>>>B_9
                                {
                                    B_9 b_9 = new B_9() { D = project.dataElements[i].Diameter };
                                    foreach (B_9 item in mainForm.myDbContext.b_9.ToList<B_9>())
                                    {
                                        keys.Add(item.get_distance(b_9));
                                        values.Add(item.ksai);
                                    }
                                    project.dataElements[i].kSai = mainForm.myDbContext.get_ksai_easyway(keys, values);
                                }
                                #endregion
                                break;
                            case PartType.Tee://T型三通
                                List<Connector> Tconnectors = new List<Connector>();
                                ElementId TelementId = new ElementId(0);//T型三通的ID
                                double Fs_Fc=0; double Fb_Fc=0;double Lb_Lc=0;double Ls_Lc=0;
                                double F0;double F1;double F2;
                                foreach (Connector connector in mEPModel.ConnectorManager.Connectors)
                                {
                                    Tconnectors.Add(connector);
                                }
                                XYZ v0 = UIOperation.get_VectorFromConnector(Tconnectors[0], ((FamilyInstance)element).FacingOrientation);
                                XYZ v1 = UIOperation.get_VectorFromConnector(Tconnectors[1], ((FamilyInstance)element).FacingOrientation);
                                XYZ v2 = UIOperation.get_VectorFromConnector(Tconnectors[2], ((FamilyInstance)element).FacingOrientation);
                                F0 = UIOperation.get_AreaOfConnector(Tconnectors[0]);
                                F1 = UIOperation.get_AreaOfConnector(Tconnectors[1]);
                                F2 = UIOperation.get_AreaOfConnector(Tconnectors[2]);
                                #region //完成T型管道id的识别
                                //判断T管并计算Fs_Fc,Fb_Fc
                                if (UIOperation.get_Angle(v0, v1) == 0)
                                {
                                    TelementId = UIOperation.GetAnotherIDAtConnector(element.Id, Tconnectors[2]);
                                    //F2>T
                                    if (F0>F1)
                                    {
                                        Fs_Fc = F1 / F0;
                                        Fb_Fc = F2 / F0;
                                    }
                                    else
                                    {
                                        Fs_Fc = F0 / F1;
                                        Fb_Fc = F2 / F1;
                                    }
                                }
                                if (UIOperation.get_Angle(v0, v1) == 90)
                                {
                                    if (UIOperation.get_Angle(v1, v2) == 0)
                                    {
                                        TelementId = UIOperation.GetAnotherIDAtConnector(element.Id, Tconnectors[0]);
                                        //F0>T
                                        if (F1 > F2)
                                        {
                                            Fs_Fc = F2 / F1;
                                            Fb_Fc = F0 / F1;
                                        }
                                        else
                                        {
                                            Fs_Fc = F1 / F2;
                                            Fb_Fc = F0 / F2;
                                        }
                                    }
                                    else
                                    {
                                        TelementId = UIOperation.GetAnotherIDAtConnector(element.Id, Tconnectors[1]);
                                        //F1>T
                                        if (F0>F2)
                                        {
                                            Fs_Fc = F2 / F0;
                                            Fb_Fc = F1 / F0;
                                        }
                                        else
                                        {
                                            Fs_Fc = F0 / F2;
                                            Fb_Fc = F1 / F2;
                                        }
                                    }
                                }
                                #endregion
                                #region 完成对支管直管的判断Lb_Lc,Ls_Lc,
                                if (project.dataElements[i - 1].ID == TelementId.IntegerValue)//T管道查询
                                {
                                    //===========>>>D_2_b
                                    Lb_Lc = project.dataElements[i - 1].Airflow / project.dataElements[i + 1].Airflow;
                                    List<D_2_b> d_2_Bs = mainForm.myDbContext.d_2_b.ToList<D_2_b>();
                                    foreach (D_2_b item in d_2_Bs)
                                    {
                                        keys.Add(item.get_distance(new D_2_b() { Fb_Fc = Fb_Fc,Fs_Fc=Fs_Fc,Lb_Lc=Lb_Lc }));
                                        values.Add(item.ksai);
                                    }
                                    project.dataElements[i].kSai = mainForm.myDbContext.get_ksai_easyway(keys, values)+0.15;
                                }
                                else//直管查询
                                {
                                    //==========>>>D_2_s
                                    Ls_Lc = project.dataElements[i - 1].Airflow / project.dataElements[i + 1].Airflow;
                                    List<D_2_s> d_2_Ss = mainForm.myDbContext.d_2_s.ToList<D_2_s>();
                                    foreach (D_2_s item in d_2_Ss)
                                    {
                                        keys.Add(item.get_distance(new D_2_s() { Fb_Fc = Fb_Fc, Fs_Fc = Fs_Fc, Ls_Lc = Ls_Lc }));
                                        values.Add(item.ksai);
                                    }
                                    project.dataElements[i].kSai = mainForm.myDbContext.get_ksai_easyway(keys, values) + 0.15;
                                }
                                #endregion
                                break;
                            case PartType.Transition://过渡件三维计算完成=>C_1
                                #region
                                double theta = 0; double F0_F1 = 0;
                                FamilySymbol familySymbol = ((FamilyInstance)element).Symbol;
                                List<double> Fs = new List<double>();//存储计算面积
                                List<Connector> Trconnectors = new List<Connector>();
                                foreach (Connector connector in ((FamilyInstance)element).MEPModel.ConnectorManager.Connectors)
                                {
                                    if (connector.Shape==ConnectorProfileType.Round)
                                    {
                                        Fs.Add(connector.Radius * connector.Radius * Math.PI);//单位未换算
                                    }
                                    if (connector.Shape==ConnectorProfileType.Rectangular)
                                    {
                                        Fs.Add(Math.Pow(project.cal_de(connector.Height, connector.Width), 2) * Math.PI / 4);
                                    }
                                    Trconnectors.Add(connector);
                                }
                                double conDis = UIOperation.get_DistanceFromConnectors(Trconnectors[0], Trconnectors[1]);
                                theta = Math.Atan(Math.Abs(Fs[0] - Fs[1])/2/conDis) * 2;
                                theta = Math.Round(theta / Math.PI * 180, 2);
                                if (Fs[0]>Fs[1])
                                {
                                    F0_F1 = Fs[1] / Fs[0];
                                }
                                else
                                {
                                    F0_F1 = Fs[0] / Fs[1];
                                }
                                //=====================
                                MessageBox.Show(theta.ToString() + "   " + F0_F1.ToString());
                                //=====================
                                List<C_1> c_1s = mainForm.myDbContext.c_1.ToList<C_1>();
                                for (int ii = 0; ii < c_1s.Count; ii++)
                                {
                                    keys.Add(c_1s[ii].get_distance(new C_1() { theta = theta, F0_F1 = F0_F1 }));
                                    values.Add(c_1s[ii].ksai);
                                }
                                project.dataElements[i].kSai = mainForm.myDbContext.get_ksai_easyway(keys, values);
                                #endregion
                                break;
                            case PartType.Wye://Y型三通 特殊放到Y型
                                #region
                                //1.判断主管支管
                                #endregion
                                break;
                        }
                        break;
                    default:
                        break;
                }   
            }
            projectForm.refresh_datagrid();
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
