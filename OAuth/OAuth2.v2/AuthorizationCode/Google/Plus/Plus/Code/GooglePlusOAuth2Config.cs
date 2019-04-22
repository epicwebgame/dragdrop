using Newtonsoft.Json;
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

        public virtual async Task<GooglePlusAPIData> GetDataAsync(string fields)
        {
            if (string.IsNullOrEmpty(this.AccessTokenResult.AccessToken))
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

                string json = null;

                try
                {
                    json = await client.GetStringAsync(url);
                }
                catch(Exception ex)
                {
                    Debug.Print(ex.ToString());
                    Debugger.Break();
                    throw ex;
                }

                try
                {
                    var googlePlusApiData = JsonConvert.DeserializeObject<GooglePlusAPIData>(json);

                    return googlePlusApiData;
                }
                catch(Exception ex)
                {
                    Debug.Print(ex.ToString());
                    Debugger.Break();
                    throw ex;
                }
            }
        }
    }

    public class GooglePlusAPIData
    {
        public Name Name;

        [JsonProperty("displayName")]
        public string FullName;

        public List<Email> Emails;
    }

    public class Name
    {
        [JsonProperty("givenName")]
        public string FirstName { get; set; }

        [JsonProperty("familyName")]
        public string LastName { get; set; }
    }

    public class Email
    {
        public string Value { get; set; }
    }
}