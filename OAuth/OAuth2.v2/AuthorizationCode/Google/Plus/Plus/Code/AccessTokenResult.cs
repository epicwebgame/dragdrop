using Newtonsoft.Json;

namespace Plus.Code
{
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
}