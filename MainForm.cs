using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Autodesk.Revit.UI;
using MySConn;
using MySConn.Tables;


namespace Revit_HyCal
{
    public partial class MainForm : Form
    {
        public MyDbContext myDbContext { get; set; }
        public MainForm()
        {
            FrmProgressBar frmProgressBar = new FrmProgressBar();
            frmProgressBar.Show();
            frmProgressBar.Show_ProgressBar("数据库连接中。。。", 0.99);
            try
            {
                myDbContext = new MyDbContext();
                if (myDbContext.a_1.ToList<A_1>().Count>1)
                {
                    frmProgressBar.Dispose();
                    MessageBox.Show("数据库连接正常！");
                    InitializeComponent();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("连接数据库失败！请联系chenxinxin@sinoma-tianjin.cn");
                frmProgressBar.Dispose();
                this.Dispose();
            }
        }

        private void 新建工程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Project project = new Project();
            MainForm_Operation.new_project(this, project);
            //this.计算ToolStripMenuItem.Enabled = true;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void 打开工程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm_Operation.open_project(this);
            //this.计算ToolStripMenuItem.Enabled = true;
        }

        private void 保存工程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm_Operation.save_project(this);
        }

        private void 保存全部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm_Operation.save_all(this);
        }


        private void 二次拾取ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm_Operation.Second_Pick(this);
        }

        private void 危废风管ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JCPZ jCPZ = new JCPZ("危废风管", this);
            jCPZ.ShowDialog();
        }

        private void 收尘ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JCPZ jCPZ = new JCPZ("收尘风管", this);
            jCPZ.ShowDialog();
        }

        private void 沿程阻力ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm_Operation.cal_R(this);
        }

        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Count() == 0)
            {
                MessageBox.Show("没有打开的工程！");
                return;
            }

            ProjectForm projectForm = (ProjectForm)this.ActiveMdiChild;
            projectForm.myproject.name = null;
            projectForm.myproject.fullpath = null;
            MainForm_Operation.save_project(this);
        }


        private void 管道拾取ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MainForm_Operation.First_Pick(this);
        }

        private void 二次拾取ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MainForm_Operation.Second_Pick(this);
        }

        private void 赋值到模型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MainForm_Operation.projectFrom_to_model(this);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MainForm_Operation.open_project(this);
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            MainForm_Operation.open_project(this);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Project project = new Project();
            MainForm_Operation.new_project(this, project);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            MainForm_Operation.First_Pick(this);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            MainForm_Operation.Second_Pick(this);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            MainForm_Operation.cal_R(this);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            MainForm_Operation.cal_ksi(this);
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            MainForm_Operation.projectFrom_to_csv(this);
        }

        private void 数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myDbContext = new MyDbContext();
            if (myDbContext.a_1.ToList<A_1>().Count > 1)
            {
                MessageBox.Show("数据库连接正常！");
            }
            else
            {
                MessageBox.Show("联系管理员，开通权限！");
            }
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void 重新校核局部阻力ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm_Operation.renew_cal_ksi(this);
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            //Revit_Hycal_Run.change();
            //MainForm_Operation.projectFrom_to_model(this);
        }

        private void 导出CSVtoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MainForm_Operation.projectFrom_to_csv(this);
        }
    }
}
