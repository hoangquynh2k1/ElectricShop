using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OJB;
using System.Data;

namespace DAO
{
    public class SanPhamDAO
    {
        DataHelper dh = new DataHelper();
        public List<SanPham> GetSanPham()
        {
            DataTable dt = dh.FillDataTable("Select *  from SP");
            return ToList(dt);
        }
        public List<SanPham> GetSanPhamLoai(string madong)
        {
            DataTable dt = dh.FillDataTable("Select *  from SP where MaDong =" + madong + ";");
            return ToList(dt);
        }
        public List<SanPham> ToList(DataTable dt)
        {
            List<SanPham> l = new List<SanPham>();
            foreach (DataRow dr in dt.Rows)
            {
                SanPham sp = new SanPham(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), int.Parse(dr[5].ToString()), dr[6].ToString());
                l.Add(sp);
            }
            return l;
        }
        public string ThemSP(SanPham sp)
        {
            string sql = "Insert into SP VALUES('" + sp.MaSP + "','" + sp.TenSP + "','" + ","
                + sp.ThongSoKT + "','" + sp.MaDong + "'," + sp.KichThuoc + "," + sp.KhoiLuong + ",'" + sp.HinhAnh+"');";
            return dh.ExecuteNonQuery(sql);
        }
        public string SuaSP(SanPham sp)
        {
            string sql = "UPDATE [dbo].[SP] SET[TenSP] = N'"+sp.TenSP+ "'     ,[ThongSoKT] = N'" + sp.ThongSoKT + "'      ,[MaDong] = '" + sp.MaDong + "'      ,[KichThuoc] = N'" + sp.KichThuoc + "'      ,[KhoiLuong] = " + sp.KhoiLuong + "      ,[HinhAnh] = N'" + sp.HinhAnh + "' WHERE[MaSP] = '" + sp.MaSP + "'";
            return dh.ExecuteNonQuery(sql);
        }
        public string Xoa(string sp)
        {
            string sql = "Delete from SP where MaSP= '" + sp+"';";
            return dh.ExecuteNonQuery(sql);
        }
    }
}
