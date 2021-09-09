using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace QLKSSML
{
    class CDV
    {
        SqlConnection conn = new SqlConnection(@"Data Source=UFYNDEVZ5K1UKA9\SQLEXPRESS;Initial Catalog=QLKS_SML;Integrated Security=True");

        string madv, tendv;
        int giadv;
        public CDV() { }
        public CDV(string madv,string tendv,int giadv) {
            this.madv = madv;
            this.tendv = tendv;
            this.giadv = giadv;
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
                string madv = row["MaDV"].ToString();
                string tendv = row["TenDV"].ToString();
                string giadv = row["giaDV"].ToString();
                item.Items.Add(madv.ToString());
                item.Items[i].SubItems.Add(tendv);
                item.Items[i].SubItems.Add(giadv);
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
            string sql = "select MaDV from DichVu";
            DataTable dt = new DataTable();
            SqlCommand comselect = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comselect;//nó mở một chút ở đây
            da.Fill(dt);
            dt.AcceptChanges();
            foreach (DataRow row in dt.Rows)
            {
                string madv = row["MaDV"].ToString();
                if (String.Compare(madv.Trim(), key.Trim(), true) == 0)
                {
                    kt = true; break;
                }
            }
            return kt;
        }
        public void insert(CDV ob)
        {

            string sql = @"Insert into DichVu (MaDV,TenDV,giaDV)
VALUES (N'" + ob.madv + @"',N'" + ob.tendv + @"',N'" + ob.giadv +  @"')"; 
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Update(dt);
            dt.AcceptChanges();
        }
        public void delete(CDV ob)
        {
            string sql = @"delete from DichVu where (MaDV =N'" + ob.madv + @"')";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Update(dt);
            dt.AcceptChanges();
        }
        public void update(CDV ob)
        {
            string sql = @"update DichVu set TenDV= N'" + ob.tendv + @"',giaDV= N'" + ob.giadv + @"' where MaDV= N'" + ob.madv + @"'";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Update(dt);
            dt.AcceptChanges();
        }
    }
}
