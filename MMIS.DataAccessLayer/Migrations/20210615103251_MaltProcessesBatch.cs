using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class MaltProcessesBatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrewNumber",
                table: "MaltingsMaltProcesses");

            migrationBuilder.AddColumn<string>(
                name: "MaltBatch",
                table: "MaltingsMaltProcesses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaltBatch",
                table: "MaltingsMaltProcesses");

            migrationBuilder.AddColumn<string>(
                name: "BrewNumber",
                table: "MaltingsMaltProcesses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
