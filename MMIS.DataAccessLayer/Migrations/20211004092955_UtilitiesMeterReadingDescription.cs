using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class UtilitiesMeterReadingDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "WaterMeterReading",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MeterReadingSteam",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MeterReadingDiesel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MeterReadingCO2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MeterReading",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "WaterMeterReading");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "MeterReadingSteam");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "MeterReadingDiesel");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "MeterReadingCO2");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "MeterReading");
        }
    }
}
