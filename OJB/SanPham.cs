using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OJB
{
    public class SanPham
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string ThongSoKT { get; set; }
        public string MaDong { get; set; }
        public int KichThuoc { get; set; }
        public int KhoiLuong { get; set; }
        public string HinhAnh { get; set; }
        public SanPham(string MaSP, string TenSP, string ThongSoKT, string MaDong, int KichThuoc, int KhoiLuong, string HinhAnh)
        {
            this.MaSP = MaSP;
            this.TenSP = TenSP;
            this.ThongSoKT = ThongSoKT;
            this.MaDong = MaDong;
            this.KichThuoc = KichThuoc;
            this.KhoiLuong = KhoiLuong;
            this.HinhAnh = HinhAnh;
        }
    }
}
