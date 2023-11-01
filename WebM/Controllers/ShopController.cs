using Microsoft.AspNetCore.Mvc;
using Web.Dal.Models.Admin;
using Web.Dal.Services;

namespace WebM.Controllers
{
    public class ShopController : Controller
    {

        private readonly ProductService productService;
        public ShopController(ProductService service)
        {
            this.productService = service;
        }
        [Route("/Shop/Details/{id}")]
        public IActionResult Details(int id)
        {
            var product = this.productService.GetProductById(id);

            return View("~/Views/Shop/Details.cshtml", product);
        }
        public IActionResult Index(int? page,decimal minPrice = 0, decimal maxPrice = 0)
        {
            var result = new ProductViewModel()
            {
                ListProducts = this.productService.GetProducts(page),
                TotalPages = this.productService.GetTotalPages(),
                CurrentPage = page != null ? page.Value : 1
            };

            return View("~/Views/Shop/index.cshtml", result);
        }
    }
}
