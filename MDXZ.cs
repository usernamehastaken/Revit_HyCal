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
    public partial class MDXZ : Form
    {
        private MainForm MainForm;
        public MDXZ(MainForm mainForm)
        {
            InitializeComponent();
            this.MainForm = mainForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Count() == 0)
            {
                MessageBox.Show("没有打开的工程！");
                this.Dispose();
                return;
            }

            ProjectForm projectForm = (ProjectForm)this.MainForm.ActiveMdiChild;
            projectForm.myproject.doubleMD = 1.197803; /*进入此窗体，自动设置密度为1.2，注意返回窗体重新定义密度*/
            projectForm.myproject.cal_MDXZ(double.Parse(this.DQYL.Text), double.Parse(this.WD.Text));
            this.Dispose();
        }
    }
}
