using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EncoreTIX.Models
{
    public class ExternalLinks
    {
        [JsonPropertyName("youtube")]
        public List<ExternalLink> Youtube { get; set; } = new List<ExternalLink>();

        [JsonPropertyName("twitter")]
        public List<ExternalLink> Twitter { get; set; } = new List<ExternalLink>();

        [JsonPropertyName("facebook")]
        public List<ExternalLink> Facebook { get; set; } = new List<ExternalLink>();

        [JsonPropertyName("instagram")]
        public List<ExternalLink> Instagram { get; set; } = new List<ExternalLink>();

        [JsonPropertyName("homepage")]
        public List<ExternalLink> Homepage { get; set; } = new List<ExternalLink>();
    }

    public class ExternalLink
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}