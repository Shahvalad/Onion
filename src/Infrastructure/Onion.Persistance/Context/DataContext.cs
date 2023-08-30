using Microsoft.EntityFrameworkCore;
using Onion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Persistance.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
                
        }
        public DataContext()
        {

        }


        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = Guid.NewGuid(), Name = "Mask", Quantity = 50, Price = 19.99m, CreationDate = DateTime.UtcNow },
                new Product() { Id = Guid.NewGuid(), Name = "Knife", Quantity = 10, Price = 250.99m, CreationDate = DateTime.UtcNow },
                new Product() { Id = Guid.NewGuid(), Name = "Glove", Quantity = 85, Price = 350.99m, CreationDate = DateTime.UtcNow }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
