using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using OJB;

namespace DAO
{
    public class KhachHangDAO
    {
        DataHelper dh = new DataHelper();
        public KhachHang GetKhachHang(string KHID)
        {
            string sql = "select*from KhachHang where MaKH='" + KHID +"'";
            DataTable dt = dh.GetDataTable(sql);
            if (dt.Rows.Count <= 0)
                return null;
            else
            {
                KhachHang us = new KhachHang(
                    dt.Rows[0][0].ToString(),
                    dt.Rows[0][1].ToString(),
                    dt.Rows[0][2].ToString(),
                    dt.Rows[0][3].ToString(),
                    dt.Rows[0][4].ToString(),
                    dt.Rows[0][5].ToString(),
                    dt.Rows[0][6].ToString());
                return us;
            }
        }
        public KhachHang ReadCustomer()
        {
            DataHelper dh = new DataHelper();
            string sql = "Select *from KhachHang";
            DataTable dt = dh.GetDataTable(sql);
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else
            {
                KhachHang cs = new KhachHang(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][3].ToString(), dt.Rows[0][4].ToString(), dt.Rows[0][5].ToString(), dt.Rows[0][6].ToString());
                return cs;
            }
        }
    }
}
