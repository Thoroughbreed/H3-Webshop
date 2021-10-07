using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class DataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    PostNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.PostNumber);
                });

            migrationBuilder.CreateTable(
                name: "PriceDiscounts",
                columns: table => new
                {
                    PriceDiscountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscountValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceDiscounts", x => x.PriceDiscountID);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    VendorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.VendorID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoadName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoadNumber = table.Column<int>(type: "int", nullable: false),
                    PostNumber = table.Column<int>(type: "int", nullable: false),
                    PhoneMain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneMobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderAmount = table.Column<int>(type: "int", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Customers_Cities_PostNumber",
                        column: x => x.PostNumber,
                        principalTable: "Cities",
                        principalColumn: "PostNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceDiscountID = table.Column<int>(type: "int", nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    VendorID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_PriceDiscounts_PriceDiscountID",
                        column: x => x.PriceDiscountID,
                        principalTable: "PriceDiscounts",
                        principalColumn: "PriceDiscountID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Vendors_VendorID",
                        column: x => x.VendorID,
                        principalTable: "Vendors",
                        principalColumn: "VendorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    LinePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => new { x.OrderID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Category" },
                values: new object[,]
                {
                    { 1, "Kød & pålæg" },
                    { 2, "Drikke" },
                    { 3, "Slik & chokolade" },
                    { 4, "Snacks, kiks & kage" },
                    { 5, "Nødder & bælgfrugter" },
                    { 7, "Glutenfri" },
                    { 8, "Bønner, frø & linser" },
                    { 9, "Frisk frugt & grønt" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "PostNumber", "Name" },
                values: new object[,]
                {
                    { 2400, "København NV" },
                    { 6300, "Sønderborg" },
                    { 6200, "Aabenraa" },
                    { 6270, "Tønder" },
                    { 6000, "Kolding" }
                });

            migrationBuilder.InsertData(
                table: "PriceDiscounts",
                columns: new[] { "PriceDiscountID", "DiscountCode", "DiscountValue" },
                values: new object[,]
                {
                    { 1, null, 0 },
                    { 2, "Vegan10", 10 },
                    { 3, null, 50 },
                    { 4, "GrandOpening", 3 }
                });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "VendorID", "Name" },
                values: new object[,]
                {
                    { 7, "Nutty Vegan" },
                    { 1, "Urtekram" },
                    { 2, "Naturli" },
                    { 3, "Dryk" },
                    { 4, "Veganz" },
                    { 5, "Happy Reindeer" },
                    { 6, "Wally and Whiz" },
                    { 8, "Vantastic Foods" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CategoryID", "Name", "Price", "PriceDiscountID", "SKU", "VendorID" },
                values: new object[,]
                {
                    { 29, 9, "Frugtkassen (min. 4 kg)", 165.00m, 1, "", null },
                    { 3, 1, "Naturel tofu", 19.95m, 1, "", 8 },
                    { 2, 1, "Røget tofu", 19.95m, 1, "", 8 },
                    { 1, 1, "Tunno - Vegansk tun", 32.95m, 1, "", 7 },
                    { 19, 3, "Cosmopolitan Cube (vingummi)", 59.00m, 1, "", 6 },
                    { 18, 3, "Mojito Cube (vingummi)", 59.00m, 1, "", 6 },
                    { 17, 3, "Cosmopolitan Flowpack (vingummi)", 5.50m, 1, "", 6 },
                    { 16, 3, "Mojito Flowpack (vingummi)", 5.50m, 1, "", 6 },
                    { 15, 3, "Lakridshyl", 12.50m, 1, "", 5 },
                    { 14, 3, "Finsk lakrids", 28.00m, 1, "", 5 },
                    { 26, 7, "Hørfrømel", 19.95m, 1, "", 4 },
                    { 25, 7, "Soya pasta", 30.95m, 1, "", 4 },
                    { 23, 4, "Tang chips - sweet soy & sea salt", 12.95m, 1, "", 4 },
                    { 20, 3, "Nuttercups - almonds (fyldte chokolader)", 14.95m, 1, "", 8 },
                    { 22, 4, "Sour cream and onion linsechips", 28.95m, 1, "", 4 },
                    { 5, 1, "Jackfruit confit", 22.00m, 1, "", 4 },
                    { 4, 1, "Seitan med karry", 26.95m, 1, "", 4 },
                    { 11, 2, "Vegansk Iskaffe", 17.95m, 1, "", 3 },
                    { 10, 2, "Havrekakao", 19.95m, 1, "", 2 },
                    { 9, 2, "Havredrik Barista Edition", 20.95m, 1, "", 2 },
                    { 8, 2, "Havredrik (natural)", 19.95m, 1, "", 2 },
                    { 7, 2, "Instant cappuccino pulpver", 69.00m, 1, "", 2 },
                    { 28, 7, "Shirataki ris", 18.95m, 1, "", 1 },
                    { 27, 7, "Shirataki nudler", 16.95m, 1, "", 1 },
                    { 13, 3, "Candy Kittens - cherry flavour", 32.00m, 1, "", 1 },
                    { 12, 3, "Veganske trøfler i gaveæske (salted caramel)", 55.00m, 1, "", 1 },
                    { 6, 2, "Økologisk kokosmælk", 19.95m, 1, "", 1 },
                    { 21, 4, "Sour cream and onion kartoffelchips", 28.95m, 1, "", 4 },
                    { 24, 4, "Veganske flæskevær", 19.95m, 1, "", 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PostNumber",
                table: "Customers",
                column: "PostNumber");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductID",
                table: "OrderItems",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PriceDiscountID",
                table: "Products",
                column: "PriceDiscountID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_VendorID",
                table: "Products",
                column: "VendorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "PriceDiscounts");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
