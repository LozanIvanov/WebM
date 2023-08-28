using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Web.Dal.Interfaces;

namespace Web.Dal.Services
{
    public class CategoryService : BaseService,ICategoryService
    {
        public CategoryService(IConfiguration configuration) : base(configuration) { }

        public void Store(Category category)
        {
            dbContext.Categories.Add(category);
            dbContext.SaveChanges();
        }
        public List<Category> GetCategories()
        {
            return dbContext.Categories.ToList();
        }
        public Category GetCategoryById(int id)
        {
            return dbContext.Categories.Where(x=>x.Id==id).FirstOrDefault();
        }
        public void Update(int id,Category category)
        {
            var currentCategory = dbContext.Categories.Where(x => x.Id == id).FirstOrDefault();
            if (currentCategory != null)
            {
                currentCategory.Name=category.Name;
                currentCategory.ParentId = category.ParentId;
            }
            dbContext.Entry(currentCategory).State = EntityState.Modified;
            dbContext.SaveChanges();

        }
        public void Delete(int id)
        {
            Category cat = GetCategoryById(id);
            dbContext.Entry(cat).State = EntityState.Deleted;
            dbContext.SaveChanges();
        }

    }
}
