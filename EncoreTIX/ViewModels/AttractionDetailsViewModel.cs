using EncoreTIX.Models;
using System.Collections.Generic;

namespace EncoreTIX.ViewModels
{
    public class AttractionDetailsViewModel
    {
        public Attraction Attraction { get; set; }
        public List<Event> Events { get; set; } = new List<Event>();
    }
}