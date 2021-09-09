using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace QLKSSML
{
    class ClassQLP
    {
       
        SqlConnection conn = new SqlConnection(@"Data Source=UFYNDEVZ5K1UKA9\SQLEXPRESS;Initial Catalog=QLKS_SML;Integrated Security=True");

        string maphong, tenp, loaiphong, mota, tthaiphong;
        int songtoida;
         public ClassQLP() { }
         public ClassQLP(string maphong, string tenp, string loaiphong, string mota, int songtoida, string tthaiphong)
         {
             this.maphong = maphong;
             this.tenp = tenp;
             this.loaiphong = loaiphong;
             this.mota = mota;
             this.songtoida = songtoida;
             this.tthaiphong = tthaiphong;
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
                 string maphong = row["MaPhong"].ToString();
                 string tenp = row["TenPhong"].ToString();
                 string loaiphong = row["loaiphong"].ToString();
                 string mota = row["Mota"].ToString();
                 string songtoida = row["songtoida"].ToString();
                 string tthaiphong = row["tthaiphong"].ToString();
                 item.Items.Add(maphong.ToString());
                 item.Items[i].SubItems.Add(tenp);
                 item.Items[i].SubItems.Add(loaiphong);
                 item.Items[i].SubItems.Add(mota);
                 item.Items[i].SubItems.Add(songtoida);
                 item.Items[i].SubItems.Add(tthaiphong);
                 i = i + 1;
             }
         }

         public bool kt_key(string key)
         {
             bool kt = false;
             string sql = "select MaPhong from Phong";
             DataTable dt = new DataTable();
             SqlCommand comselect = new SqlCommand(sql, conn);
             SqlDataAdapter da = new SqlDataAdapter();
             da.SelectCommand = comselect;//nó mở một chút ở đây
             da.Fill(dt);
             dt.AcceptChanges();
             foreach (DataRow row in dt.Rows)
             {
                 string masp = row["MaPhong"].ToString();
                 if (String.Compare(masp.Trim(), key.Trim(), true) == 0)
                 {
                     kt = true; break;
                 }
             }
             return kt;
         }


         public void insert(ClassQLP i)
         {

             string sql = @"Insert into Phong (MaPhong,TenPhong,loaiphong,Mota,songtoida,tthaiphong)
VALUES (N'" + i.maphong + @"',N'" + i.tenp + @"',N'" + i.loaiphong + @"',N'" + i.mota + @"',N'" + i.songtoida + @"',N'" + i.tthaiphong + @"')"; ;
             SqlDataAdapter da = new SqlDataAdapter(sql, conn);
             DataTable dt = new DataTable();
             da.Fill(dt);
             da.Update(dt);
             dt.AcceptChanges();
         }

         public void update(ClassQLP i)
         {
             string sql = @"UPDATE Phong set TenPhong =N'" + i.tenp + @"',loaiphong =N'" + i.loaiphong + @"',Mota =N'" + i.mota + @"',songtoida =N'" + i.songtoida + @"',tthaiphong =N'" + i.tthaiphong + @"' where MaPhong= N'" + i.maphong + @"'";
             SqlDataAdapter da = new SqlDataAdapter(sql, conn);
             DataTable dt = new DataTable();
             da.Fill(dt);
             da.Update(dt);
             dt.AcceptChanges();
         }

         public void delete(ClassQLP i)
         {
             string sql = @"delete from Phong where (MaPhong =N'" + i.maphong + @"')";
             SqlDataAdapter da = new SqlDataAdapter(sql, conn);
             DataTable dt = new DataTable();
             da.Fill(dt);
             da.Update(dt);
             dt.AcceptChanges();
         }
        public DataTable LoadTable(string sql)
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
            try
            {
                ad.Fill(dt);
            }
            catch (System.Data.SqlClient.SqlException) { }
            conn.Close();
            return dt;
        }
        //Phương thức truy vấn để xem dữ liệu
        public DataTable XemDL(string sql)
        {
            conn.Open();
            SqlDataAdapter adap = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            conn.Close();
            return dt;

        }

        public void Excecute(string sql)
        {
            conn.Open();
            SqlCommand thuchienlenh = new SqlCommand(sql, conn);
            try
            {
                thuchienlenh.ExecuteReader();
            }
            catch (System.Data.SqlClient.SqlException) { }
            conn.Close();
        }
    }
}
