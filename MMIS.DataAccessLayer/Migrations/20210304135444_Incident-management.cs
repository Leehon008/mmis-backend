using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class Incidentmanagement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "description",
                table: "EnvironmentalIncidentMedia",
                newName: "Description");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "EnvironmentalIncidentMedia",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EnvironmentalIncidentMedia");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "EnvironmentalIncidentMedia",
                newName: "description");
        }
    }
}
