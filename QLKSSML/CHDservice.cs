using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLKSSML
{
    class CHDservice
    {
        SqlConnection conn = new SqlConnection(@"Data Source=UFYNDEVZ5K1UKA9\SQLEXPRESS;Initial Catalog=QLKS_SML;Integrated Security=True");

        //MahdDV,Makh,MaDV,TenDV,MaPhong,Manv,giaDV,ngaybatdaudv,ngaykethucdv,phidv
        string mahddv, makh, madv, tendv, maphong, manv;
        DateTime ngaybatdau, ngaykethuc;
        int giadv, phidv;
        public CHDservice() { }
        public CHDservice(string mahddv, string makh, string madv, string tendv, string maphong, string manv, int giadv,
            DateTime ngaybatdau, DateTime ngaykethuc,int phidv ) {
                this.mahddv = mahddv;
                this.makh = makh;
                this.madv = madv;
                this.tendv = tendv;
                this.maphong = maphong;
                this.manv = manv;
                this.giadv = giadv;
                this.ngaybatdau = ngaybatdau;
                this.ngaykethuc = ngaykethuc;
                this.phidv = phidv;
        }

//HIỂN THỊ 
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
                //--MahdDV,Makh,MaDV,TenDV,MaPhong,Manv,giaDV,ngaybatdaudv,ngaykethucdv,phidv
                string mahddv = row["MahoadonDV"].ToString();
                string makh = row["Makh"].ToString();
                string maphong = row["MaPhong"].ToString();
                string tendv = row["TenDV"].ToString();
                string giadv = row["giaDV"].ToString();
                string ngaybatdau = row["ngaybatdaudv"].ToString();
                string ngaykethuc = row["ngaykethucdv"].ToString();
                string phidv = row["phidv"].ToString();
                item.Items.Add(mahddv.ToString());
                item.Items[i].SubItems.Add(makh);
                item.Items[i].SubItems.Add(maphong);
                item.Items[i].SubItems.Add(tendv);
                item.Items[i].SubItems.Add(giadv);
                item.Items[i].SubItems.Add(ngaybatdau);
                item.Items[i].SubItems.Add(ngaykethuc);
                item.Items[i].SubItems.Add(phidv);
                i = i + 1;
            }
        }
        public void hienthi_listviewmain(ListView item, string sql)
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
                //--MahdDV,Makh,MaDV,TenDV,MaPhong,Manv,giaDV,ngaybatdaudv,ngaykethucdv,phidv
                string mahddv = row["MahoadonDV"].ToString();
                string makh = row["Makh"].ToString();
                string madv = row["MaDV"].ToString();
                string tendv = row["TenDV"].ToString();
                string maphong = row["MaPhong"].ToString();
                string manv = row["Manv"].ToString();
                string giadv = row["giaDV"].ToString();
                string ngaybatdau = row["ngaybatdaudv"].ToString();
                string ngaykethuc = row["ngaykethucdv"].ToString();
                string phidv = row["phidv"].ToString();
                item.Items.Add(mahddv.ToString());
                item.Items[i].SubItems.Add(makh);
                item.Items[i].SubItems.Add(madv);
                item.Items[i].SubItems.Add(tendv);
                item.Items[i].SubItems.Add(maphong);
                item.Items[i].SubItems.Add(manv);
                item.Items[i].SubItems.Add(giadv);
                item.Items[i].SubItems.Add(ngaybatdau);
                item.Items[i].SubItems.Add(ngaykethuc);
                item.Items[i].SubItems.Add(phidv);
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
            string sql = "select MahoadonDV from HDDichVu";
            DataTable dt = new DataTable();
            SqlCommand comselect = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comselect;//nó mở một chút ở đây
            da.Fill(dt);
            dt.AcceptChanges();
            foreach (DataRow row in dt.Rows)
            {
                string mahddv = row["MahoadonDV"].ToString();
                if (String.Compare(mahddv.Trim(), key.Trim(), true) == 0)
                {
                    kt = true; break;
                }
            }
            return kt;
        }

    }
}
