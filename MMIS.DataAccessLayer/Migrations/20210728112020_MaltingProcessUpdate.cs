using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class MaltingProcessUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "UtilitiesMeter",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ChitCount",
                table: "MaltingsSteeping",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TimeSteeped",
                table: "MaltingsSteeping",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WaterUsed",
                table: "MaltingsSteeping",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "KilnStartTime",
                table: "MaltingsKilning",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "McStart",
                table: "MaltingsKilning",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AirOff",
                table: "MaltingsGermination",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AirOn",
                table: "MaltingsGermination",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GerminationPeriod",
                table: "MaltingsGermination",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VesselNumber",
                table: "MaltingsGermination",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MaltingsDispatch",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Shift = table.Column<string>(nullable: true),
                    MaltBatch = table.Column<string>(nullable: true),
                    Dispatches = table.Column<string>(nullable: true),
                    Tonnages = table.Column<string>(nullable: true),
                    STONumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaltingsDispatch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaltingsDryLoad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Shift = table.Column<string>(nullable: true),
                    MaltBatch = table.Column<string>(nullable: true),
                    ByProductsQty = table.Column<string>(nullable: true),
                    VarietyOfGrain = table.Column<string>(nullable: true),
                    SourceOfGrain = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaltingsDryLoad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaltingsMilling",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Shift = table.Column<string>(nullable: true),
                    MaltBatch = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Yield = table.Column<string>(nullable: true),
                    MillingPlan = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaltingsMilling", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaltingsTransfer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Shift = table.Column<string>(nullable: true),
                    MaltBatch = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    HMBNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaltingsTransfer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UtilitiesCoalUsage",
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
                    boiler_ID = table.Column<string>(nullable: true),
                    Usage = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilitiesCoalUsage", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaltingsDispatch");

            migrationBuilder.DropTable(
                name: "MaltingsDryLoad");

            migrationBuilder.DropTable(
                name: "MaltingsMilling");

            migrationBuilder.DropTable(
                name: "MaltingsTransfer");

            migrationBuilder.DropTable(
                name: "UtilitiesCoalUsage");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "UtilitiesMeter");

            migrationBuilder.DropColumn(
                name: "ChitCount",
                table: "MaltingsSteeping");

            migrationBuilder.DropColumn(
                name: "TimeSteeped",
                table: "MaltingsSteeping");

            migrationBuilder.DropColumn(
                name: "WaterUsed",
                table: "MaltingsSteeping");

            migrationBuilder.DropColumn(
                name: "KilnStartTime",
                table: "MaltingsKilning");

            migrationBuilder.DropColumn(
                name: "McStart",
                table: "MaltingsKilning");

            migrationBuilder.DropColumn(
                name: "AirOff",
                table: "MaltingsGermination");

            migrationBuilder.DropColumn(
                name: "AirOn",
                table: "MaltingsGermination");

            migrationBuilder.DropColumn(
                name: "GerminationPeriod",
                table: "MaltingsGermination");

            migrationBuilder.DropColumn(
                name: "VesselNumber",
                table: "MaltingsGermination");
        }
    }
}
