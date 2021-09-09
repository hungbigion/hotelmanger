using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLKSSML
{
    class Clthuephong
    {
        SqlConnection conn = new SqlConnection(@"Data Source=UFYNDEVZ5K1UKA9\SQLEXPRESS;Initial Catalog=QLKS_SML;Integrated Security=True");

        string mathue,maphong,makh,manv,tenphong,loaiphong,trangthai;
        int giap,songuoi;
        DateTime ngaydat,ngaynhan;
        public Clthuephong() { }

        public Clthuephong(string mathue,string maphong,string makh
                            ,string manv,string tenphong,string loaiphong,DateTime ngaydat,
                                DateTime ngaynhan,int giap,int songuoi,string trangthai) {

                        this.mathue = mathue;
                        this.maphong = maphong;
                        this.makh = makh;
                        this.manv = manv;
                        this.tenphong = tenphong;
                        this.loaiphong = loaiphong;
                        this.ngaydat = ngaydat;
                        this.ngaynhan = ngaynhan;
                        this.giap = giap;
                        this.songuoi = songuoi;
                        this.trangthai = trangthai;
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
                string mathue = row["MaThuep"].ToString();
                string maphong = row["MaPhong"].ToString();
                string makh = row["Makh"].ToString();
                string manv = row["Manv"].ToString();
                string tenp = row["TenPhong"].ToString();
                string loaiphong = row["loaiphong"].ToString();
                string ngaydat = row["Ngaydatphong"].ToString();
                string ngaynhan = row["Ngaynhanphong"].ToString();
                string giap = row["giaphong"].ToString();
                string songuoi = row["songuoi"].ToString();
                string trangthai = row["trangthai"].ToString();
                item.Items.Add(mathue.ToString());
                item.Items[i].SubItems.Add(maphong);
                item.Items[i].SubItems.Add(makh);
                item.Items[i].SubItems.Add(manv);
                item.Items[i].SubItems.Add(tenp);
                item.Items[i].SubItems.Add(loaiphong);
                item.Items[i].SubItems.Add(ngaydat);
                item.Items[i].SubItems.Add(ngaynhan);
                item.Items[i].SubItems.Add(giap);
                item.Items[i].SubItems.Add(songuoi);
                item.Items[i].SubItems.Add(trangthai);
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

        public void insert(Clthuephong ob)
        {

            string sql = @"Insert into TTthuephong (MaThuep,MaPhong,Makh,Manv,TenPhong,loaiphong,Ngaydatphong,Ngaynhanphong,giaphong,songuoi,trangthai)
VALUES (N'" + ob.mathue + @"',N'" + ob.maphong + @"',N'" + ob.makh + @"',N'" + ob.manv + @"',N'" + ob.tenphong + @"',N'" + ob.loaiphong + @"',N'" + ob.ngaydat + @"',N'" + ob.ngaynhan + @"',N'" + ob.giap + @"',N'" + ob.songuoi + @"',N'" + ob.trangthai + @"')"; ;
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Update(dt);
            dt.AcceptChanges();
        }
        public void delete(Clthuephong ob)
        {
            string sql = @"delete from TTthuephong where (MaThuep =N'" + ob.mathue + @"')";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Update(dt);
            dt.AcceptChanges();
        }
        public void update(Clthuephong ob)
        {
            string sql = @"update TTthuephong set MaPhong= N'" + ob.maphong + @"',Makh= N'" + ob.makh + @"',Manv= N'" + ob.manv + @"',TenPhong= N'" + ob.tenphong + @"',loaiphong= N'" + ob.loaiphong + @"',Ngaydatphong= N'" + ob.ngaydat + @"',Ngaynhanphong= N'" + ob.ngaynhan + @"',giaphong= N'" + ob.giap + @"',songuoi= N'" + ob.songuoi + @"',trangthai= N'" + ob.trangthai + @"' where MaThuep= N'" + ob.mathue + @"'";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Update(dt);
            dt.AcceptChanges();
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
            string sql = "select MaThuep from TTthuephong";
            DataTable dt = new DataTable();
            SqlCommand comselect = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comselect;//nó mở một chút ở đây
            da.Fill(dt);
            dt.AcceptChanges();
            foreach (DataRow row in dt.Rows)
            {
                string mathue = row["MaThuep"].ToString();
                if (String.Compare(mathue.Trim(), key.Trim(), true) == 0)
                {
                    kt = true; break;
                }
            }
            return kt;
        }
        public bool kt_keymaph(string key)
        {
            bool kt = false;
            string sql = "select MaPhong from TTthuephong";
            DataTable dt = new DataTable();
            SqlCommand comselect = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comselect;//nó mở một chút ở đây
            da.Fill(dt);
            dt.AcceptChanges();
            foreach (DataRow row in dt.Rows)
            {
                string maphong = row["MaPhong"].ToString();
                if (String.Compare(maphong.Trim(), key.Trim(), true) == 0)
                {
                    kt = true; break;
                }
            }
            return kt;
        }
    }
}
