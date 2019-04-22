using Newtonsoft.Json;

namespace People.Code
{
    public class Name
    {
        [JsonProperty("givenName")]
        public string FirstName { get; set; }

        [JsonProperty("familyName")]
        public string LastName { get; set; }

        [JsonProperty("displayName")]
        public string FullName;
    }
}