using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class MaltingsAdditions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AirOff",
                table: "MaltingsMaltBatch");

            migrationBuilder.DropColumn(
                name: "AirOn",
                table: "MaltingsMaltBatch");

            migrationBuilder.DropColumn(
                name: "BufferVolume",
                table: "MaltingsMaltBatch");

            migrationBuilder.DropColumn(
                name: "ChitCount",
                table: "MaltingsMaltBatch");

            migrationBuilder.DropColumn(
                name: "DateStartKiln",
                table: "MaltingsMaltBatch");

            migrationBuilder.DropColumn(
                name: "DateSteeped",
                table: "MaltingsMaltBatch");

            migrationBuilder.DropColumn(
                name: "ExKilnDate",
                table: "MaltingsMaltBatch");

            migrationBuilder.DropColumn(
                name: "GKVnumber",
                table: "MaltingsMaltBatch");

            migrationBuilder.DropColumn(
                name: "GerminationDuration",
                table: "MaltingsMaltBatch");

            migrationBuilder.DropColumn(
                name: "GrainSource",
                table: "MaltingsMaltBatch");

            migrationBuilder.DropColumn(
                name: "GrainVariety",
                table: "MaltingsMaltBatch");

            migrationBuilder.DropColumn(
                name: "KilnTime",
                table: "MaltingsMaltBatch");

            migrationBuilder.DropColumn(
                name: "MoistureContent",
                table: "MaltingsMaltBatch");

            migrationBuilder.DropColumn(
                name: "SprayType",
                table: "MaltingsMaltBatch");

            migrationBuilder.DropColumn(
                name: "SprayVolume",
                table: "MaltingsMaltBatch");

            migrationBuilder.DropColumn(
                name: "SteepTanks",
                table: "MaltingsMaltBatch");

            migrationBuilder.DropColumn(
                name: "TonnageSteeped",
                table: "MaltingsMaltBatch");

            migrationBuilder.AddColumn<string>(
                name: "BatchNumber",
                table: "MaltingsSteeping",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BatchNumber",
                table: "MaltingsSorghumGrain",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobcardNumber",
                table: "MaltingsMaltBatch",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SAPWorkorderNumber",
                table: "MaltingsMaltBatch",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WaterSource",
                table: "MaltingsMaltBatch",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BatchNumber",
                table: "MaltingsKilning",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BatchNumber",
                table: "MaltingsGermination",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MaltingsDryEndMalt",
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
                    BatchNumber = table.Column<string>(nullable: true),
                    HMBStatus = table.Column<decimal>(nullable: false),
                    MillngStartTime = table.Column<string>(nullable: true),
                    HourlyHammerMillEfficiency = table.Column<decimal>(nullable: false),
                    MaltMilled = table.Column<DateTime>(nullable: false),
                    SieveAnalysis = table.Column<string>(nullable: true),
                    MaltLoadedStart = table.Column<DateTime>(nullable: false),
                    MaltLoadedEnd = table.Column<DateTime>(nullable: false),
                    MaltLoaded = table.Column<decimal>(nullable: false),
                    MaltDispatched = table.Column<decimal>(nullable: false),
                    MaltOnFloor = table.Column<decimal>(nullable: false),
                    PieceMillingStartTime = table.Column<DateTime>(nullable: false),
                    PieceMillingEndTime = table.Column<DateTime>(nullable: false),
                    TotalPieceMillingTime = table.Column<decimal>(nullable: false),
                    PieceTonnage = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaltingsDryEndMalt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaltingsMaltingCycle",
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
                    MaltId = table.Column<int>(nullable: false),
                    TotalCycleTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaltingsMaltingCycle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaltingsMStocks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Material = table.Column<string>(nullable: true),
                    OpeningStock = table.Column<decimal>(nullable: false),
                    ClosingStock = table.Column<decimal>(nullable: false),
                    BatchId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaltingsMStocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaltingsMStocks_MaltingsMaltBatch_BatchId",
                        column: x => x.BatchId,
                        principalTable: "MaltingsMaltBatch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaltingsWetEndMalt",
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
                    BatchNumber = table.Column<string>(nullable: true),
                    BufferVolume = table.Column<decimal>(nullable: false),
                    SteepTanks = table.Column<string>(nullable: true),
                    GKVnumber = table.Column<decimal>(nullable: false),
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
                    table.PrimaryKey("PK_MaltingsWetEndMalt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaltingsProcesses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Shift = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    StartTemp = table.Column<decimal>(nullable: false),
                    EndTemp = table.Column<decimal>(nullable: false),
                    StartMoisture = table.Column<decimal>(nullable: false),
                    EndMoisture = table.Column<decimal>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    MCId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaltingsProcesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaltingsProcesses_MaltingsMaltingCycle_MCId",
                        column: x => x.MCId,
                        principalTable: "MaltingsMaltingCycle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaltingsStoppages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Shift = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    MCId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaltingsStoppages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaltingsStoppages_MaltingsMaltingCycle_MCId",
                        column: x => x.MCId,
                        principalTable: "MaltingsMaltingCycle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaltingsMStocks_BatchId",
                table: "MaltingsMStocks",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_MaltingsProcesses_MCId",
                table: "MaltingsProcesses",
                column: "MCId");

            migrationBuilder.CreateIndex(
                name: "IX_MaltingsStoppages_MCId",
                table: "MaltingsStoppages",
                column: "MCId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaltingsDryEndMalt");

            migrationBuilder.DropTable(
                name: "MaltingsMStocks");

            migrationBuilder.DropTable(
                name: "MaltingsProcesses");

            migrationBuilder.DropTable(
                name: "MaltingsStoppages");

            migrationBuilder.DropTable(
                name: "MaltingsWetEndMalt");

            migrationBuilder.DropTable(
                name: "MaltingsMaltingCycle");

            migrationBuilder.DropColumn(
                name: "BatchNumber",
                table: "MaltingsSteeping");

            migrationBuilder.DropColumn(
                name: "BatchNumber",
                table: "MaltingsSorghumGrain");

            migrationBuilder.DropColumn(
                name: "JobcardNumber",
                table: "MaltingsMaltBatch");

            migrationBuilder.DropColumn(
                name: "SAPWorkorderNumber",
                table: "MaltingsMaltBatch");

            migrationBuilder.DropColumn(
                name: "WaterSource",
                table: "MaltingsMaltBatch");

            migrationBuilder.DropColumn(
                name: "BatchNumber",
                table: "MaltingsKilning");

            migrationBuilder.DropColumn(
                name: "BatchNumber",
                table: "MaltingsGermination");

            migrationBuilder.AddColumn<string>(
                name: "AirOff",
                table: "MaltingsMaltBatch",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AirOn",
                table: "MaltingsMaltBatch",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "BufferVolume",
                table: "MaltingsMaltBatch",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ChitCount",
                table: "MaltingsMaltBatch",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateStartKiln",
                table: "MaltingsMaltBatch",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateSteeped",
                table: "MaltingsMaltBatch",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ExKilnDate",
                table: "MaltingsMaltBatch",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "GKVnumber",
                table: "MaltingsMaltBatch",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "GerminationDuration",
                table: "MaltingsMaltBatch",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GrainSource",
                table: "MaltingsMaltBatch",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GrainVariety",
                table: "MaltingsMaltBatch",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "KilnTime",
                table: "MaltingsMaltBatch",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "MoistureContent",
                table: "MaltingsMaltBatch",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SprayType",
                table: "MaltingsMaltBatch",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SprayVolume",
                table: "MaltingsMaltBatch",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "SteepTanks",
                table: "MaltingsMaltBatch",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TonnageSteeped",
                table: "MaltingsMaltBatch",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
