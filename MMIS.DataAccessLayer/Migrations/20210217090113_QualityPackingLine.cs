using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class QualityPackingLine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PackingLine",
                table: "QualityPIPScud",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PackingLine",
                table: "QualityPIP",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PackingLine",
                table: "QualityPIPScud");

            migrationBuilder.DropColumn(
                name: "PackingLine",
                table: "QualityPIP");
        }
    }
}
