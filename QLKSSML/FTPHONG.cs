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
    public partial class FTPHONG : Form
    {
        public FTPHONG()
        {
            InitializeComponent();
        }

        private void FTPHONG_Load(object sender, EventArgs e)
        {
            CLPhong ob = new CLPhong();
            ob.hienthi_listview(listViewacc,"select * from LPhong");
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            CLPhong ob = new CLPhong(txtloaip.Text, txtmota.Text, Int32.Parse(txtgiap.Text));
            if (txtloaip.Text == "" || txtmota.Text == "" || txtgiap.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else {
                if (ob.kt_keymath(txtloaip.Text) == false) {
                    ob.insert(ob);
                    FTPHONG_Load(sender,e);
                }
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            CLPhong ob = new CLPhong(txtloaip.Text, txtmota.Text, Int32.Parse(txtgiap.Text));
            if (txtloaip.Text == "" || txtmota.Text == "" || txtgiap.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else
            {
                    ob.update(ob);
                    FTPHONG_Load(sender, e);
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            CLPhong ob = new CLPhong(txtloaip.Text, txtmota.Text, Int32.Parse(txtgiap.Text));
            ob.delete(ob);
            FTPHONG_Load(sender, e);
        }

        private void btnnhaplai_Click(object sender, EventArgs e)
        {
            txtloaip.Text = "";
            txtmota.Text = "";
            txtgiap.Text = "";
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
            txtloaip.Text = listViewacc.SelectedItems[0].SubItems[0].Text;
            txtmota.Text = listViewacc.SelectedItems[0].SubItems[1].Text;
            txtgiap.Text = listViewacc.SelectedItems[0].SubItems[2].Text;
        }

        private void txtsearchacc_TextChanged(object sender, EventArgs e)
        {
            string tukhoa = txtsearchacc.Text;
            CLPhong ob = new CLPhong();
            //Loại phòng
            //Mô tả 
            //Giá phòng
            if (cbxluachonacc.Text == "Loại phòng")
            {
                ob.hienthi_listview(listViewacc, "Select * from LPhong where loaiphong like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(cbxluachonacc.Text, "Mô tả", true) == 0)
            {
                ob.hienthi_listview(listViewacc, "Select * from LPhong where mota like N'%" + tukhoa + "%'");
            }
            else 
            {
                ob.hienthi_listview(listViewacc, "Select * from LPhong where giaphong like N'%" + tukhoa + "%'");
            }
        }
    }
}
