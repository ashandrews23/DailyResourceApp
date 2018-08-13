namespace DailyResource
{
    partial class Report
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Report));
            this.DailyResourceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.zTestAA09DailyResourceAppDataSet = new DailyResource.zTestAA09DailyResourceAppDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dailyResourceBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.DailyResourceTableAdapter = new DailyResource.zTestAA09DailyResourceAppDataSetTableAdapters.DailyResourceTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DailyResourceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zTestAA09DailyResourceAppDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dailyResourceBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // DailyResourceBindingSource
            // 
            this.DailyResourceBindingSource.DataMember = "DailyResource";
            this.DailyResourceBindingSource.DataSource = this.zTestAA09DailyResourceAppDataSet;
            // 
            // zTestAA09DailyResourceAppDataSet
            // 
            this.zTestAA09DailyResourceAppDataSet.DataSetName = "zTestAA09DailyResourceAppDataSet";
            this.zTestAA09DailyResourceAppDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.DailyResourceBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DailyResource.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(47, 94);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1143, 465);
            this.reportViewer1.TabIndex = 0;
            // 
            // dailyResourceBindingSource1
            // 
            this.dailyResourceBindingSource1.DataMember = "DailyResource";
            // 
            // DailyResourceTableAdapter
            // 
            this.DailyResourceTableAdapter.ClearBeforeFill = true;
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 695);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Report";
            this.Text = "Report";
            this.Load += new System.EventHandler(this.Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DailyResourceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zTestAA09DailyResourceAppDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dailyResourceBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DailyResourceBindingSource;
        private zTestAA09DailyResourceAppDataSet zTestAA09DailyResourceAppDataSet;
        private zTestAA09DailyResourceAppDataSetTableAdapters.DailyResourceTableAdapter DailyResourceTableAdapter;
        private System.Windows.Forms.BindingSource dailyResourceBindingSource1;

    }
}