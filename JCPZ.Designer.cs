
namespace Revit_HyCal
{
    partial class JCPZ
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.CmdOK = new System.Windows.Forms.Button();
            this.MD = new System.Windows.Forms.TextBox();
            this.YDND = new System.Windows.Forms.TextBox();
            this.GBCCD = new System.Windows.Forms.TextBox();
            this.GBCCDXZXS = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.CmdOK);
            this.groupBox1.Controls.Add(this.MD);
            this.groupBox1.Controls.Add(this.YDND);
            this.groupBox1.Controls.Add(this.GBCCD);
            this.groupBox1.Controls.Add(this.GBCCDXZXS);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 251);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本参数";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(245, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "(如果进行密度修正，则此处设置为1.197803)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 222);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "密度修正";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CmdOK
            // 
            this.CmdOK.Location = new System.Drawing.Point(285, 222);
            this.CmdOK.Name = "CmdOK";
            this.CmdOK.Size = new System.Drawing.Size(75, 23);
            this.CmdOK.TabIndex = 8;
            this.CmdOK.Text = "确定";
            this.CmdOK.UseVisualStyleBackColor = true;
            this.CmdOK.Click += new System.EventHandler(this.CmdOK_Click);
            // 
            // MD
            // 
            this.MD.Location = new System.Drawing.Point(188, 174);
            this.MD.Name = "MD";
            this.MD.Size = new System.Drawing.Size(100, 21);
            this.MD.TabIndex = 7;
            this.MD.Text = "1.197803";
            // 
            // YDND
            // 
            this.YDND.Location = new System.Drawing.Point(188, 128);
            this.YDND.Name = "YDND";
            this.YDND.Size = new System.Drawing.Size(100, 21);
            this.YDND.TabIndex = 6;
            this.YDND.Text = "15.06";
            // 
            // GBCCD
            // 
            this.GBCCD.Location = new System.Drawing.Point(188, 83);
            this.GBCCD.Name = "GBCCD";
            this.GBCCD.Size = new System.Drawing.Size(100, 21);
            this.GBCCD.TabIndex = 5;
            this.GBCCD.Text = "0.01";
            // 
            // GBCCDXZXS
            // 
            this.GBCCDXZXS.Location = new System.Drawing.Point(188, 37);
            this.GBCCDXZXS.Name = "GBCCDXZXS";
            this.GBCCDXZXS.Size = new System.Drawing.Size(100, 21);
            this.GBCCDXZXS.TabIndex = 4;
            this.GBCCDXZXS.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "密度(kg/m^3)：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "运动粘度(1.0e-6m^2/s)：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "管壁粗糙度(1.0e-3m)：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "管壁粗糙度修正系数：";
            // 
            // JCPZ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 267);
            this.Controls.Add(this.groupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "JCPZ";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "JCPZ";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.JCPZ_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button CmdOK;
        private System.Windows.Forms.TextBox MD;
        private System.Windows.Forms.TextBox YDND;
        private System.Windows.Forms.TextBox GBCCD;
        private System.Windows.Forms.TextBox GBCCDXZXS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}