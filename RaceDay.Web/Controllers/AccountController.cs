using Microsoft.AspNetCore.Mvc;

namespace RaceDay.Web.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(string email, string password)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}