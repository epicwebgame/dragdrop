using System.Web;
using System.Web.Mvc;

namespace AjaxCookies.Controllers
{
    public class LoginController : Controller
    {
        [HttpPost]
        public JsonResult Index()
        {
            var cookie = new HttpCookie("X-Foo-Auth", "abcde");
            cookie.HttpOnly = true;
            Response.SetCookie(cookie);

            return Json(true);
        }
    }
}