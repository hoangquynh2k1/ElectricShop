using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BUS;
using OJB;
using Newtonsoft.Json;

namespace ElecShop.Controllers
{
    public class HomeController : Controller
    {
        SanPhamBUS SanPhamBuss = new SanPhamBUS();
        UserBUS UserBUS = new UserBUS();
        public ActionResult Index()
        {
            List<SanPham> lsp = SanPhamBuss.GetSanPhams();
            return View(lsp);
        }
        public ActionResult CTSP()
        {
            
            return View();
        }
        public ActionResult AAAAA()
        {

            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public JsonResult LaySP()
        {
            List<SanPham> lsp = SanPhamBuss.GetSanPhams();
            return Json(lsp, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LaySPDong(string ma)
        {
            List<SanPham> lsp = SanPhamBuss.GetSanPhamsLoai(ma);
            return Json(lsp, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LaySPCT(string ma)
        {
            SanPham lsp = SanPhamBuss.GetSanPhamsChiTiet(ma);
            return Json(lsp, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Login(string us,string pw)
        {
            User user = UserBUS.GetUser(us, pw);
            //if(!rp)
            //{
            //    user.Password = "";
            //}    
            if(user == null)
            {
                Session["login"] = "0";
                return Json(new { login = "0", Khach = user }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                Session["login"] = "1";
                Session["khach"] = JsonConvert.SerializeObject(user);
                Session.Timeout = 360;
                return Json(new { login = "1", Khach = user }, JsonRequestBehavior.AllowGet);
            }
            
        }
        public JsonResult Logout()
        {
            Session.Remove("login");
            Session.Remove("khach");
            return Json(0, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Cart()
        {
            return View();
        }
    }
}