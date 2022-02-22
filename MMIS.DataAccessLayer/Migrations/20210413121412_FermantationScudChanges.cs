using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class FermantationScudChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Volume",
                table: "QualityFermentationSuper",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Volume",
                table: "QualityFermentationScud",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Volume",
                table: "FParametersScud",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Volume",
                table: "QualityFermentationSuper");

            migrationBuilder.DropColumn(
                name: "Volume",
                table: "QualityFermentationScud");

            migrationBuilder.DropColumn(
                name: "Volume",
                table: "FParametersScud");
        }
    }
}
