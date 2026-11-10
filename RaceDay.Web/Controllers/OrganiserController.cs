using Microsoft.AspNetCore.Mvc;

namespace RaceDay.Web.Controllers
{
    public class OrganiserController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OrganiserController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        //Organiser Dashboard with Event Summaries
        public IActionResult Dashboard()
        {
            return View();
        }

        // Event Management (CRUD List & Actions)
        public IActionResult ManageEvents()
        {
            return View();
        }

        // Create Event Form
        public IActionResult CreateEvent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateEvent(IFormFile bannerImage, string eventName)
        {
            // Handle creation and banner upload logic
            return RedirectToAction(nameof(ManageEvents));
        }

        //Category Management
        public IActionResult Categories()
        {
            return View();
        }

        //Results Entry Page
        public IActionResult EnterResults()
        {
            return View();
        }
    }
}