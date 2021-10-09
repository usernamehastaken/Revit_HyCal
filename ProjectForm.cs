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
        private Project Project;
        public Project myproject 
        {
            get
            {
                return Project;
            }
            set
            {
                Project = value;
                refresh_datagrid();                                
            }
        }
        public ProjectForm(Project project)
        {
            //此处窗体代码有添加
            InitializeComponent();
            myproject = project;
            this.Text = myproject.name;
            this.Project = project;

        }

        public void refresh_datagrid()
        {
            this.dataGridView1.DataSource = myproject.dataElements;
            this.Refresh();
        }
    }
}
