using Newtonsoft.Json;

namespace Plus.Code
{
    public class Name
    {
        [JsonProperty("givenName")]
        public string FirstName { get; set; }

        [JsonProperty("familyName")]
        public string LastName { get; set; }
    }
}