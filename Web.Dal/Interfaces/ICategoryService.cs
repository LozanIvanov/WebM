using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Database.Models;

namespace Web.Dal.Interfaces
{
    public interface ICategoryService
    {
        public void Store(Category category);
        public List<Category> GetCategories();
        public void Update(int id, Category category);
        public void Delete(int id);
        public Category GetCategoryById(int id);
    }
}
