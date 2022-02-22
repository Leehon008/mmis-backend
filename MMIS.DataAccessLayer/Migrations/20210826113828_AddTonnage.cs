using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class AddTonnage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Tonnage",
                table: "MaltingsMilling",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tonnage",
                table: "MaltingsMilling");
        }
    }
}
