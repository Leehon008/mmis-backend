using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class UtilitiesModifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "UtilitiesMeter",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "UtilitiesMeter",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "UtilitiesMeter",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "UtilitiesHourlyUsageWater",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "UtilitiesHourlyUsageSteam",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "UtilitiesHourlyUsageElectricity",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "UtilitiesHourlyUsageDiesel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "UtilitiesHourlyUsageCO2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "UtilitiesMeter");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "UtilitiesMeter");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "UtilitiesMeter");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "UtilitiesHourlyUsageWater");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "UtilitiesHourlyUsageSteam");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "UtilitiesHourlyUsageElectricity");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "UtilitiesHourlyUsageDiesel");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "UtilitiesHourlyUsageCO2");
        }
    }
}
