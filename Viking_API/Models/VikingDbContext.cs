using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Viking_API.Models
{
    public class VikingDbContext : DbContext
    {
        public VikingDbContext() : base("DefaultConnection") { }
        public DbSet<Viking> Vikings { get; set; }
    }
}