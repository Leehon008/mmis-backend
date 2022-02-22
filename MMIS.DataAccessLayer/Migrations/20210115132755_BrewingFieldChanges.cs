using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class BrewingFieldChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "AdditionTime",
            //    table: "BrewingMaltAddition",
            //    nullable: false,
            //    oldClrType: typeof(decimal),
            //    oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Vessel",
                table: "BrewingCoolTo54",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<decimal>(
            //    name: "AdditionTime",
            //    table: "BrewingMaltAddition",
            //    type: "decimal(18,2)",
            //    nullable: false,
            //    oldClrType: typeof(DateTime));

            //migrationBuilder.AlterColumn<decimal>(
            //    name: "Vessel",
            //    table: "BrewingCoolTo54",
            //    type: "decimal(18,2)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldNullable: true);
        }
    }
}
