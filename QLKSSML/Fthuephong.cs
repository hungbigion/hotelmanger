using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace QLKSSML
{
    public partial class Fthuephong : Form
    {
        public Fthuephong()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Fthuephong_Load(object sender, EventArgs e)
        {
            ClassQLP ob = new ClassQLP();
            ob.hienthi_listview(listViewphong, "select * from Phong");
            Clthuephong ob1 = new Clthuephong();
            ob1.hienthi_listview(listviewThueP, "select * from TTthuephong");

            cbxmaphong.DataSource = ob1.load("select * from Phong");
            cbxmaphong.DisplayMember = "MaPhong";
            cbxmaphong.ValueMember = "MaPhong";

            cbxmakh.DataSource = ob1.load("select * from Khachhang");
            cbxmakh.DisplayMember = "Tenkh";
            cbxmakh.ValueMember = "Makh";

            cbxmanv.DataSource = ob1.load("select * from Nhanvien");
            cbxmanv.DisplayMember = "Tennv";
            cbxmanv.ValueMember = "Manv";

            cbxtenphong.DataSource= ob1.load("select * from Phong");
            cbxtenphong.DisplayMember = "TenPhong";
            cbxtenphong.ValueMember = "TenPhong";

            cbxloaiphong.DataSource = ob1.load("select * from LPhong");
            cbxloaiphong.DisplayMember = "loaiphong";
            cbxloaiphong.ValueMember = "loaiphong";

            cbxgiaphong.DataSource = ob1.load("select * from LPhong");
            cbxgiaphong.DisplayMember = "giaphong";
            cbxgiaphong.ValueMember = "giaphong";
            
            

        }

        private void cbxmaphong_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clthuephong ob1 = new Clthuephong();
            DataTable dt = new DataTable();
            dt = ob1.load("select TenPhong,loaiphong from Phong where MaPhong='" + cbxmaphong.SelectedValue.ToString() + "'");
            foreach (DataRow row in dt.Rows)
            {
                cbxtenphong.SelectedValue = row["TenPhong"].ToString();
                cbxloaiphong.SelectedValue = row["loaiphong"].ToString();
            }
        }

        private void cbxloaiphong_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clthuephong ob1 = new Clthuephong();
            DataTable dt = new DataTable();
            dt = ob1.load("select giaphong from LPhong where loaiphong='" + cbxloaiphong.SelectedValue.ToString() + "'");
            foreach (DataRow row in dt.Rows)
            {
               cbxgiaphong.SelectedValue = row["giaphong"].ToString();
                
            }
        }

        private void btnthue_Click(object sender, EventArgs e)
        {
            Clthuephong ob = new Clthuephong();
            string sql = "select songtoida from Phong where MaPhong='" + cbxmaphong.SelectedValue.ToString() + "'";
            DataTable dt = new DataTable();
            dt = ob.load(sql);
            string soluong1 = "";
            foreach (DataRow row in dt.Rows)
            {
                soluong1 = row["songtoida"].ToString();

            }
            if (Int32.Parse(txtsonguoi.Text) > Int32.Parse(soluong1))
            {
                MessageBox.Show("Vượt quá số lượng người vui lòng kiểm tra lại");
                txtsonguoi.Text = "";
                txtsonguoi.Enabled = true;
            }
            else
            {
                //MaThuep,
                //MaPhong,
                //Makh,Manv,
                //TenPhong,loaiphong,
                //Ngaydatphong,Ngaynhanphong,
                //giaphong,songuoi,trangthai
                Clthuephong ob1 = new Clthuephong(txtmapthue.Text, cbxmaphong.SelectedValue.ToString(), cbxmakh.SelectedValue.ToString(), cbxmanv.SelectedValue.ToString(), cbxtenphong.SelectedValue.ToString(), cbxloaiphong.SelectedValue.ToString(), Convert.ToDateTime(txtngaydat.Text), Convert.ToDateTime(txtngaynhan.Text), Int32.Parse(cbxgiaphong.SelectedValue.ToString()), Int32.Parse(txtsonguoi.Text), cbxtrangthai.Text);
                if (ob1.kt_keymath(txtmapthue.Text) == true)
                {
                    MessageBox.Show("Trùng mã phiếu thuê");
                }
                else if (ob1.kt_keymaph(cbxmaphong.Text) == true)
                {
                    MessageBox.Show("Phòng đã được thuê. Vui lòng thuê phòng khác");
                }
                else
                {
                   
                    int compare = DateTime.Compare(Convert.ToDateTime(txtngaynhan.Text), Convert.ToDateTime(txtngaydat.Text));
                    if (compare >= 0)
                    {
                        ob1.insert(ob1);
                        string sql1;
                        sql1 = "update Phong set tthaiphong=N'" + cbxtrangthai.Text + "'where MaPhong='" + cbxmaphong.SelectedValue.ToString() + "'";
                        ob1.excute(sql1);
                        //form load
                        Fthuephong_Load(sender, e);
                    }
                  
                    else
                    {
                        MessageBox.Show("Ngày Đặt và ngày nhận không hợp lệ");
                        txtngaydat.Focus();
                    }
                    
                }
                
               
            }
        }

        private void listviewThueP_Click(object sender, EventArgs e)
        {
            txtmapthue.Text = listviewThueP.SelectedItems[0].SubItems[0].Text;
            cbxmaphong.Text = listviewThueP.SelectedItems[0].SubItems[1].Text;
            cbxmakh.SelectedValue = listviewThueP.SelectedItems[0].SubItems[2].Text;
            cbxmanv.SelectedValue = listviewThueP.SelectedItems[0].SubItems[3].Text;
            cbxtenphong.Text = listviewThueP.SelectedItems[0].SubItems[4].Text;
            cbxloaiphong.Text = listviewThueP.SelectedItems[0].SubItems[5].Text;
            txtngaydat.Text = listviewThueP.SelectedItems[0].SubItems[6].Text;
            txtngaynhan.Text = listviewThueP.SelectedItems[0].SubItems[7].Text;
            cbxgiaphong.Text = listviewThueP.SelectedItems[0].SubItems[8].Text;
            txtsonguoi.Text = listviewThueP.SelectedItems[0].SubItems[9].Text;
            cbxtrangthai.Text = listviewThueP.SelectedItems[0].SubItems[10].Text;
            TimeSpan khoangngay = Convert.ToDateTime(txtngaynhan.Text).Subtract(Convert.ToDateTime(txtngaydat.Text));
           int a = khoangngay.Days;
                lbldate.Text = "Số ngày chờ nhận phòng :" + a.ToString() + "  Ngày";
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {

            Clthuephong ob1 = new Clthuephong(txtmapthue.Text, cbxmaphong.SelectedValue.ToString(), cbxmakh.SelectedValue.ToString(), cbxmanv.SelectedValue.ToString(), cbxtenphong.SelectedValue.ToString(), cbxloaiphong.SelectedValue.ToString(), Convert.ToDateTime(txtngaydat.Text), Convert.ToDateTime(txtngaynhan.Text), Int32.Parse(cbxgiaphong.SelectedValue.ToString()), Int32.Parse(txtsonguoi.Text), cbxtrangthai.Text);
            ob1.delete(ob1);
            string sql1;
           // float sl = float.Parse(txtsoluong.Text) + soluong1;
            sql1 = "update Phong set tthaiphong= N'Trống' where MaPhong='" + cbxmaphong.SelectedValue.ToString() + "'"; ob1.excute(sql1);
            Fthuephong_Load(sender, e);
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            Clthuephong ob = new Clthuephong();
            string sql = "select songtoida from Phong where MaPhong='" + cbxmaphong.SelectedValue.ToString() + "'";
            DataTable dt = new DataTable();
            dt = ob.load(sql);
            string soluong1 = "";
            foreach (DataRow row in dt.Rows)
            {
                soluong1 = row["songtoida"].ToString();

            }
            if (Int32.Parse(txtsonguoi.Text) > Int32.Parse(soluong1))
            {
                MessageBox.Show("Vượt quá số lượng người vui lòng kiểm tra lại");
                txtsonguoi.Text = "";
                txtsonguoi.Enabled = true;
            }
            else
            {
                //MaThuep,
                //MaPhong,
                //Makh,Manv,
                //TenPhong,loaiphong,
                //Ngaydatphong,Ngaynhanphong,
                //giaphong,songuoi,trangthai
                int compare = DateTime.Compare(Convert.ToDateTime(txtngaynhan.Text), Convert.ToDateTime(txtngaydat.Text));
                if (compare >= 0)
                {
                    Clthuephong ob1 = new Clthuephong(txtmapthue.Text, cbxmaphong.SelectedValue.ToString(), cbxmakh.SelectedValue.ToString(), cbxmanv.SelectedValue.ToString(), cbxtenphong.SelectedValue.ToString(), cbxloaiphong.SelectedValue.ToString(), Convert.ToDateTime(txtngaydat.Text), Convert.ToDateTime(txtngaynhan.Text), Int32.Parse(cbxgiaphong.SelectedValue.ToString()), Int32.Parse(txtsonguoi.Text), cbxtrangthai.Text);
                    ob1.update(ob1);
                    string sql1;
                    sql1 = "update Phong set tthaiphong=N'" + cbxtrangthai.Text + "'where MaPhong='" + cbxmaphong.SelectedValue.ToString() + "'";
                    ob1.excute(sql1);
                    //form load
                    Fthuephong_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Ngày Đặt và ngày nhận không hợp lệ");
                    txtngaydat.Focus();
                }

            }
        }
        public void Clear()
        {
            txtmapthue.Enabled = true;
            txtmapthue.Text = "";
            txtsonguoi.Text = "";

            btnthue.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;

            txtmapthue.Focus();
            // txt_ma.Enabled = true;
            // txt_ma.Text = "";

            // txt_song.Text = "";
            // txt_ten.Text = "";
            // txt_search.Text = "";
            // rtb_mota.Text = "";
            // btn_xoa.Enabled = false;
            //  btn_sua.Enabled = false;
            //  btn_them.Enabled = true;

            // txt_ma.Focus();

        }
        private void btnnhaplai_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtsearch_thuep_TextChanged(object sender, EventArgs e)
        {
            // Mã thuê phòng, Mã phòng,Mã khách hàng,Mã nhân viên,Tên phòng,Loại phòng,Ngày đặt phòng,Ngày nhận phòng,
            //MaThuep,
            //MaPhong,
            //Makh,Manv,
            //TenPhong,loaiphong,
            //Ngaydatphong,Ngaynhanphong,
            //giaphong,songuoi,trangthai   Giá phòng, Số người , Trạng thái  
            string tukhoa = txtsearch_thuep.Text;
            Clthuephong ob = new Clthuephong();
            if (cbxluachon_thuep.Text == "Mã thuê phòng")
            {
                ob.hienthi_listview(listviewThueP, "Select * from TTthuephong where MaThuep like N'%" +tukhoa+ "%'");
            }
            else if (String.Compare(cbxluachon_thuep.Text, "Mã phòng", true) == 0)
            {
                ob.hienthi_listview(listviewThueP, "Select * from TTthuephong where MaPhong like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(cbxluachon_thuep.Text, "Mã khách hàng", true) == 0)
            {
                ob.hienthi_listview(listviewThueP, "Select * from TTthuephong where Makh like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(cbxluachon_thuep.Text, "Mã nhân viên", true) == 0)
            {
                ob.hienthi_listview(listviewThueP, "Select * from TTthuephong where Manv like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(cbxluachon_thuep.Text, "Tên phòng", true) == 0)
            {
                ob.hienthi_listview(listviewThueP, "Select * from TTthuephong where TenPhong like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(cbxluachon_thuep.Text, "Loại phòng", true) == 0)
            {
                ob.hienthi_listview(listviewThueP, "Select * from TTthuephong where loaiphong like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(cbxluachon_thuep.Text, "Ngày đặt phòng", true) == 0)
            {
                ob.hienthi_listview(listviewThueP, "Select * from TTthuephong where Ngaydatphong like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(cbxluachon_thuep.Text, "Ngày nhận phòng", true) == 0)
            {
                ob.hienthi_listview(listviewThueP, "Select * from TTthuephong where Ngaynhanphong like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(cbxluachon_thuep.Text, "Giá phòng", true) == 0)
            {
                ob.hienthi_listview(listviewThueP, "Select * from TTthuephong where giaphong like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(cbxluachon_thuep.Text, "Số người", true) == 0)
            {
                ob.hienthi_listview(listviewThueP, "Select * from TTthuephong where songuoi like N'%" + tukhoa + "%'");
            }
            else
            {
                ob.hienthi_listview(listviewThueP, "Select * from TTthuephong where trangthai like N'%" + tukhoa + "%'");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FQLKSSML f = new FQLKSSML();
            f.Show();
            this.Close();
        }

        private void txtsearch_phong_TextChanged(object sender, EventArgs e)
        {
            string tukhoa = txtsearch_phong.Text;
            ClassQLP ob = new ClassQLP();
            if (cbxluachon_phong.Text == "Mã phòng")
            {
                ob.hienthi_listview(listViewphong, "Select * from Phong where MaPhong like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(cbxluachon_phong.Text, "Tên phòng", true) == 0)
            {
                ob.hienthi_listview(listViewphong, "Select * from Phong where TenPhong like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(cbxluachon_phong.Text, "Loại phòng", true) == 0)
            {
                ob.hienthi_listview(listViewphong, "Select * from Phong where loaiphong like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(cbxluachon_phong.Text, "Mô tả phòng", true) == 0)
            {
                ob.hienthi_listview(listViewphong, "Select * from Phong where Mota like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(cbxluachon_phong.Text, "Số người tối đa", true) == 0)
            {
                ob.hienthi_listview(listViewphong, "Select * from Phong where songtoida like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(cbxluachon_phong.Text, "Giá phòng", true) == 0)
            {
                ob.hienthi_listview(listViewphong, "Select * from Phong where giaphong like N'%" + tukhoa + "%'");
            }
            else
            {
                ob.hienthi_listview(listViewphong, "Select * from Phong where tthaiphong like N'%" + tukhoa + "%'");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FQLKH f = new FQLKH();
            f.Show();
        }


    }
}
