using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLKSSML
{
    class Ctraphong
    {
        SqlConnection conn = new SqlConnection(@"Data Source=UFYNDEVZ5K1UKA9\SQLEXPRESS;Initial Catalog=QLKS_SML;Integrated Security=True");
        // --Mahoadon,Maphong,MahoadonDV,Makh,Manv,Ngaydatphong,Ngaynhanphong,
        //Ngaytraphong,soluongnguoi,phiphong,phidv,thanhtien
        string mahd, mapthue, maphong, makh, manv;
        DateTime ngaydat, ngaynhan, ngaytra;
        int soluongnguoi, phiphong;
        public Ctraphong() { }
        public Ctraphong(string mahd, string mapthue, string maphong, string mahddv, string makh, string manv,
            DateTime ngaydat, DateTime ngaynhan, DateTime ngaytra,
            int soluongnguoi, int phiphong, int phidv)
        {
            this.mahd = mahd;
            this.mapthue = mapthue;
            this.maphong = maphong;
            this.makh = makh;
            this.manv = manv;
            this.ngaydat = ngaydat;
            this.ngaynhan = ngaynhan;
            this.ngaytra = ngaytra;
            this.soluongnguoi = soluongnguoi;
            this.phiphong = phiphong;
            //this.trangthai = trangthai;
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
                // --Mahoadon,MaThuep,Maphong,MahoadonDV,Makh,Manv,Ngaydatphong,Ngaynhanphong,
                //Ngaytraphong,soluongnguoi,phiphong,phidv,thanhtien

            //    string mahd, string maphong, string mahddv, string makh, string manv,
            //DateTime ngaydat, DateTime ngaynhan, DateTime ngaytra,
            //int soluongnguoi, int phiphong, int phidv, int thanhtien
                string mahd = row["Mahoadon"].ToString();
                string mapthue = row["MaThuep"].ToString();
                string maphong = row["Maphong"].ToString();
                string makh = row["Makh"].ToString();
                string manv = row["Manv"].ToString();
                string ngaydat = row["Ngaydatphong"].ToString();
                string ngaynhan = row["Ngaynhanphong"].ToString();
                string ngaytra = row["Ngaytraphong"].ToString();
                string soluongnguoi = row["soluongnguoi"].ToString();
                string phiphong = row["phiphong"].ToString();
                //string trangthai = row["trangthai"].ToString();
                item.Items.Add(mahd.ToString());
                item.Items[i].SubItems.Add(mapthue);
                item.Items[i].SubItems.Add(maphong);
                item.Items[i].SubItems.Add(makh);
                item.Items[i].SubItems.Add(manv);
                item.Items[i].SubItems.Add(ngaydat);
                item.Items[i].SubItems.Add(ngaynhan);
                item.Items[i].SubItems.Add(ngaytra);
                item.Items[i].SubItems.Add(soluongnguoi);
                item.Items[i].SubItems.Add(phiphong);
                //item.Items[i].SubItems.Add(trangthai);
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
          string sql = "select Mahoadon from Hoadon";
          DataTable dt = new DataTable();
          SqlCommand comselect = new SqlCommand(sql, conn);
          SqlDataAdapter da = new SqlDataAdapter();
          da.SelectCommand = comselect;//nó mở một chút ở đây
          da.Fill(dt);
          dt.AcceptChanges();
          foreach (DataRow row in dt.Rows)
          {
              string mahd = row["Mahoadon"].ToString();
              if (String.Compare(mahd.Trim(), key.Trim(), true) == 0)
              {
                  kt = true; break;
              }
          }
          return kt;
      }
        }

    }

