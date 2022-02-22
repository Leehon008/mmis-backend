using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class RemoveMaizeFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BatchNo",
                table: "QualityRIMaize");

            migrationBuilder.DropColumn(
                name: "COA",
                table: "QualityRIMaize");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BatchNo",
                table: "QualityRIMaize",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "COA",
                table: "QualityRIMaize",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
