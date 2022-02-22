using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class IncidentDepartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IcidentID",
                table: "IncidentTypes");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "SHEMails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IncidentID",
                table: "IncidentTypes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "SHEMails");

            migrationBuilder.DropColumn(
                name: "IncidentID",
                table: "IncidentTypes");

            migrationBuilder.AddColumn<string>(
                name: "IcidentID",
                table: "IncidentTypes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
