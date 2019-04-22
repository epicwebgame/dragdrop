using People.Code;
using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace People.Controllers
{
    [RoutePrefix("OAuth2/Google/People")]
    public class GooglePeopleOAuth2Controller : Controller
    {
        [Route("AuthorizationCode")]
        public async Task<ActionResult> AuthorizationCodeAsync()
        {
            try
            {
                var config = new GooglePeopleOAuth2Config();
                var state = Session["OAuth2XSRFState"]?.ToString();
                var clientId = ConfigurationManager.AppSettings["GooglePeopleOAuth2ClientId"];
                var clientSecret = ConfigurationManager.AppSettings["GooglePeopleOAuth2ClientSecret"];

                var authorizationCode = config.GetAuthorizationCode(Request, state);

                var accessTokenResult = await config.GetAccessTokenAsync(
                    clientId,
                    clientSecret,
                    "https://localhost:44348/OAuth2/Google/People/AuthorizationCode",
                    authorizationCode);

                if (!string.IsNullOrEmpty(accessTokenResult.Error))
                {
                    return View("~/Views/GooglePeopleOAuth2/Error.cshtml", (object)accessTokenResult.Error);
                }
                else
                {
                    var data = await config.GetDataAsync("emailAddresses/value,names(displayName,familyName,givenName)");

                    if (data == null)
                    {
                        return View("~/Views/GooglePeopleOAuth2/Error.cshtml", "Unable to get data from the server.");
                    }

                    return View("~/Views/GooglePeopleOAuth2/Welcome.cshtml", data);
                }
            }
            catch (UserCancelledException userCancelled)
            {
                return View("~/Views/GooglePeopleOAuth2/UserCancelled.cshtml", (object)userCancelled.Message);
            }
            catch (InvalidStateException invalidState)
            {
                return View("~/Views/GooglePeopleOAuth2/InvalidState.cshtml", (object)invalidState.Message);
            }
            catch (Exception ex)
            {
                return View("~/Views/GooglePeopleOAuth2/Error.cshtml", (object)ex.Message);
            }
        }
    }
}