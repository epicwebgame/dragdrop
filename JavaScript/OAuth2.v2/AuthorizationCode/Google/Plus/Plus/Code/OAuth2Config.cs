using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

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


        public AccessTokenResult AccessTokenResult { get; protected set; }

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
            if (previousState != state)
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

        public async virtual Task<AccessTokenResult> GetAccessTokenAsync(
            string clientId, 
            string clientSecret, 
            string accessTokenRedirectBaseUri, 
            string authorizationCode)
        {
            this.ClientId = clientId;
            this.ClientSecret = clientSecret;
            this.AccessTokenRedirectBaseUri = accessTokenRedirectBaseUri;
            this.AuthorizationCode = authorizationCode;
            
            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(AccessTokenBaseUrl, 
                    new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                        ["client_id"] = ClientId,
                        ["client_secret"] = ClientSecret,
                        ["code"] = AuthorizationCode,
                        ["grant_type"] = GrantType,
                        ["redirect_uri"] = AccessTokenRedirectBaseUri
                    }
                ));

                var json = await response.Content.ReadAsStringAsync();
                var accessTokenResult = JsonConvert.DeserializeObject<AccessTokenResult>(json);
                this.AccessTokenResult = accessTokenResult;
                return accessTokenResult;
            }
        }
    }

    public class AccessTokenResult
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public long ExpiresInSeconds { get; set; }

        [JsonProperty("id_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        public string Error { get; set; }

        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }

        public string Scope { get; set; }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Error))
            {
                return string.Format($"Error: {Error}, {ErrorDescription}");
            }
            else
            {
                return string.Format(
                    $"Access Token: {AccessToken}<br />Expires in: {ExpiresInSeconds} seconds<br />Refresh Token: {RefreshToken}<br />Token Type: {TokenType}.");
            }
        }
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
            "Are you browing this website on a computer that you don't own? " + 
            "Like one in a library or an airport or a hotel room or a cafe or that of a friend? " + 
            "It is recommended that you do not browse this website on this computer. " + 
            "The security of this computer may have been compromised.";
    }
}