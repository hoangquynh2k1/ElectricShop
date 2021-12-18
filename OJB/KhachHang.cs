using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OJB
{
    public class KhachHang
    {
        public string MaKH;
        public string HoTen;
        public int NamSinh;
        public string GioiTinh;
        public string DiaChi;
        public string SoDT;
        public string Email;
        public KhachHang()
        { }
        public KhachHang(string ma,string hoten,string nam,string gioi,string dia,string sodt,string email)
        {
            MaKH = ma;
            HoTen = hoten;
            NamSinh = int.Parse(nam);
            GioiTinh = gioi;
            DiaChi = dia;
            SoDT = sodt;
            Email = email;
        }
    }
}
