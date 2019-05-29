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
            var quote = StaticData.GetQuote();

            return Content(quote);
        }
    }
}