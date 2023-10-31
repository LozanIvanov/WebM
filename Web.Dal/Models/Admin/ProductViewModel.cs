using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Database.Models;

namespace Web.Dal.Models.Admin
{
    public  class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
      
        public string Description { get; set; }

        public int Quantity { get; set; }
       
        public decimal Price { get; set; }
        public string? MainImage { get; set; }
        public string? GalleryImage { get; set; }
     
        public int CategoryId { get; set; }
        public int? ColorId { get; set; }
        public int? SizeId { get; set; }
        
        public IFormFile MainImageFile { get; set; }
        public List<Category> Categories { get; set; }
        public List<Size> Sizes { get; set; }
        public List<Color> Colors { get; set; }
        public List<Product> ListProducts { get; set; }

        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }

        public ProductViewModel()
         {
            Categories = new List<Category>();
            Sizes = new List<Size>();
            Colors = new List<Color>();
            ListProducts = new List<Product>();
        }
    }
}

