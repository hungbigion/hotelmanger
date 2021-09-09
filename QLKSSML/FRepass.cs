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
    public partial class FRepass : Form
    {
        public FRepass()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=UFYNDEVZ5K1UKA9\SQLEXPRESS;Initial Catalog=QLKS_SML;Integrated Security=True");
       
        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select count(*) from DangNhap where Taikhoan=N'" + tentk.Text + "' and Matkhau=N'" + mkcu.Text + "'", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if(tentk.Text==""||mkcu.Text==""||mkm.Text==""||xnmkcu.Text==""){
                MessageBox.Show("Hãy nhập đầy đủ thông tin !!!");
            }
            else{
                if (dt.Rows[0][0].ToString() == "1")
                {
                    if (mkm.Text == xnmkcu.Text)
                    {

                        if (mkm.Text.Length == 6)
                        {
                            SqlDataAdapter da1 = new SqlDataAdapter("update DangNhap set Matkhau=N'" + mkm.Text + "'  where Taikhoan=N'" + tentk.Text + "' and Matkhau=N'" + mkcu.Text + "'", conn);
                            MessageBox.Show("Đổi mật khẩu thành công !!!");
                            da1.Fill(dt);
                            FDangN f = new FDangN();
                            f.Show();
                            this.Close();
                        }
                        else if (mkm.Text.Length < 6) { MessageBox.Show("Mật khẩu bắt buộc phải đủ 6 ký tự!!!"); }
                        else { MessageBox.Show("Mật khẩu vượt quá 6 ký tự!!!"); }

                    }
                    else
                    {
                        MessageBox.Show("Xác nhận mật khẩu nhập lại không khớp !!!");
                    }
                }
                else
                {
                    MessageBox.Show("Tên người dùng hoặc mật khẩu không đúng !!!");
                }
            }

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
