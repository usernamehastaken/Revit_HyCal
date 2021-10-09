
namespace Revit_HyCal
{
    partial class MainForm
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
            MainForm_Operation.check_before_close(this);
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建工程ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开工程ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存工程ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存全部ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.计算ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.管道拾取ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.二次拾取ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.沿程阻力ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.局部阻力ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.基础配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.危废风管ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.收尘ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.计算ToolStripMenuItem,
            this.基础配置ToolStripMenuItem,
            this.数据库ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1050, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建工程ToolStripMenuItem,
            this.打开工程ToolStripMenuItem,
            this.保存工程ToolStripMenuItem,
            this.保存全部ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 新建工程ToolStripMenuItem
            // 
            this.新建工程ToolStripMenuItem.Name = "新建工程ToolStripMenuItem";
            this.新建工程ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.新建工程ToolStripMenuItem.Text = "新建工程";
            this.新建工程ToolStripMenuItem.Click += new System.EventHandler(this.新建工程ToolStripMenuItem_Click);
            // 
            // 打开工程ToolStripMenuItem
            // 
            this.打开工程ToolStripMenuItem.Name = "打开工程ToolStripMenuItem";
            this.打开工程ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.打开工程ToolStripMenuItem.Text = "打开工程";
            this.打开工程ToolStripMenuItem.Click += new System.EventHandler(this.打开工程ToolStripMenuItem_Click);
            // 
            // 保存工程ToolStripMenuItem
            // 
            this.保存工程ToolStripMenuItem.Name = "保存工程ToolStripMenuItem";
            this.保存工程ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.保存工程ToolStripMenuItem.Text = "保存工程";
            this.保存工程ToolStripMenuItem.Click += new System.EventHandler(this.保存工程ToolStripMenuItem_Click);
            // 
            // 保存全部ToolStripMenuItem
            // 
            this.保存全部ToolStripMenuItem.Name = "保存全部ToolStripMenuItem";
            this.保存全部ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.保存全部ToolStripMenuItem.Text = "保存全部";
            this.保存全部ToolStripMenuItem.Click += new System.EventHandler(this.保存全部ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 计算ToolStripMenuItem
            // 
            this.计算ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.管道拾取ToolStripMenuItem,
            this.二次拾取ToolStripMenuItem,
            this.沿程阻力ToolStripMenuItem,
            this.局部阻力ToolStripMenuItem});
            this.计算ToolStripMenuItem.Name = "计算ToolStripMenuItem";
            this.计算ToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.计算ToolStripMenuItem.Text = "计算";
            // 
            // 管道拾取ToolStripMenuItem
            // 
            this.管道拾取ToolStripMenuItem.Name = "管道拾取ToolStripMenuItem";
            this.管道拾取ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.管道拾取ToolStripMenuItem.Text = "管道拾取";
            this.管道拾取ToolStripMenuItem.Click += new System.EventHandler(this.管道拾取ToolStripMenuItem_Click);
            // 
            // 二次拾取ToolStripMenuItem
            // 
            this.二次拾取ToolStripMenuItem.Name = "二次拾取ToolStripMenuItem";
            this.二次拾取ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.二次拾取ToolStripMenuItem.Text = "二次拾取";
            this.二次拾取ToolStripMenuItem.Click += new System.EventHandler(this.二次拾取ToolStripMenuItem_Click);
            // 
            // 沿程阻力ToolStripMenuItem
            // 
            this.沿程阻力ToolStripMenuItem.Name = "沿程阻力ToolStripMenuItem";
            this.沿程阻力ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.沿程阻力ToolStripMenuItem.Text = "沿程阻力";
            this.沿程阻力ToolStripMenuItem.Click += new System.EventHandler(this.沿程阻力ToolStripMenuItem_Click);
            // 
            // 局部阻力ToolStripMenuItem
            // 
            this.局部阻力ToolStripMenuItem.Name = "局部阻力ToolStripMenuItem";
            this.局部阻力ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.局部阻力ToolStripMenuItem.Text = "局部阻力";
            // 
            // 基础配置ToolStripMenuItem
            // 
            this.基础配置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.危废风管ToolStripMenuItem,
            this.收尘ToolStripMenuItem});
            this.基础配置ToolStripMenuItem.Name = "基础配置ToolStripMenuItem";
            this.基础配置ToolStripMenuItem.Size = new System.Drawing.Size(68, 22);
            this.基础配置ToolStripMenuItem.Text = "基础配置";
            // 
            // 危废风管ToolStripMenuItem
            // 
            this.危废风管ToolStripMenuItem.Name = "危废风管ToolStripMenuItem";
            this.危废风管ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.危废风管ToolStripMenuItem.Text = "危废风管";
            this.危废风管ToolStripMenuItem.Click += new System.EventHandler(this.危废风管ToolStripMenuItem_Click);
            // 
            // 收尘ToolStripMenuItem
            // 
            this.收尘ToolStripMenuItem.Name = "收尘ToolStripMenuItem";
            this.收尘ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.收尘ToolStripMenuItem.Text = "收尘风管";
            this.收尘ToolStripMenuItem.Click += new System.EventHandler(this.收尘ToolStripMenuItem_Click);
            // 
            // 数据库ToolStripMenuItem
            // 
            this.数据库ToolStripMenuItem.Name = "数据库ToolStripMenuItem";
            this.数据库ToolStripMenuItem.Size = new System.Drawing.Size(56, 22);
            this.数据库ToolStripMenuItem.Text = "数据库";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1050, 539);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "风管阻力计算";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 计算ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 管道拾取ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建工程ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开工程ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存工程ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存全部ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 二次拾取ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 基础配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 危废风管ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 收尘ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 沿程阻力ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 局部阻力ToolStripMenuItem;
    }
}