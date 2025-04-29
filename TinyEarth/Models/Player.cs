using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace TinyEarth.Models
{
    public class PlayerResponse
    {
        [JsonProperty("data")]
        public List<PlayerData> Data { get; set; }
    }

    public class PlayerData
    {
        [JsonProperty("name")]
        public string NameHtml { get; set; }

        [JsonProperty("sessions")]
        public string Sessions { get; set; }

        [JsonProperty("activePlaytime")]
        public Playtime ActivePlaytime { get; set; }

        [JsonProperty("index")]
        public IndexData Index { get; set; }

        [JsonProperty("registered")]
        public TimestampData Registered { get; set; }

        [JsonProperty("seen")]
        public TimestampData Seen { get; set; }

        [JsonProperty("permissionGroups")]
        public DisplayValue PermissionGroups { get; set; }

        [JsonProperty("primaryGroup")]
        public DisplayValue PrimaryGroup { get; set; }


        [JsonProperty("geolocation")]
        public string Geolocation { get; set; }

        // Udtræk navn uden HTML-tags
        public string PlainName => HtmlRemovalUtility.ExtractName(NameHtml);
    }

    public class Playtime
    {
        [JsonProperty("d")]
        public string Display { get; set; }

        [JsonProperty("v")]
        public string Value { get; set; }
    }

    public class IndexData
    {
        [JsonProperty("d")]
        public string Display { get; set; }

        [JsonProperty("v")]
        public string Value { get; set; }
    }

    public class TimestampData
    {
        [JsonProperty("d")]
        public string Display { get; set; }

        [JsonProperty("v")]
        public string Value { get; set; }
    }

    public class DisplayValue
    {
        [JsonProperty("d")]
        public string Display { get; set; }

        [JsonProperty("v")]
        public string Value { get; set; }
    }
    public static class HtmlRemovalUtility
    {
        public static string ExtractName(string html)
        {
            if (string.IsNullOrEmpty(html))
                return string.Empty;

            // Simpelt regex for at fjerne HTML-tags
            var match = Regex.Match(html, @">(.+?)<");
            return match.Success ? match.Groups[1].Value : html;
        }
    }
}
