using Microsoft.AspNetCore.Mvc;
using RaceDay.Web.Models;

namespace RaceDay.Web.Controllers
{
    public class ParticipantController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public ParticipantController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        private bool IsParticipant()
        {
            return HttpContext.Session.GetString("UserRole") == "Participant";
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (!IsParticipant()) return RedirectToAction("Login", "Account");

            var client = _clientFactory.CreateClient("RaceDayAPI");
            var events = await client.GetFromJsonAsync<List<EventDto>>("api/events") ?? new List<EventDto>();

            return View(events);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (!IsParticipant()) return RedirectToAction("Login", "Account");

            var client = _clientFactory.CreateClient("RaceDayAPI");
            var eventDetail = await client.GetFromJsonAsync<EventDetailDto>($"api/events/{id}");

            if (eventDetail == null) return NotFound();

            return View(eventDetail);
        }

        [HttpPost]
        public async Task<IActionResult> Enrol(int eventId, int categoryId)
        {
            if (!IsParticipant()) return RedirectToAction("Login", "Account");

            var userIdString = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userIdString)) return RedirectToAction("Login", "Account");

            var client = _clientFactory.CreateClient("RaceDayAPI");
            var enrolDto = new
            {
                ParticipantId = int.Parse(userIdString),
                EventId = eventId,
                CategoryId = categoryId
            };

            var response = await client.PostAsJsonAsync("api/enrolments", enrolDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("MyEnrolments");
            }

            TempData["Error"] = "Failed to enrol for event.";
            return RedirectToAction("Details", new { id = eventId });
        }

        [HttpGet]
        public async Task<IActionResult> MyEnrolments()
        {
            if (!IsParticipant()) return RedirectToAction("Login", "Account");

            var userIdString = HttpContext.Session.GetString("UserId");
            var client = _clientFactory.CreateClient("RaceDayAPI");
            
            var enrolments = await client.GetFromJsonAsync<List<EnrolmentDto>>($"api/enrolments/participant/{userIdString}") ?? new List<EnrolmentDto>();

            return View(enrolments);
        }
    }

    public class EventDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Distance { get; set; } = string.Empty;
        public string EventType { get; set; } = string.Empty;
        public string? BannerUrl { get; set; }
        public List<CategoryDto> Categories { get; set; } = new();
    }

    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class EnrolmentDto
    {
        public int Id { get; set; }
        public string EventName { get; set; } = string.Empty;
        public DateTime EventDate { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty; // Confirmed, Pending, etc.
    }
}