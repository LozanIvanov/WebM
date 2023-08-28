using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Database.Models
{
  public class User:IdentityUser
    {
        public int? Age { get; set; }
    }
}
