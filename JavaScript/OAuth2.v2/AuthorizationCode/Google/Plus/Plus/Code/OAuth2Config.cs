using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Linq;
using System.Threading.Tasks;

namespace Plus.Code
{
    public abstract class OAuth2Config
    {
        public abstract string AuthorizationServerBaseUrl { get; }
        public string AuthorizationCodeRedirectBaseUri { get; protected set; }
        public string ClientId { get; protected set; }
        public string Scope { get; protected set; }
        public virtual string ResponseType => "code";
        public string State { get; protected set; }


        public abstract string AccessTokenBaseUrl { get; }
        public string ClientSecret { get; protected set; }
        public string AccessTokenRedirectBaseUri { get; protected set; }
        public string AuthorizationCode { get; protected set; }
        public string GrantType => "authorization_code";



        public string AccessToken { get; set; }
        public long AccessTokenExpiresInSeconds { get; set; }
        public string AccessTokenType { get; set; }
        public string RefreshToken { get; set; }
        public string Error { get; set; }


        public abstract string ResourceServerBaseUrl { get; }
        public string Fields { get; set; }

        public virtual string GetSignInUrl(
            string clientId, 
            string authorizationCodeRedirectBaseUri, 
            string scope, 
            string state)
        {
            this.ClientId = clientId;
            this.AuthorizationCodeRedirectBaseUri = authorizationCodeRedirectBaseUri;
            this.Scope = scope;
            this.State = state;

            return this.MakeUrlWithQueryString(this.AuthorizationServerBaseUrl,
                new Dictionary<string, string>
                {
                    ["client_id"] = ClientId,
                    ["redirect_uri"] = AuthorizationCodeRedirectBaseUri,
                    ["response_type"] = ResponseType,
                    ["scope"] = Scope,
                    ["state"] = State,

                });
        }

        protected virtual string MakeUrlWithQueryString(string baseUrl, 
            IEnumerable<KeyValuePair<string, string>> parameters)
        {
            if (string.IsNullOrEmpty(baseUrl))
            {
                throw new ArgumentNullException(nameof(baseUrl));
            }

            if (parameters == null || parameters.Count() == 0)
            {
                return baseUrl;
            }

            var builder = new StringBuilder(baseUrl);

            if (!baseUrl.Contains("?"))
            {
                if (!baseUrl.EndsWith("?"))
                {
                    builder.Append("?");
                }
            }
            else
            {
                if (!baseUrl.EndsWith("&"))
                {
                    builder.Append("&");
                }
            }

            foreach(var kvp in parameters)
            {
                builder.AppendFormat($"{kvp.Key}={kvp.Value}&");
            }

            var value = builder.ToString();

            if (value.EndsWith("&"))
            {
                value = value.Substring(0, value.Length - 1);
            }

            return value;
        }

        public virtual string GetAuthorizationCode(HttpRequestBase request, string previousState)
        {
            var error = request.QueryString["error"];

            if (!string.IsNullOrEmpty(error))
            {
                throw new UserCancelledException(error);
            }

            var state = request.QueryString["state"];
            if (!string.IsNullOrEmpty(previousState) && previousState != state)
            {
                throw new InvalidStateException();
            }

            var authorizationCode = request.QueryString["code"];

            if (string.IsNullOrEmpty(authorizationCode))
            {
                throw new Exception("The server returned neither an authorization code nor an error.");
            }

            return authorizationCode;
        }

        public async virtual Task<string> GetAccessTokenAsync(
            string clientId, 
            string clientSecret, 
            string accessTokenRedirectBaseUri, 
            string authorizationCode,
            string state)
        {
            this.ClientId = clientId;
            this.ClientSecret = clientSecret;
            this.AccessTokenRedirectBaseUri = accessTokenRedirectBaseUri;
            this.AuthorizationCode = authorizationCode;
            this.State = state;

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(AccessTokenBaseUrl, 
                    new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                        ["client_id"] = ClientId,
                        ["client_secret"] = ClientSecret,
                        ["code"] = AuthorizationCode,
                        ["grant_type"] = GrantType,
                        ["redirect_uri"] = AccessTokenRedirectBaseUri,
                        ["state"] = State
                    }
                ));

                var json = await response.Content.ReadAsStringAsync();

            }
        }

        protected abstract AccessTokenResult DeserializeAccessTokenResponse(string json)
        {

        }
    }

    public class AccessTokenResult
    {
        public bool Successful { get; set; }
        public string AccessToken { get; set; }
        public long ExpiresInSeconds { get; set; }
        public string RefreshToken { get; set; }
        public string TokenType { get; set; }

        public string Error { get; set; }
    }

    public class UserCancelledException : Exception
    {
        private string _message = null;

        public override string Message => _message;
        public UserCancelledException(string error = null) : base()
        {
            _message = "The user cancelled out of either the login dialog or the consent dialog.";
            if (!string.IsNullOrEmpty(error))
            {
                _message += string.Format($"Error received from OAuth proivider: ${error}");
            }
        }
    }
    public class InvalidStateException : Exception
    {
        public override string Message =>
            "The XSRF state did not match. Are you browing this website on a computer that you don't own? Like one in a library or an airport or a hotel room or a cafe or that of a friend? It is recommended that you do not browse this website on a computer. The security of this computer may have been compromised.";
    }
}