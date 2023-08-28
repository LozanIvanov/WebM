using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Database.Models;

namespace Web.Database
{
    public class DBInitializer
    {
        public static void Initialize(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext dbContext)
        {
            var users = userManager.Users.ToList();

            if (users.Count == 0)
            {
                #region Create Users
                // Create Users in the DB
                var password = "123";
                var adminUser = new User()
                {
                    UserName = "Admin",
                    Email = "admin@test.com"
                };
                userManager.CreateAsync(adminUser, password).Wait();

                var user = new User()
                {
                    UserName = "User",
                    Email = "user@test.com"
                };
                userManager.CreateAsync(user, password).Wait();

                var managerUser = new User()
                {
                    UserName = "Manager",
                    Email = "manager@test.com"
                };
                userManager.CreateAsync(managerUser, password).Wait();

                // Add two roles in the DB
                roleManager.CreateAsync(new IdentityRole() { Name = "Admin" }).Wait();
                roleManager.CreateAsync(new IdentityRole() { Name = "User" }).Wait();
                roleManager.CreateAsync(new IdentityRole() { Name = "Manager" }).Wait();

                // Assign roles to the users
                userManager.AddToRoleAsync(adminUser, "Admin").Wait();
                userManager.AddToRoleAsync(user, "User").Wait();
                userManager.AddToRoleAsync(managerUser, "Manager").Wait();
                #endregion

                #region Create Categories
                dbContext.Categories.Add(new Category() { Name = "Shoes" });
                dbContext.Categories.Add(new Category() { Name = "Shirts" });
                dbContext.Categories.Add(new Category() { Name = "Jackets" });
                dbContext.SaveChanges();
                #endregion

                #region Create Products
                dbContext.Products.Add(new Product() { Name = "Addidas Shoes", CategoryId = 1, Description = "Brand new model", Price = 120, Quantity = 17, MainImage = "6db95382-ff8f-455a-af11-be9969bc4385-obuvki.webp" });
                dbContext.Products.Add(new Product() { Name = "Addidas Shirt", CategoryId = 2, Description = "Brand new model", Price = 40, Quantity = 28, MainImage = "product-8.jpg" });
                dbContext.Products.Add(new Product() { Name = "Nike Shirt", CategoryId = 2, Description = "Brand new model", Price = 50, Quantity = 15, MainImage = "product-4.jpg" });
                dbContext.Products.Add(new Product() { Name = "Addidas Jacket", CategoryId = 3, Description = "Brand new model", Price = 250, Quantity = 10, MainImage = "product-3.jpg" });
                dbContext.Products.Add(new Product() { Name = "Puma Jacket", CategoryId = 3, Description = "Brand new model", Price = 190, Quantity = 18, MainImage = "product-6.jpg" });
                dbContext.SaveChanges();
                #endregion

                #region Create Colors
                dbContext.Colors.Add(new Color() { Name = "Blue" });
                dbContext.Colors.Add(new Color() { Name = "Green" });
                dbContext.Colors.Add(new Color() { Name = "Black" });
                dbContext.SaveChanges();
                #endregion

                #region Create Sizes
                dbContext.Sizes.Add(new Size() { Name = "XS" });
                dbContext.Sizes.Add(new Size() { Name = "S" });
                dbContext.Sizes.Add(new Size() { Name = "M" });
                dbContext.Sizes.Add(new Size() { Name = "L" });
                dbContext.Sizes.Add(new Size() { Name = "XL" });
                dbContext.SaveChanges();
                #endregion
            }
        }
    }
}
