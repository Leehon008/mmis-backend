using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class MaltingFieldsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BrewNo",
                table: "QualityPQIOtherScud",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "QualityPQIOtherScud",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "BrewNo",
                table: "QualityPQIOther",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "QualityPQIOther",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "STONumber",
                table: "MaltingsMilling",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tonnage",
                table: "MaltingsMilling",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GKV",
                table: "MaltingsGermination",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sprays",
                table: "MaltingsGermination",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrewNo",
                table: "QualityPQIOtherScud");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "QualityPQIOtherScud");

            migrationBuilder.DropColumn(
                name: "BrewNo",
                table: "QualityPQIOther");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "QualityPQIOther");

            migrationBuilder.DropColumn(
                name: "STONumber",
                table: "MaltingsMilling");

            migrationBuilder.DropColumn(
                name: "Tonnage",
                table: "MaltingsMilling");

            migrationBuilder.DropColumn(
                name: "GKV",
                table: "MaltingsGermination");

            migrationBuilder.DropColumn(
                name: "Sprays",
                table: "MaltingsGermination");
        }
    }
}
