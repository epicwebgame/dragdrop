using Plus.Code;
using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Plus.Controllers
{
    [RoutePrefix("OAuth2/Google/Plus")]
    public class GooglePlusOAuth2Controller : Controller
    {
        [Route("AuthorizationCode")]
        public async Task<ActionResult> AuthorizationCodeAsync()
        {
            try
            {
                var config = new GooglePlusOAuth2Config();
                var state = Session["OAuth2XSRFState"]?.ToString();
                var clientId = ConfigurationManager.AppSettings["GooglePlusOAuth2ClientId"];
                var clientSecret = ConfigurationManager.AppSettings["GooglePlusOAuth2ClientSecret"];

                var authorizationCode = config.GetAuthorizationCode(Request, state);

                var accessTokenResult = await config.GetAccessTokenAsync(
                    clientId,
                    clientSecret,
                    "https://localhost:44374/OAuth2/Google/Plus/AccessToken",
                    authorizationCode,
                    state);

                if (!string.IsNullOrEmpty(accessTokenResult.Error))
                {
                    return View("~/Views/GooglePlusOAuth2/Error.cshtml", accessTokenResult.Error);
                }
                else
                {

                }

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