using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using OJB;

namespace BUS
{
    public class SanPhamBUS
    {
        SanPhamDAO SanPhamDAO = new SanPhamDAO();
        public List<SanPham> GetSanPhams()
        {
            return SanPhamDAO.GetSanPham();
        }
        public List<SanPham> GetSanPhamsLoai(string maloai)
        {
            return SanPhamDAO.GetSanPhamLoai(maloai);
        }
        public SanPham GetSanPhamsChiTiet(string maloai)
        {
            List<SanPham> sanphams = SanPhamDAO.GetSanPham();
            for (int i =0;i<sanphams.Count;i++)
            {
                if (sanphams[i].MaSP == maloai)
                    return sanphams[i];
            }
            return null;
        }
        public string Them(SanPham sp)
        {
            return SanPhamDAO.ThemSP(sp);
        }
        public string Sua(SanPham sp)
        {
            return SanPhamDAO.SuaSP(sp);
        }
        public string Xoa(string sp)
        {
            return SanPhamDAO.Xoa(sp);
        }
    }
}
