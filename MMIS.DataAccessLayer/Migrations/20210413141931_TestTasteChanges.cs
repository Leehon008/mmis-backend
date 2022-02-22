using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class TestTasteChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductType",
                table: "QualityTasteTest",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TasteTest",
                table: "QualitySLParameters",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "QualityTasteTest");

            migrationBuilder.DropColumn(
                name: "TasteTest",
                table: "QualitySLParameters");
        }
    }
}
