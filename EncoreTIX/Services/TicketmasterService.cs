using EncoreTIX.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace EncoreTIX.Services
{
    public class TicketmasterService : ITicketmasterService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly JsonSerializerOptions _jsonOptions;

        public TicketmasterService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["Ticketmaster:ApiKey"];
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<AttractionSearchResponse> SearchAttractionsAsync(string keyword)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://app.ticketmaster.com/discovery/v2/attractions.json?keyword={Uri.EscapeDataString(keyword)}&apikey={_apiKey}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var searchResponse = JsonSerializer.Deserialize<AttractionSearchResponse>(content, _jsonOptions);
                    return searchResponse;
                }

                return new AttractionSearchResponse { Embedded = new AttractionEmbedded() };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching attractions: {ex.Message}");
                return new AttractionSearchResponse { Embedded = new AttractionEmbedded() };
            }
        }

        public async Task<Attraction> GetAttractionByIdAsync(string attractionId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://app.ticketmaster.com/discovery/v2/attractions/{attractionId}.json?apikey={_apiKey}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var attraction = JsonSerializer.Deserialize<Attraction>(content, _jsonOptions);
                    return attraction;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting attraction: {ex.Message}");
                return null;
            }
        }

        public async Task<EventSearchResponse> GetEventsByAttractionIdAsync(string attractionId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://app.ticketmaster.com/discovery/v2/events.json?attractionId={attractionId}&apikey={_apiKey}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var eventsResponse = JsonSerializer.Deserialize<EventSearchResponse>(content, _jsonOptions);
                    return eventsResponse;
                }

                return new EventSearchResponse { Embedded = new EventsEmbedded() };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting events: {ex.Message}");
                return new EventSearchResponse { Embedded = new EventsEmbedded() };
            }
        }
    }
}