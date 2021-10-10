using System;
using System.Linq;
using System.Windows.Forms;

namespace Revit_HyCal
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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
            MainForm_Operation.Second_Pick(this);
        }
    }
}
