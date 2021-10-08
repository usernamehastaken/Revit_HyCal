using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Form_Operation.new_project(this,project);
            //this.计算ToolStripMenuItem.Enabled = true;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void 打开工程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Operation.open_project(this);
            //this.计算ToolStripMenuItem.Enabled = true;
        }

        private void 保存工程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Operation.save_project(this);
        }

        private void 保存全部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Operation.save_all(this);
        }

        private void 管道拾取ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Operation.First_Pick(this);            
        }

        private void 二次拾取ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIOperation.ElementIds = UIOperation.SecSelectPipeline(UIOperation.uIDocument, UIOperation.document, UIOperation.ElementIds);
            UIOperation.uIDocument.Selection.SetElementIds(UIOperation.ElementIds);
        }
    }
}
