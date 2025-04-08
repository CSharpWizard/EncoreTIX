using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EncoreTIX.Models
{
    public class Event
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("dates")]
        public Dates Dates { get; set; }

        [JsonPropertyName("images")]
        public List<Image> Images { get; set; } = new List<Image>();

        [JsonPropertyName("_embedded")]
        public EventEmbedded Embedded { get; set; }

        // Helper property to get venue information
        public string VenueName => Embedded?.Venues?.Count > 0
            ? Embedded.Venues[0].Name
            : "Unknown Venue";

        public string VenueCity => Embedded?.Venues?.Count > 0
            ? $"{Embedded.Venues[0].City.Name}, {Embedded.Venues[0].State?.StateCode ?? Embedded.Venues[0].Country.CountryCode}"
            : "Unknown Location";

        // Helper property to get a suitable image
        public string ImageUrl => Images.Count > 0
            ? Images[0].Url
            : "/images/placeholder.png";

        // Helper property to format the date
        public string FormattedDate => Dates?.Start?.LocalDate != null
            ? DateTime.Parse(Dates.Start.LocalDate).ToString("dddd, MMMM d, yyyy")
            : "Date TBA";
    }

    public class Dates
    {
        [JsonPropertyName("start")]
        public Start Start { get; set; }
    }

    public class Start
    {
        [JsonPropertyName("localDate")]
        public string LocalDate { get; set; }

        [JsonPropertyName("localTime")]
        public string LocalTime { get; set; }
    }

    public class EventEmbedded
    {
        [JsonPropertyName("venues")]
        public List<Venue> Venues { get; set; } = new List<Venue>();
    }

    public class Venue
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("city")]
        public City City { get; set; }

        [JsonPropertyName("state")]
        public State State { get; set; }

        [JsonPropertyName("country")]
        public Country Country { get; set; }
    }

    public class City
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class State
    {
        [JsonPropertyName("stateCode")]
        public string StateCode { get; set; }
    }

    public class Country
    {
        [JsonPropertyName("countryCode")]
        public string CountryCode { get; set; }
    }
}