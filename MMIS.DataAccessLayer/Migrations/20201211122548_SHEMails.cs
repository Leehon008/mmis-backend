using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class SHEMails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PitchingTime",
                table: "BrewingYeastHandling");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfReceipt",
                table: "BrewingYeastHandling",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "IncidentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    IcidentID = table.Column<string>(nullable: true),
                    IncidentType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SHEMails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    PositionID = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHEMails", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncidentTypes");

            migrationBuilder.DropTable(
                name: "SHEMails");

            migrationBuilder.DropColumn(
                name: "DateOfReceipt",
                table: "BrewingYeastHandling");

            migrationBuilder.AddColumn<decimal>(
                name: "PitchingTime",
                table: "BrewingYeastHandling",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
