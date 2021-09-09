using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace QLKSSML
{
    class CACC
    {
        string Taikhoan, Matkhau, FullName, Email,phanquyen;
        SqlConnection conn = new SqlConnection(@"Data Source=UFYNDEVZ5K1UKA9\SQLEXPRESS;Initial Catalog=QLKS_SML;Integrated Security=True");
                        public CACC() { }
                        public CACC(string Taikhoan, string Matkhau, string FullName, string Email, string phanquyen)
                {
                    this.Taikhoan = Taikhoan;
                    this.Matkhau = Matkhau;
                    this.FullName = FullName;
                    this.Email = Email;
                     this.phanquyen = phanquyen;
                }
                        public void hienthi_listview(ListView item, string sql)
                        {
                            item.Items.Clear();
                            DataTable dt = new DataTable();
                            SqlCommand comselect = new SqlCommand(sql, conn);
                            SqlDataAdapter da = new SqlDataAdapter();
                            da.SelectCommand = comselect;//nó mở một chút ở đây
                            da.Fill(dt);
                            dt.AcceptChanges();
                            int i = 0;
                            foreach (DataRow row in dt.Rows)
                            {
                                //Taikhoan, Matkhau, FullName, Email,phanquyen;
                                string Taikhoan = row["Taikhoan"].ToString();
                                string Matkhau = row["Matkhau"].ToString();
                                string FullName = row["FullName"].ToString();
                                string Email = row["Email"].ToString();
                                string phanquyen = row["phanquyen"].ToString();
                                item.Items.Add(Taikhoan.ToString());
                                item.Items[i].SubItems.Add(Matkhau);
                                item.Items[i].SubItems.Add(FullName);
                                item.Items[i].SubItems.Add(Email);
                                item.Items[i].SubItems.Add(phanquyen);
                                i = i + 1;
                            }
                        }
                        public DataTable load(string sql)
                        {
                            DataTable dt = new DataTable();
                            SqlCommand comselect = new SqlCommand(sql, conn);
                            SqlDataAdapter da = new SqlDataAdapter();
                            da.SelectCommand = comselect;
                            da.Fill(dt);
                            dt.AcceptChanges();
                            return dt;
                        }
                        public bool kt_keymath(string key)
                        {
                            bool kt = false;
                            string sql = "select Taikhoan from DangNhap";
                            DataTable dt = new DataTable();
                            SqlCommand comselect = new SqlCommand(sql, conn);
                            SqlDataAdapter da = new SqlDataAdapter();
                            da.SelectCommand = comselect;//nó mở một chút ở đây
                            da.Fill(dt);
                            dt.AcceptChanges();
                            foreach (DataRow row in dt.Rows)
                            {
                                string Taikhoan = row["Taikhoan"].ToString();
                                if (String.Compare(Taikhoan.Trim(), key.Trim(), true) == 0)
                                {
                                    kt = true; break;
                                }
                            }
                            return kt;
                        }
                        public void insert(CACC ob)
                        {
                           
                            string sql = @"Insert into DangNhap (Taikhoan, Matkhau, FullName, Email,phanquyen)
VALUES (N'" + ob.Taikhoan + @"',N'" + ob.Matkhau+ @"',N'" + ob.FullName + @"',N'" + ob.Email + @"',N'" + ob.phanquyen  + @"')";
                            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            da.Update(dt);
                            dt.AcceptChanges();
                        }
                        public void delete(CACC ob)
                        {
                            string sql = @"delete from DangNhap where (Taikhoan =N'" + ob.Taikhoan + @"')";
                            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            da.Update(dt);
                            dt.AcceptChanges();
                        }
                        public void update(CACC ob)
                        {
                            //Taikhoan, Matkhau, FullName, Email,phanquyen;
                            string sql = @"update DangNhap set Matkhau= N'" + ob.Matkhau + @"',FullName= N'" + ob.FullName + @"',Email= N'" + ob.Email + @"',phanquyen= N'" + ob.phanquyen + @"' where Taikhoan= N'" + ob.Taikhoan + @"'";
                            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            da.Update(dt);
                            dt.AcceptChanges();
                        }
    }
}
