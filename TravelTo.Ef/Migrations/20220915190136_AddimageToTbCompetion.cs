using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelTo.Ef.Migrations
{
    public partial class AddimageToTbCompetion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "TbCompetition",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "TbCompetition");
        }
    }
}
