using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DataLayer
{
    public class CoreContext : DbContext
    {
        //public CoreContext(DbContextOptions<CoreContext> options) : base(options)
        //{

        //}

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<PriceDiscounts> PriceDiscounts { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Vendors> Vendors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder oB)
        {
            if (!oB.IsConfigured)
            {
                oB.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = Webshop; Trusted_Connection = True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder mB)
        {
            //            public Orders Orders { get; set; }
            //public Products Products { get; set; }

            mB.Entity<OrderItems>()
                .HasKey(k => new { k.OrderID, k.ProductID });

            mB.Entity<Orders>()
                .HasMany(orders => orders.OrderItems)
                .WithOne(orderItems => orderItems.Orders);

            mB.Entity<Products>()
                .HasMany(products => products.OrderItems)
                .WithOne(orderItems => orderItems.Products);
        }
    }
}
