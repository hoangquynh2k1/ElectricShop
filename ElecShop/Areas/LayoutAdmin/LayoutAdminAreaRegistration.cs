using System.Web.Mvc;

namespace ElecShop.Areas.LayoutAdmin
{
    public class LayoutAdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "LayoutAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "LayoutAdmin_default",
                "LayoutAdmin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}