using EncoreTIX.Models;
using System.Threading.Tasks;

namespace EncoreTIX.Services
{
    public interface ITicketmasterService
    {
        Task<AttractionSearchResponse> SearchAttractionsAsync(string keyword);
        Task<Attraction> GetAttractionByIdAsync(string attractionId);
        Task<EventSearchResponse> GetEventsByAttractionIdAsync(string attractionId);
    }
}