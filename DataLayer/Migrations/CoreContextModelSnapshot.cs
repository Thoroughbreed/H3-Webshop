﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataLayer.Migrations
{
    [DbContext(typeof(CoreContext))]
    partial class CoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataLayer.Models.Categories", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            Category = "Kød & pålæg"
                        },
                        new
                        {
                            CategoryID = 2,
                            Category = "Drikke"
                        },
                        new
                        {
                            CategoryID = 3,
                            Category = "Slik & chokolade"
                        },
                        new
                        {
                            CategoryID = 4,
                            Category = "Snacks, kiks & kage"
                        },
                        new
                        {
                            CategoryID = 5,
                            Category = "Nødder & bælgfrugter"
                        },
                        new
                        {
                            CategoryID = 7,
                            Category = "Glutenfri"
                        },
                        new
                        {
                            CategoryID = 8,
                            Category = "Bønner, frø & linser"
                        },
                        new
                        {
                            CategoryID = 9,
                            Category = "Frisk frugt & grønt"
                        });
                });

            modelBuilder.Entity("DataLayer.Models.Cities", b =>
                {
                    b.Property<int>("PostNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PostNumber");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            PostNumber = 6270,
                            Name = "Tønder"
                        },
                        new
                        {
                            PostNumber = 6000,
                            Name = "Kolding"
                        },
                        new
                        {
                            PostNumber = 6300,
                            Name = "Sønderborg"
                        },
                        new
                        {
                            PostNumber = 2400,
                            Name = "København NV"
                        },
                        new
                        {
                            PostNumber = 6200,
                            Name = "Aabenraa"
                        });
                });

            modelBuilder.Entity("DataLayer.Models.Customers", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderAmount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("0");

                    b.Property<string>("PhoneMain")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneMobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostNumber")
                        .HasColumnType("int");

                    b.Property<string>("RoadName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoadNumber")
                        .HasColumnType("int");

                    b.HasKey("CustomerID");

                    b.HasIndex("PostNumber");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("DataLayer.Models.OrderItems", b =>
                {
                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<decimal>("LinePrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderID", "ProductID");

                    b.HasIndex("ProductID");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("DataLayer.Models.Orders", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<Guid>("OrderGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<DateTime>("PurchaseDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DataLayer.Models.PriceDiscounts", b =>
                {
                    b.Property<int>("PriceDiscountID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiscountCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DiscountValue")
                        .HasColumnType("int");

                    b.HasKey("PriceDiscountID");

                    b.ToTable("PriceDiscounts");

                    b.HasData(
                        new
                        {
                            PriceDiscountID = 1,
                            DiscountValue = 0
                        },
                        new
                        {
                            PriceDiscountID = 2,
                            DiscountCode = "Vegan10",
                            DiscountValue = 10
                        },
                        new
                        {
                            PriceDiscountID = 3,
                            DiscountValue = 50
                        },
                        new
                        {
                            PriceDiscountID = 4,
                            DiscountCode = "GrandOpening",
                            DiscountValue = 3
                        });
                });

            modelBuilder.Entity("DataLayer.Models.Products", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(8,2)");

                    b.Property<int?>("PriceDiscountID")
                        .HasColumnType("int");

                    b.Property<string>("SKU")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VendorID")
                        .HasColumnType("int");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("PriceDiscountID");

                    b.HasIndex("VendorID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductID = 1,
                            CategoryID = 1,
                            Name = "Tunno - Vegansk tun",
                            Price = 32.95m,
                            PriceDiscountID = 1,
                            SKU = "",
                            VendorID = 7
                        },
                        new
                        {
                            ProductID = 2,
                            CategoryID = 1,
                            Name = "Røget tofu",
                            Price = 19.95m,
                            PriceDiscountID = 1,
                            SKU = "",
                            VendorID = 8
                        },
                        new
                        {
                            ProductID = 3,
                            CategoryID = 1,
                            Name = "Naturel tofu",
                            Price = 19.95m,
                            PriceDiscountID = 1,
                            SKU = "",
                            VendorID = 8
                        },
                        new
                        {
                            ProductID = 4,
                            CategoryID = 1,
                            Name = "Seitan med karry",
                            Price = 26.95m,
                            PriceDiscountID = 1,
                            SKU = "",
                            VendorID = 4
                        },
                        new
                        {
                            ProductID = 5,
                            CategoryID = 1,
                            Name = "Jackfruit confit",
                            Price = 22.00m,
                            PriceDiscountID = 1,
                            SKU = "",
                            VendorID = 4
                        },
                        new
                        {
                            ProductID = 6,
                            CategoryID = 2,
                            Name = "Økologisk kokosmælk",
                            Price = 19.95m,
                            PriceDiscountID = 1,
                            SKU = "",
                            VendorID = 1
                        },
                        new
                        {
                            ProductID = 7,
                            CategoryID = 2,
                            Name = "Instant cappuccino pulpver",
                            Price = 69.00m,
                            PriceDiscountID = 1,
                            SKU = "",
                            VendorID = 2
                        },
                        new
                        {
                            ProductID = 8,
                            CategoryID = 2,
                            Name = "Havredrik (natural)",
                            Price = 19.95m,
                            PriceDiscountID = 1,
                            SKU = "",
                            VendorID = 2
                        },
                        new
                        {
                            ProductID = 9,
                            CategoryID = 2,
                            Name = "Havredrik Barista Edition",
                            Price = 20.95m,
                            PriceDiscountID = 1,
                            SKU = "",
                            VendorID = 2
                        },
                        new
                        {
                            ProductID = 10,
                            CategoryID = 2,
                            Name = "Havrekakao",
                            Price = 19.95m,
                            PriceDiscountID = 1,
                            SKU = "",
                            VendorID = 2
                        },
                        new
                        {
                            ProductID = 11,
                            CategoryID = 2,
                            Name = "Vegansk Iskaffe",
                            Price = 17.95m,
                            PriceDiscountID = 1,
                            SKU = "",
                            VendorID = 3
                        },
                        new
                        {
                            ProductID = 12,
                            CategoryID = 3,
                            Name = "Veganske trøfler i gaveæske (salted caramel)",
                            Price = 55.00m,
                            PriceDiscountID = 1,
                            SKU = "",
                            VendorID = 1
                        },
                        new
                        {
                            ProductID = 13,
                            CategoryID = 3,
                            Name = "Candy Kittens - cherry flavour",
                            Price = 32.00m,
                            PriceDiscountID = 1,
                            SKU = "",
                            VendorID = 1
                        },
                        new
                        {
                            ProductID = 14,
                            CategoryID = 3,
                            Name = "Finsk lakrids",
                            Price = 28.00m,
                            PriceDiscountID = 1,
                            SKU = "",
                            VendorID = 5
                        },
                        new
                        {
                            ProductID = 15,
                            CategoryID = 3,
                            Name = "Lakridshyl",
                            Price = 12.50m,
                            PriceDiscountID = 1,
                            SKU = "",
                            VendorID = 5
                        },
                        new
                        {
                            ProductID = 16,
                            CategoryID = 3,
                            Name = "Mojito Flowpack (vingummi)",
                            Price = 5.50m,
                            PriceDiscountID = 1,
                            SKU = "",
                            VendorID = 6
                        },
                        new
                        {
                            ProductID = 17,
                            CategoryID = 3,
                            Name = "Cosmopolitan Flowpack (vingummi)",
                            Price = 5.50m,
                            PriceDiscountID = 1,
                            SKU = "",
                            VendorID = 6
                        },
                        new
                        {
                            ProductID = 18,
                            CategoryID = 3,
                            Name = "Mojito Cube (vingummi)",
                            Price = 59.00m,
                            PriceDiscountID = 1,
                            SKU = "",
                            VendorID = 6
                        },
                        new
                        {
                            ProductID = 19,
                            CategoryID = 3,
                            Name = "Cosmopolitan Cube (vingummi)",
                            Price = 59.00m,
                            PriceDiscountID = 1,
                            SKU = "",
                            VendorID = 6
                        },
                        new
                        {
                            ProductID = 20,
                            CategoryID = 3,
                            Name = "Nuttercups - almonds (fyldte chokolader)",
                            Price = 14.95m,
                            PriceDiscountID = 1,
                            SKU = "",
                            VendorID = 8
                        },
                        new
                        {
                            ProductID = 21,
                            CategoryID = 4,
                            Name = "Sour cream and onion kartoffelchips",
                            Price = 28.95m,
                            PriceDiscountID = 1,
                            SKU = "",
                            VendorID = 4
                        },
                        new
                        {
                            ProductID = 22,
                            CategoryID = 4,
                            Name = "Sour cream and onion linsechips",
                            Price = 28.95m,
                            PriceDiscountID = 1,
                            SKU = "",
                            VendorID = 4
                        },
                        new
                        {
                            ProductID = 23,
                            CategoryID = 4,
                            Name = "Tang chips - sweet soy & sea salt",
                            Price = 12.95m,
                            PriceDiscountID = 1,
                            SKU = "",
                            VendorID = 4
                        },
                        new
                        {
                            ProductID = 24,
                            CategoryID = 4,
                            Name = "Veganske flæskevær",
                            Price = 19.95m,
                            PriceDiscountID = 1,
                            SKU = "",
                            VendorID = 8
                        },
                        new
                        {
                            ProductID = 25,
                            CategoryID = 7,
                            Name = "Soya pasta",
                            Price = 30.95m,
                            PriceDiscountID = 1,
                            SKU = "",
                            VendorID = 4
                        },
                        new
                        {
                            ProductID = 26,
                            CategoryID = 7,
                            Name = "Hørfrømel",
                            Price = 19.95m,
                            PriceDiscountID = 1,
                            SKU = "",
                            VendorID = 4
                        },
                        new
                        {
                            ProductID = 27,
                            CategoryID = 7,
                            Name = "Shirataki nudler",
                            Price = 16.95m,
                            PriceDiscountID = 1,
                            SKU = "",
                            VendorID = 1
                        },
                        new
                        {
                            ProductID = 28,
                            CategoryID = 7,
                            Name = "Shirataki ris",
                            Price = 18.95m,
                            PriceDiscountID = 1,
                            SKU = "",
                            VendorID = 1
                        },
                        new
                        {
                            ProductID = 29,
                            CategoryID = 9,
                            Name = "Frugtkassen (min. 4 kg)",
                            Price = 165.00m,
                            PriceDiscountID = 1,
                            SKU = ""
                        });
                });

            modelBuilder.Entity("DataLayer.Models.Vendors", b =>
                {
                    b.Property<int>("VendorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VendorID");

                    b.ToTable("Vendors");

                    b.HasData(
                        new
                        {
                            VendorID = 1,
                            Name = "Urtekram"
                        },
                        new
                        {
                            VendorID = 2,
                            Name = "Naturli"
                        },
                        new
                        {
                            VendorID = 3,
                            Name = "Dryk"
                        },
                        new
                        {
                            VendorID = 4,
                            Name = "Veganz"
                        },
                        new
                        {
                            VendorID = 5,
                            Name = "Happy Reindeer"
                        },
                        new
                        {
                            VendorID = 6,
                            Name = "Wally and Whiz"
                        },
                        new
                        {
                            VendorID = 7,
                            Name = "Nutty Vegan"
                        },
                        new
                        {
                            VendorID = 8,
                            Name = "Vantastic Foods"
                        });
                });

            modelBuilder.Entity("DataLayer.Models.Customers", b =>
                {
                    b.HasOne("DataLayer.Models.Cities", "City")
                        .WithMany("Customer")
                        .HasForeignKey("PostNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("DataLayer.Models.OrderItems", b =>
                {
                    b.HasOne("DataLayer.Models.Orders", "Orders")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Models.Products", "Products")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orders");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("DataLayer.Models.Orders", b =>
                {
                    b.HasOne("DataLayer.Models.Customers", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("DataLayer.Models.Products", b =>
                {
                    b.HasOne("DataLayer.Models.Categories", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Models.PriceDiscounts", "PriceDiscount")
                        .WithMany("Products")
                        .HasForeignKey("PriceDiscountID");

                    b.HasOne("DataLayer.Models.Vendors", "Vendor")
                        .WithMany("Products")
                        .HasForeignKey("VendorID");

                    b.Navigation("Category");

                    b.Navigation("PriceDiscount");

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("DataLayer.Models.Categories", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("DataLayer.Models.Cities", b =>
                {
                    b.Navigation("Customer");
                });

            modelBuilder.Entity("DataLayer.Models.Customers", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("DataLayer.Models.Orders", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("DataLayer.Models.PriceDiscounts", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("DataLayer.Models.Products", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("DataLayer.Models.Vendors", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
