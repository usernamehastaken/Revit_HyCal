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
    public partial class JCPZ : Form
    {
        private MainForm MainForm;
        public JCPZ(string value,MainForm mainForm)
        {
            InitializeComponent();
            this.MainForm = mainForm;
            this.groupBox1.Text = value;
        }

        private void JCPZ_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void CmdOK_Click(object sender, EventArgs e)
        {
            if (this.MainForm.MdiChildren.Count()==0)
            {
                MessageBox.Show("没有打开的工程！");
                this.Dispose();
                return;
            }
            ProjectForm projectForm = (ProjectForm)this.MainForm.ActiveMdiChild;

            projectForm.myproject.doubleGBCCDXZXS = double.Parse(this.GBCCDXZXS.Text);
            projectForm.myproject.doubleGBCCD = double.Parse(this.GBCCD.Text) * 0.001;
            projectForm.myproject.doubleYDND = double.Parse(this.YDND.Text) * 0.000001;
            projectForm.myproject.doubleMD = double.Parse(this.MD.Text);
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.MD.Text = "1.197803";
            //this.MD.Enabled = false;
            MDXZ mDXZ = new MDXZ(this.MainForm);
            mDXZ.Show();
        }
    }
}
