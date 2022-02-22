using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class Changemanagement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FinesPossibility",
                table: "PermitsAndLicenses",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IncidentNumber",
                table: "ExpensesBreakDown",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinesPossibility",
                table: "PermitsAndLicenses");

            migrationBuilder.DropColumn(
                name: "IncidentNumber",
                table: "ExpensesBreakDown");
        }
    }
}
