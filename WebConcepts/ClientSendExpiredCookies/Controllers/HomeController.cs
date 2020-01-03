using System;
using System.Web.Mvc;

namespace ClientSendExpiredCookies.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ResetAuthCookieIfExists();
            return View();
        }
        public JsonResult Whatever()
        {
            ResetAuthCookieIfExists();
            return Json(new object(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteAuthCookie()
        {
            DeleteAuthCookieIfExists();
            return Json(new object(), JsonRequestBehavior.AllowGet);
        }
        private void DeleteAuthCookieIfExists()
        {
            Response.Cookies["AUTH"].Expires = DateTime.Now.AddSeconds(-1);
        }
        private void ResetAuthCookieIfExists()
        {
            int interval = Request.Cookies["AUTH"] == null ? 60 : 50;

            var expiry = DateTime.UtcNow.AddSeconds(interval);

            var epochTime = expiry.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;

            Response.Cookies.Set(new System.Web.HttpCookie("AUTH")
            {   
                Value = epochTime.ToString(),
                Expires = expiry
            });
        }
    }
}