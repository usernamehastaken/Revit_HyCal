﻿
using System;
using System.Windows.Forms;

namespace Revit_HyCal
{
    partial class ProjectForm
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
            MainForm_Operation.save_project((MainForm)this.MdiParent);
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataElementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.noDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarksDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.airflowDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.widthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.heightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diameterDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lengthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kSaiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dPressureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pjDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPressureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataElementBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.noDataGridViewTextBoxColumn,
            this.remarksDataGridViewTextBoxColumn,
            this.airflowDataGridViewTextBoxColumn,
            this.widthDataGridViewTextBoxColumn,
            this.heightDataGridViewTextBoxColumn,
            this.diameterDataGridViewTextBoxColumn,
            this.lengthDataGridViewTextBoxColumn,
            this.vDataGridViewTextBoxColumn,
            this.rDataGridViewTextBoxColumn,
            this.pyDataGridViewTextBoxColumn,
            this.kSaiDataGridViewTextBoxColumn,
            this.dPressureDataGridViewTextBoxColumn,
            this.pjDataGridViewTextBoxColumn,
            this.totalPressureDataGridViewTextBoxColumn,
            this.iDDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.dataElementBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(800, 450);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.datagridview1_RowHeaderMouseClick);
            // 
            // dataElementBindingSource
            // 
            this.dataElementBindingSource.DataSource = typeof(Revit_HyCal.DataElement);
            // 
            // noDataGridViewTextBoxColumn
            // 
            this.noDataGridViewTextBoxColumn.DataPropertyName = "No";
            this.noDataGridViewTextBoxColumn.HeaderText = "序号";
            this.noDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.noDataGridViewTextBoxColumn.Name = "noDataGridViewTextBoxColumn";
            // 
            // remarksDataGridViewTextBoxColumn
            // 
            this.remarksDataGridViewTextBoxColumn.DataPropertyName = "Remarks";
            this.remarksDataGridViewTextBoxColumn.HeaderText = "类型";
            this.remarksDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.remarksDataGridViewTextBoxColumn.Name = "remarksDataGridViewTextBoxColumn";
            // 
            // airflowDataGridViewTextBoxColumn
            // 
            this.airflowDataGridViewTextBoxColumn.DataPropertyName = "Airflow";
            this.airflowDataGridViewTextBoxColumn.HeaderText = "风量(m³/h)";
            this.airflowDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.airflowDataGridViewTextBoxColumn.Name = "airflowDataGridViewTextBoxColumn";
            // 
            // widthDataGridViewTextBoxColumn
            // 
            this.widthDataGridViewTextBoxColumn.DataPropertyName = "Width";
            this.widthDataGridViewTextBoxColumn.HeaderText = "风管宽(mm)";
            this.widthDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.widthDataGridViewTextBoxColumn.Name = "widthDataGridViewTextBoxColumn";
            // 
            // heightDataGridViewTextBoxColumn
            // 
            this.heightDataGridViewTextBoxColumn.DataPropertyName = "Height";
            this.heightDataGridViewTextBoxColumn.HeaderText = "风管高(mm)";
            this.heightDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.heightDataGridViewTextBoxColumn.Name = "heightDataGridViewTextBoxColumn";
            // 
            // diameterDataGridViewTextBoxColumn
            // 
            this.diameterDataGridViewTextBoxColumn.DataPropertyName = "Diameter";
            this.diameterDataGridViewTextBoxColumn.HeaderText = "直径(mm)";
            this.diameterDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.diameterDataGridViewTextBoxColumn.Name = "diameterDataGridViewTextBoxColumn";
            // 
            // lengthDataGridViewTextBoxColumn
            // 
            this.lengthDataGridViewTextBoxColumn.DataPropertyName = "Length";
            this.lengthDataGridViewTextBoxColumn.HeaderText = "风管长(mm)";
            this.lengthDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.lengthDataGridViewTextBoxColumn.Name = "lengthDataGridViewTextBoxColumn";
            // 
            // vDataGridViewTextBoxColumn
            // 
            this.vDataGridViewTextBoxColumn.DataPropertyName = "V";
            this.vDataGridViewTextBoxColumn.HeaderText = "风速(m/s)";
            this.vDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.vDataGridViewTextBoxColumn.Name = "vDataGridViewTextBoxColumn";
            // 
            // rDataGridViewTextBoxColumn
            // 
            this.rDataGridViewTextBoxColumn.DataPropertyName = "R";
            this.rDataGridViewTextBoxColumn.HeaderText = "R(Pa/m)";
            this.rDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.rDataGridViewTextBoxColumn.Name = "rDataGridViewTextBoxColumn";
            // 
            // pyDataGridViewTextBoxColumn
            // 
            this.pyDataGridViewTextBoxColumn.DataPropertyName = "Py";
            this.pyDataGridViewTextBoxColumn.HeaderText = "沿程阻力(Pa)";
            this.pyDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.pyDataGridViewTextBoxColumn.Name = "pyDataGridViewTextBoxColumn";
            // 
            // kSaiDataGridViewTextBoxColumn
            // 
            this.kSaiDataGridViewTextBoxColumn.DataPropertyName = "kSai";
            this.kSaiDataGridViewTextBoxColumn.HeaderText = "局部阻力系数";
            this.kSaiDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.kSaiDataGridViewTextBoxColumn.Name = "kSaiDataGridViewTextBoxColumn";
            // 
            // dPressureDataGridViewTextBoxColumn
            // 
            this.dPressureDataGridViewTextBoxColumn.DataPropertyName = "DPressure";
            this.dPressureDataGridViewTextBoxColumn.HeaderText = "动压(Pa)";
            this.dPressureDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.dPressureDataGridViewTextBoxColumn.Name = "dPressureDataGridViewTextBoxColumn";
            // 
            // pjDataGridViewTextBoxColumn
            // 
            this.pjDataGridViewTextBoxColumn.DataPropertyName = "Pj";
            this.pjDataGridViewTextBoxColumn.HeaderText = "局部阻力(Pa)";
            this.pjDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.pjDataGridViewTextBoxColumn.Name = "pjDataGridViewTextBoxColumn";
            // 
            // totalPressureDataGridViewTextBoxColumn
            // 
            this.totalPressureDataGridViewTextBoxColumn.DataPropertyName = "TotalPressure";
            this.totalPressureDataGridViewTextBoxColumn.HeaderText = "总阻力(Pa)";
            this.totalPressureDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.totalPressureDataGridViewTextBoxColumn.Name = "totalPressureDataGridViewTextBoxColumn";
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            // 
            // ProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ProjectForm";
            this.Text = "新建管道系统";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataElementBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

 

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //this.dataGridView1.Refresh();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource dataElementBindingSource;
        private DataGridViewTextBoxColumn noDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn remarksDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn airflowDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn widthDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn heightDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn diameterDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lengthDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn vDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn rDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn pyDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn kSaiDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dPressureDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn pjDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalPressureDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
    }
}