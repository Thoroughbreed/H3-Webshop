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
        #region Key constraints
            mB.Entity<OrderItems>()
                .HasKey(k => new { k.OrderID, k.ProductID });

            mB.Entity<Orders>()
                .HasMany(orders => orders.OrderItems)
                .WithOne(orderItems => orderItems.Orders);

            mB.Entity<Products>()
                .HasMany(products => products.OrderItems)
                .WithOne(orderItems => orderItems.Products);

            mB.Entity<Customers>()
                .HasOne(customer => customer.City)
                .WithMany(cities => cities.Customer)
                .HasForeignKey(customer => customer.PostNumber);
            #endregion

            #region Data Seeding
            mB.Entity<Categories>().HasData(
                new Categories { CategoryID = 1, Category = "Bælgfrugter" },
                new Categories { CategoryID = 2, Category = "Kød erstatninger"},
                new Categories { CategoryID = 3, Category = "Brød"},
                new Categories { CategoryID = 4, Category = "Raw food"}
                );
            mB.Entity<Cities>().HasData(
                new Cities { PostNumber = 6270, Name = "Tønder" },
                new Cities { PostNumber = 6000, Name = "Kolding" },
                new Cities { PostNumber = 6300, Name = "Sønderborg" },
                new Cities { PostNumber = 2400, Name = "København NV" },
                new Cities { PostNumber = 6200, Name = "Aabenraa" }
                );
            mB.Entity<PriceDiscounts>().HasData(
                new PriceDiscounts { PriceDiscountID = 1, DiscountValue = 10, DiscountCode = "Vegan10" },
                new PriceDiscounts { PriceDiscountID = 2, DiscountValue = 50 },
                new PriceDiscounts { PriceDiscountID = 3, DiscountValue = 3, DiscountCode = "GrandOpening" }
                );
            mB.Entity<Vendors>().HasData(

                );
        #endregion
        }
    }
}
