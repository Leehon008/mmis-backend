using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class Incidents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IncidentNumber",
                table: "IncidentLogging",
                nullable: true,
                computedColumnSql: "+ 'IRX' + cast([Id] as varchar)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IncidentNumber",
                table: "IncidentLogging");
        }
    }
}
