using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElecCarApiApp.Models
{
    public class ElecCarContext : DbContext
    {
     

        public ElecCarContext(DbContextOptions<ElecCarContext> options)
          : base(options)
        {
        }
    
        public DbSet<Car> Cars { get; set; }
        public DbSet <Manufacturer> Manufacturers { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Car>().OwnsOne(c => c.Manufacturer);
        //}

    }
}
