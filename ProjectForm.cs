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
    public partial class ProjectForm : Form
    {
        public Project myproject { get; set; }
        public ProjectForm(Project project)
        {
            //此处窗体代码有添加
            myproject = project;
            InitializeComponent();
            this.Text = myproject.name;
            this.dataGridView1.DataSource = myproject.dataElements;

        }
    }
}
