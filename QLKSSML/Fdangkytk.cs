using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLKSSML
{
    public partial class Fdangkytk : Form
    {
        public Fdangkytk()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=UFYNDEVZ5K1UKA9\SQLEXPRESS;Initial Catalog=QLKS_SML;Integrated Security=True");
       
        private void Fdangkytk_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlDataAdapter da = new SqlDataAdapter("select count(*) from DangNhap where Taikhoan=N'" + tentk.Text +  "'", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);


            if (tentk.Text == "" || mk.Text == "" || mkcheck.Text == "" || fullname.Text == "" || email.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !!!");
            }
            else {

                if (dt.Rows[0][0].ToString() == "0")
                {
                    if (mk.Text == mkcheck.Text)
                    {

                        if (mk.Text.Length == 6)
                        {                                           
                            SqlDataAdapter da1 = new SqlDataAdapter(@"Insert into DangNhap (Taikhoan,Matkhau,FullName,Email,phanquyen)
VALUES (N'" + tentk.Text + @"',N'" + mk.Text + @"',N'" + fullname.Text + @"',N'" + email.Text + @"','nhân viên')", conn);
                            MessageBox.Show("Đăng Ký thành công !!!");
                            da1.Fill(dt);
                            FDangN f = new FDangN();
                            f.Show();
                            this.Close();
                        }
                        else if (mk.Text.Length < 6) { MessageBox.Show("Mật khẩu bắt buộc phải đủ 6 ký tự!!!"); }
                        else { MessageBox.Show("Mật khẩu vượt quá 6 ký tự!!!"); }

                    }
                    else
                    {
                        MessageBox.Show("Xác nhận mật khẩu nhập lại không khớp !!!");
                    }
                }
                else
                {
                    MessageBox.Show("Tên người dùng đã tồn tại !!!");
                }
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
