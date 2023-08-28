using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Database.Models
{
    public class Product
    {
        public int Id { get; set; }

        [StringLength(100)]
        [Required]
        public string Name { get; set; }
        [StringLength(200)]
        [Required]
        public string Description { get; set; }

        public int Quantity { get; set; }
        [Column(TypeName = "decimal(15,2)")]
        public decimal Price { get; set; }
        public string? MainImage { get; set; }
        public string? GalleryImage { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        
        public Category Category { get; set; }

        public int? SizeId { get; set; }
        public Size? Size { get; set; }

        public int? ColorId { get; set; }
        public Color? Color { get; set; }
    }
}
