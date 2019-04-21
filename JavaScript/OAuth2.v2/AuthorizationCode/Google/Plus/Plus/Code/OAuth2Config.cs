namespace Plus.Code
{
    public class OAuth2Config
    {
        public string AuthorizationCodeRedirectBaseUri { get; set; }
        public string AccessTokenRedirectBaseUri { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string State { get; set; }
        public string Scope { get; set; }
        public string AuthorizationServerUrl { get; set; }
        public string ResourceServerUrl { get; set; }
        public string ResponseType { get; set; }
        public string Fields { get; set; }
        public string GrantType { get; set; }
    }
}