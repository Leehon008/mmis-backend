using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class UtilitiesEng : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UtilitiesBCOL",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Shift = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Inspector = table.Column<string>(nullable: true),
                    tank_ID = table.Column<string>(nullable: true),
                    CoolingWaterTemperature = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilitiesBCOL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UtilitiesHourlyUsageCO2",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Shift = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Inspector = table.Column<string>(nullable: true),
                    Hour = table.Column<int>(nullable: false),
                    tank_ID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilitiesHourlyUsageCO2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UtilitiesHourlyUsageDiesel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Shift = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Inspector = table.Column<string>(nullable: true),
                    Hour = table.Column<int>(nullable: false),
                    genset_ID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilitiesHourlyUsageDiesel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UtilitiesHourlyUsageElectricity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Shift = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Inspector = table.Column<string>(nullable: true),
                    Hour = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilitiesHourlyUsageElectricity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UtilitiesHourlyUsageSteam",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Shift = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Inspector = table.Column<string>(nullable: true),
                    Hour = table.Column<int>(nullable: false),
                    boiler_ID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilitiesHourlyUsageSteam", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UtilitiesHourlyUsageWater",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Shift = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Inspector = table.Column<string>(nullable: true),
                    Hour = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilitiesHourlyUsageWater", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UtilitiesIQMS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Shift = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Inspector = table.Column<string>(nullable: true),
                    AssetTagCO2 = table.Column<string>(nullable: true),
                    CO2Taste = table.Column<string>(nullable: true),
                    CO2Smell = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilitiesIQMS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UtilitiesMeter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    PID = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Process = table.Column<string>(nullable: true),
                    Feed = table.Column<string>(nullable: true),
                    Frequency = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilitiesMeter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UtilitiesPREF",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Shift = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Inspector = table.Column<string>(nullable: true),
                    Tank_ID = table.Column<string>(nullable: true),
                    Glycolpressure = table.Column<decimal>(nullable: false),
                    Glycoltemperature = table.Column<decimal>(nullable: false),
                    Beertemperature = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilitiesPREF", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UtilitiesShiftEnd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Shift = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Inspector = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilitiesShiftEnd", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UtilitiesShiftStart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Shift = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Inspector = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilitiesShiftStart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HourlyUsageBCOL",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PIdId = table.Column<int>(nullable: true),
                    Hour = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Reading = table.Column<decimal>(nullable: false),
                    Usage = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HourlyUsageBCOL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HourlyUsageBCOL_UtilitiesBCOL_PIdId",
                        column: x => x.PIdId,
                        principalTable: "UtilitiesBCOL",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeterReadingCO2",
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
                    table.PrimaryKey("PK_MeterReadingCO2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeterReadingCO2_UtilitiesHourlyUsageCO2_HUIdId",
                        column: x => x.HUIdId,
                        principalTable: "UtilitiesHourlyUsageCO2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeterReadingDiesel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HUIdId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Reading = table.Column<decimal>(nullable: false),
                    Usage = table.Column<decimal>(nullable: false),
                    HourlyUsageDieselId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeterReadingDiesel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeterReadingDiesel_UtilitiesHourlyUsageCO2_HUIdId",
                        column: x => x.HUIdId,
                        principalTable: "UtilitiesHourlyUsageCO2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeterReadingDiesel_UtilitiesHourlyUsageDiesel_HourlyUsageDieselId",
                        column: x => x.HourlyUsageDieselId,
                        principalTable: "UtilitiesHourlyUsageDiesel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeterReadingSteam",
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
                    table.PrimaryKey("PK_MeterReadingSteam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeterReadingSteam_UtilitiesHourlyUsageSteam_HUIdId",
                        column: x => x.HUIdId,
                        principalTable: "UtilitiesHourlyUsageSteam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeterReading",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HUIdId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Reading = table.Column<decimal>(nullable: false),
                    Usage = table.Column<decimal>(nullable: false),
                    HourlyUsageWaterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeterReading", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeterReading_UtilitiesHourlyUsageElectricity_HUIdId",
                        column: x => x.HUIdId,
                        principalTable: "UtilitiesHourlyUsageElectricity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeterReading_UtilitiesHourlyUsageWater_HourlyUsageWaterId",
                        column: x => x.HourlyUsageWaterId,
                        principalTable: "UtilitiesHourlyUsageWater",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WaterParameters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PIdId = table.Column<int>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    AssetTag = table.Column<string>(nullable: true),
                    Hardness = table.Column<decimal>(nullable: false),
                    Sulphates = table.Column<decimal>(nullable: false),
                    HardnessAsCaCO3 = table.Column<decimal>(nullable: false),
                    AlkalinityAsCaCO3 = table.Column<decimal>(nullable: false),
                    AlkalinityAsOH = table.Column<decimal>(nullable: false),
                    MalkalinityCO3OH = table.Column<decimal>(nullable: false),
                    Chlorides = table.Column<decimal>(nullable: false),
                    TDS = table.Column<decimal>(nullable: false),
                    pH = table.Column<decimal>(nullable: false),
                    Conductivity = table.Column<decimal>(nullable: false),
                    Micro = table.Column<decimal>(nullable: false),
                    Taste = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WaterParameters_UtilitiesIQMS_PIdId",
                        column: x => x.PIdId,
                        principalTable: "UtilitiesIQMS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HourlyCooling",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PIdId = table.Column<int>(nullable: true),
                    Hour = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Reading = table.Column<decimal>(nullable: false),
                    CoolTemp = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HourlyCooling", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HourlyCooling_UtilitiesPREF_PIdId",
                        column: x => x.PIdId,
                        principalTable: "UtilitiesPREF",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HourlyCooling_PIdId",
                table: "HourlyCooling",
                column: "PIdId");

            migrationBuilder.CreateIndex(
                name: "IX_HourlyUsageBCOL_PIdId",
                table: "HourlyUsageBCOL",
                column: "PIdId");

            migrationBuilder.CreateIndex(
                name: "IX_MeterReading_HUIdId",
                table: "MeterReading",
                column: "HUIdId");

            migrationBuilder.CreateIndex(
                name: "IX_MeterReading_HourlyUsageWaterId",
                table: "MeterReading",
                column: "HourlyUsageWaterId");

            migrationBuilder.CreateIndex(
                name: "IX_MeterReadingCO2_HUIdId",
                table: "MeterReadingCO2",
                column: "HUIdId");

            migrationBuilder.CreateIndex(
                name: "IX_MeterReadingDiesel_HUIdId",
                table: "MeterReadingDiesel",
                column: "HUIdId");

            migrationBuilder.CreateIndex(
                name: "IX_MeterReadingDiesel_HourlyUsageDieselId",
                table: "MeterReadingDiesel",
                column: "HourlyUsageDieselId");

            migrationBuilder.CreateIndex(
                name: "IX_MeterReadingSteam_HUIdId",
                table: "MeterReadingSteam",
                column: "HUIdId");

            migrationBuilder.CreateIndex(
                name: "IX_WaterParameters_PIdId",
                table: "WaterParameters",
                column: "PIdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HourlyCooling");

            migrationBuilder.DropTable(
                name: "HourlyUsageBCOL");

            migrationBuilder.DropTable(
                name: "MeterReading");

            migrationBuilder.DropTable(
                name: "MeterReadingCO2");

            migrationBuilder.DropTable(
                name: "MeterReadingDiesel");

            migrationBuilder.DropTable(
                name: "MeterReadingSteam");

            migrationBuilder.DropTable(
                name: "UtilitiesMeter");

            migrationBuilder.DropTable(
                name: "UtilitiesShiftEnd");

            migrationBuilder.DropTable(
                name: "UtilitiesShiftStart");

            migrationBuilder.DropTable(
                name: "WaterParameters");

            migrationBuilder.DropTable(
                name: "UtilitiesPREF");

            migrationBuilder.DropTable(
                name: "UtilitiesBCOL");

            migrationBuilder.DropTable(
                name: "UtilitiesHourlyUsageElectricity");

            migrationBuilder.DropTable(
                name: "UtilitiesHourlyUsageWater");

            migrationBuilder.DropTable(
                name: "UtilitiesHourlyUsageCO2");

            migrationBuilder.DropTable(
                name: "UtilitiesHourlyUsageDiesel");

            migrationBuilder.DropTable(
                name: "UtilitiesHourlyUsageSteam");

            migrationBuilder.DropTable(
                name: "UtilitiesIQMS");
        }
    }
}
