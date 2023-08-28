using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Database.Models
{
    public class Publication
    {
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string Title { get; set; }
        [StringLength(200)]
        [Required]
        public string Description { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        public string Image { get; set; }
    }
}
