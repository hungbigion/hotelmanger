using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace QLKSSML
{
    public partial class FQLtraphong : Form
    {
        public FQLtraphong()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=UFYNDEVZ5K1UKA9\SQLEXPRESS;Initial Catalog=QLKS_SML;Integrated Security=True");
        string sql;
        SqlCommand thuchien;
       SqlDataReader docdulieu;
        Ctraphong ob1 = new Ctraphong();
        int i;
        private void FQLtraphong_Load(object sender, EventArgs e)
        {
            CHDservice ob = new CHDservice();
            ob.hienthi_listview(listViewhdDV, "select MahoadonDV,Makh,MaPhong,TenDV,giaDV,ngaybatdaudv,ngaykethucdv,phidv from HDDichVu");
            Ctraphong ob1 = new Ctraphong();
            ob1.hienthi_listview(listViewhoadontong, "select * from Hoadon");

            cbxmapthue.DataSource = ob1.load("select * from TTthuephong");
            cbxmapthue.DisplayMember = "MaThuep";
            cbxmapthue.ValueMember = "MaThuep";

            cbxmakh.DataSource = ob1.load("select * from Khachhang");
            cbxmakh.DisplayMember = "Tenkh";
            cbxmakh.ValueMember = "Makh";

            
            cbxmaphong.DataSource = ob1.load("select * from TTthuephong");
            cbxmaphong.DisplayMember = "MaPhong";
            cbxmaphong.ValueMember = "MaPhong";

            cbxmanv.DataSource = ob1.load("select * from Nhanvien");
            cbxmanv.DisplayMember = "Tennv";
            cbxmanv.ValueMember = "Manv";

            cbxngaydat.DataSource = ob1.load("select * from TTthuephong");
            cbxngaydat.DisplayMember = "Ngaydatphong";
            cbxngaydat.ValueMember = "Ngaydatphong";

            cbxngaynhan.DataSource = ob1.load("select * from TTthuephong");
            cbxngaynhan.DisplayMember = "Ngaynhanphong";
            cbxngaynhan.ValueMember = "Ngaynhanphong";

            cbxsonguoi.DataSource = ob1.load("select * from TTthuephong");
            cbxsonguoi.DisplayMember = "songuoi";
            cbxsonguoi.ValueMember = "songuoi";

            cbxgiaphong.DataSource = ob1.load("select * from TTthuephong");
            cbxgiaphong.DisplayMember = "giaphong";
            cbxgiaphong.ValueMember = "giaphong";
        }

        private void cbxmapthue_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ctraphong ob1 = new Ctraphong();
            DataTable dt = new DataTable();
            dt = ob1.load("select Makh,MaPhong,Manv,Ngaydatphong,Ngaynhanphong,songuoi,giaphong from TTthuephong where MaThuep='" + cbxmapthue.SelectedValue.ToString() + "'");
            foreach (DataRow row in dt.Rows)
            {
                cbxmakh.SelectedValue = row["Makh"].ToString();
                cbxmaphong.SelectedValue = row["MaPhong"].ToString();
                cbxmanv.SelectedValue = row["Manv"].ToString();
                cbxngaydat.SelectedValue = row["Ngaydatphong"].ToString();
                cbxngaynhan.SelectedValue = row["Ngaynhanphong"].ToString();
                cbxsonguoi.SelectedValue = row["songuoi"].ToString();
                cbxgiaphong.SelectedValue = row["giaphong"].ToString();
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnhome_Click(object sender, EventArgs e)
        {
            FQLKSSML f = new FQLKSSML();
            f.Show();
            this.Close();
        }
        public void clears() {
        
            txtphiphong.Text = "";
            //cbxmakh.Text = "";
            //cbxmapthue.Text = "";
            //cbxngaydat.Text = "";
            //cbxngaynhan.Text = "";
            //txtngaytra.Text = "";
            //cbxmaphong.Text = "";
            //cbxmanv.Text = "";
            //cbxsonguoi.Text = "";
            //txtmahd.Text = "";
            //cbxmahoadonDV.Text = "";
            //cbxgiaphong.Text = "";

            txtmahd.Focus();
        }
        public void hienthi()
        {
            listViewhoadontong.Items.Clear();
            conn.Open();
            sql = @"select * from Hoadon";
            thuchien = new SqlCommand(sql, conn);
            docdulieu = thuchien.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                listViewhoadontong.Items.Add(docdulieu[0].ToString());
                listViewhoadontong.Items[i].SubItems.Add(docdulieu[1].ToString());
                listViewhoadontong.Items[i].SubItems.Add(docdulieu[2].ToString());
                listViewhoadontong.Items[i].SubItems.Add(docdulieu[3].ToString());
                listViewhoadontong.Items[i].SubItems.Add(docdulieu[4].ToString());
                listViewhoadontong.Items[i].SubItems.Add(docdulieu[5].ToString());
                listViewhoadontong.Items[i].SubItems.Add(docdulieu[6].ToString());
                listViewhoadontong.Items[i].SubItems.Add(docdulieu[7].ToString());
                listViewhoadontong.Items[i].SubItems.Add(docdulieu[8].ToString());
                listViewhoadontong.Items[i].SubItems.Add(docdulieu[9].ToString());
                i++;
            }
            conn.Close();
        }
        private void btntraphong_Click(object sender, EventArgs e)
        {
            listViewhoadontong.Items.Clear();
            Ctraphong ob1 = new Ctraphong();
            if (txtmahd.Text == "" || txtngaytra.Text == "" || txtngaytra.Text == "mm/dd/yyyy")
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin !!!");
            }
            else {
                if (ob1.kt_keymath(txtmahd.Text) == true)
                {
                    MessageBox.Show("Trùng mã phiếu thuê");
                }
                else
                {
                    int compare = DateTime.Compare(Convert.ToDateTime(txtngaytra.Text), Convert.ToDateTime(cbxngaynhan.SelectedValue.ToString()));
                    if (compare > 0)
                    {
                        conn.Open();
                        string gphong = ob1.load("select giaphong from TTthuephong where MaThuep='" + cbxmapthue.SelectedValue.ToString() + "'").Rows[0][0].ToString().Trim();
                        string slnguoi = ob1.load("select songuoi from TTthuephong where MaThuep='" + cbxmapthue.SelectedValue.ToString() + "'").Rows[0][0].ToString().Trim();
                        int solnguoi = Int32.Parse(slnguoi);
                        int giaphong = Int32.Parse(gphong);
                         
                        TimeSpan khoangngay = Convert.ToDateTime(txtngaytra.Text).Subtract(Convert.ToDateTime(cbxngaynhan.SelectedValue.ToString()));
                        int songayo = khoangngay.Days;
                        
                        int phip = giaphong * solnguoi * songayo;
                        txtphiphong.Text = phip.ToString();
                        //txtthanhtien.Text = ttien.ToString();
                        lblngayo.Text = "Số ngày ở : " + songayo.ToString() + "Ngày";
                        sql = @"Insert into Hoadon 
                (Mahoadon,MaThuep,Maphong,Makh,Manv,Ngaydatphong,
                Ngaynhanphong,Ngaytraphong,soluongnguoi,phiphong)
                VALUES (N'" + txtmahd.Text + @"',N'" + cbxmapthue.SelectedValue.ToString() + @"',N'" + cbxmaphong.SelectedValue.ToString() + @"',N'" + cbxmakh.SelectedValue.ToString() + @"',N'" + cbxmanv.SelectedValue.ToString() + @"',N'" + Convert.ToDateTime(cbxngaydat.SelectedValue.ToString()) + @"',N'" + Convert.ToDateTime(cbxngaynhan.SelectedValue.ToString()) + @"',N'" + Convert.ToDateTime(txtngaytra.Text) + @"',N'" + Int32.Parse(cbxsonguoi.SelectedValue.ToString()) + @"',N'" + Int32.Parse(txtphiphong.Text) + @"')";
                        thuchien = new SqlCommand(sql, conn);
                        thuchien.ExecuteNonQuery();
                        string sql1, sql2;
                        sql1 = "update Phong set tthaiphong=N'Trống' where MaPhong='" + cbxmaphong.SelectedValue.ToString() + "'";
                        sql2 = "delete from TTthuephong where MaThuep='" + cbxmapthue.SelectedValue.ToString() + "'";
                        ob1.excute(sql1);
                        ob1.excute(sql2);
                        conn.Close();
                        hienthi();
                        // FQLtraphong_Load(sender, e);
                    }
                    else if (compare == 0)
                    {
                        conn.Open();
                        string gphong = ob1.load("select giaphong from TTthuephong where MaThuep='" + cbxmapthue.SelectedValue.ToString() + "'").Rows[0][0].ToString().Trim();
                        string slnguoi = ob1.load("select songuoi from TTthuephong where MaThuep='" + cbxmapthue.SelectedValue.ToString() + "'").Rows[0][0].ToString().Trim();
                        int solnguoi = Int32.Parse(slnguoi);
                        int giaphong = Int32.Parse(gphong);
                        TimeSpan khoangngay = Convert.ToDateTime(txtngaytra.Text).Subtract(Convert.ToDateTime(cbxngaynhan.SelectedValue.ToString()));
                        int songayo = khoangngay.Days;
                        int phip = giaphong * solnguoi * 1;
                        txtphiphong.Text = phip.ToString();
                        lblngayo.Text = "Số ngày ở : 1 Ngày";
                        sql = @"Insert into Hoadon 
                (Mahoadon,MaThuep,Maphong,Makh,Manv,Ngaydatphong,
                Ngaynhanphong,Ngaytraphong,soluongnguoi,phiphong)
                VALUES (N'" + txtmahd.Text + @"',N'" + cbxmapthue.SelectedValue.ToString() + @"',N'" + cbxmaphong.SelectedValue.ToString() + @"',N'" + cbxmakh.SelectedValue.ToString() + @"',N'" + cbxmanv.SelectedValue.ToString() + @"',N'" + Convert.ToDateTime(cbxngaydat.SelectedValue.ToString()) + @"',N'" + Convert.ToDateTime(cbxngaynhan.SelectedValue.ToString()) + @"',N'" + Convert.ToDateTime(txtngaytra.Text) + @"',N'" + Int32.Parse(cbxsonguoi.SelectedValue.ToString()) + @"',N'" + Int32.Parse(txtphiphong.Text) + @"')";
                        thuchien = new SqlCommand(sql, conn);
                        thuchien.ExecuteNonQuery();
                        string sql1, sql2;
                        sql1 = "update Phong set tthaiphong=N'Trống' where MaPhong='" + cbxmaphong.SelectedValue.ToString() + "'";
                        sql2 = "delete from TTthuephong where MaThuep='" + cbxmapthue.SelectedValue.ToString() + "'";
                        ob1.excute(sql1);
                        ob1.excute(sql2);
                        conn.Close();
                        hienthi();
                    }

                    else
                    {
                        MessageBox.Show("Ngày trả phòng không hợp lệ!!");
                        txtngaytra.Focus();
                    }

                }
            
            }
       
          
        }

        private void btnnhaplai_Click(object sender, EventArgs e)
        {
            clears();
        }

        private void cbxmahoadonDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Ctraphong ob1 = new Ctraphong();
            //DataTable dt = new DataTable();
            //dt = ob1.load("select  from HDDichVu where MahoadonDV='" + cbxmahoadonDV.SelectedValue.ToString() + "'");
            //foreach (DataRow row in dt.Rows)
            //{
            //    textphidv.Text = row["phidv"].ToString();
            //}
        }

        private void listViewhoadontong_Click(object sender, EventArgs e)
        {
            // --Mahoadon,MaThuep,Maphong,MahoadonDV,Makh,Manv,Ngaydatphong,
            //Ngaynhanphong,Ngaytraphong,soluongnguoi,phiphong,phidv,thanhtien
            txtmahd.Text = listViewhoadontong.SelectedItems[0].SubItems[0].Text;
            cbxmapthue.Text = listViewhoadontong.SelectedItems[0].SubItems[1].Text;
            cbxmaphong.Text = listViewhoadontong.SelectedItems[0].SubItems[2].Text;
            cbxmakh.SelectedValue = listViewhoadontong.SelectedItems[0].SubItems[3].Text;
            cbxmanv.SelectedValue = listViewhoadontong.SelectedItems[0].SubItems[4].Text;
            cbxngaydat.Text = listViewhoadontong.SelectedItems[0].SubItems[5].Text;
            cbxngaynhan.Text = listViewhoadontong.SelectedItems[0].SubItems[6].Text;
            txtngaytra.Text = listViewhoadontong.SelectedItems[0].SubItems[7].Text;
            cbxsonguoi.Text = listViewhoadontong.SelectedItems[0].SubItems[8].Text;
            txtphiphong.Text = listViewhoadontong.SelectedItems[0].SubItems[9].Text;
            
     
        }

        private void txtsearchHD_TextChanged(object sender, EventArgs e)
        {
            string tukhoa = txtsearchHD.Text;
            string tusosa = cbxluachonHD.Text;
            Ctraphong ob = new Ctraphong();
            
            if (tusosa == "Mã hóa đơn")
            {
                ob.hienthi_listview(listViewhoadontong, "Select * from Hoadon where Mahoadon like N'%" + tukhoa + "%'");
            }

            else if (String.Compare(tusosa, "Mã phiếu thuê", true) == 0)
            {
                ob.hienthi_listview(listViewhoadontong, "Select * from Hoadon where MaThuep like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(tusosa, "Mã phòng", true) == 0)
            {
                ob.hienthi_listview(listViewhoadontong, "Select * from Hoadon where Maphong like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(tusosa, "Mã khách hàng", true) == 0)
            {
                ob.hienthi_listview(listViewhoadontong, "Select * from Hoadon where Makh like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(tusosa, "Mã nhân viên", true) == 0)
            {
                ob.hienthi_listview(listViewhoadontong, "Select * from Hoadon where Manv like N'%" + tukhoa + "%'");
            }
            // --Mahoadon,MaThuep,Maphong,MahoadonDV,Makh,Manv,Ngaydatphong,Ngaynhanphong,
            //Ngaytraphong,soluongnguoi,phiphong,phidv,thanhtien
            else if (String.Compare(tusosa, "Ngày đặt phòng", true) == 0)
            {
                ob.hienthi_listview(listViewhoadontong, "Select * from Hoadon where Ngaydatphong like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(tusosa, "Ngày nhận phòng", true) == 0)
            {
                ob.hienthi_listview(listViewhoadontong, "Select * from Hoadon where Ngaynhanphong like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(tusosa, "Ngày trả phòng", true) == 0)
            {
                ob.hienthi_listview(listViewhoadontong, "Select * from Hoadon where Ngaytraphong like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(tusosa, "Số lượng người", true) == 0)
            {
                ob.hienthi_listview(listViewhoadontong, "Select * from Hoadon where soluongnguoi like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(tusosa, "Phí phòng", true) == 0)
            {
                ob.hienthi_listview(listViewhoadontong, "Select * from Hoadon where phiphong like N'%" + tukhoa + "%'");
            }
            
            
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            listViewhoadontong.Items.Clear();
            int compare = DateTime.Compare(Convert.ToDateTime(txtngaytra.Text), Convert.ToDateTime(cbxngaynhan.SelectedValue.ToString()));
            if (compare >= 0)
            {
                conn.Open();
                string gphong = ob1.load("select giaphong from TTthuephong where MaThuep='" + cbxmapthue.SelectedValue.ToString() + "'").Rows[0][0].ToString().Trim();
                string slnguoi = ob1.load("select songuoi from TTthuephong where MaThuep='" + cbxmapthue.SelectedValue.ToString() + "'").Rows[0][0].ToString().Trim();
                string phidv = ob1.load("select sum(phidv) from HDDichVu where Makh = '" + cbxmakh.SelectedValue.ToString() + "'").Rows[0][0].ToString().Trim();
                int solnguoi = Int32.Parse(slnguoi);
                int giaphong = Int32.Parse(gphong);
                TimeSpan khoangngay = Convert.ToDateTime(txtngaytra.Text).Subtract(Convert.ToDateTime(cbxngaynhan.SelectedValue.ToString()));
                int songayo = khoangngay.Days;
                int phip = giaphong * solnguoi * songayo;
                int pdv = Int32.Parse(phidv);
                int ttien = phip + pdv;
                txtphiphong.Text = phip.ToString();
                string sql = "update Hoadon set MaThueP =N'" + cbxmapthue.SelectedValue.ToString() + @"',MaPhong =N'" + cbxmaphong.SelectedValue.ToString() + @"',Makh=N'" + cbxmakh.SelectedValue.ToString() + @"',Manv=N'" + cbxmanv.SelectedValue.ToString() + @"',Ngaydatphong=N'" + Convert.ToDateTime(cbxngaydat.SelectedValue.ToString()) + @"',Ngaynhanphong=N'" + Convert.ToDateTime(cbxngaynhan.SelectedValue.ToString()) + @"',Ngaytraphong=N'" + Convert.ToDateTime(txtngaytra.Text) + @"',soluongnguoi=N'" + Int32.Parse(cbxsonguoi.SelectedValue.ToString()) + @"',phiphong=N'" + Int32.Parse(txtphiphong.Text) + @"' where Mahoadon =N'" + txtmahd.Text + @"'";
                thuchien = new SqlCommand(sql, conn);
                thuchien.ExecuteNonQuery();
                conn.Close();
                hienthi();
                // 
                //FQLtraphong_Load(sender, e);
            }
            else {
                MessageBox.Show("Ngày trả phòng không hợp lệ!!");
                txtngaytra.Focus();
            }

        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            listViewhoadontong.Items.Clear();
            conn.Open();
            string sql = "delete from Hoadon where Mahoadon=N'" + txtmahd.Text + @"'";
            thuchien = new SqlCommand(sql, conn);
            thuchien.ExecuteNonQuery();
            conn.Close();
            hienthi();
            //FQLtraphong_Load(sender, e);
        }

        private void txtsearchhdDV_TextChanged(object sender, EventArgs e)
        {
            string tukhoa = txtsearchhdDV.Text;
            string tusosa = cbxluachonhdDv.Text;
            CHDservice ob = new CHDservice();
            //MahdDV,Makh,MaPhong,TenDV,giaDV,ngaybatdaudv,ngaykethucdv,phidv
            if (tusosa == "Mã hóa đơn dịch vụ")
            {
                ob.hienthi_listview(listViewhdDV, "Select * from HDDichVu where MahoadonDV like N'%" + tukhoa + "%'");
            }

            else if (String.Compare(tusosa, "Mã khách hàng", true) == 0)
            {
                ob.hienthi_listview(listViewhdDV, "Select * from HDDichVu where Makh like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(tusosa, "Mã phòng", true) == 0)
            {
                ob.hienthi_listview(listViewhdDV, "Select * from HDDichVu where MaPhong like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(tusosa, "Tên dịch vụ", true) == 0)
            {
                ob.hienthi_listview(listViewhdDV, "Select * from HDDichVu where TenDV like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(tusosa, "Giá dịch vụ", true) == 0)
            {
                ob.hienthi_listview(listViewhdDV, "Select * from HDDichVu where giaDV like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(tusosa, "Ngày bắt đầu dịch vụ", true) == 0)
            {
                ob.hienthi_listview(listViewhdDV, "Select * from HDDichVu where ngaybatdaudv like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(tusosa, "Ngày kết thúc dịch vụ", true) == 0)
            {
                ob.hienthi_listview(listViewhdDV, "Select * from HDDichVu where ngaykethucdv like N'%" + tukhoa + "%'");
            }
            else
            {
                ob.hienthi_listview(listViewhdDV, "Select * from HDDichVu where phidv like N'%" + tukhoa + "%'");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FinHD f = new FinHD();
            f.Show();
        }

    }
}
