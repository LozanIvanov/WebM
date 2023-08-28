using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Database.Models;

namespace Web.Dal.Models
{
    public class CategoryEditViewModel
    {
        public List<Category> Categories { get; set; }
        public Category SelectedCategory { get; set; }

    }
}
