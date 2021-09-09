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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string phanquyen;
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        Clogin lg = new Clogin();
        private void btnlogin_Click(object sender, EventArgs e)
        {
            FDangN f = new FDangN();
            f.Show();
            this.Hide();
        }
  private void btnthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

  private void button1_Click(object sender, EventArgs e)
  {
      Fdangkytk f = new Fdangkytk();
      f.Show();
      this.Hide();
  }
    }
}
