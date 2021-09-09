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
    public partial class FQLACC : Form
    {
        public FQLACC()
        {
            InitializeComponent();
        }

        private void FQLACC_Load(object sender, EventArgs e)
        {
            CACC ob = new CACC();
            ob.hienthi_listview(listViewacc, "select * from DangNhap");
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            CACC ob = new CACC(txtusername.Text, txtpassword.Text, txtfullname.Text, txtemail.Text,cbxphanquyen.Text);
            if (txtusername.Text == "" || txtpassword.Text == "" || txtfullname.Text == "" || txtemail.Text == "" || cbxphanquyen.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else {
                if (ob.kt_keymath(txtusername.Text) == false)
                {
                    ob.insert(ob);
                    FQLACC_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Trùng mã nhân viên");
                }
            }

        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            CACC ob = new CACC(txtusername.Text, txtpassword.Text, txtfullname.Text, txtemail.Text, cbxphanquyen.Text);
            if (txtusername.Text == "" || txtpassword.Text == "" || txtfullname.Text == "" || txtemail.Text == "" || cbxphanquyen.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else {

                ob.update(ob);
                FQLACC_Load(sender, e);
            }
           
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            CACC ob = new CACC(txtusername.Text, txtpassword.Text, txtfullname.Text, txtemail.Text, cbxphanquyen.Text);
            ob.delete(ob);
            FQLACC_Load(sender, e);
        }

        private void txtsearchacc_TextChanged(object sender, EventArgs e)
        {
            //Tên tài khoản
            //Mật khẩu
            //Tên đầy đủ
            //Email
            //Phân quyền
//           
            string tukhoa = txtsearchacc.Text;
            CACC ob = new CACC();
            if (cbxluachonacc.Text == "Tên tài khoản")
            {
                ob.hienthi_listview(listViewacc, "Select * from DangNhap where Taikhoan like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(cbxluachonacc.Text, "Mật khẩu", true) == 0)
            {
                ob.hienthi_listview(listViewacc, "Select * from DangNhap where Matkhau like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(cbxluachonacc.Text, "Tên đầy đủ", true) == 0)
            {
                ob.hienthi_listview(listViewacc, "Select * from DangNhap where FullName like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(cbxluachonacc.Text, "Email", true) == 0)
            {
                ob.hienthi_listview(listViewacc, "Select * from DangNhap where Email like N'%" + tukhoa + "%'");
            }
            else {
                ob.hienthi_listview(listViewacc, "Select * from DangNhap where phanquyen like N'%" + tukhoa + "%'");
           
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FQLKSSML f = new FQLKSSML();
            f.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listViewacc_Click(object sender, EventArgs e)
        {
            // Taikhoan, Matkhau, FullName, Email,phanquyen;
            txtusername.Text = listViewacc.SelectedItems[0].SubItems[0].Text;
            txtpassword.Text = listViewacc.SelectedItems[0].SubItems[1].Text;
            txtfullname.Text = listViewacc.SelectedItems[0].SubItems[2].Text;
            txtemail.Text = listViewacc.SelectedItems[0].SubItems[3].Text;
            cbxphanquyen.Text = listViewacc.SelectedItems[0].SubItems[4].Text;
        }
    }
}
