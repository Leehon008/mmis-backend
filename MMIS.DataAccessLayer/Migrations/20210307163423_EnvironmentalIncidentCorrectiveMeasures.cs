using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class EnvironmentalIncidentCorrectiveMeasures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "IncidentVehicleInformation",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EnvironmentalIncidentCorrectiveMeasures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    IncidentNumber = table.Column<string>(nullable: true),
                    IncidentType = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    AssignedTo = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnvironmentalIncidentCorrectiveMeasures", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnvironmentalIncidentCorrectiveMeasures");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "IncidentVehicleInformation");
        }
    }
}
