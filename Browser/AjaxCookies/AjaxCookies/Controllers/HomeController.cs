using System;
using System.Web.Mvc;

namespace AjaxCookies.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ContentResult Message()
        {
            return Content("The time on the server is now " + DateTimeOffset.Now.ToString());
        }
    }
}