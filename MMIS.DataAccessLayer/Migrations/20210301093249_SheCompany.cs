using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class SheCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "IncidentLogging",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "IncidentInvestigation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NOSANumber",
                table: "IncidentInvestigation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "IncidentInvestigation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "IncidentCauses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "EnvironmentalIncidentInvestigation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "EnvironmentalIncident",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "EnvironmentalIncident",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Company",
                table: "IncidentLogging");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "IncidentInvestigation");

            migrationBuilder.DropColumn(
                name: "NOSANumber",
                table: "IncidentInvestigation");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "IncidentInvestigation");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "IncidentCauses");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "EnvironmentalIncidentInvestigation");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "EnvironmentalIncident");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "EnvironmentalIncident");
        }
    }
}
