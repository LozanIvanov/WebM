﻿using Microsoft.EntityFrameworkCore;
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
        public ProductService(IConfiguration configuration) : base(configuration)
        {
        }
        
        public void Store(Product product)
        {
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
        }
        public List<Product>GetProducts()
        {
            var query = this.dbContext.Products.AsQueryable();
            return query
              .Include(p => p.Category)
              .Include(p => p.Color)
              .Include(p => p.Size).ToList();
        }
        public Product GetProductById(int id)
        {
            return dbContext.Products.Where(x => x.Id == id).FirstOrDefault();
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