using Newtonsoft.Json;
using System.Collections.Generic;

namespace Plus.Code
{
    public class GooglePlusAPIData
    {
        public Name Name;

        [JsonProperty("displayName")]
        public string FullName;

        public List<Email> Emails;
    }
}