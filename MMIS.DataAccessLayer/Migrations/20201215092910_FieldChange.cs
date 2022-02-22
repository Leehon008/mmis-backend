using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class FieldChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EorrectTools",
                table: "IncidentInvestigation");

            migrationBuilder.AddColumn<string>(
                name: "CorrectTools",
                table: "IncidentInvestigation",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorrectTools",
                table: "IncidentInvestigation");

            migrationBuilder.AddColumn<string>(
                name: "EorrectTools",
                table: "IncidentInvestigation",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
