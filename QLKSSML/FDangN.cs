using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLKSSML
{
    public partial class FDangN : Form
    {
        public FDangN()
        {
            InitializeComponent();
        }
        public static string phanquyen;
        private void FDangN_Load(object sender, EventArgs e)
        {

        }
        Clogin lg = new Clogin();

        private void btnlogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=UFYNDEVZ5K1UKA9\SQLEXPRESS;Initial Catalog=QLKS_SML;Integrated Security=True");
            string tk = txttentk.Text;
            string mk = txtmk.Text;
            string sql = "select * from DangNhap where Taikhoan='" + tk + "' and Matkhau='" + mk + "'";
            if (tk != "" || mk != "")
            {
                if (lg.XemDL(sql).Rows.Count != 0)
                {
                    FQLKSSML.quyen = lg.XemDL("select phanquyen from DangNhap where Taikhoan='" + tk + "' and Matkhau='" + mk + "'").Rows[0][0].ToString().Trim();
                    FQLKSSML.tendaydu = lg.XemDL("select FullName from DangNhap where Taikhoan='" + tk + "' and Matkhau='" + mk + "'").Rows[0][0].ToString().Trim();
                    MessageBox.Show("Đăng Nhập thành công,!!!");
                    FQLKSSML f = new FQLKSSML();
                    f.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Đăng Nhập Thất Bại,Vui lòng kiểm tra thông tin đăng nhập!!!");
                    txtmk.Text = "";
                    txttentk.Text = "";
                    txttentk.Focus();
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập thông tin đăng nhập !!!");
                txtmk.Text = "";
                txttentk.Text = "";
                txttentk.Focus();
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
