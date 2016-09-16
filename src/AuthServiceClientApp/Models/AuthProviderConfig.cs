using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthServiceClientApp.Models
{
    public class AuthProviderConfig
    {
        public string Identifier { get; set; }

        public Dictionary<string, string> DisplayName { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Grants GrantType { get; set; }

        public bool Preferred { get; set; }
    }
}