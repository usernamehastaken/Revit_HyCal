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
    public partial class FrmProgressBar : Form
    {
        public FrmProgressBar()
        {
            
            InitializeComponent();
        }
        public void Show_ProgressBar(string str,double percent)//model funs single between 0~1
        {
            if(percent <= 1 & percent >= 0)
            {
                this.Show();
                int labWidth = this.labFix.Width;
                int labLeft = this.labFix.Left;
                this.labTitle.Text = str;
                this.labProgressBar.Width = labWidth - Convert.ToInt16(labWidth * percent);
                this.labProgressBar.Left = labLeft + Convert.ToInt16(labWidth * percent);
                //this.Refresh();
                System.Windows.Forms.Application.DoEvents();
            }
            else
            {
                this.Dispose();
            }
        }
    }
}
