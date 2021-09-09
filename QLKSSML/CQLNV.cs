using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace QLKSSML
{
    class CQLNV
    {
        string Manv, Tennv, gioitinh, sdt, Cmnd, Email,tentk,chuvu;
        DateTime Ngaysinh;
        SqlConnection conn = new SqlConnection(@"Data Source=UFYNDEVZ5K1UKA9\SQLEXPRESS;Initial Catalog=QLKS_SML;Integrated Security=True");
                public CQLNV() { }
                public CQLNV(string Manv, string Tennv, DateTime Ngaysinh, string gioitinh, string sdt, string Cmnd, string Email,string tentk,string chuvu)
                {
                    this.Manv = Manv;
                    this.Tennv = Tennv;
            this.Ngaysinh = Ngaysinh;
            this.gioitinh = gioitinh;
            this.sdt = sdt;
            this.Cmnd = Cmnd;
            this.Email = Email;
                    this.tentk= tentk;
                    this.chuvu = chuvu;
                    
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
                        //--MaKh,Tenkh,Ngaysinh,gioitinh,sdt,Cmnd,Email;Manv, Tennv
                        string Manv = row["Manv"].ToString();
                        string Tennv = row["Tennv"].ToString();
                        string Ngaysinh = row["Ngaysinh"].ToString();
                        string gioitinh = row["gioitinh"].ToString();
                        string sdt = row["sdt"].ToString();
                        string Cmnd = row["Cmnd"].ToString();
                        string Email = row["Email"].ToString();
                            string tentk = row["Taikhoan"].ToString();
                        string chuvu = row["chucvu"].ToString();
                        item.Items.Add(Manv.ToString());
                        item.Items[i].SubItems.Add(Tennv);
                        item.Items[i].SubItems.Add(Ngaysinh);
                        item.Items[i].SubItems.Add(gioitinh);
                        item.Items[i].SubItems.Add(sdt);
                        item.Items[i].SubItems.Add(Cmnd);
                        item.Items[i].SubItems.Add(Email);
                        item.Items[i].SubItems.Add(tentk);
                        item.Items[i].SubItems.Add(chuvu);
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
                    string sql = "select Manv from Nhanvien";
                    DataTable dt = new DataTable();
                    SqlCommand comselect = new SqlCommand(sql, conn);
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = comselect;//nó mở một chút ở đây
                    da.Fill(dt);
                    dt.AcceptChanges();
                    foreach (DataRow row in dt.Rows)
                    {
                        string Manv = row["Manv"].ToString();
                        if (String.Compare(Manv.Trim(), key.Trim(), true) == 0)
                        {
                            kt = true; break;
                        }
                    }
                    return kt;
                }
                public void insert(CQLNV ob)
                {

                    string sql = @"Insert into Nhanvien (Manv,Tennv,Ngaysinh,gioitinh,sdt,Cmnd,Email,Taikhoan,chucvu)
VALUES (N'" + ob.Manv + @"',N'" + ob.Tennv + @"',N'" + ob.Ngaysinh + @"',N'" + ob.gioitinh + @"',N'" + ob.sdt + @"',N'" + ob.Cmnd + @"',N'" + ob.Email + @"',N'" + ob.tentk + @"',N'" + ob.chuvu + @"')";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    da.Update(dt);
                    dt.AcceptChanges();
                }
                public void delete(CQLNV ob)
                {
                    string sql = @"delete from Nhanvien where (Manv =N'" + ob.Manv + @"')";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    da.Update(dt);
                    dt.AcceptChanges();
                }
                public void update(CQLNV ob)
                {
                    string sql = @"update Nhanvien set Tennv= N'" + ob.Tennv + @"',Ngaysinh= N'" + ob.Ngaysinh + @"',gioitinh= N'" + ob.gioitinh + @"',sdt= N'" + ob.sdt + @"',Cmnd= N'" + ob.Cmnd + @"',Email= N'" + ob.Email + @"',Taikhoan= N'" + ob.tentk + @"',chucvu= N'" + ob.chuvu + @"' where Manv= N'" + ob.Manv + @"'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    da.Update(dt);
                    dt.AcceptChanges();
                }

    }
}
