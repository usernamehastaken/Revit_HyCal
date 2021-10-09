
namespace Revit_HyCal
{
    partial class MDXZ
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.XDSD = new System.Windows.Forms.TextBox();
            this.WD = new System.Windows.Forms.TextBox();
            this.DQYL = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(149, 137);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // XDSD
            // 
            this.XDSD.Location = new System.Drawing.Point(124, 93);
            this.XDSD.Name = "XDSD";
            this.XDSD.Size = new System.Drawing.Size(100, 21);
            this.XDSD.TabIndex = 12;
            this.XDSD.Text = "60";
            // 
            // WD
            // 
            this.WD.Location = new System.Drawing.Point(124, 51);
            this.WD.Name = "WD";
            this.WD.Size = new System.Drawing.Size(100, 21);
            this.WD.TabIndex = 11;
            this.WD.Text = "20";
            // 
            // DQYL
            // 
            this.DQYL.Location = new System.Drawing.Point(124, 6);
            this.DQYL.Name = "DQYL";
            this.DQYL.Size = new System.Drawing.Size(100, 21);
            this.DQYL.TabIndex = 10;
            this.DQYL.Text = "101325";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "相对湿度(%)：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "温度(℃)：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "大气压力(Pa)：";
            // 
            // MDXZ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 171);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.XDSD);
            this.Controls.Add(this.WD);
            this.Controls.Add(this.DQYL);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MDXZ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MDXZ";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox XDSD;
        private System.Windows.Forms.TextBox WD;
        private System.Windows.Forms.TextBox DQYL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}