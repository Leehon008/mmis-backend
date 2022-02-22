using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class MaltingsInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaltingsGermination",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Shift = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Attendant = table.Column<string>(nullable: true),
                    Temperature = table.Column<decimal>(nullable: false),
                    ChitCount = table.Column<decimal>(nullable: false),
                    MoistureContent = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaltingsGermination", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaltingsKilning",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Shift = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Attendant = table.Column<string>(nullable: true),
                    KilnTemperature = table.Column<decimal>(nullable: false),
                    BoilerPressure = table.Column<decimal>(nullable: false),
                    MoistureExkiln = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaltingsKilning", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaltingsMaintenance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Shift = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Attendant = table.Column<string>(nullable: true),
                    JobcardNumber = table.Column<string>(nullable: true),
                    SAPWorkorderNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaltingsMaintenance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaltingsMaltBatch",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Shift = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Attendant = table.Column<string>(nullable: true),
                    BufferVolume = table.Column<decimal>(nullable: false),
                    SteepTanks = table.Column<string>(nullable: true),
                    GKVnumber = table.Column<decimal>(nullable: false),
                    BatchNumber = table.Column<string>(nullable: true),
                    DateSteeped = table.Column<DateTime>(nullable: false),
                    TonnageSteeped = table.Column<decimal>(nullable: false),
                    GrainVariety = table.Column<string>(nullable: true),
                    GrainSource = table.Column<string>(nullable: true),
                    GerminationDuration = table.Column<string>(nullable: true),
                    SprayType = table.Column<string>(nullable: true),
                    SprayVolume = table.Column<decimal>(nullable: false),
                    ChitCount = table.Column<string>(nullable: true),
                    MoistureContent = table.Column<string>(nullable: true),
                    AirOn = table.Column<string>(nullable: true),
                    AirOff = table.Column<string>(nullable: true),
                    DateStartKiln = table.Column<DateTime>(nullable: false),
                    KilnTime = table.Column<decimal>(nullable: false),
                    ExKilnDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaltingsMaltBatch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaltingsOverseerInput",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Shift = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Attendant = table.Column<string>(nullable: true),
                    RiskAssessmentNumber = table.Column<string>(nullable: true),
                    CleaningDuration = table.Column<decimal>(nullable: false),
                    FactoryCapacity = table.Column<decimal>(nullable: false),
                    MachineDowntimeType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaltingsOverseerInput", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaltingsSorghumGrain",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Shift = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Attendant = table.Column<string>(nullable: true),
                    Moisture = table.Column<decimal>(nullable: false),
                    Unthreashed = table.Column<decimal>(nullable: false),
                    Chipped = table.Column<decimal>(nullable: false),
                    ForeginMatter = table.Column<decimal>(nullable: false),
                    GerminativeCapacity = table.Column<decimal>(nullable: false),
                    Infestation = table.Column<decimal>(nullable: false),
                    PreGermination = table.Column<decimal>(nullable: false),
                    Defective = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaltingsSorghumGrain", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaltingsSteeping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Shift = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Attendant = table.Column<string>(nullable: true),
                    Tonnage = table.Column<decimal>(nullable: false),
                    WaterTemp = table.Column<decimal>(nullable: false),
                    BlowerPressure = table.Column<decimal>(nullable: false),
                    CalciumHydroxideAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaltingsSteeping", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaltingsGermination");

            migrationBuilder.DropTable(
                name: "MaltingsKilning");

            migrationBuilder.DropTable(
                name: "MaltingsMaintenance");

            migrationBuilder.DropTable(
                name: "MaltingsMaltBatch");

            migrationBuilder.DropTable(
                name: "MaltingsOverseerInput");

            migrationBuilder.DropTable(
                name: "MaltingsSorghumGrain");

            migrationBuilder.DropTable(
                name: "MaltingsSteeping");
        }
    }
}
