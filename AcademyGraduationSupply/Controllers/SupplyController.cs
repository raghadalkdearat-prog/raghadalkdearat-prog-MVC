using AcademyGraduationSupply.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using AcademyGraduationSupply.Data;
using Microsoft.EntityFrameworkCore;

namespace AcademyGraduationSupply.Controllers
{
   

    public class SupplyController : Controller
    {

        private readonly AcademyGraduationPreparationContext _context;

        public SupplyController(AcademyGraduationPreparationContext context)
        {
            _context = context;
        }
        private static readonly List<Offer> offers = new List<Offer>
{
    new Offer
    {
        Id = 1,
        SupplierName = "Supplier A",
        OfferName = "Premium Certificate Package",
        Quantity = 35,
        UnitPrice = 2,
        Category = "Graduation Certificates"
    },

    new Offer
    {
        Id = 2,
        SupplierName = "Supplier B",
        OfferName = "Standard Certificate Package",
        Quantity = 35,
        UnitPrice = 1.5m,
        Category = "Graduation Certificates"
    },


    new Offer
    {
          Id = 3,
             SupplierName = "Supplier C",
             OfferName = "Luxury Certificate Package",
             Quantity = 35,
             UnitPrice = 2.5m,
             Category = "Graduation Certificates"
    },




    new Offer
    {
         Id = 4,
             SupplierName = "Supplier D",
             OfferName = "Coffee & Drinks Package",
             Quantity = 100,
             UnitPrice = 2,
             Category = "Hospitality"
    },




    new Offer
    {
           Id = 5,
             SupplierName = "Supplier E",
             OfferName = "Sandwiches & Snacks Package",
             Quantity = 100,
             UnitPrice = 3,
             Category = "Hospitality"
    },




    new Offer
    {
             Id = 6,
             SupplierName = "Supplier F",
             OfferName = "Full Hospitality Package",
             Quantity = 100,
             UnitPrice = 4,
             Category = "Hospitality"
    },





    new Offer
    {
            Id = 7,
             SupplierName = "Supplier G",
             OfferName = "Customized Mugs Package",
             Quantity = 35,
             UnitPrice = 3,
             Category = "Graduation Gifts"
    },





    new Offer
    {
     Id = 8,
             SupplierName = "Supplier H",
             OfferName = "Graduation Bags Package",
             Quantity = 35,
             UnitPrice = 3,
             Category = "Graduation Gifts"
    },
    

       new Offer
    {
     Id = 9,
             SupplierName = "Supplier I",
             OfferName = "Premium Gift Boxes Package",
             Quantity = 35,
             UnitPrice = 4,
             Category = "Graduation Gifts"
    }

   
};
        public IActionResult Index()
        {
           
            ViewBag.Offers= offers;//عشان اعرض القاىمه للمستخدم
            return View();
        }





        [HttpPost]
        public IActionResult SelectOffer(int id)
        {
            string? saved = HttpContext.Session.GetString("SelectedOffers");

            List<Offer> selectedOffers = new List<Offer>();

            if (saved != null)
            {
                selectedOffers = JsonSerializer.Deserialize<List<Offer>>(saved)
                                 ?? new List<Offer>();
            }

            foreach (var offer in offers)
            {
                if (offer.Id == id)
                {
                    selectedOffers.RemoveAll(x => x.Category == offer.Category);

                    selectedOffers.Add(offer);

                    break;
                }
            }

            string json = JsonSerializer.Serialize(selectedOffers);

            HttpContext.Session.SetString("SelectedOffers", json);

            return RedirectToAction("Index");
        }










        [HttpGet]
        public IActionResult Review()
        {
            string? saved = HttpContext.Session.GetString("SelectedOffers");

            List<Offer> selectedOffers = new List<Offer>();

            if (saved != null)
            {
                selectedOffers = JsonSerializer.Deserialize<List<Offer>>(saved)
                                 ?? new List<Offer>();
            }

            if (selectedOffers.Count != 3 ||
                selectedOffers.Count(x => x.Category == "Graduation Certificates") != 1 ||
                selectedOffers.Count(x => x.Category == "Hospitality") != 1 ||
                selectedOffers.Count(x => x.Category == "Graduation Gifts") != 1)
            {
                TempData["Message"] = "Please select one offer from each category!";
                return RedirectToAction("Index");
            }

            decimal subtotal = 0;

            foreach (var offer in selectedOffers)
            {
                offer.TotalPrice = offer.Quantity * offer.UnitPrice;

                subtotal += offer.TotalPrice;
            }

            decimal discountPercentage = 0;

            if (subtotal > 500)
            {
                discountPercentage = 15;
            }
            else if (subtotal > 300)
            {
                discountPercentage = 10;
            }

            decimal discount = subtotal * discountPercentage / 100;

            decimal finalTotal = subtotal - discount;

            ViewBag.SelectedOffers = selectedOffers;
            ViewBag.Subtotal = subtotal;
            ViewBag.DiscountPercentage = discountPercentage;
            ViewBag.Discount = discount;
            ViewBag.FinalTotal = finalTotal;

            return View();
        }


        [HttpGet]
        public IActionResult About()
        {
            return View();
        }




    }
}
