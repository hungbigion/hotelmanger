namespace QLKSSML
{
    partial class FinHD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FinHD));
            this.DataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetinHD = new QLKSSML.DataSetinHD();
            this.cbxluachonkh = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btninhoadon = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.txttdv = new System.Windows.Forms.TextBox();
            this.txttphong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txttongtt = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetinHD)).BeginInit();
            this.SuspendLayout();
            // 
            // DataTable1BindingSource
            // 
            this.DataTable1BindingSource.DataMember = "DataTable1";
            this.DataTable1BindingSource.DataSource = this.DataSetinHD;
            // 
            // DataSetinHD
            // 
            this.DataSetinHD.DataSetName = "DataSetinHD";
            this.DataSetinHD.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cbxluachonkh
            // 
            this.cbxluachonkh.FormattingEnabled = true;
            this.cbxluachonkh.Location = new System.Drawing.Point(241, 73);
            this.cbxluachonkh.Name = "cbxluachonkh";
            this.cbxluachonkh.Size = new System.Drawing.Size(204, 28);
            this.cbxluachonkh.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên khách hàng";
            // 
            // btninhoadon
            // 
            this.btninhoadon.Location = new System.Drawing.Point(1625, 64);
            this.btninhoadon.Name = "btninhoadon";
            this.btninhoadon.Size = new System.Drawing.Size(159, 39);
            this.btninhoadon.TabIndex = 2;
            this.btninhoadon.Text = "In Hóa Đơn";
            this.btninhoadon.UseVisualStyleBackColor = true;
            this.btninhoadon.Click += new System.EventHandler(this.btninhoadon_Click);
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSetinHD";
            reportDataSource1.Value = this.DataTable1BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLKSSML.ReportInHD.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(76, 207);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1586, 813);
            this.reportViewer1.TabIndex = 3;
            // 
            // txttdv
            // 
            this.txttdv.Location = new System.Drawing.Point(716, 70);
            this.txttdv.Name = "txttdv";
            this.txttdv.Size = new System.Drawing.Size(100, 26);
            this.txttdv.TabIndex = 4;
            // 
            // txttphong
            // 
            this.txttphong.Location = new System.Drawing.Point(1006, 69);
            this.txttphong.Name = "txttphong";
            this.txttphong.Size = new System.Drawing.Size(100, 26);
            this.txttphong.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(530, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tổng tiền dịch vụ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(864, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tổng tiền phòng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1173, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tổng thành tiền";
            // 
            // txttongtt
            // 
            this.txttongtt.Location = new System.Drawing.Point(1315, 69);
            this.txttongtt.Name = "txttongtt";
            this.txttongtt.Size = new System.Drawing.Size(100, 26);
            this.txttongtt.TabIndex = 8;
            // 
            // FinHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1828, 1050);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txttongtt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txttphong);
            this.Controls.Add(this.txttdv);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.btninhoadon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxluachonkh);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FinHD";
            this.Text = "In Hóa Đơn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FinHD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetinHD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxluachonkh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btninhoadon;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DataTable1BindingSource;
        private DataSetinHD DataSetinHD;
        private System.Windows.Forms.TextBox txttdv;
        private System.Windows.Forms.TextBox txttphong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txttongtt;
    }
}