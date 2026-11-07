
using Microsoft.AspNetCore.Mvc;
using UniversityCafeteria.Models;
namespace UniversityCafeteria.Controllers
{
    public class SupplyRequestController : Controller
    {

        private static List<SupplyItem> products = new List<SupplyItem>();
        public IActionResult Index()
        {
            return View();
        }




        [HttpPost]
        public IActionResult AddItem(
            string ProductName,
            string Category,
            int Quantity,
            decimal UnitPrice,
            string Priority)
        {
            if (string.IsNullOrWhiteSpace(ProductName))
            {
                ViewBag.Message = "Product Name is required!";
                return View("Index");
            }

            if (Quantity <= 0 || UnitPrice <= 0)
            {
                ViewBag.Message = "Quantity and Unit Price must be greater than zero!";
                return View("Index");
            }

            SupplyItem item = new SupplyItem
            {
                ProductName = ProductName,
                Category = Category,
                Quantity = Quantity,
                UnitPrice = UnitPrice,
                Priority = Priority
            };

            products.Add(item);

            ViewBag.Message = "Product added successfully!";
            ViewBag.Products = products;

            return View("Index");
        }













        public IActionResult Review()
        {
            decimal subtotal = 0;

            foreach (var item in products)
            {
                subtotal += item.Quantity * item.UnitPrice;
            }

            string priority = products.Count > 0
                ? products[0].Priority
                : "Normal";

            decimal preparationFee = 0;

            switch (priority)
            {
                case "Normal":
                    preparationFee = 2;
                    break;

                case "Urgent":
                    preparationFee = 5;
                    break;

                case "Emergency":
                    preparationFee = 10;
                    break;
            }

            decimal discount = 0;

            if (subtotal > 200)
            {
                discount = subtotal * 0.15m;
            }
            else if (subtotal > 100)
            {
                discount = subtotal * 0.10m;
            }

            decimal finalTotal = subtotal + preparationFee - discount;

            ViewBag.Products = products;
            ViewBag.Priority = priority;
            ViewBag.Subtotal = subtotal;
            ViewBag.PreparationFee = preparationFee;
            ViewBag.Discount = discount;
            ViewBag.FinalTotal = finalTotal;

            return View();
        }










        [HttpPost]
        public IActionResult ConfirmRequest()
        {
            if (products.Count == 0)
            {
                TempData["Message"] = "Cannot confirm an empty request!";
                return RedirectToAction("Review");
            }

            return RedirectToAction("Review");
        }






        [HttpPost]
        public IActionResult ClearDraft()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SavePreference()
        {
            return RedirectToAction("Index");
        }

        public IActionResult MyRequests()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
