using EncoreTIX.Models;
using System.Collections.Generic;

namespace EncoreTIX.ViewModels
{
    public class AttractionViewModel
    {
        public string SearchTerm { get; set; } = "Phish";
        public List<Attraction> Attractions { get; set; } = new List<Attraction>();
        public string SelectedAttractionId { get; set; }
    }
}