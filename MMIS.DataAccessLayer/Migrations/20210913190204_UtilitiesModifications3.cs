using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class UtilitiesModifications3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "UtilitiesUnits");

            migrationBuilder.AddColumn<string>(
                name: "Abbr",
                table: "UtilitiesUnits",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Abbr",
                table: "UtilitiesUnits");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "UtilitiesUnits",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
