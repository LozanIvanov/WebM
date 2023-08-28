using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Database.Models;

namespace Web.Database.Seeds
{
    public static class UserSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            //var user = new User()
            //{
            //    Id = "b74ddd14-6340-4840-95c2-db12554843e5",
            //    UserName = "admin",
            //    Email = "admin",
            //    EmailConfirmed = true,
            //    NormalizedUserName = "admin",
            //    NormalizedEmail = "admin",
            //};
            //var password = new PasswordHasher<User>();
            //user.PasswordHash = password.HashPassword(user, "123");
            //builder.Entity<User>().HasData(user);
            //builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>()
            //{
            //    UserId = "b74ddd14-6340-4840-95c2-db12554843e5",
            //    RoleId = "1"
            //});

        }
    }
}
