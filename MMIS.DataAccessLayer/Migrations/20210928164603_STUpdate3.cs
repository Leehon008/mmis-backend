using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class STUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "MWSTsLineItems");

            migrationBuilder.DropColumn(
                name: "Personnel",
                table: "MWSTsLineItems");

            migrationBuilder.DropColumn(
                name: "Plant",
                table: "MWSTsLineItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "MWSTsLineItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Personnel",
                table: "MWSTsLineItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plant",
                table: "MWSTsLineItems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
