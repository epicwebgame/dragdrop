using People.Code;
using System.Configuration;
using System.Web.Mvc;

namespace People.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var googleOAuth2Config = new GooglePeopleOAuth2Config();
            var clientId = ConfigurationManager.AppSettings["GooglePlusOAuth2ClientId"];
            var state = "abcd";

            HttpContext.Session["OAuth2XSRFState"] = state;

            if (string.IsNullOrEmpty(clientId))
            {
                return new HttpStatusCodeResult(500, "The application hasn't been configured correctly. It will not take any requests.");
            }

            var signInLink = googleOAuth2Config.GetSignInUrl(
                clientId,
                "https://localhost:44348/OAuth2/Google/People/AuthorizationCode",
                "https://www.googleapis.com/auth/plus.login https://www.googleapis.com/auth/userinfo.email",
                state);

            return View((object)signInLink);
        }        
    }
}