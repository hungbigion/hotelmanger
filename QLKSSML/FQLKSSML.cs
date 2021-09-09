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
    public partial class FQLKSSML : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=UFYNDEVZ5K1UKA9\SQLEXPRESS;Initial Catalog=QLKS_SML;Integrated Security=True");
        ClassQLP ob = new ClassQLP();
        public static string quyen;
        public static string tendaydu;
        public FQLKSSML()
        {
            InitializeComponent();
        }
        public static SqlCommand com;
        private void quảnLýPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void TSMQlP_Click(object sender, EventArgs e)
        {
            FQLROOM f = new FQLROOM();
            f.Show();
            this.Close();
        }

        private void FQLKSSML_Load(object sender, EventArgs e)
        {
            if (quyen=="nhân viên") {
                toolStripMenuItem2.Enabled = false;
                NVToolStripMenuItem.Enabled = false;
            }
            lblpq.Text = "Phân Quyền : " +quyen;
            lblhoten.Text = "Xin Chào : " +tendaydu;
        }

        private void quảnLýThuêPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fthuephong f = new Fthuephong();
            f.Show();
            this.Close();
        }

        private void trảPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void trảPhòngLậpHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FQLtraphong f = new FQLtraphong();
            f.Show();
            this.Close();
        }

        private void quảnLýHóaĐơnDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FQHDV f = new FQHDV();
            f.Show();
            this.Close();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FQLDV f = new FQLDV();
            f.Show();
            this.Close();
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FQLKH f = new FQLKH();
            f.Show();
            this.Close();
        }

        private void NVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FQLNV f = new FQLNV();
            f.Show();
            this.Close();
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FQLACC f = new FQLACC();
            f.Show();
            this.Close();
        }

        private void quảnLýLoạiPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FTPHONG f = new FTPHONG();
            f.Show();
            this.Close();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FRepass f = new FRepass();
            f.Show();
            this.Close();
        }
    }
}
