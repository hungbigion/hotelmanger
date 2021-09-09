using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLKSSML
{
    public partial class FQLKH : Form
    {
        public FQLKH()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FQLKSSML f = new FQLKSSML();
            f.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FQLKH_Load(object sender, EventArgs e)
        {
            CKHinfo ob = new CKHinfo();
            ob.hienthi_listview(listViewkh, "select * from Khachhang");
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            //--MaKh,Tenkh,Ngaysinh,gioitinh,sdt,Cmnd,Email;
            CKHinfo ob = new CKHinfo(txtmakh.Text,txthotenkh.Text,Convert.ToDateTime(txtngaysinh.Text),txtgoitinh.Text,txtsdt.Text,txtscmnd.Text,txtemail.Text);
            if (txtmakh.Text == "" || txthotenkh.Text == "" || txtgoitinh.Text == "" || txtngaysinh.Text == "" || txtscmnd.Text == "" || txtemail.Text == "")
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin !!!");
            }
            else {
                if (ob.kt_keymath(txtmakh.Text) == false)
                {
                    ob.insert(ob);
                    FQLKH_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Trùng mã khách hàng");
                }
            }
           
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
             CKHinfo ob = new CKHinfo(txtmakh.Text,txthotenkh.Text,Convert.ToDateTime(txtngaysinh.Text),txtgoitinh.Text,txtsdt.Text,txtscmnd.Text,txtemail.Text);
                ob.update(ob);
            FQLKH_Load(sender,e);
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            CKHinfo ob = new CKHinfo(txtmakh.Text,txthotenkh.Text,Convert.ToDateTime(txtngaysinh.Text),txtgoitinh.Text,txtsdt.Text,txtscmnd.Text,txtemail.Text);
            ob.delete(ob);
            FQLKH_Load(sender,e);
        }

        private void listViewkh_Click(object sender, EventArgs e)
        {
            txtmakh.Text = listViewkh.SelectedItems[0].SubItems[0].Text;
            txthotenkh.Text = listViewkh.SelectedItems[0].SubItems[1].Text;
            txtngaysinh.Text = listViewkh.SelectedItems[0].SubItems[2].Text;
            txtgoitinh.Text = listViewkh.SelectedItems[0].SubItems[3].Text;
            txtsdt.Text = listViewkh.SelectedItems[0].SubItems[4].Text;
            txtscmnd.Text = listViewkh.SelectedItems[0].SubItems[5].Text;
            txtemail.Text = listViewkh.SelectedItems[0].SubItems[6].Text;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtmakh.Text = "";
            txthotenkh.Text = "";
            txtngaysinh.Text = "";
            txtgoitinh.Text = "";
            txtsdt.Text = "";
            txtscmnd.Text = "";
            txtemail.Text = "";
        }

        private void txtsearchkh_TextChanged(object sender, EventArgs e)
        {
            //Mã khách hàng
            //Họ tên khách hàng
            //Ngày sinh
            //Giới tính
            //Số điện thoại
            //Số CMND
            //Email
            string tukhoa = txtsearchkh.Text;
            CKHinfo ob = new CKHinfo();
            if (cbxluachonkh.Text == "Mã khách hàng")
            {
                ob.hienthi_listview(listViewkh, "Select * from Khachhang where Makh like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(cbxluachonkh.Text, "Họ tên khách hàng", true) == 0)
            {
                ob.hienthi_listview(listViewkh, "Select * from Khachhang where Tenkh like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(cbxluachonkh.Text, "Ngày sinh", true) == 0)
            {
                ob.hienthi_listview(listViewkh, "Select * from Khachhang where Ngaysinh like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(cbxluachonkh.Text, "Giới tính", true) == 0)
            {
                ob.hienthi_listview(listViewkh, "Select * from Khachhang where gioitinh like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(cbxluachonkh.Text, "Số điện thoại", true) == 0)
            {
                ob.hienthi_listview(listViewkh, "Select * from Khachhang where sdt like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(cbxluachonkh.Text, "Số CMND", true) == 0)
            {
                ob.hienthi_listview(listViewkh, "Select * from Khachhang where Cmnd like N'%" + tukhoa + "%'");
            }
            else
            {
                ob.hienthi_listview(listViewkh, "Select * from Khachhang where quoctich like N'%" + tukhoa + "%'");

            }
        }


    }
}
