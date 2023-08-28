using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Dal.Interfaces;
using Web.Dal.Models;
using Web.Dal.Services;
using Web.Database.Models;

namespace WebM.Controllers.Admin
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService service;
        public CategoryController(ICategoryService service)
        {
            this.service=service;    
        }
        [Route("Admin/Categories")]
        [Authorize(Roles="Admin")]
        public IActionResult Index()
        {
            List<Category> categories = service.GetCategories();  
            return View("~/Views/Admin/Categories/Index.cshtml",categories);
        }
        [HttpGet]
        [Route("Admin/Categories/Create")]
        public IActionResult Create()
        {
            List<Category>categories=service.GetCategories();
            return View("~/Views/Admin/Categories/Create.cshtml",categories);
        }
        [HttpPost]
        [Route("Admin/Categories/Create")]
        public IActionResult Create(Category category)
        {
            service.Store(category);
            return Redirect("/Admin/Categories");
        }
        [HttpGet]
        [Route("/Admin/Categories/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            CategoryEditViewModel model=new CategoryEditViewModel();
            model.Categories = service.GetCategories();
            model.SelectedCategory = service.GetCategoryById(id);
            return View("~/Views/Admin/Categories/Edit.cshtml", model);
        }
        [HttpPost]
        [Route("/Admin/Categories/Edit/{id}")]
        public IActionResult Edit(int id,Category category)
        {
            service.Update(id,category);
            return Redirect("/Admin/Categories");
        }
        [HttpGet]
        [Route("/Admin/Categories/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            service.Delete(id);
            return Redirect("/Admin/Categories");
        }
    }
   
}

