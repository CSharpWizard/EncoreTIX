using EncoreTIX.Models;
using EncoreTIX.Services;
using EncoreTIX.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace EncoreTIX.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITicketmasterService _ticketmasterService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ITicketmasterService ticketmasterService, ILogger<HomeController> logger)
        {
            _ticketmasterService = ticketmasterService;
            _logger = logger;
        }

        public async Task<IActionResult> Index(string searchTerm = "Phish")
        {
            var viewModel = new AttractionViewModel
            {
                SearchTerm = searchTerm
            };

            var result = await _ticketmasterService.SearchAttractionsAsync(searchTerm);
            if (result?.Embedded?.Attractions != null)
            {
                viewModel.Attractions = result.Embedded.Attractions;
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Search(AttractionViewModel model)
        {
            return RedirectToAction("Index", new { searchTerm = model.SearchTerm });
        }

        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index");
            }

            var attraction = await _ticketmasterService.GetAttractionByIdAsync(id);
            if (attraction == null)
            {
                return NotFound();
            }

            var eventsResponse = await _ticketmasterService.GetEventsByAttractionIdAsync(id);

            var viewModel = new AttractionDetailsViewModel
            {
                Attraction = attraction,
                Events = eventsResponse?.Embedded?.Events ?? new List<Event>()
            };

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}