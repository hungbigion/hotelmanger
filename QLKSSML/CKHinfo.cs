using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLKSSML
{
    class CKHinfo
    {
        //--MaKh,Tenkh,Ngaysinh,gioitinh,sdt,Cmnd,Email;
        string MaKh, Tenkh, gioitinh, sdt, Cmnd, quoctich;
        DateTime Ngaysinh;
        SqlConnection conn = new SqlConnection(@"Data Source=UFYNDEVZ5K1UKA9\SQLEXPRESS;Initial Catalog=QLKS_SML;Integrated Security=True");

        public CKHinfo() { }
        public CKHinfo(string MaKh, string Tenkh, DateTime Ngaysinh, string gioitinh, string sdt, string Cmnd, string quoctich)
        {
            this.MaKh = MaKh;
            this.Tenkh = Tenkh;
            this.Ngaysinh = Ngaysinh;
            this.gioitinh = gioitinh;
            this.sdt = sdt;
            this.Cmnd = Cmnd;
            this.quoctich = quoctich;
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
                //--MaKh,Tenkh,Ngaysinh,gioitinh,sdt,Cmnd,Email;
                string MaKh = row["Makh"].ToString();
                string Tenkh = row["Tenkh"].ToString();
                string Ngaysinh = row["Ngaysinh"].ToString();
                string gioitinh = row["gioitinh"].ToString();
                string sdt = row["sdt"].ToString();
                string Cmnd = row["Cmnd"].ToString();
                string quoctich = row["quoctich"].ToString();
                item.Items.Add(MaKh.ToString());
                item.Items[i].SubItems.Add(Tenkh);
                item.Items[i].SubItems.Add(Ngaysinh);
                item.Items[i].SubItems.Add(gioitinh);
                item.Items[i].SubItems.Add(sdt);
                item.Items[i].SubItems.Add(Cmnd);
                item.Items[i].SubItems.Add(quoctich);
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
        public void excute(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Update(dt);
            dt.AcceptChanges();
        }
        public bool kt_keymath(string key)
        {
            bool kt = false;
            string sql = "select Makh from Khachhang";
            DataTable dt = new DataTable();
            SqlCommand comselect = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comselect;//nó mở một chút ở đây
            da.Fill(dt);
            dt.AcceptChanges();
            foreach (DataRow row in dt.Rows)
            {
                string MaKh = row["Makh"].ToString();
                if (String.Compare(MaKh.Trim(), key.Trim(), true) == 0)
                {
                    kt = true; break;
                }
            }
            return kt;
        }
        public void insert(CKHinfo ob)
        {

            string sql = @"Insert into Khachhang (Makh,Tenkh,Ngaysinh,gioitinh,sdt,Cmnd,quoctich)
VALUES (N'" + ob.MaKh + @"',N'" + ob.Tenkh + @"',N'" + ob.Ngaysinh + @"',N'" + ob.gioitinh + @"',N'" + ob.sdt + @"',N'" + ob.Cmnd + @"',N'" + ob.quoctich + @"')";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Update(dt);
            dt.AcceptChanges();
        }
        public void delete(CKHinfo ob)
        {
            string sql = @"delete from Khachhang where (Makh =N'" + ob.MaKh + @"')";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Update(dt);
            dt.AcceptChanges();
        }
        public void update(CKHinfo ob)
        {
            string sql = @"update Khachhang set Tenkh= N'" + ob.Tenkh + @"',Ngaysinh= N'" + ob.Ngaysinh + @"',gioitinh= N'" + ob.gioitinh + @"',sdt= N'" + ob.sdt + @"',Cmnd= N'" + ob.Cmnd + @"',quoctich= N'" + ob.quoctich + @"' where Makh= N'" + ob.MaKh + @"'";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Update(dt);
            dt.AcceptChanges();
        }
    }
}
