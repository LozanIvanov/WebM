using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Dal.Models.Home;
using Web.Database;
using WebM.Models;

namespace WebM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext db)
        {
            _context = db;  
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new HomePageViewModel();
            model.Categories = _context.Categories
                .Select(c => new CategoryViewModel()
                {
                    Name = c.Name,
                    ProductCount = c.Products.Count,
                    MainImage=c.MainImage,
                }).ToList();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}