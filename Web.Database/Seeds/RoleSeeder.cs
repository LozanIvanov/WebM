﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Database.Seeds
{
    public static class RoleSeeder
    {
        public static void Seed(ModelBuilder builder)
        {
            //builder.Entity<IdentityRole>().HasData(new IdentityRole()
            //{
            //    Id = "1",
            //    Name = "Admin",
            //    NormalizedName = "Admin",
            //    ConcurrencyStamp = "Admin"
            //}, new IdentityRole()
            //{
            //    Id = "2",
            //    Name = "User",
            //    NormalizedName = "User",
            //    ConcurrencyStamp = "User"
            //});
        }
    }
}
