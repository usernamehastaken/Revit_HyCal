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
            project.name = "1111";
            DataElement data = new DataElement();
            data.ID = "123";data.No = 78;
            project.dataElements.Add(data);
            Form_Operation.new_project(this,project);
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void 打开工程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Operation.open_project(this);
        }

        private void 保存工程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Operation.save_project(this);
        }
    }
}
