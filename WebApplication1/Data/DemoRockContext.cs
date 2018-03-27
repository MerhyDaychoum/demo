using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class DemoRockContext : DbContext
    {
        public DemoRockContext (DbContextOptions<DemoRockContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication1.Models.User> User { get; set; }
    }
}
