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
    public partial class FQLDV : Form
    {
        public FQLDV()
        {
            InitializeComponent();
        }

        private void FQLDV_Load(object sender, EventArgs e)
        {
            CDV obdv = new CDV();
            obdv.hienthi_listview(listView1, "select * from DichVu");

        }

        private void btnhome_Click(object sender, EventArgs e)
        {
            FQLKSSML f = new FQLKSSML();
            f.Show();
            this.Close();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            CDV ob = new CDV(textBox1.Text, textBox2.Text, Int32.Parse(textBox3.Text));
            if (ob.kt_keymath(textBox1.Text) == false)
            {
                ob.insert(ob);
                FQLDV_Load(sender, e);
            }
            else {
                MessageBox.Show("Trùng mã dịch vụ");
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            CDV ob = new CDV(textBox1.Text, textBox2.Text, Int32.Parse(textBox3.Text));
            ob.update(ob);
            FQLDV_Load(sender, e);
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            CDV ob = new CDV(textBox1.Text, textBox2.Text, Int32.Parse(textBox3.Text));
            ob.delete(ob);
            FQLDV_Load(sender, e);
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
        }

        private void btnnhaplai_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox1.Focus();
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
                ob.hienthi_listview(listView1, "Select * from DichVu where MaDV like N'%" + tukhoa + "%'");
            }
            else if (String.Compare(cbxluachondv.Text, "Tên dịch vụ", true) == 0)
            {
                ob.hienthi_listview(listView1, "Select * from DichVu where TenDV like N'%" + tukhoa + "%'");
            }
            else {
                ob.hienthi_listview(listView1, "Select * from DichVu where giaDV like N'%" + tukhoa + "%'");
           
            }
        }
    }
}
