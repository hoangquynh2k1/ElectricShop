﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OJB;

namespace ElecShop.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetCarts()
        {
            int sl = 0;
            double ThanhTien = 0;
            List<Cart> ds = new List<Cart>();
            if (Session["giohang"] == null)
            {
                Session["giohang"] = new List<Cart>();
                sl = 0;
                ThanhTien = 0;
            }
            else
            {
                ds = Session["giohang"] as List<Cart>;
                ThanhTien = Convert.ToDouble(ds.Sum(s => s.GiaBan * s.SoLuong));
                sl = int.Parse(ds.Sum(s => s.SoLuong).ToString());

            }
            return Json(new { dsDonHang = ds, SoLuong = sl, TT = ThanhTien }, JsonRequestBehavior.AllowGet);

        }
        public JsonResult AddCart(string Ma, string Ten, string Thong, string MaD, string Kich, int Khoi, string Hinh)
        {
            SanPham s = new SanPham(Ma.Trim(), Ten, Thong, MaD, Kich, Khoi, Hinh);
            if (Session["giohang"] == null)// nếu giỏ hàng chưa được khởi tạo
            {
                Session["giohang"] = new List<Cart>();
            }
            List<Cart> giohang = Session["giohang"] as List<Cart>;
            Cart c = null;
            // sản phầm có trong giỏ hàng tăng số lượng sản phẩm chọn mua tăng lên 1
            if (giohang.Find(m => m.MaSP == s.MaSP) != null) // sản phẩm có trong giỏ hàng
            {

                giohang.Find(m => m.MaSP == s.MaSP).SoLuong = giohang.Find(m => m.MaSP == s.MaSP).SoLuong + 1;
            }
            else  // Sản phẩm chưa có trong giỏ hàng
            {
                c = new Cart();
                c.GiaBan = (int)s.KhoiLuong;
                c.TenSP = s.TenSP;
                c.MaSP = s.MaSP;
                c.SoLuong = 1;
                c.Anh = s.HinhAnh;
                c.ThanhTien = c.GiaBan;
                giohang.Add(c);
            }
            //Session["giohang"] = giohang;
            return Json(new { giohang, status = true }, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult AddCart(SanPham s)
        //{
        //    if (Session["giohang"] == null)// nếu giỏ hàng chưa được khởi tạo
        //    {
        //        Session["giohang"] = new List<Cart>();
        //    }
        //    List<Cart> giohang = Session["giohang"] as List<Cart>;
        //    Cart c = null;
        //    // sản phầm có trong giỏ hàng tăng số lượng sản phẩm chọn mua tăng lên 1
        //    if (giohang.Find(m => m.MaSP == s.MaSP) != null) // sản phẩm có trong giỏ hàng
        //    {

        //        giohang.Find(m => m.MaSP == s.MaSP).SoLuong = giohang.Find(m => m.MaSP == s.MaSP).SoLuong + 1;
        //    }
        //    else  // Sản phẩm chưa có trong giỏ hàng
        //    {
        //        c = new Cart();
        //        c.GiaBan = (int)s.KhoiLuong;
        //        c.TenSP = s.TenSP;
        //        c.MaSP = s.MaSP;
        //        c.SoLuong = 1;
        //        c.ThanhTien = c.GiaBan;
        //        giohang.Add(c);
        //    }
        //    Session["giohang"] = giohang;
        //    return Json(new { status = true }, JsonRequestBehavior.AllowGet);
        //}
    }
}