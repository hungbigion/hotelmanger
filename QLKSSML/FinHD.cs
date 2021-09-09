using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace QLKSSML
{
    public partial class FinHD : Form
    {
        public FinHD()
        {
            InitializeComponent();
        }

        private void FinHD_Load(object sender, EventArgs e)
        {
            Ctraphong ob = new Ctraphong();
            cbxluachonkh.DataSource = ob.load("select * from Khachhang");
            cbxluachonkh.DisplayMember = "Tenkh";
            cbxluachonkh.ValueMember = "Makh";
            string ttdv = ob.load("select sum(phidv) from HDDichVu where Makh=N'"+cbxluachonkh.SelectedValue.ToString()+"'").Rows[0][0].ToString().Trim();
            txttdv.Text = ttdv;
            string ttp = ob.load("select sum(phiphong) from Hoadon where Makh=N'" + cbxluachonkh.SelectedValue.ToString() + "'").Rows[0][0].ToString().Trim();
            txttphong.Text = ttp;
            int tttien = Int32.Parse(ttdv) + Int32.Parse(ttp);
            string tthanhtien = tttien.ToString();
            txttongtt.Text = tthanhtien;
            this.reportViewer1.RefreshReport();
        }

        private void btninhoadon_Click(object sender, EventArgs e)
        {
            string sql1;
            //
            Ctraphong ob = new Ctraphong();
            string ttdv = ob.load("select sum(phidv) from HDDichVu where Makh=N'" + cbxluachonkh.SelectedValue.ToString() + "'").Rows[0][0].ToString().Trim();
            txttdv.Text = ttdv;
            string ttp = ob.load("select sum(phiphong) from Hoadon where Makh=N'" + cbxluachonkh.SelectedValue.ToString() + "'").Rows[0][0].ToString().Trim();
            txttphong.Text = ttp;
            int tttien = Int32.Parse(ttdv) + Int32.Parse(ttp);
            string tthanhtien = tttien.ToString();
            txttongtt.Text = tthanhtien;
            sql1 = "select nv.Manv,Tenkh,Tennv,kh.sdt,Ngaynhanphong,Ngaytraphong,ngaybatdaudv,ngaykethucdv from Hoadon hd inner join Khachhang kh on kh.Makh=hd.Makh inner join Nhanvien nv on hd.Manv= nv.Manv inner join HDDichVu dv on hd.Makh=dv.Makh  where hd.MaPhong=dv.MaPhong and hd.MaKh='" + cbxluachonkh.SelectedValue.ToString() + "'";
            DataTable dt = new DataTable();
            dt = ob.load(sql1);

            ReportParameter dv = new ReportParameter("ttdv");
            dv.Values.Add(txttdv.Text);
            reportViewer1.LocalReport.SetParameters(dv);

            ReportParameter tp = new ReportParameter("ttp");
            tp.Values.Add(txttphong.Text);
            reportViewer1.LocalReport.SetParameters(tp);

            ReportParameter tt = new ReportParameter("tthanhtien");
            tt.Values.Add(txttongtt.Text);
            reportViewer1.LocalReport.SetParameters(tt);

            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = @"C:\Users\Microsoft Windows\Documents\My Palettes\QLKSSML\QLKSSML\ReportInHD.rdlc";
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSetinHD";
            rds.Value = dt;
            reportViewer1.LocalReport.DataSources.Clear();
            //Add dữ liệu vào
            reportViewer1.LocalReport.DataSources.Add(rds);
            //Refresh lại báo cáo
            reportViewer1.RefreshReport();
        }
    }
}
