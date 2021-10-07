﻿using DataLayer.Models;
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

         #region Misc settings
            mB.Entity<Customers>()
                .Property(p => p.OrderAmount)
                .HasDefaultValueSql("0");
        #endregion

            #region Data Seeding
            mB.Entity<Cities>().HasData(
                new Cities { PostNumber = 6270, Name = "Tønder" },
                new Cities { PostNumber = 6000, Name = "Kolding" },
                new Cities { PostNumber = 6300, Name = "Sønderborg" },
                new Cities { PostNumber = 2400, Name = "København NV" },
                new Cities { PostNumber = 6200, Name = "Aabenraa" }
                );
            mB.Entity<Categories>().HasData(
                new Categories { CategoryID = 1, Category = "Kød & pålæg" },
                new Categories { CategoryID = 2, Category = "Drikke" },
                new Categories { CategoryID = 3, Category = "Slik & chokolade" },
                new Categories { CategoryID = 4, Category = "Snacks, kiks & kage" },
                new Categories { CategoryID = 5, Category = "Nødder & bælgfrugter" },
                new Categories { CategoryID = 7, Category = "Glutenfri" },
                new Categories { CategoryID = 8, Category = "Bønner, frø & linser" },
                new Categories { CategoryID = 9, Category = "Frisk frugt & grønt" }
                );
            mB.Entity<PriceDiscounts>().HasData(
                new PriceDiscounts { PriceDiscountID = 1, DiscountValue = 0},
                new PriceDiscounts { PriceDiscountID = 2, DiscountValue = 10, DiscountCode = "Vegan10" },
                new PriceDiscounts { PriceDiscountID = 3, DiscountValue = 50 },
                new PriceDiscounts { PriceDiscountID = 4, DiscountValue = 3, DiscountCode = "GrandOpening" }
                );
            mB.Entity<Vendors>().HasData(
                new Vendors { VendorID = 1, Name = "Urtekram"},
                new Vendors { VendorID = 2, Name = "Naturli" },
                new Vendors { VendorID = 3, Name = "Dryk"},
                new Vendors { VendorID = 4, Name = "Veganz"},
                new Vendors { VendorID = 5, Name = "Happy Reindeer"},
                new Vendors { VendorID = 6, Name = "Wally and Whiz"},
                new Vendors { VendorID = 7, Name = "Nutty Vegan"},
                new Vendors { VendorID = 8, Name = "Vantastic Foods"}
                );
            mB.Entity<Products>().HasData(
                new Products { ProductID = 1,  CategoryID = 1, VendorID = 7, Price = 32.95m, PriceDiscountID =1, Name = "Tunno - Vegansk tun", SKU = "" },
                new Products { ProductID = 2,  CategoryID = 1, VendorID = 8, Price = 19.95m, PriceDiscountID = 1, Name = "Røget tofu", SKU = "" },
                new Products { ProductID = 3,  CategoryID = 1, VendorID = 8, Price = 19.95m, PriceDiscountID = 1, Name = "Naturel tofu", SKU = "" },
                new Products { ProductID = 4,  CategoryID = 1, VendorID = 4, Price = 26.95m, PriceDiscountID = 1, Name = "Seitan med karry", SKU = "" },
                new Products { ProductID = 5,  CategoryID = 1, VendorID = 4, Price = 22.00m, PriceDiscountID = 1, Name = "Jackfruit confit", SKU = "" },
                new Products { ProductID = 6,  CategoryID = 2, VendorID = 1, Price = 19.95m, PriceDiscountID = 1, Name = "Økologisk kokosmælk", SKU = "" },
                new Products { ProductID = 7,  CategoryID = 2, VendorID = 2, Price = 69.00m, PriceDiscountID = 1, Name = "Instant cappuccino pulpver", SKU = "" },
                new Products { ProductID = 8,  CategoryID = 2, VendorID = 2, Price = 19.95m, PriceDiscountID = 1, Name = "Havredrik (natural)", SKU = "" },
                new Products { ProductID = 9,  CategoryID = 2, VendorID = 2, Price = 20.95m, PriceDiscountID = 1, Name = "Havredrik Barista Edition", SKU = "" },
                new Products { ProductID = 10, CategoryID = 2, VendorID = 2, Price = 19.95m, PriceDiscountID = 1, Name = "Havrekakao", SKU = "" },
                new Products { ProductID = 11, CategoryID = 2, VendorID = 3, Price = 17.95m, PriceDiscountID = 1, Name = "Vegansk Iskaffe", SKU = "" },
                new Products { ProductID = 12, CategoryID = 3, VendorID = 1, Price = 55.00m, PriceDiscountID = 1, Name = "Veganske trøfler i gaveæske (salted caramel)", SKU = "" },
                new Products { ProductID = 13, CategoryID = 3, VendorID = 1, Price = 32.00m, PriceDiscountID = 1, Name = "Candy Kittens - cherry flavour", SKU = "" },
                new Products { ProductID = 14, CategoryID = 3, VendorID = 5, Price = 28.00m, PriceDiscountID = 1, Name = "Finsk lakrids", SKU = "" },
                new Products { ProductID = 15, CategoryID = 3, VendorID = 5, Price = 12.50m, PriceDiscountID = 1, Name = "Lakridshyl", SKU = "" },
                new Products { ProductID = 16, CategoryID = 3, VendorID = 6, Price =  5.50m, PriceDiscountID = 1, Name = "Mojito Flowpack (vingummi)", SKU = "" },
                new Products { ProductID = 17, CategoryID = 3, VendorID = 6, Price =  5.50m, PriceDiscountID = 1, Name = "Cosmopolitan Flowpack (vingummi)", SKU = "" },
                new Products { ProductID = 18, CategoryID = 3, VendorID = 6, Price = 59.00m, PriceDiscountID = 1, Name = "Mojito Cube (vingummi)", SKU = "" },
                new Products { ProductID = 19, CategoryID = 3, VendorID = 6, Price = 59.00m, PriceDiscountID = 1, Name = "Cosmopolitan Cube (vingummi)", SKU = "" },
                new Products { ProductID = 20, CategoryID = 3, VendorID = 8, Price = 14.95m, PriceDiscountID = 1, Name = "Nuttercups - almonds (fyldte chokolader)", SKU = "" },
                new Products { ProductID = 21, CategoryID = 4, VendorID = 4, Price = 28.95m, PriceDiscountID = 1, Name = "Sour cream and onion kartoffelchips", SKU = "" },
                new Products { ProductID = 22, CategoryID = 4, VendorID = 4, Price = 28.95m, PriceDiscountID = 1, Name = "Sour cream and onion linsechips", SKU = "" },
                new Products { ProductID = 23, CategoryID = 4, VendorID = 4, Price = 12.95m, PriceDiscountID = 1, Name = "Tang chips - sweet soy & sea salt", SKU = "" },
                new Products { ProductID = 24, CategoryID = 4, VendorID = 8, Price = 19.95m, PriceDiscountID = 1, Name = "Veganske flæskevær", SKU = "" },
                new Products { ProductID = 25, CategoryID = 7, VendorID = 4, Price = 30.95m, PriceDiscountID = 1, Name = "Soya pasta", SKU = "" },
                new Products { ProductID = 26, CategoryID = 7, VendorID = 4, Price = 19.95m, PriceDiscountID = 1, Name = "Hørfrømel", SKU = "" },
                new Products { ProductID = 27, CategoryID = 7, VendorID = 1, Price = 16.95m, PriceDiscountID = 1, Name = "Shirataki nudler", SKU = "" },
                new Products { ProductID = 28, CategoryID = 7, VendorID = 1, Price = 18.95m, PriceDiscountID = 1, Name = "Shirataki ris", SKU = "" },
                new Products { ProductID = 29, CategoryID = 9, Price = 165.00m, PriceDiscountID = 1, Name = "Frugtkassen (min. 4 kg)", SKU = "" }
                );
        #endregion
        }
    }
}
