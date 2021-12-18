using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BUS;
using OJB;

namespace ElecShop.Controllers
{
    public class DatHangController : Controller
    {
        // GET: DatHang
        public ActionResult Index()
        {
            return View();
        }
        //        [HttpGet]
        //        //public JsonResult GetCustomer()
        //        {
        //            //User user = UserBUS.GetUser(us, pw);
        //            ////if(!rp)
        //            ////{
        //            ////    user.Password = "";
        //            ////}    
        //            //if (user == null)
        //            //{
        //            //    Session["login"] = "0";
        //            //    return Json(new { login = "0", Khach = user }, JsonRequestBehavior.AllowGet);
        //            //}
        //            //else
        //            //{
        //            //    Session["login"] = "1";
        //            //    Session["khach"] = JsonConvert.SerializeObject(user);
        //            //    Session.Timeout = 360;
        //            //    return Json(new { login = "1", Khach = user }, JsonRequestBehavior.AllowGet);
        //            //}

        //            //CustomerBUS lb = new CustomerBUS();
        //            //Customer u = lb.ReadCustomer();
        //            //string l = "0";
        //            //if (Session["login"] != null)
        //            //{
        //            //    l = Session["login"].ToString();
        //            //}
        //            //string p = "";
        //            //if (l == "1")
        //            //{
        //            //    //string t = Session["khach"].ToString();
        //            //    Session["khach"] = JsonConvert.SerializeObject(u);
        //            //    //u = JsonConvert.DeserializeObject<Customer>(t) as Customer;

        //            //}
        //            //return Json(new { login = 1, khach = u }, JsonRequestBehavior.AllowGet);
        //        }
    }
}