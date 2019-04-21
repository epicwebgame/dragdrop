using System.Web.Mvc;

namespace Plus.Controllers
{
    [RoutePrefix("~/OAuth2/Google/Plus")]
    public class GooglePlusOAuth2Controller : Controller
    {
        public ActionResult AuthorizationCode()
        {
            return View();
        }

        public ActionResult AccessToken()
        {
            return View();
        }
    }
}