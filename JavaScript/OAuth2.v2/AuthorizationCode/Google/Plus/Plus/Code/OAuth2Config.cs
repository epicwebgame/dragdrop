using System.Text;

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


        public string ClientSecret { get; set; }
        public string AccessTokenRedirectBaseUri { get; }
        public string GrantType { get; set; }
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

            var builder = new StringBuilder(this.AuthorizationServerBaseUrl);

            builder.AppendFormat($"client_id={ClientId}&");
            builder.AppendFormat($"redirect_uri={AuthorizationCodeRedirectBaseUri}&");
            builder.AppendFormat($"response_type={ResponseType}&");
            builder.AppendFormat($"scope={Scope}&");
            builder.AppendFormat($"state={State}");

            return builder.ToString();
        }
    }
}