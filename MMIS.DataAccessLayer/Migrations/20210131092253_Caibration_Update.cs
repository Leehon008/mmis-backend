using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class Caibration_Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
             name: "Date",
             table: "Alcolyser",
             nullable: false,
             defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
            name: "Date",
            table: "Viscometer",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
          name: "Date",
          table: "Refractometer",
          nullable: false,
          defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
          name: "Date",
          table: "PHMeter",
          nullable: false,
          defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
