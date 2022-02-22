using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class ProductionTimes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeterReading_UtilitiesHourlyUsageWater_HourlyUsageWaterId",
                table: "MeterReading");

            migrationBuilder.DropForeignKey(
                name: "FK_MeterReadingDiesel_UtilitiesHourlyUsageCO2_HUIdId",
                table: "MeterReadingDiesel");

            migrationBuilder.DropForeignKey(
                name: "FK_MeterReadingDiesel_UtilitiesHourlyUsageDiesel_HourlyUsageDieselId",
                table: "MeterReadingDiesel");

            migrationBuilder.DropIndex(
                name: "IX_MeterReadingDiesel_HourlyUsageDieselId",
                table: "MeterReadingDiesel");

            migrationBuilder.DropIndex(
                name: "IX_MeterReading_HourlyUsageWaterId",
                table: "MeterReading");

            migrationBuilder.DropColumn(
                name: "HourlyUsageDieselId",
                table: "MeterReadingDiesel");

            migrationBuilder.DropColumn(
                name: "HourlyUsageWaterId",
                table: "MeterReading");

            migrationBuilder.AddColumn<double>(
                name: "StandardHours",
                table: "ShiftHeader",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "StdAdjustedHours",
                table: "ShiftHeader",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "StdOperatingHours",
                table: "ShiftHeader",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "StdProcessingHours",
                table: "ShiftHeader",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "WaterMeterReading",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HUIdId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Reading = table.Column<decimal>(nullable: false),
                    Usage = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterMeterReading", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WaterMeterReading_UtilitiesHourlyUsageWater_HUIdId",
                        column: x => x.HUIdId,
                        principalTable: "UtilitiesHourlyUsageWater",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WaterMeterReading_HUIdId",
                table: "WaterMeterReading",
                column: "HUIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeterReadingDiesel_UtilitiesHourlyUsageDiesel_HUIdId",
                table: "MeterReadingDiesel",
                column: "HUIdId",
                principalTable: "UtilitiesHourlyUsageDiesel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeterReadingDiesel_UtilitiesHourlyUsageDiesel_HUIdId",
                table: "MeterReadingDiesel");

            migrationBuilder.DropTable(
                name: "WaterMeterReading");

            migrationBuilder.DropColumn(
                name: "StandardHours",
                table: "ShiftHeader");

            migrationBuilder.DropColumn(
                name: "StdAdjustedHours",
                table: "ShiftHeader");

            migrationBuilder.DropColumn(
                name: "StdOperatingHours",
                table: "ShiftHeader");

            migrationBuilder.DropColumn(
                name: "StdProcessingHours",
                table: "ShiftHeader");

            migrationBuilder.AddColumn<int>(
                name: "HourlyUsageDieselId",
                table: "MeterReadingDiesel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HourlyUsageWaterId",
                table: "MeterReading",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MeterReadingDiesel_HourlyUsageDieselId",
                table: "MeterReadingDiesel",
                column: "HourlyUsageDieselId");

            migrationBuilder.CreateIndex(
                name: "IX_MeterReading_HourlyUsageWaterId",
                table: "MeterReading",
                column: "HourlyUsageWaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeterReading_UtilitiesHourlyUsageWater_HourlyUsageWaterId",
                table: "MeterReading",
                column: "HourlyUsageWaterId",
                principalTable: "UtilitiesHourlyUsageWater",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MeterReadingDiesel_UtilitiesHourlyUsageCO2_HUIdId",
                table: "MeterReadingDiesel",
                column: "HUIdId",
                principalTable: "UtilitiesHourlyUsageCO2",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MeterReadingDiesel_UtilitiesHourlyUsageDiesel_HourlyUsageDieselId",
                table: "MeterReadingDiesel",
                column: "HourlyUsageDieselId",
                principalTable: "UtilitiesHourlyUsageDiesel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
