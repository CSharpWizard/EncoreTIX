using System.Text.Json.Serialization;

namespace EncoreTIX.Models
{
    public class Attraction
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("images")]
        public List<Image> Images { get; set; } = new List<Image>();

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("externalLinks")]
        public ExternalLinks ExternalLinks { get; set; }

        // Helper property to get a suitable image
        public string ImageUrl => Images.Count > 0
            ? Images[0].Url
            : "/images/placeholder.png";
    }
}