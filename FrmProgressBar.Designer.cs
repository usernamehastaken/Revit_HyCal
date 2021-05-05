
namespace Revit_HyCal
{
    partial class FrmProgressBar
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
            this.labTitle = new System.Windows.Forms.Label();
            this.labFix = new System.Windows.Forms.Label();
            this.labProgressBar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labTitle
            // 
            this.labTitle.AutoSize = true;
            this.labTitle.Font = new System.Drawing.Font("华文琥珀", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTitle.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labTitle.Location = new System.Drawing.Point(0, 0);
            this.labTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(132, 25);
            this.labTitle.TabIndex = 0;
            this.labTitle.Text = "模型分析中";
            this.labTitle.UseWaitCursor = true;
            // 
            // labFix
            // 
            this.labFix.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labFix.Font = new System.Drawing.Font("华文琥珀", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labFix.ForeColor = System.Drawing.SystemColors.Control;
            this.labFix.Location = new System.Drawing.Point(0, 25);
            this.labFix.Margin = new System.Windows.Forms.Padding(0);
            this.labFix.Name = "labFix";
            this.labFix.Size = new System.Drawing.Size(400, 25);
            this.labFix.TabIndex = 1;
            this.labFix.Text = "HVAC HYDRAULIC CALCULATION";
            this.labFix.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labFix.UseWaitCursor = true;
            // 
            // labProgressBar
            // 
            this.labProgressBar.Location = new System.Drawing.Point(57, 110);
            this.labProgressBar.Name = "labProgressBar";
            this.labProgressBar.Size = new System.Drawing.Size(100, 23);
            this.labProgressBar.TabIndex = 2;
            this.labProgressBar.UseWaitCursor = true;
            // 
            // FrmProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(677, 267);
            this.ControlBox = false;
            this.Controls.Add(this.labProgressBar);
            this.Controls.Add(this.labFix);
            this.Controls.Add(this.labTitle);
            this.Font = new System.Drawing.Font("华文琥珀", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmProgressBar";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.UseWaitCursor = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label labTitle;
        public System.Windows.Forms.Label labFix;
        public System.Windows.Forms.Label labProgressBar;
    }
}