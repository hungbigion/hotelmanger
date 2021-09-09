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
    public partial class FQLNV : Form
    {
        public FQLNV()
        {
            InitializeComponent();
        }

        private void FQLNV_Load(object sender, EventArgs e)
        {
            CQLNV ob = new CQLNV();
            ob.hienthi_listview(listViewnv, "select * from Nhanvien");
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            CQLNV ob = new CQLNV(txtmanv.Text, txthotennv.Text, Convert.ToDateTime(txtngaysinh.Text), txtgoitinh.Text, txtsdt.Text, txtscmnd.Text, textBox1.Text,txttentk.Text,txtchucvu.Text);
            if (txttentk.Text == "" || txtchucvu.Text == "" || txtmanv.Text == "" || txthotennv.Text == "" || txtngaysinh.Text == "" || txtgoitinh.Text == "" || txtsdt.Text == "" || txtscmnd.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else
            {
                if (txtscmnd.Text.Length > 9 || txtscmnd.Text.Length < 9)
                {
                    MessageBox.Show("Số CMND không hợp lệ !!!");
                }
                else {
                    if (ob.kt_keymath(txtmanv.Text) == false)
                    {
                        ob.insert(ob);
                        FQLNV_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Trùng mã nhân viên");
                    }
                
                }
            }
            
     
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            CQLNV ob = new CQLNV(txtmanv.Text, txthotennv.Text, Convert.ToDateTime(txtngaysinh.Text), txtgoitinh.Text, txtsdt.Text, txtscmnd.Text, textBox1.Text, txttentk.Text, txtchucvu.Text); 
                if (txttentk.Text == "" || txtchucvu.Text == "" || txtmanv.Text == "" || txthotennv.Text == "" || txtngaysinh.Text == "" || txtgoitinh.Text == "" || txtsdt.Text == "" || txtscmnd.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else
            {
                if (txtscmnd.Text.Length > 9 || txtscmnd.Text.Length < 9)
                {
                    MessageBox.Show("Số CMND không hợp lệ !!!");
                }
                else
                {
                    ob.update(ob);
                    FQLNV_Load(sender, e);
                   

                }
            }
            
            
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            CQLNV ob = new CQLNV(txtmanv.Text, txthotennv.Text, Convert.ToDateTime(txtngaysinh.Text), txtgoitinh.Text, txtsdt.Text, txtscmnd.Text, textBox1.Text, txttentk.Text, txtchucvu.Text); ob.delete(ob);
            FQLNV_Load(sender, e);
        }

        private void listViewnv_Click(object sender, EventArgs e)
        {
            txtmanv.Text = listViewnv.SelectedItems[0].SubItems[0].Text;
            txthotennv.Text = listViewnv.SelectedItems[0].SubItems[1].Text;
            txtngaysinh.Text = listViewnv.SelectedItems[0].SubItems[2].Text;
            txtgoitinh.Text = listViewnv.SelectedItems[0].SubItems[3].Text;
            txtsdt.Text = listViewnv.SelectedItems[0].SubItems[4].Text;
            txtscmnd.Text = listViewnv.SelectedItems[0].SubItems[5].Text;
            textBox1.Text = listViewnv.SelectedItems[0].SubItems[6].Text;
            txttentk.Text = listViewnv.SelectedItems[0].SubItems[7].Text;
            txtchucvu.Text = listViewnv.SelectedItems[0].SubItems[8].Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtmanv.Text = "";
            txthotennv.Text = "";
            txtngaysinh.Text = "";
            txtgoitinh.Text = "";
            txtsdt.Text = "";
            txtscmnd.Text = "";
            textBox1.Text = "";
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

        private void txtsearchnv_TextChanged(object sender, EventArgs e)
        {
            //Mã nhân viên
            //Họ tên nhân viên
            //Ngày sinh
            //Giới tính
            //Số điện thoại
            //Số CMND
            //Email
            string tukhoa = txtsearchnv.Text;
            CQLNV ob = new CQLNV();
            if (cbxluachonkh.Text == "Mã nhân viên")
            {
                ob.hienthi_listview(listViewnv, "Select * from Nhanvien where Manv like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(cbxluachonkh.Text, "Họ tên nhân viên", true) == 0)
            {
                ob.hienthi_listview(listViewnv, "Select * from Nhanvien where Tennv like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(cbxluachonkh.Text, "Ngày sinh", true) == 0)
            {
                ob.hienthi_listview(listViewnv, "Select * from Nhanvien where Ngaysinh like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(cbxluachonkh.Text, "Giới tính", true) == 0)
            {
                ob.hienthi_listview(listViewnv, "Select * from Nhanvien where gioitinh like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(cbxluachonkh.Text, "Số điện thoại", true) == 0)
            {
                ob.hienthi_listview(listViewnv, "Select * from Nhanvien where sdt like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(cbxluachonkh.Text, "Số CMND", true) == 0)
            {
                ob.hienthi_listview(listViewnv, "Select * from Nhanvien where Cmnd like N'%" + tukhoa + "%'");
            }
            //Tên tài khoản Chức vụ   Taikhoan,chucvu
            else if (String.Compare(cbxluachonkh.Text, "Email", true) == 0)
            {
                ob.hienthi_listview(listViewnv, "Select * from Nhanvien where Email like N'%" + tukhoa + "%'");

            }
            else if (String.Compare(cbxluachonkh.Text, "Tên tài khoản", true) == 0)
            {
                ob.hienthi_listview(listViewnv, "Select * from Nhanvien where Taikhoan like N'%" + tukhoa + "%'");

            }
            else 
            {
                ob.hienthi_listview(listViewnv, "Select * from Nhanvien where chucvu like N'%" + tukhoa + "%'");

            }
        }
    }
}
