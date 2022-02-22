using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class CIP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BrewNumber",
                table: "BrewingSuperBBT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "BrewingSuperBBT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "BrewingSuperBBT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "BrewNumber",
                table: "BrewingMaltAddition",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "BrewingMaltAddition",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "BrewingMaltAddition",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrewNumber",
                table: "BrewingSuperBBT");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "BrewingSuperBBT");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "BrewingSuperBBT");

            migrationBuilder.DropColumn(
                name: "BrewNumber",
                table: "BrewingMaltAddition");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "BrewingMaltAddition");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "BrewingMaltAddition");
        }
    }
}
