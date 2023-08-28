using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Dal.Interfaces;
using Web.Dal.Models.Admin;
using Web.Dal.Services;
using Web.Database.Models;

namespace WebM.Controllers.Admin
{
    [Authorize(Roles = "Admin,Manager")]
    public class ProductController : Controller
    {
        private readonly ProductService productService;
        private readonly ICategoryService categoryService;
        private readonly ColorService colorService;
        private readonly SizeService sizeService;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ProductController(IWebHostEnvironment webHostEnvironment,ProductService productService, ICategoryService categoryService, ColorService colorService, SizeService sizeService)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.productService = productService;  
            this.categoryService = categoryService;
            this.colorService = colorService;
            this.sizeService=sizeService;
        }
        [Route("Admin/Products")]
        public IActionResult Index()
        {
            var result = productService.GetProducts();
            return View("~/Views/Admin/Products/Index.cshtml",result);
        }
        [HttpGet]
        [Route("Admin/Products/Create")]
        public  IActionResult Create()
        {
            ProductViewModel model=new ProductViewModel();
            model.Categories = categoryService.GetCategories();
            model.Colors = colorService.GetColor();
            model.Sizes = sizeService.GetSize();
            
            return View("~/Views/Admin/Products/Create.cshtml",model);
        }
        [HttpPost]
        [Route("Admin/Products/Create")]
        public async Task<IActionResult> Create(ProductViewModel product)
        {
            var p = new Product();
            p.Name = product.Name;
            p.Description = product.Description;
            p.Quantity = product.Quantity;
            p.Price = product.Price;
            p.CategoryId = product.CategoryId;
            p.SizeId = product.SizeId;
            p.ColorId = product.ColorId;
            if (product.MainImageFile!=null && product.MainImageFile.Length > 0)
            {
                var wwwroot = this.webHostEnvironment.WebRootPath;
                var dir = Path.Combine(wwwroot, "images");
                //wwwroot/images
                //.jpg
              var extension = System.IO.Path.GetExtension(product.MainImageFile.FileName);
               //randomname.product
               var fileName = Guid.NewGuid().ToString() + extension;
               //F:/WebStore/..../randomname.jpg
               var fullFilePath = Path.Combine(dir, fileName);
               using (var fileStream = new FileStream(fullFilePath, FileMode.Create))
               {
                    await product.MainImageFile.CopyToAsync(fileStream);
               }

               p.MainImage = "/images/" + fileName;
            }
            productService.Store(p);
            return Redirect("/Admin/Products");
        }
        [HttpGet]
        [Route("Admin/Products/Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var product = productService.GetProductById(id);
            var category = categoryService.GetCategories();
            var size=sizeService.GetSize();
            var color = colorService.GetColor();
            ProductViewModel model = new ProductViewModel();
            model.Id = product.Id;
            model.Name = product.Name;
            model.Description = product.Description;
            model.Quantity = product.Quantity;
            model.CategoryId=product.CategoryId;
            model.Price = product.Price;
             model.CategoryId = product.CategoryId;
             model.SizeId = product.SizeId;
             model.ColorId = product.ColorId;
            model.Categories = category;
            model.Sizes = size;
            model.Colors = color;
            model.MainImage = product.MainImage;

            //if(model.MainImageFile.Length > 0)
            //{
            //    var wwwroot = this.webHostEnvironment.WebRootPath;
            //    var dir = Path.Combine(wwwroot, "images");
            //    var extention = System.IO.Path.GetExtension(model.MainImageFile.FileName);
            //    var filename = Guid.NewGuid().ToString() + extention;
            //    var fullFilePath = Path.Combine(dir, filename);
            //    using(var fileStream=new FileStream(fullFilePath,FileMode.Create))
            //    {
            //        await model.MainImageFile.CopyToAsync(fileStream);
            //    }
            //}
            
            
            return View("~/Views/Admin/Products/Edit.cshtml", model);
        }
        [HttpPost]
        [Route("Admin/Products/Edit/{id}")]
        public async Task<IActionResult> Edit(int id,ProductViewModel product)
        {
            var model = new Product();
           
            model.Id = id;
            model.Name = product.Name;
            model.Description = product.Description;
            model.Quantity = product.Quantity;
            model.Price = product.Price;
            model.CategoryId = product.CategoryId;
            model.SizeId = product.SizeId;
            model.ColorId = product.ColorId;
            if (product.MainImageFile != null && product.MainImageFile.Length > 0)
            {
                var wwwroot = this.webHostEnvironment.WebRootPath;
                var dir = Path.Combine(wwwroot, "images");
                //wwwroot/images
                //.jpg
                var extension = System.IO.Path.GetExtension(product.MainImageFile.FileName);
                //randomname.product
                var fileName = Guid.NewGuid().ToString() + extension;
                //F:/WebStore/..../randomname.jpg
                var fullFilePath = Path.Combine(dir, fileName);
                using (var fileStream = new FileStream(fullFilePath, FileMode.Create))
                {
                    await product.MainImageFile.CopyToAsync(fileStream);
                }
                model.MainImage = "/images/" + fileName;
            }
                

                productService.UpdateProduct(model);

            return Redirect("/Admin/Products");
        }
        [HttpGet]
        [Route("Admin/Products/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            productService.Delete(id);

            return Redirect("/Admin/Products");
        }
    }
}
