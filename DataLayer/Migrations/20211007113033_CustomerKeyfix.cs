using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class CustomerKeyfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Cities_CityPostNumber",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CityPostNumber",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CityPostNumber",
                table: "Customers");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PostNumber",
                table: "Customers",
                column: "PostNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Cities_PostNumber",
                table: "Customers",
                column: "PostNumber",
                principalTable: "Cities",
                principalColumn: "PostNumber",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Cities_PostNumber",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_PostNumber",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "CityPostNumber",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CityPostNumber",
                table: "Customers",
                column: "CityPostNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Cities_CityPostNumber",
                table: "Customers",
                column: "CityPostNumber",
                principalTable: "Cities",
                principalColumn: "PostNumber",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
