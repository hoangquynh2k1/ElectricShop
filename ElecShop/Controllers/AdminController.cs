using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BUS;
using OJB;


namespace ElecShop.Controllers
{
    public class AdminController : Controller
    {
        SanPhamBUS SanPhamBuss = new SanPhamBUS();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult LaySP1()
        {
            List<SanPham> lsp = SanPhamBuss.GetSanPhams();
            return Json(lsp, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Them(string Ma, string Ten, string Thong, string MaD, string Kich, int Khoi, string Hinh)
        {
            SanPham sanPham = new SanPham(Ma.Trim(), Ten, Thong, MaD, Kich, Khoi, Hinh);
            string s = SanPhamBuss.Them(sanPham);
            return Json(s, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Xoa(string ma)
        {
            string s= SanPhamBuss.Xoa(ma);
            return Json(s,JsonRequestBehavior.AllowGet);
        }
        public JsonResult Sua(string Ma, string Ten, string Thong, string MaD, string Kich, int Khoi, string Hinh)
        {
            SanPham sanPham = new SanPham(Ma.Trim(),Ten,Thong,MaD,Kich,Khoi,Hinh);
            string s = SanPhamBuss.Sua(sanPham);
            return Json(s, JsonRequestBehavior.AllowGet);
        }
    }
}