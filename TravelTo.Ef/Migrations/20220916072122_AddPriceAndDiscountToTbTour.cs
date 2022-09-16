using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelTo.Ef.Migrations
{
    public partial class AddPriceAndDiscountToTbTour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "TbTour",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "TbTour",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "TbTour");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "TbTour");
        }
    }
}
