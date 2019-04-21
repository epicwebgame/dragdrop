using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Plus.Code
{
    public class GooglePlusOAuth2Config : OAuth2Config
    {
        public override string AuthorizationServerBaseUrl 
            => "https://accounts.google.com/o/oauth2/v2/auth";

        public override string AccessTokenBaseUrl =>
            "https://www.googleapis.com/oauth2/v4/token";
        public override string ResourceServerBaseUrl 
            => "https://www.googleapis.com/plus/v1/people/me?";

        public override Task<T> GetDataAsync<T>(string fields)
        {
            if (!string.IsNullOrEmpty(this.AccessTokenResult.AccessToken))
            {
                throw new Exception("Access token missing. Cannot get data.");
            }

            var parameters = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(fields))
            {
                this.Fields = fields;
                parameters.Add("fields", this.Fields);
            }

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = 
                    new AuthenticationHeaderValue("Bearer", this.AccessTokenResult.AccessToken);

                var url = this.MakeUrlWithQueryString(this.ResourceServerBaseUrl, parameters);

                var json = client.GetStringAsync(url);

                Debugger.Break();
            }
        }
    }
}