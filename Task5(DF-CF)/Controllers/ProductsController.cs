using Microsoft.AspNetCore.Mvc;
using Task5_DF_CF_.Models;

namespace Task5_DF_CF_.Controllers
{
    public class ProductsController : Controller
    {
        private readonly MyDbContext _context;//الوصول لقاعدة البيانات
        public ProductsController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var products = _context.Products.ToList();//الوصول لجدول Products و اجمع البيانات اللي فيه على شكل ليست

            return View(products);//عرض البيانات بالصفحه
        }
    }
}
