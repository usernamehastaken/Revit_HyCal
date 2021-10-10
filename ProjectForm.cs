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
            this.myproject = project;

        }

        public void refresh_datagrid()
        {
            List<DataElement> show_datas = new List<DataElement>(myproject.dataElements);
            double total_yancheng=0, total_jubu=0;
            foreach (DataElement data in myproject.dataElements)
            {
                total_yancheng += data.Py;
                total_jubu += data.Pj;
            }
            show_datas.Add(new DataElement() {Py = total_yancheng,Pj=total_jubu }) ;
            this.dataGridView1.DataSource = show_datas;
            this.Refresh();
        }
    }
}
