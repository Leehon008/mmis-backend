using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class BrewingStdUpdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "BrewingProcessTimeStds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Product",
                table: "BrewingProcessTimeStds",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "BrewingProcessTimeStds");

            migrationBuilder.DropColumn(
                name: "Product",
                table: "BrewingProcessTimeStds");
        }
    }
}
