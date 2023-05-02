using BlazorSaleOrderApp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorSaleOrderApp.Server.AppDbContext
{
    public class BlazorAppDbContext : DbContext 
    {
        public BlazorAppDbContext(DbContextOptions<BlazorAppDbContext> options) :base(options)
        {

        }

        public DbSet<Product> Products{ get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(x=>x.Name).IsRequired().HasMaxLength(50);

            builder.Entity<Order>().Property(x => x.Id).ValueGeneratedOnAdd();

        }
    }
}
