using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EncoreTIX.Models
{
    public class AttractionSearchResponse
    {
        [JsonPropertyName("_embedded")]
        public AttractionEmbedded Embedded { get; set; }
    }

    public class AttractionEmbedded
    {
        [JsonPropertyName("attractions")]
        public List<Attraction> Attractions { get; set; } = new List<Attraction>();
    }

    public class EventSearchResponse
    {
        [JsonPropertyName("_embedded")]
        public EventsEmbedded Embedded { get; set; }
    }

    public class EventsEmbedded
    {
        [JsonPropertyName("events")]
        public List<Event> Events { get; set; } = new List<Event>();
    }
}