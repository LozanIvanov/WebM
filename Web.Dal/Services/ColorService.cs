using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Database.Models;

namespace Web.Dal.Services
{
    public class ColorService : BaseService
    {
        public ColorService(IConfiguration configuration) : base(configuration)
        {
        }
        public List<Color> GetColor()
        {
            return dbContext.Colors.ToList();
        }
    }
}
