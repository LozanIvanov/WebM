using Microsoft.AspNetCore.Mvc;
using Web.Dal.Services;

namespace WebM.Controllers
{
    public class ShopController : Controller
    {

        private readonly ProductService service;
        public ShopController(ProductService service)
        {
            this.service = service;
        }
        [Route("/Shop/Details/{id}")]
        public IActionResult Details(int id)
        {
            var product = this.service.GetProductById(id);

            return View("~/Views/Shop/Details.cshtml", product);
        }
        public IActionResult Index(decimal minPrice = 0, decimal maxPrice = 0)
        {
            var products = this.service.GetProducts(minPrice, maxPrice);

            return View("~/Views/Shop/index.cshtml", products);
        }
    }
}
