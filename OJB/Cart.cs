using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OJB
{
    public class Cart
    {
        public string MaSP { get; set; }
        public string MaLoai { get; set; }
        public string TenSP { get; set; }
        public string Anh { get; set; }
        public int SoLuong { get; set; }
        public int GiaBan { get; set; }
        public int ThanhTien { get; set; }
        public Cart(string masp, string maloai, string tensp, string anh, int soluong, int giaban, int thanhtien)
        {
            this.MaSP = masp;
            this.MaLoai = maloai;
            this.TenSP = tensp;
            this.Anh = anh;
            this.SoLuong = soluong;
            this.GiaBan = giaban;
            this.ThanhTien = thanhtien;

        }
        public Cart() { }
    }
}
