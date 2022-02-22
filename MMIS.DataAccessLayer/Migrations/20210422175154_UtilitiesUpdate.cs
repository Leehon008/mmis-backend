using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class UtilitiesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Frequency",
                table: "UtilitiesHourlyUsageWater",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Frequency",
                table: "UtilitiesHourlyUsageSteam",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Frequency",
                table: "UtilitiesHourlyUsageElectricity",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Frequency",
                table: "UtilitiesHourlyUsageDiesel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Frequency",
                table: "UtilitiesHourlyUsageCO2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Receipt",
                table: "MeterReadingSteam",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Receipt",
                table: "MeterReadingDiesel",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Receipt",
                table: "MeterReadingCO2",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "UtilitiesHourlyUsageWater");

            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "UtilitiesHourlyUsageSteam");

            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "UtilitiesHourlyUsageElectricity");

            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "UtilitiesHourlyUsageDiesel");

            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "UtilitiesHourlyUsageCO2");

            migrationBuilder.DropColumn(
                name: "Receipt",
                table: "MeterReadingSteam");

            migrationBuilder.DropColumn(
                name: "Receipt",
                table: "MeterReadingDiesel");

            migrationBuilder.DropColumn(
                name: "Receipt",
                table: "MeterReadingCO2");
        }
    }
}
