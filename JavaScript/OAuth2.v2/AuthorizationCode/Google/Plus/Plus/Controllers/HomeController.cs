using System.Web.Mvc;

namespace Plus.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var signInLink = string.Empty;
            return View(signInLink);
        }
    }
}