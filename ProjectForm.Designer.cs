﻿
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
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(800, 450);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataElementBindingSource
            // 
            this.dataElementBindingSource.DataSource = typeof(Revit_HyCal.DataElement);
            // 
            // noDataGridViewTextBoxColumn
            // 
            this.noDataGridViewTextBoxColumn.DataPropertyName = "No";
            this.noDataGridViewTextBoxColumn.HeaderText = "No";
            this.noDataGridViewTextBoxColumn.Name = "noDataGridViewTextBoxColumn";
            // 
            // airflowDataGridViewTextBoxColumn
            // 
            this.airflowDataGridViewTextBoxColumn.DataPropertyName = "Airflow";
            this.airflowDataGridViewTextBoxColumn.HeaderText = "Airflow";
            this.airflowDataGridViewTextBoxColumn.Name = "airflowDataGridViewTextBoxColumn";
            // 
            // widthDataGridViewTextBoxColumn
            // 
            this.widthDataGridViewTextBoxColumn.DataPropertyName = "Width";
            this.widthDataGridViewTextBoxColumn.HeaderText = "Width";
            this.widthDataGridViewTextBoxColumn.Name = "widthDataGridViewTextBoxColumn";
            // 
            // heightDataGridViewTextBoxColumn
            // 
            this.heightDataGridViewTextBoxColumn.DataPropertyName = "Height";
            this.heightDataGridViewTextBoxColumn.HeaderText = "Height";
            this.heightDataGridViewTextBoxColumn.Name = "heightDataGridViewTextBoxColumn";
            // 
            // diameterDataGridViewTextBoxColumn
            // 
            this.diameterDataGridViewTextBoxColumn.DataPropertyName = "Diameter";
            this.diameterDataGridViewTextBoxColumn.HeaderText = "Diameter";
            this.diameterDataGridViewTextBoxColumn.Name = "diameterDataGridViewTextBoxColumn";
            // 
            // lengthDataGridViewTextBoxColumn
            // 
            this.lengthDataGridViewTextBoxColumn.DataPropertyName = "Length";
            this.lengthDataGridViewTextBoxColumn.HeaderText = "Length";
            this.lengthDataGridViewTextBoxColumn.Name = "lengthDataGridViewTextBoxColumn";
            // 
            // vDataGridViewTextBoxColumn
            // 
            this.vDataGridViewTextBoxColumn.DataPropertyName = "V";
            this.vDataGridViewTextBoxColumn.HeaderText = "V";
            this.vDataGridViewTextBoxColumn.Name = "vDataGridViewTextBoxColumn";
            // 
            // rDataGridViewTextBoxColumn
            // 
            this.rDataGridViewTextBoxColumn.DataPropertyName = "R";
            this.rDataGridViewTextBoxColumn.HeaderText = "R";
            this.rDataGridViewTextBoxColumn.Name = "rDataGridViewTextBoxColumn";
            // 
            // pyDataGridViewTextBoxColumn
            // 
            this.pyDataGridViewTextBoxColumn.DataPropertyName = "Py";
            this.pyDataGridViewTextBoxColumn.HeaderText = "Py";
            this.pyDataGridViewTextBoxColumn.Name = "pyDataGridViewTextBoxColumn";
            // 
            // kSaiDataGridViewTextBoxColumn
            // 
            this.kSaiDataGridViewTextBoxColumn.DataPropertyName = "kSai";
            this.kSaiDataGridViewTextBoxColumn.HeaderText = "kSai";
            this.kSaiDataGridViewTextBoxColumn.Name = "kSaiDataGridViewTextBoxColumn";
            // 
            // dPressureDataGridViewTextBoxColumn
            // 
            this.dPressureDataGridViewTextBoxColumn.DataPropertyName = "DPressure";
            this.dPressureDataGridViewTextBoxColumn.HeaderText = "DPressure";
            this.dPressureDataGridViewTextBoxColumn.Name = "dPressureDataGridViewTextBoxColumn";
            // 
            // pjDataGridViewTextBoxColumn
            // 
            this.pjDataGridViewTextBoxColumn.DataPropertyName = "Pj";
            this.pjDataGridViewTextBoxColumn.HeaderText = "Pj";
            this.pjDataGridViewTextBoxColumn.Name = "pjDataGridViewTextBoxColumn";
            // 
            // totalPressureDataGridViewTextBoxColumn
            // 
            this.totalPressureDataGridViewTextBoxColumn.DataPropertyName = "TotalPressure";
            this.totalPressureDataGridViewTextBoxColumn.HeaderText = "TotalPressure";
            this.totalPressureDataGridViewTextBoxColumn.Name = "totalPressureDataGridViewTextBoxColumn";
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
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

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource dataElementBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn noDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn airflowDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn widthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn heightDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diameterDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lengthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kSaiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dPressureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pjDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPressureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
    }
}