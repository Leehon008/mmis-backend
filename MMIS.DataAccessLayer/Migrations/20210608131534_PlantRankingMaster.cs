using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class PlantRankingMaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ABT",
                table: "MandevPlantRanking");

            migrationBuilder.DropColumn(
                name: "AFE",
                table: "MandevPlantRanking");

            migrationBuilder.DropColumn(
                name: "BPI",
                table: "MandevPlantRanking");

            migrationBuilder.DropColumn(
                name: "BalanceBacks",
                table: "MandevPlantRanking");

            migrationBuilder.DropColumn(
                name: "CAPScore",
                table: "MandevPlantRanking");

            migrationBuilder.DropColumn(
                name: "CoalUsageRatio",
                table: "MandevPlantRanking");

            migrationBuilder.DropColumn(
                name: "CustomerComplaints",
                table: "MandevPlantRanking");

            migrationBuilder.DropColumn(
                name: "DIFR",
                table: "MandevPlantRanking");

            migrationBuilder.DropColumn(
                name: "EBIT",
                table: "MandevPlantRanking");

            migrationBuilder.DropColumn(
                name: "EBITMargin",
                table: "MandevPlantRanking");

            migrationBuilder.DropColumn(
                name: "ElectricityUsageRatio",
                table: "MandevPlantRanking");

            migrationBuilder.DropColumn(
                name: "EnvironmentalLegalNonCompliances",
                table: "MandevPlantRanking");

            migrationBuilder.DropColumn(
                name: "GEMScore",
                table: "MandevPlantRanking");

            migrationBuilder.DropColumn(
                name: "HLSSoldPerVehiclePerMonth",
                table: "MandevPlantRanking");

            migrationBuilder.DropColumn(
                name: "LTI",
                table: "MandevPlantRanking");

            migrationBuilder.DropColumn(
                name: "ME",
                table: "MandevPlantRanking");

            migrationBuilder.DropColumn(
                name: "MQI",
                table: "MandevPlantRanking");

            migrationBuilder.DropColumn(
                name: "Overtime",
                table: "MandevPlantRanking");

            migrationBuilder.DropColumn(
                name: "PQI",
                table: "MandevPlantRanking");

            migrationBuilder.DropColumn(
                name: "SalesVolumes",
                table: "MandevPlantRanking");

            migrationBuilder.DropColumn(
                name: "TCD",
                table: "MandevPlantRanking");

            migrationBuilder.DropColumn(
                name: "TCM",
                table: "MandevPlantRanking");

            migrationBuilder.DropColumn(
                name: "TasteScoreMarket",
                table: "MandevPlantRanking");

            migrationBuilder.DropColumn(
                name: "VehicleCapacityUtilisation",
                table: "MandevPlantRanking");

            migrationBuilder.DropColumn(
                name: "WaterUsageRatio",
                table: "MandevPlantRanking");

            migrationBuilder.CreateTable(
                name: "MandevKPIBasket",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Percentage = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MandevKPIBasket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MandevKPIBasket_MandevPlantRanking_PRId",
                        column: x => x.PRId,
                        principalTable: "MandevPlantRanking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MandevPlantRankingMaster",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Personnel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MandevPlantRankingMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MandevKPI",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KPIBId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Incentive = table.Column<decimal>(nullable: false),
                    Target = table.Column<decimal>(nullable: false),
                    Actual = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MandevKPI", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MandevKPI_MandevKPIBasket_KPIBId",
                        column: x => x.KPIBId,
                        principalTable: "MandevKPIBasket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MandevKPIBasketMaster",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRMId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Percentage = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MandevKPIBasketMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MandevKPIBasketMaster_MandevPlantRankingMaster_PRMId",
                        column: x => x.PRMId,
                        principalTable: "MandevPlantRankingMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MandevKPIMaster",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Basket = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Incentive = table.Column<decimal>(nullable: false),
                    Target = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    KPIBasketMasterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MandevKPIMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MandevKPIMaster_MandevKPIBasketMaster_KPIBasketMasterId",
                        column: x => x.KPIBasketMasterId,
                        principalTable: "MandevKPIBasketMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MandevKPI_KPIBId",
                table: "MandevKPI",
                column: "KPIBId");

            migrationBuilder.CreateIndex(
                name: "IX_MandevKPIBasket_PRId",
                table: "MandevKPIBasket",
                column: "PRId");

            migrationBuilder.CreateIndex(
                name: "IX_MandevKPIBasketMaster_PRMId",
                table: "MandevKPIBasketMaster",
                column: "PRMId");

            migrationBuilder.CreateIndex(
                name: "IX_MandevKPIMaster_KPIBasketMasterId",
                table: "MandevKPIMaster",
                column: "KPIBasketMasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MandevKPI");

            migrationBuilder.DropTable(
                name: "MandevKPIMaster");

            migrationBuilder.DropTable(
                name: "MandevKPIBasket");

            migrationBuilder.DropTable(
                name: "MandevKPIBasketMaster");

            migrationBuilder.DropTable(
                name: "MandevPlantRankingMaster");

            migrationBuilder.AddColumn<decimal>(
                name: "ABT",
                table: "MandevPlantRanking",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AFE",
                table: "MandevPlantRanking",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BPI",
                table: "MandevPlantRanking",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BalanceBacks",
                table: "MandevPlantRanking",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CAPScore",
                table: "MandevPlantRanking",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CoalUsageRatio",
                table: "MandevPlantRanking",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CustomerComplaints",
                table: "MandevPlantRanking",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DIFR",
                table: "MandevPlantRanking",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "EBIT",
                table: "MandevPlantRanking",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "EBITMargin",
                table: "MandevPlantRanking",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ElectricityUsageRatio",
                table: "MandevPlantRanking",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "EnvironmentalLegalNonCompliances",
                table: "MandevPlantRanking",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "GEMScore",
                table: "MandevPlantRanking",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "HLSSoldPerVehiclePerMonth",
                table: "MandevPlantRanking",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "LTI",
                table: "MandevPlantRanking",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ME",
                table: "MandevPlantRanking",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MQI",
                table: "MandevPlantRanking",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Overtime",
                table: "MandevPlantRanking",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PQI",
                table: "MandevPlantRanking",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SalesVolumes",
                table: "MandevPlantRanking",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TCD",
                table: "MandevPlantRanking",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TCM",
                table: "MandevPlantRanking",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TasteScoreMarket",
                table: "MandevPlantRanking",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VehicleCapacityUtilisation",
                table: "MandevPlantRanking",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WaterUsageRatio",
                table: "MandevPlantRanking",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
