
using Microsoft.AspNetCore.Mvc;

namespace UniversityCafeteria.Controllers
{
    public class SupplyController : Controller
    {
        public IActionResult Index()
        {
            string[] categories =
  {
        "Drinks",
        "Food",
        "Snacks",
        "Hot Drinks",
        "Cold Drinks"
    };

            ViewBag.Categories = categories;

            return View();
        }

        public IActionResult Products()

        {

            ViewData["Title"] = "Cafeteria Products";
            ViewData["Manager"] = "Ahmad Ali";
            ViewData["TotalProducts"] = 5;


            string[] products =
   {
        "Water",
        "Orange Juice",
        "Coffee",
        "Sandwich",
        "Chocolate"
    };
            ViewData["products"] = products;





            return View();
        }

        public IActionResult Suppliers()

        {
            ViewBag.Title = "Our Suppliers";
            ViewBag.NumofSuppliers = 3;

            string[] suppliers =
{
        "Fresh Food Company",
        "Happy Drinks Company",
        "Daily Supplies Company"
      
    };


            return View();
        }

        [HttpGet]
        public IActionResult CreateRequest()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubmitRequest()
        {
            string employeeName = Request.Form["employeeName"].ToString();

            if (string.IsNullOrWhiteSpace(employeeName))
            {
                ViewBag.Error = "Employee Name is required!";
                return View("CreateRequest");
            }

            TempData["Message"] = "Request Submitted Successfully!";

            return RedirectToAction("About");
        }


        public IActionResult About()
        {
            return View();
        }
    }
}
