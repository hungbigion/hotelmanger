using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLKSSML
{
    class CLPhong
    {
         SqlConnection conn = new SqlConnection(@"Data Source=UFYNDEVZ5K1UKA9\SQLEXPRESS;Initial Catalog=QLKS_SML;Integrated Security=True");

        string loaip, mota;
        int giap;
        public CLPhong() { }
        public CLPhong(string loaip,string mota,int giap) {
            this.loaip = loaip;
            this.mota = mota;
            this.giap = giap;
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
                //string loaip, mota;
                //int giap;
                string loaip = row["loaiphong"].ToString();
                string mota = row["mota"].ToString();
                string giap = row["giaphong"].ToString();
                item.Items.Add(loaip.ToString());
                item.Items[i].SubItems.Add(mota);
                item.Items[i].SubItems.Add(giap);
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
            string sql = "select loaiphong from LPhong";
            DataTable dt = new DataTable();
            SqlCommand comselect = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comselect;//nó mở một chút ở đây
            da.Fill(dt);
            dt.AcceptChanges();
            foreach (DataRow row in dt.Rows)
            {
                string loaip= row["loaiphong"].ToString();
                if (String.Compare(loaip.Trim(), key.Trim(), true) == 0)
                {
                    kt = true; break;
                }
            }
            return kt;
        }
        public void insert(CLPhong ob)
        {

            string sql = @"Insert into LPhong (loaiphong,mota,giaphong)
VALUES (N'" + ob.loaip + @"',N'" + ob.mota + @"',N'" + ob.giap + @"')";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Update(dt);
            dt.AcceptChanges();
        }
        public void delete(CLPhong ob)
        {
            string sql = @"delete from LPhong where (loaiphong =N'" + ob.loaip + @"')";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Update(dt);
            dt.AcceptChanges();
        }
        public void update(CLPhong ob)
        {
            string sql = @"update LPhong set mota= N'" + ob.mota + @"',giaphong= N'" + ob.giap + @"' where loaiphong= N'" + ob.loaip + @"'";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Update(dt);
            dt.AcceptChanges();
        }
    }
}

