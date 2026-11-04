
using Microsoft.AspNetCore.Mvc;

namespace UniversityPortalDemo.Controllers
{
    public class StudentServicesController : Controller
    {
        // GET - Display Student Portal
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // GET - Display Registration Information
        [HttpGet]
        public IActionResult RegistrationInfo()
        {
            return Content("Registration for Fall Semester is Open!");
        }

        // POST - Submit Student Request
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubmitRequest()
        {
            return Content("Your student request was submitted successfully!");
        }

        // Redirect to another Action
        [HttpGet]
        public IActionResult StudentServices()
        {
            return RedirectToAction("RegistrationInfo");
        }

        // Redirect to University Website
        [HttpGet]
        public IActionResult UniversityWebsite()
        {
            return Redirect("https://www.gju.edu.jo");
        }
    }
}
