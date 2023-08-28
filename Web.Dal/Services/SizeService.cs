using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Database.Models;

namespace Web.Dal.Services
{
    public class SizeService : BaseService
    {
        public SizeService(IConfiguration configuration) : base(configuration)
        {
        }
        public List<Size> GetSize()
        {
            return dbContext.Sizes.ToList();
        }
    }
}
