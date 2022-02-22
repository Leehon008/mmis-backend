using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class AddTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AdditionTime",
                table: "BrewingMaltAddition",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionTime",
                table: "BrewingMaltAddition");
        }
    }
}
