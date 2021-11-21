
using System;

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
            if (this.MdiChildren.Length!=0)
            {
                foreach (ProjectForm item in this.MdiChildren)
                {
                    item.Dispose();
                }
            }
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建工程ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开工程ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存工程ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.另存为ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存全部ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.计算ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.沿程阻力ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.局部阻力ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重新校核局部阻力ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.模型ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.管道拾取ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.二次拾取ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.赋值到模型ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.模型信息重新提取ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出CSVtoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.基础配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.危废风管ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.收尘ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.计算ToolStripMenuItem,
            this.模型ToolStripMenuItem,
            this.基础配置ToolStripMenuItem,
            this.数据库ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1575, 32);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建工程ToolStripMenuItem,
            this.打开工程ToolStripMenuItem,
            this.保存工程ToolStripMenuItem,
            this.另存为ToolStripMenuItem,
            this.保存全部ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(62, 28);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 新建工程ToolStripMenuItem
            // 
            this.新建工程ToolStripMenuItem.Name = "新建工程ToolStripMenuItem";
            this.新建工程ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.新建工程ToolStripMenuItem.Text = "新建工程";
            this.新建工程ToolStripMenuItem.Click += new System.EventHandler(this.新建工程ToolStripMenuItem_Click);
            // 
            // 打开工程ToolStripMenuItem
            // 
            this.打开工程ToolStripMenuItem.Name = "打开工程ToolStripMenuItem";
            this.打开工程ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.打开工程ToolStripMenuItem.Text = "打开工程";
            this.打开工程ToolStripMenuItem.Click += new System.EventHandler(this.打开工程ToolStripMenuItem_Click);
            // 
            // 保存工程ToolStripMenuItem
            // 
            this.保存工程ToolStripMenuItem.Name = "保存工程ToolStripMenuItem";
            this.保存工程ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.保存工程ToolStripMenuItem.Text = "保存工程";
            this.保存工程ToolStripMenuItem.Click += new System.EventHandler(this.保存工程ToolStripMenuItem_Click);
            // 
            // 另存为ToolStripMenuItem
            // 
            this.另存为ToolStripMenuItem.Name = "另存为ToolStripMenuItem";
            this.另存为ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.另存为ToolStripMenuItem.Text = "另存为...";
            this.另存为ToolStripMenuItem.Click += new System.EventHandler(this.另存为ToolStripMenuItem_Click);
            // 
            // 保存全部ToolStripMenuItem
            // 
            this.保存全部ToolStripMenuItem.Name = "保存全部ToolStripMenuItem";
            this.保存全部ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.保存全部ToolStripMenuItem.Text = "保存全部";
            this.保存全部ToolStripMenuItem.Click += new System.EventHandler(this.保存全部ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 计算ToolStripMenuItem
            // 
            this.计算ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.沿程阻力ToolStripMenuItem,
            this.局部阻力ToolStripMenuItem,
            this.重新校核局部阻力ToolStripMenuItem});
            this.计算ToolStripMenuItem.Name = "计算ToolStripMenuItem";
            this.计算ToolStripMenuItem.Size = new System.Drawing.Size(62, 28);
            this.计算ToolStripMenuItem.Text = "计算";
            // 
            // 沿程阻力ToolStripMenuItem
            // 
            this.沿程阻力ToolStripMenuItem.Name = "沿程阻力ToolStripMenuItem";
            this.沿程阻力ToolStripMenuItem.Size = new System.Drawing.Size(259, 34);
            this.沿程阻力ToolStripMenuItem.Text = "沿程阻力";
            this.沿程阻力ToolStripMenuItem.Click += new System.EventHandler(this.沿程阻力ToolStripMenuItem_Click);
            // 
            // 局部阻力ToolStripMenuItem
            // 
            this.局部阻力ToolStripMenuItem.Name = "局部阻力ToolStripMenuItem";
            this.局部阻力ToolStripMenuItem.Size = new System.Drawing.Size(259, 34);
            this.局部阻力ToolStripMenuItem.Text = "局部阻力(局部0值)";
            this.局部阻力ToolStripMenuItem.Click += new System.EventHandler(this.局部阻力ToolStripMenuItem_Click);
            // 
            // 重新校核局部阻力ToolStripMenuItem
            // 
            this.重新校核局部阻力ToolStripMenuItem.Name = "重新校核局部阻力ToolStripMenuItem";
            this.重新校核局部阻力ToolStripMenuItem.Size = new System.Drawing.Size(259, 34);
            this.重新校核局部阻力ToolStripMenuItem.Text = "重新校核局部阻力";
            this.重新校核局部阻力ToolStripMenuItem.Click += new System.EventHandler(this.重新校核局部阻力ToolStripMenuItem_Click);
            // 
            // 模型ToolStripMenuItem
            // 
            this.模型ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.管道拾取ToolStripMenuItem1,
            this.二次拾取ToolStripMenuItem1,
            this.赋值到模型ToolStripMenuItem,
            this.模型信息重新提取ToolStripMenuItem,
            this.导出CSVtoolStripMenuItem1});
            this.模型ToolStripMenuItem.Name = "模型ToolStripMenuItem";
            this.模型ToolStripMenuItem.Size = new System.Drawing.Size(62, 28);
            this.模型ToolStripMenuItem.Text = "模型";
            // 
            // 管道拾取ToolStripMenuItem1
            // 
            this.管道拾取ToolStripMenuItem1.Name = "管道拾取ToolStripMenuItem1";
            this.管道拾取ToolStripMenuItem1.Size = new System.Drawing.Size(270, 34);
            this.管道拾取ToolStripMenuItem1.Text = "管道拾取";
            this.管道拾取ToolStripMenuItem1.Click += new System.EventHandler(this.管道拾取ToolStripMenuItem1_Click);
            // 
            // 二次拾取ToolStripMenuItem1
            // 
            this.二次拾取ToolStripMenuItem1.Name = "二次拾取ToolStripMenuItem1";
            this.二次拾取ToolStripMenuItem1.Size = new System.Drawing.Size(270, 34);
            this.二次拾取ToolStripMenuItem1.Text = "二次拾取";
            this.二次拾取ToolStripMenuItem1.Click += new System.EventHandler(this.二次拾取ToolStripMenuItem1_Click);
            // 
            // 赋值到模型ToolStripMenuItem
            // 
            this.赋值到模型ToolStripMenuItem.Name = "赋值到模型ToolStripMenuItem";
            this.赋值到模型ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.赋值到模型ToolStripMenuItem.Text = "表赋值到模型";
            this.赋值到模型ToolStripMenuItem.Click += new System.EventHandler(this.赋值到模型ToolStripMenuItem_Click);
            // 
            // 模型信息重新提取ToolStripMenuItem
            // 
            this.模型信息重新提取ToolStripMenuItem.Name = "模型信息重新提取ToolStripMenuItem";
            this.模型信息重新提取ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.模型信息重新提取ToolStripMenuItem.Text = "模型提取到表";
            // 
            // 导出CSVtoolStripMenuItem1
            // 
            this.导出CSVtoolStripMenuItem1.Name = "导出CSVtoolStripMenuItem1";
            this.导出CSVtoolStripMenuItem1.Size = new System.Drawing.Size(270, 34);
            this.导出CSVtoolStripMenuItem1.Text = "导出CSV";
            this.导出CSVtoolStripMenuItem1.Click += new System.EventHandler(this.导出CSVtoolStripMenuItem1_Click);
            // 
            // 基础配置ToolStripMenuItem
            // 
            this.基础配置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.危废风管ToolStripMenuItem,
            this.收尘ToolStripMenuItem});
            this.基础配置ToolStripMenuItem.Name = "基础配置ToolStripMenuItem";
            this.基础配置ToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.基础配置ToolStripMenuItem.Text = "基础配置";
            // 
            // 危废风管ToolStripMenuItem
            // 
            this.危废风管ToolStripMenuItem.Name = "危废风管ToolStripMenuItem";
            this.危废风管ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.危废风管ToolStripMenuItem.Text = "危废风管";
            this.危废风管ToolStripMenuItem.Click += new System.EventHandler(this.危废风管ToolStripMenuItem_Click);
            // 
            // 收尘ToolStripMenuItem
            // 
            this.收尘ToolStripMenuItem.Name = "收尘ToolStripMenuItem";
            this.收尘ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.收尘ToolStripMenuItem.Text = "收尘风管";
            this.收尘ToolStripMenuItem.Click += new System.EventHandler(this.收尘ToolStripMenuItem_Click);
            // 
            // 数据库ToolStripMenuItem
            // 
            this.数据库ToolStripMenuItem.Name = "数据库ToolStripMenuItem";
            this.数据库ToolStripMenuItem.Size = new System.Drawing.Size(80, 28);
            this.数据库ToolStripMenuItem.Text = "数据库";
            this.数据库ToolStripMenuItem.Click += new System.EventHandler(this.数据库ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(62, 28);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(58, 58);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripButton7,
            this.toolStripButton8,
            this.toolStripButton9});
            this.toolStrip1.Location = new System.Drawing.Point(0, 32);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1575, 54);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::Revit_HyCal.Properties.Resources.打开文档;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(46, 38);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "导入工程";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::Revit_HyCal.Properties.Resources.添加数据;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(46, 38);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.ToolTipText = "新建工程";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.AutoSize = false;
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::Revit_HyCal.Properties.Resources.提取边界线;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(46, 38);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.ToolTipText = "管道拾取";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.AutoSize = false;
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::Revit_HyCal.Properties.Resources.线拓扑检查;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(46, 38);
            this.toolStripButton4.Text = "toolStripButton4";
            this.toolStripButton4.ToolTipText = "二次拾取";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.AutoSize = false;
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = global::Revit_HyCal.Properties.Resources.折线路径;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(46, 38);
            this.toolStripButton5.Text = "toolStripButton5";
            this.toolStripButton5.ToolTipText = "沿程阻力计算";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.AutoSize = false;
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = global::Revit_HyCal.Properties.Resources.曲线路径;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(46, 38);
            this.toolStripButton6.Text = "toolStripButton6";
            this.toolStripButton6.ToolTipText = "局部阻力(0值计算)";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.AutoSize = false;
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = global::Revit_HyCal.Properties.Resources.数据导入;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(46, 38);
            this.toolStripButton7.Text = "toolStripButton7";
            this.toolStripButton7.ToolTipText = "模型提取到表";
            this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_Click);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.AutoSize = false;
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = global::Revit_HyCal.Properties.Resources.数据导出;
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(46, 38);
            this.toolStripButton8.Text = "toolStripButton8";
            this.toolStripButton8.ToolTipText = "表赋值到模型";
            this.toolStripButton8.Click += new System.EventHandler(this.toolStripButton8_Click);
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.AutoSize = false;
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton9.Image = global::Revit_HyCal.Properties.Resources.CSV;
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(46, 38);
            this.toolStripButton9.Text = "toolStripButton9";
            this.toolStripButton9.Click += new System.EventHandler(this.toolStripButton9_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1575, 808);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "风管阻力计算";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void 局部阻力ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm_Operation.cal_ksi(this);
        }


        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 计算ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建工程ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开工程ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存工程ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存全部ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 基础配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 危废风管ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 收尘ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 沿程阻力ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 局部阻力ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 另存为ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重新校核局部阻力ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 模型ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 管道拾取ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 二次拾取ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 赋值到模型ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 模型信息重新提取ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private System.Windows.Forms.ToolStripMenuItem 导出CSVtoolStripMenuItem1;
    }
}