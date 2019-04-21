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
                    "https://localhost:44374/OAuth2/Google/Plus/AuthorizationCode",
                    authorizationCode);

                if (!string.IsNullOrEmpty(accessTokenResult.Error))
                {
                    return View("~/Views/GooglePlusOAuth2/Error.cshtml", (object)accessTokenResult.Error);
                }
                else
                {
                    GooglePlusAPIData data = 
                        await config.GetDataAsync<GooglePlusAPIData>("emails/value, displayName, names(givenName, familyName)");
                    
                    if (data == null)
                    {
                        return View("~/Views/GooglePlusOAuth2/Error.cshtml", "Unable to get data from the server.");
                    }

                    return View("~/Views/GooglePlusOAuth2/Welcome.cshtml", data);
                }
            }
            catch(UserCancelledException userCancelled)
            {
                return View("~/Views/GooglePlusOAuth2/UserCancelled.cshtml", (object)userCancelled.Message);
            }
            catch(InvalidStateException invalidState)
            {
                return View("~/Views/GooglePlusOAuth2/InvalidState.cshtml", (object)invalidState.Message);
            }
            catch (Exception ex)
            {
                return View("~/Views/GooglePlusOAuth2/Error.cshtml", (object)ex.Message);
            }
        }
    }
}