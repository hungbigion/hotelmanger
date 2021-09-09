using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms.PropertyGridInternal;
using System.Windows.Forms;
using System.ComponentModel.Design;

namespace QLKSSML
{
    public partial class FQLROOM : Form
    {
        public FQLROOM()
        {
            InitializeComponent();

        }
        //string chuoiketnoi = @"Data Source=UFYNDEVZ5K1UKA9\SQLEXPRESS;Initial Catalog=QLKS_SML;Integrated Security=True";
          DataTable dt = new DataTable();
       ClassQLP ob = new ClassQLP();
        SqlConnection conn = new SqlConnection(@"Data Source=UFYNDEVZ5K1UKA9\SQLEXPRESS;Initial Catalog=QLKS_SML;Integrated Security=True");
        public static SqlCommand com;
        private void FQLROOM_Load(object sender, EventArgs e)
        {
            conn.Open();
            ClassQLP ob = new ClassQLP();
            ob.hienthi_listview(listView1, "select * from Phong");
            cb_luachon.Text = "Mã phòng";
            cbxloaiphong.DataSource = ob.LoadTable("select * from Phong");
            cbxloaiphong.DisplayMember = "loaiphong";
            cbxloaiphong.ValueMember = "loaiphong";
            cbxtrangthai.DataSource = ob.LoadTable("select * from Phong");
            cbxtrangthai.DisplayMember = "tthaiphong";
            cbxtrangthai.ValueMember = "tthaiphong";
            conn.Close();
        }



    public void Clear()
        {
            txtmaphong.Enabled = true;
            txtmaphong.Text = "";
            txttenphong.Text = "";
            txtmotap.Text = "";
            txtsongtoida.Text = "";

            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;

            txtmaphong.Focus();
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }



        private void btnthem_Click(object sender, EventArgs e)
        {
            ClassQLP ob = new ClassQLP(txtmaphong.Text, txttenphong.Text, cbxloaiphong.SelectedValue.ToString(), txtmotap.Text, int.Parse(txtsongtoida.Text), cbxtrangthai.Text);

            if (txtmaphong.Text == "" || txttenphong.Text == "" || txtmotap.Text == "" || txtsongtoida.Text == "")
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin !!!");
            }
            else {
                if (ob.kt_key(txtmaphong.Text) == true)
                {
                    MessageBox.Show("trung khoa chinh");
                }
                else
                {
                    ob.insert(ob);
                    FQLROOM_Load(sender, e);
                }
            }
           
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            ClassQLP ob = new ClassQLP(txtmaphong.Text, txttenphong.Text, cbxloaiphong.SelectedValue.ToString(), txtmotap.Text, int.Parse(txtsongtoida.Text), cbxtrangthai.SelectedValue.ToString());
            ob.update(ob);
            FQLROOM_Load(sender, e);
        }
  private void btnxoa_Click(object sender, EventArgs e)
        {
            ClassQLP ob = new ClassQLP(txtmaphong.Text, txttenphong.Text, cbxloaiphong.SelectedValue.ToString(), txtmotap.Text, int.Parse(txtsongtoida.Text), cbxtrangthai.SelectedValue.ToString());
            ob.delete(ob);
            FQLROOM_Load(sender, e);
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnnhaplai_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnhome_Click(object sender, EventArgs e)
        {
            FQLKSSML f = new FQLKSSML();
            f.Show();
            this.Close();
        }

        private void data_gridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void listView1_Click_1(object sender, EventArgs e)
        {
            txtmaphong.Text = listView1.SelectedItems[0].SubItems[0].Text;
            txttenphong.Text = listView1.SelectedItems[0].SubItems[1].Text;
            cbxloaiphong.Text = listView1.SelectedItems[0].SubItems[2].Text;
            txtmotap.Text = listView1.SelectedItems[0].SubItems[3].Text;
            txtsongtoida.Text = listView1.SelectedItems[0].SubItems[4].Text;
            cbxtrangthai.Text = listView1.SelectedItems[0].SubItems[5].Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string tukhoa = textBox1.Text;
            ClassQLP ob = new ClassQLP();
            if (cb_luachon.Text == "Mã phòng")
            {
                ob.hienthi_listview(listView1, "Select * from Phong where MaPhong like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(cb_luachon.Text, "Tên phòng", true) == 0)
            {
                ob.hienthi_listview(listView1, "Select * from Phong where TenPhong like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(cb_luachon.Text, "Loại phòng", true) == 0)
            {
                ob.hienthi_listview(listView1, "Select * from Phong where loaiphong like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(cb_luachon.Text, "Mô tả phòng", true) == 0)
            {
                ob.hienthi_listview(listView1, "Select * from Phong where Mota like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(cb_luachon.Text, "Số người tối đa", true) == 0)
            {
                ob.hienthi_listview(listView1, "Select * from Phong where songtoida like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(cb_luachon.Text, "Giá phòng", true) == 0)
            {
                ob.hienthi_listview(listView1, "Select * from Phong where giaphong like N'%" + tukhoa + "%'");
            }
            else
            {
                ob.hienthi_listview(listView1, "Select * from Phong where tthaiphong like N'%" + tukhoa + "%'");
            }

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
        }


    }
}
