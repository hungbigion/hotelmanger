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
    public partial class FQHDV : Form
    {
        public FQHDV()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=UFYNDEVZ5K1UKA9\SQLEXPRESS;Initial Catalog=QLKS_SML;Integrated Security=True");
        string sql;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        Ctraphong ob1 = new Ctraphong();
        int i;
        private void FQHDV_Load(object sender, EventArgs e)
        {
            CHDservice ob = new CHDservice();
            ob.hienthi_listviewmain(listViewhddv, "select * from HDDichVu");
            CDV obdv = new CDV();
            obdv.hienthi_listview(listViewdv, "select * from DichVu");

            cbxmadv.DataSource = ob.load("select * from DichVu");
            cbxmadv.DisplayMember = "MaDV";
            cbxmadv.ValueMember = "MaDV";

            cbxtendv.DataSource = ob.load("select * from DichVu");
            cbxtendv.DisplayMember = "TenDV";
            cbxtendv.ValueMember = "TenDV";

            cbxgiadv.DataSource = ob.load("select * from DichVu");
            cbxgiadv.DisplayMember = "giaDV";
            cbxgiadv.ValueMember = "giaDV";

            cbxmakh.DataSource = ob.load("select * from TTthuephong inner join Khachhang on TTthuephong.Makh = Khachhang.Makh ");
            cbxmakh.DisplayMember = "Tenkh";
            cbxmakh.ValueMember = "Makh";

            cbxmap.DataSource = ob.load("select * from TTthuephong");
            cbxmap.DisplayMember = "MaPhong";
            cbxmap.ValueMember = "MaPhong";

            cbxmanv.DataSource = ob.load("select * from TTthuephong inner join Nhanvien on TTthuephong.Manv = Nhanvien.Manv ");
            cbxmanv.DisplayMember = "Tennv";
            cbxmanv.ValueMember = "Manv";
        }

        private void cbxmadv_SelectedIndexChanged(object sender, EventArgs e)
        {
            CHDservice ob1 = new CHDservice();
            DataTable dt = new DataTable();
            dt = ob1.load("select TenDV,giaDV from DichVu where MaDV='" + cbxmadv.SelectedValue.ToString() + "'");
            foreach (DataRow row in dt.Rows)
            {
                cbxtendv.SelectedValue = row["TenDV"].ToString();
                cbxgiadv.Text = row["giaDV"].ToString();
            }
        }

        private void cbxmap_SelectedIndexChanged(object sender, EventArgs e)
        {
            CHDservice ob1 = new CHDservice();
            DataTable dt = new DataTable();
            dt = ob1.load("select Manv,Makh from TTthuephong where MaPhong='" + cbxmap.SelectedValue.ToString() + "'");
            foreach (DataRow row in dt.Rows)
            {
                cbxmanv.SelectedValue = row["Manv"].ToString();
                cbxmakh.SelectedValue = row["Makh"].ToString();
            }
        }
        public void hienthi()
        {
            listViewhddv.Items.Clear();
            conn.Open();
            sql = @"select * from HDDichVu";
            thuchien = new SqlCommand(sql, conn);
            docdulieu = thuchien.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                // listView1.Items.Add((i + 1).ToString());
                //listView1.Items.Add(docdulieu[0].ToString());
                // listView1.Items[i].SubItems.Add(docdulieu[1].ToString());
                //listView1.Items[i].SubItems.Add(docdulieu[2].ToString());
                listViewhddv.Items.Add(docdulieu[0].ToString());
                listViewhddv.Items[i].SubItems.Add(docdulieu[1].ToString());
                listViewhddv.Items[i].SubItems.Add(docdulieu[2].ToString());
                listViewhddv.Items[i].SubItems.Add(docdulieu[3].ToString());
                listViewhddv.Items[i].SubItems.Add(docdulieu[4].ToString());
                listViewhddv.Items[i].SubItems.Add(docdulieu[5].ToString());
                listViewhddv.Items[i].SubItems.Add(docdulieu[6].ToString());
                listViewhddv.Items[i].SubItems.Add(docdulieu[7].ToString());
                listViewhddv.Items[i].SubItems.Add(docdulieu[8].ToString());
                listViewhddv.Items[i].SubItems.Add(docdulieu[9].ToString());
                i++;
            }
            conn.Close();
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            listViewhddv.Items.Clear();
            CHDservice ob1 = new CHDservice();
            if (txthoadondv.Text == "" || txtngaybatdau.Text == "" || txtngayketthuc.Text == "")
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin !!!");
            }
            else {
                if (ob1.kt_keymath(txthoadondv.Text) == true)
                {
                    MessageBox.Show("Trùng mã hóa đơn dịch vụ");
                }
                else
                {
                    int compare = DateTime.Compare(Convert.ToDateTime(txtngayketthuc.Text), Convert.ToDateTime(txtngaybatdau.Text));
                    if (compare > 0)
                    {
                        conn.Open();
                        string gv = ob1.load("select giaDV from DichVu where MaDV='" + cbxmadv.SelectedValue.ToString() + "'").Rows[0][0].ToString().Trim();
                        int gvd = Int32.Parse(gv);
                        TimeSpan khoangngay = Convert.ToDateTime(txtngayketthuc.Text).Subtract(Convert.ToDateTime(txtngaybatdau.Text));
                        int songayo = khoangngay.Days;
                        int phidv = songayo * gvd;
                        lblsoigio.Text = "số ngày sử dụng DV: " + songayo.ToString() + "ngày";
                        txtphidv.Text = phidv.ToString();
                        sql = @"Insert into HDDichVu 
                (MahoadonDV,Makh,MaDV,TenDV,MaPhong,Manv,giaDV,ngaybatdaudv,ngaykethucdv,phidv)
                VALUES (N'" + txthoadondv.Text + @"',N'" + cbxmakh.SelectedValue.ToString() + @"',N'" + cbxmadv.SelectedValue.ToString() + @"',N'" + cbxtendv.SelectedValue.ToString() + @"',N'" + cbxmap.SelectedValue.ToString() + @"',N'" + cbxmanv.SelectedValue.ToString() + @"',N'" + cbxgiadv.SelectedValue.ToString() + @"',N'" + Convert.ToDateTime(txtngaybatdau.Text) + @"',N'" + Convert.ToDateTime(txtngayketthuc.Text) + @"',N'" + Int32.Parse(txtphidv.Text) + @"')";
                        thuchien = new SqlCommand(sql, conn);
                        thuchien.ExecuteNonQuery();
                        conn.Close();
                        hienthi();
                    }
                    else if (compare == 0)
                    {
                        conn.Open();
                        string gv = ob1.load("select giaDV from DichVu where MaDV='" + cbxmadv.SelectedValue.ToString() + "'").Rows[0][0].ToString().Trim();
                        int gvd = Int32.Parse(gv);
                        lblsoigio.Text = "số ngày sử dụng DV: 1 ngày";
                        int phidvh = gvd*1;
                        txtphidv.Text = phidvh.ToString();
                        sql = @"Insert into HDDichVu 
                (MahoadonDV,Makh,MaDV,TenDV,MaPhong,Manv,giaDV,ngaybatdaudv,ngaykethucdv,phidv)
                VALUES (N'" + txthoadondv.Text + @"',N'" + cbxmakh.SelectedValue.ToString() + @"',N'" + cbxmadv.Text + @"',N'" + cbxtendv.Text+ @"',N'" + cbxmap.Text + @"',N'" + cbxmanv.Text+ @"',N'" + cbxgiadv.Text + @"',N'" + Convert.ToDateTime(txtngaybatdau.Text) + @"',N'" + Convert.ToDateTime(txtngayketthuc.Text) + @"',N'" + Int32.Parse(txtphidv.Text) + @"')";
                        thuchien = new SqlCommand(sql, conn);
                        thuchien.ExecuteNonQuery();
                        conn.Close();
                        hienthi();
                    }
                    else
                    {
                        MessageBox.Show("Ngày bắt đầu hoặc ngày kết thúc không hợp lệ!!");
                        txtngaybatdau.Focus();
                    }
                }
            }
           
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnhome_Click(object sender, EventArgs e)
        {
            FQLKSSML f = new FQLKSSML();
            f.Show();
            this.Close();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {

            int compare = DateTime.Compare(Convert.ToDateTime(txtngayketthuc.Text), Convert.ToDateTime(txtngaybatdau.Text));
            listViewhddv.Items.Clear();
            CHDservice ob1 = new CHDservice();
            if (compare > 0)
            {
                conn.Open();
                string gv = ob1.load("select giaDV from DichVu where MaDV='" + cbxmadv.SelectedValue.ToString() + "'").Rows[0][0].ToString().Trim();
                int gvd = Int32.Parse(gv);
                TimeSpan khoangngay = Convert.ToDateTime(txtngayketthuc.Text).Subtract(Convert.ToDateTime(txtngaybatdau.Text));
                int songayo = khoangngay.Days;
                int phidv = songayo * gvd;
                lblsoigio.Text = "số ngày sử dụng DV: " + songayo.ToString() + "ngày";
                txtphidv.Text = phidv.ToString();
                //MahdDV,Makh,MaDV,TenDV,MaPhong,Manv,giaDV,ngaybatdaudv,ngaykethucdv,phidv
                string sql = "update HDDichVu set Makh =N'" + cbxmakh.SelectedValue.ToString() + @"',MaDV =N'" + cbxmadv.SelectedValue.ToString() + @"',TenDV=N'" + cbxtendv.SelectedValue.ToString() + @"',MaPhong=N'" + cbxmap.SelectedValue.ToString() + @"',Manv=N'" + cbxmanv.SelectedValue.ToString() + @"',giaDV=N'" + cbxgiadv.SelectedValue.ToString() + @"',Ngaybatdaudv=N'" + Convert.ToDateTime(txtngaybatdau.Text) + @"',Ngaykethucdv=N'" + Convert.ToDateTime(txtngayketthuc.Text) + @"',phidv=N'" + Int32.Parse(txtphidv.Text) + @"' where MahoadonDV =N'" + txthoadondv.Text + @"'";

                thuchien = new SqlCommand(sql, conn);
                thuchien.ExecuteNonQuery();
                conn.Close();
                hienthi();
            }
            else if (compare == 0)
            {
                conn.Open();
                string gv = ob1.load("select giaDV from DichVu where MaDV='" + cbxmadv.SelectedValue.ToString() + "'").Rows[0][0].ToString().Trim();
                int gvd = Int32.Parse(gv);
                lblsoigio.Text = "số ngày sử dụng DV: 1 ngày";
                int phidvh = gvd;
                txtphidv.Text = phidvh.ToString();
                string sql = "update HDDichVu set Makh =N'" + cbxmakh.SelectedValue.ToString() + @"',MaDV =N'" + cbxmadv.SelectedValue.ToString() + @"',TenDV=N'" + cbxtendv.SelectedValue.ToString() + @"',MaPhong=N'" + cbxmap.SelectedValue.ToString() + @"',Manv=N'" + cbxmanv.SelectedValue.ToString() + @"',giaDV=N'" + cbxgiadv.SelectedValue.ToString() + @"',Ngaybatdaudv=N'" + Convert.ToDateTime(txtngaybatdau.Text) + @"',Ngaykethucdv=N'" + Convert.ToDateTime(txtngayketthuc.Text) + @"',phidv=N'" + Int32.Parse(txtphidv.Text) + @"' where MahoadonDV =N'" + txthoadondv.Text + @"'";
                thuchien = new SqlCommand(sql, conn);
                thuchien.ExecuteNonQuery();
                conn.Close();
                hienthi();
            }
            else
            {
                MessageBox.Show("Ngày bắt đầu hoặc ngày kết thúc không hợp lệ!!");
                txtngaybatdau.Focus();
            }
        }
        public void clears() {
            txthoadondv.Text = "";
            cbxmadv.Text = "";
            cbxmap.Text = "";
            txtngaybatdau.Text = "";
            txtngayketthuc.Text = "";
            txtphidv.Text = "";
            txthoadondv.Focus();
        }
        private void listViewhddv_Click(object sender, EventArgs e)
        {
            //MahdDV,Makh,MaDV,TenDV,MaPhong,Manv,giaDV,ngaybatdaudv,ngaykethucdv,phidv
            txthoadondv.Text = listViewhddv.SelectedItems[0].SubItems[0].Text;
            cbxmakh.Text = listViewhddv.SelectedItems[0].SubItems[1].Text;
            cbxmadv.Text = listViewhddv.SelectedItems[0].SubItems[2].Text;
            cbxtendv.Text = listViewhddv.SelectedItems[0].SubItems[3].Text;
            cbxmap.Text = listViewhddv.SelectedItems[0].SubItems[4].Text;
            cbxmanv.Text = listViewhddv.SelectedItems[0].SubItems[5].Text;
            cbxgiadv.Text = listViewhddv.SelectedItems[0].SubItems[6].Text;
            txtngaybatdau.Text = listViewhddv.SelectedItems[0].SubItems[7].Text;
            txtngayketthuc.Text = listViewhddv.SelectedItems[0].SubItems[8].Text;
            txtphidv.Text = listViewhddv.SelectedItems[0].SubItems[9].Text;
            int compare = DateTime.Compare(Convert.ToDateTime(txtngayketthuc.Text), Convert.ToDateTime(txtngaybatdau.Text));
            TimeSpan khoangngay = Convert.ToDateTime(txtngayketthuc.Text).Subtract(Convert.ToDateTime(txtngaybatdau.Text));
            int songayo = khoangngay.Days;
            if (compare > 0)
            {
                lblsoigio.Text = "số ngày sử dụng DV: " + songayo.ToString() + " ngày";
            }
            else if (compare == 0) { lblsoigio.Text = "số ngày sử dụng DV: 1 ngày"; }
            
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            listViewhddv.Items.Clear();
            conn.Open();
            string sql = "delete from HDDichVu where MahoadonDV=N'" + txthoadondv.Text + @"'";
            thuchien = new SqlCommand(sql, conn);
            thuchien.ExecuteNonQuery();
            conn.Close();
            hienthi();
        }

        private void btnnhaplai_Click(object sender, EventArgs e)
        {
            clears();
        }

        private void txtsearchhddv_TextChanged(object sender, EventArgs e)
        {
          
            
            //Mã dịch vụ
            //Mã nhân viên
            string tukhoa = txtsearchhddv.Text;
            string tusosa = cbxluachonhddv.Text;
            CHDservice ob = new CHDservice();
            //MahdDV,Makh,MaPhong,TenDV,giaDV,ngaybatdaudv,ngaykethucdv,phidv
            if (tusosa == "Mã hóa đơn dịch vụ")
            {
                ob.hienthi_listviewmain(listViewhddv, "Select * from HDDichVu where MahoadonDV like N'%" + tukhoa + "%'");
            }

            else if (String.Compare(tusosa, "Mã khách hàng", true) == 0)
            {
                ob.hienthi_listviewmain(listViewhddv, "Select * from HDDichVu where Makh like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(tusosa, "Mã phòng", true) == 0)
            {
                ob.hienthi_listviewmain(listViewhddv, "Select * from HDDichVu where MaPhong like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(tusosa, "Tên dịch vụ", true) == 0)
            {
                ob.hienthi_listviewmain(listViewhddv, "Select * from HDDichVu where TenDV like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(tusosa, "Giá dịch vụ", true) == 0)
            {
                ob.hienthi_listviewmain(listViewhddv, "Select * from HDDichVu where giaDV like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(tusosa, "Ngày bắt đầu dịch vụ", true) == 0)
            {
                ob.hienthi_listviewmain(listViewhddv, "Select * from HDDichVu where ngaybatdaudv like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(tusosa, "Ngày kết thúc dịch vụ", true) == 0)
            {
                ob.hienthi_listviewmain(listViewhddv, "Select * from HDDichVu where ngaykethucdv like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(tusosa, "Mã dịch vụ", true) == 0)
            {
                ob.hienthi_listviewmain(listViewhddv, "Select * from HDDichVu where MaDV like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(tusosa, "Mã nhân viên", true) == 0)
            {
                ob.hienthi_listviewmain(listViewhddv, "Select * from HDDichVu where Manv like N'%" + tukhoa + "%'");
            }
            else
            {
                ob.hienthi_listviewmain(listViewhddv, "Select * from HDDichVu where phidv like N'%" + tukhoa + "%'");
            }
        }

        private void txtsearchdv_TextChanged(object sender, EventArgs e)
        {
            //Mã dịch vụ
            //Tên dịch vụ
            //Giá dịch vu
            string tukhoa = txtsearchdv.Text;
            CDV ob = new CDV();
            if (cbxluachondv.Text == "Mã dịch vụ")
            {
                ob.hienthi_listview(listViewdv, "Select * from DichVu where MaDV like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(cbxluachondv.Text, "Tên dịch vụ", true) == 0)
            {
                ob.hienthi_listview(listViewdv, "Select * from DichVu where TenDV like N'%" + tukhoa + "%'");
            }
            else
            {
                ob.hienthi_listview(listViewdv, "Select * from DichVu where giaDV like N'%" + tukhoa + "%'");

            }
        }
    }
}
