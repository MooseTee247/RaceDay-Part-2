using Microsoft.AspNetCore.Mvc;

namespace RaceDay.Web.Controllers
{
    public class ParticipantController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ParticipantController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        //Browse and filter events
        public IActionResult Index(string category)
        {
            ViewData["SelectedCategory"] = category;
            return View();
        }

        //Detailed event view with category selection & enrolment
        public IActionResult Details(int id)
        {
            ViewData["EventId"] = id;
            return View();
        }

        // Track enrolment status
        public IActionResult MyEnrolments()
        {
            return View();
        }

        // Race history and results
        public IActionResult RaceHistory()
        {
            return View();
        }

        //User profile page 
        public IActionResult Profile()
        {
            return View();
        }
    }
}