using Plus.Code;
using System;
using System.Web.Mvc;

namespace Plus.Controllers
{
    [RoutePrefix("OAuth2/Google/Plus")]
    public class GooglePlusOAuth2Controller : Controller
    {
        [Route("AuthorizationCode")]
        public ActionResult AuthorizationCode()
        {
            try
            {
                var config = new GooglePlusOAuth2Config();

                var authorizationCode = config.GetAuthorizationCode(Request, 
                    HttpContext.Session["OAuth2XSRFState"]?.ToString());

                return Content(authorizationCode);
            }
            catch(UserCancelledException userCancelled)
            {
                return View("~/Views/GooglePlusOAuth2/UserCancelled.cshtml", userCancelled.Message);
            }
            catch(InvalidStateException invalidState)
            {
                return View("~/Views/GooglePlusOAuth2/InvalidState.cshtml", invalidState.Message);
            }
            catch (Exception ex)
            {
                return View("~/Views/GooglePlusOAuth2/Error.cshtml", ex.Message);
            }
        }

        public ActionResult AccessToken()
        {
            return View();
        }
    }
}