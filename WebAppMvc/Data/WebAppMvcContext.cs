using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppMvc.Models;

namespace WebAppMvc.Models
{
    public class WebAppMvcContext : DbContext
    {
        public WebAppMvcContext (DbContextOptions<WebAppMvcContext> options)
            : base(options)
        {
        }

        public DbSet<WebAppMvc.Models.Department> Department { get; set; }

        public DbSet<WebAppMvc.Models.Seller> Seller { get; set; }

        public DbSet<WebAppMvc.Models.SalesRecord> SalesRecord { get; set; }


    }
}
