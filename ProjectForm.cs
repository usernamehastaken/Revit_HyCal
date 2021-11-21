using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using System.IO;

namespace Revit_HyCal
{
    public partial class ProjectForm : System.Windows.Forms.Form
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
            this.dataGridView1.Refresh();
        }

        private void datagridview1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //int id = int.Parse(this.dataGridView1["iDDataGridViewTextBoxColumn", this.dataGridView1.CurrentRow.Index].Value.ToString());
            //ElementId elementId = new ElementId(id);
            //UIOperation.uIDocument.Selection.SetElementIds(new List<ElementId>() { elementId });
            List<ElementId> elementIds = new List<ElementId>();
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                elementIds.Add(new ElementId(int.Parse(item.Cells["iDDataGridViewTextBoxColumn"].Value.ToString())));
            }
            UIOperation.uIDocument.Selection.SetElementIds(elementIds);
        }

        public void ProjectFrom_to_CSV()
        {
            string csvfile_path;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "工程文件|.csv";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                csvfile_path = saveFileDialog.FileName;
            }
            else
            {
                return;
            }

            using (StreamWriter sw=new StreamWriter (csvfile_path))
            {
                string headers = "";
                for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
                {
                    headers = headers + this.dataGridView1.Columns[i].HeaderText+",";
                }
                sw.WriteLine(headers);

                for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                {
                    string text = "";
                    for (int j = 0; j < this.dataGridView1.Columns.Count; j++)
                    {
                        text = text + this.dataGridView1.Rows[i].Cells[j].Value+",";
                    }
                    sw.WriteLine(text);
                }
            }
        }
    }
}
