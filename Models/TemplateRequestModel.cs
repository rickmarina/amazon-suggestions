using System.Text.Json.Serialization;

#nullable disable
[Serializable]
public class TemplateRequestModel
    {
        public string limit { get; set; }
        public string prefix { get; set; }

        [JsonPropertyName("page-type")]
        public string pagetype { get; set; }
        public string alias { get; set; }

        [JsonPropertyName("site-variant")]
        public string sitevariant { get; set; }
        public string version { get; set; }
        public string @event { get; set; }
        public string wc { get; set; }
        public string lop { get; set; }

        [JsonPropertyName("last-prefix")]
        public string lastprefix { get; set; }

        [JsonPropertyName("avg-ks-time")]
        public string avgkstime { get; set; }
        public string fb { get; set; }

        [JsonPropertyName("session-id")]
        public string sessionid { get; set; }

        [JsonPropertyName("request-id")]
        public string requestid { get; set; }
        public string mid { get; set; }

        [JsonPropertyName("plain-mid")]
        public string plainmid { get; set; }

        [JsonPropertyName("client-info")]
        public string clientinfo { get; set; }
    }

