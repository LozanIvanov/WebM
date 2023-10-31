using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Database.Models;

namespace Web.Dal.Services
{
    public class ProductService : BaseService
    {
        private int perPage = 3;
        public ProductService(IConfiguration configuration) : base(configuration)
        {
        }
        
        public void Store(Product product)
        {
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
        }
        public List<Product>GetProducts(int? pageNullable, decimal minPrice = 0, decimal maxPrice = 0 )
        {
            int page=pageNullable !=null ? pageNullable.Value : 1;
            var query = this.dbContext.Products.AsQueryable();
            if(maxPrice>0)
            {
                query = query.Where(p => p.Price <= maxPrice);
            }
            if(minPrice>0)
            {
                query=query.Where(p=>p.Price>=minPrice);    
            }
            return query.Skip((page-1)*this.perPage)
                .Take(this.perPage)
              .Include(p => p.Category)
              .Include(p => p.Color)
              .Include(p => p.Size).ToList();
        }
        public int GetTotalPages()
        {
            double count = this.dbContext.Products.Count();
            return (int) Math.Ceiling(count / this.perPage);
        }
        public Product GetProductById(int id)
        {
            return dbContext.Products.Where(x => x.Id == id)
                .Include(x => x.Category)
                .FirstOrDefault();
        }
        public void UpdateProduct(Product product)
        {
            dbContext.Entry(product).State = EntityState.Modified;
             dbContext.SaveChanges();   
        }
        public void Delete(int id)
        {
            var d = GetProductById(id);
 
            dbContext.Entry(d).State = EntityState.Deleted;
            dbContext.SaveChanges();
        }
    }
}
