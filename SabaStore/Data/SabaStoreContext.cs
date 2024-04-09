using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SabaStore.Models;

namespace SabaStore.Data
{
    public class SabaStoreContext : DbContext
    {
        public SabaStoreContext (DbContextOptions<SabaStoreContext> options)
            : base(options)
        {
        }

        public DbSet<SabaStore.Models.Product> Product { get; set; } = default!;
    }
}
