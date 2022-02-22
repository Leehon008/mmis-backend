using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class MQS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accessibility",
                table: "QualityMQSCompetitorProduct");

            migrationBuilder.DropColumn(
                name: "Organoleptic",
                table: "QualityMQSCompetitorProduct");

            migrationBuilder.DropColumn(
                name: "Alcohol",
                table: "QualityMarketQualityScore");

            migrationBuilder.DropColumn(
                name: "Bite",
                table: "QualityMarketQualityScore");

            migrationBuilder.DropColumn(
                name: "Co2",
                table: "QualityMarketQualityScore");

            migrationBuilder.DropColumn(
                name: "Colour",
                table: "QualityMarketQualityScore");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "QualityMarketQualityScore");

            migrationBuilder.DropColumn(
                name: "ExpiryDate",
                table: "QualityMarketQualityScore");

            migrationBuilder.DropColumn(
                name: "Organoleptic",
                table: "QualityMarketQualityScore");

            migrationBuilder.DropColumn(
                name: "PackSize",
                table: "QualityMarketQualityScore");

            migrationBuilder.DropColumn(
                name: "Torque",
                table: "QualityMarketQualityScore");

            migrationBuilder.DropColumn(
                name: "TotalAcids",
                table: "QualityMarketQualityScore");

            migrationBuilder.DropColumn(
                name: "Viscosity",
                table: "QualityMarketQualityScore");

            migrationBuilder.AlterColumn<string>(
                name: "Viscosity",
                table: "QualityMQSCompetitorProduct",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "TotalAcids",
                table: "QualityMQSCompetitorProduct",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Alcohol",
                table: "QualityMQSCompetitorProduct",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "AlcoholScore",
                table: "QualityMQSCompetitorProduct",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "QualityMQSCompetitorProduct",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PresentabilityScore",
                table: "QualityMQSCompetitorProduct",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Score",
                table: "QualityMQSCompetitorProduct",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "TasteTest",
                table: "QualityMQSCompetitorProduct",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TasteTestScore",
                table: "QualityMQSCompetitorProduct",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Total",
                table: "QualityMQSCompetitorProduct",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalAcidsScore",
                table: "QualityMQSCompetitorProduct",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ViscosityScore",
                table: "QualityMQSCompetitorProduct",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "StockRotation",
                table: "QualityMarketQualityScore",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Shrinkfilm",
                table: "QualityMarketQualityScore",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "ProductPresentation",
                table: "QualityMarketQualityScore",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductAvailability125L",
                table: "QualityMarketQualityScore",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Closures",
                table: "QualityMarketQualityScore",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Bottles",
                table: "QualityMarketQualityScore",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "BeerStorageArea",
                table: "QualityMarketQualityScore",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BeerAvailability1LSuper",
                table: "QualityMarketQualityScore",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Accessibility",
                table: "QualityMarketQualityScore",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "QualityMarketQualityScore",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Outlet",
                table: "QualityMarketQualityScore",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductAvailability15L",
                table: "QualityMarketQualityScore",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Score",
                table: "QualityMarketQualityScore",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Total",
                table: "QualityMarketQualityScore",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "QualityMQSScud",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MQSId = table.Column<int>(nullable: true),
                    Batch = table.Column<string>(nullable: true),
                    ProductionDate = table.Column<DateTime>(nullable: false),
                    PackSize = table.Column<int>(nullable: false),
                    TotalAcids = table.Column<int>(nullable: false),
                    Viscosity = table.Column<int>(nullable: false),
                    Alcohol = table.Column<int>(nullable: false),
                    Taste = table.Column<int>(nullable: false),
                    Total = table.Column<int>(nullable: false),
                    Score = table.Column<decimal>(nullable: false),
                    ExpiryDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityMQSScud", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QualityMQSScud_QualityMarketQualityScore_MQSId",
                        column: x => x.MQSId,
                        principalTable: "QualityMarketQualityScore",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QualityMQSSuper",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MQSId = table.Column<int>(nullable: true),
                    Batch = table.Column<string>(nullable: true),
                    ProductionDate = table.Column<DateTime>(nullable: false),
                    PackSize = table.Column<int>(nullable: false),
                    TotalAcids = table.Column<int>(nullable: false),
                    Viscosity = table.Column<int>(nullable: false),
                    Alcohol = table.Column<int>(nullable: false),
                    Colour = table.Column<int>(nullable: false),
                    Co2 = table.Column<int>(nullable: false),
                    Organoleptic = table.Column<int>(nullable: false),
                    Torque = table.Column<int>(nullable: false),
                    Taste = table.Column<int>(nullable: false),
                    Total = table.Column<int>(nullable: false),
                    Score = table.Column<decimal>(nullable: false),
                    ExpiryDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityMQSSuper", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QualityMQSSuper_QualityMarketQualityScore_MQSId",
                        column: x => x.MQSId,
                        principalTable: "QualityMarketQualityScore",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QualityShelflifeScud",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Analyst = table.Column<string>(nullable: true),
                    BatchNumber = table.Column<string>(nullable: true),
                    Silo = table.Column<string>(nullable: true),
                    BrewTank = table.Column<string>(nullable: true),
                    MaltYeast = table.Column<string>(nullable: true),
                    TRS = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityShelflifeScud", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualitySLParametersScud",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Visc = table.Column<decimal>(nullable: false),
                    pH = table.Column<decimal>(nullable: false),
                    TotalAcids = table.Column<decimal>(nullable: false),
                    Head = table.Column<decimal>(nullable: false),
                    Sett = table.Column<decimal>(nullable: false),
                    Alcohol = table.Column<decimal>(nullable: false),
                    Brix = table.Column<decimal>(nullable: false),
                    SG = table.Column<decimal>(nullable: false),
                    OE = table.Column<decimal>(nullable: false),
                    RDF = table.Column<decimal>(nullable: false),
                    Taste = table.Column<decimal>(nullable: false),
                    Temp = table.Column<decimal>(nullable: false),
                    Analyst = table.Column<string>(nullable: true),
                    SLId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualitySLParametersScud", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QualitySLParametersScud_QualityShelflifeScud_SLId",
                        column: x => x.SLId,
                        principalTable: "QualityShelflifeScud",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QualityMQSScud_MQSId",
                table: "QualityMQSScud",
                column: "MQSId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityMQSSuper_MQSId",
                table: "QualityMQSSuper",
                column: "MQSId");

            migrationBuilder.CreateIndex(
                name: "IX_QualitySLParametersScud_SLId",
                table: "QualitySLParametersScud",
                column: "SLId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QualityMQSScud");

            migrationBuilder.DropTable(
                name: "QualityMQSSuper");

            migrationBuilder.DropTable(
                name: "QualitySLParametersScud");

            migrationBuilder.DropTable(
                name: "QualityShelflifeScud");

            migrationBuilder.DropColumn(
                name: "AlcoholScore",
                table: "QualityMQSCompetitorProduct");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "QualityMQSCompetitorProduct");

            migrationBuilder.DropColumn(
                name: "PresentabilityScore",
                table: "QualityMQSCompetitorProduct");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "QualityMQSCompetitorProduct");

            migrationBuilder.DropColumn(
                name: "TasteTest",
                table: "QualityMQSCompetitorProduct");

            migrationBuilder.DropColumn(
                name: "TasteTestScore",
                table: "QualityMQSCompetitorProduct");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "QualityMQSCompetitorProduct");

            migrationBuilder.DropColumn(
                name: "TotalAcidsScore",
                table: "QualityMQSCompetitorProduct");

            migrationBuilder.DropColumn(
                name: "ViscosityScore",
                table: "QualityMQSCompetitorProduct");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "QualityMarketQualityScore");

            migrationBuilder.DropColumn(
                name: "Outlet",
                table: "QualityMarketQualityScore");

            migrationBuilder.DropColumn(
                name: "ProductAvailability15L",
                table: "QualityMarketQualityScore");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "QualityMarketQualityScore");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "QualityMarketQualityScore");

            migrationBuilder.AlterColumn<decimal>(
                name: "Viscosity",
                table: "QualityMQSCompetitorProduct",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAcids",
                table: "QualityMQSCompetitorProduct",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Alcohol",
                table: "QualityMQSCompetitorProduct",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Accessibility",
                table: "QualityMQSCompetitorProduct",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Organoleptic",
                table: "QualityMQSCompetitorProduct",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StockRotation",
                table: "QualityMarketQualityScore",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "Shrinkfilm",
                table: "QualityMarketQualityScore",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "ProductPresentation",
                table: "QualityMarketQualityScore",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "ProductAvailability125L",
                table: "QualityMarketQualityScore",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "Closures",
                table: "QualityMarketQualityScore",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "Bottles",
                table: "QualityMarketQualityScore",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "BeerStorageArea",
                table: "QualityMarketQualityScore",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "BeerAvailability1LSuper",
                table: "QualityMarketQualityScore",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Accessibility",
                table: "QualityMarketQualityScore",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<decimal>(
                name: "Alcohol",
                table: "QualityMarketQualityScore",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Bite",
                table: "QualityMarketQualityScore",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Co2",
                table: "QualityMarketQualityScore",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Colour",
                table: "QualityMarketQualityScore",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "QualityMarketQualityScore",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiryDate",
                table: "QualityMarketQualityScore",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Organoleptic",
                table: "QualityMarketQualityScore",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PackSize",
                table: "QualityMarketQualityScore",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Torque",
                table: "QualityMarketQualityScore",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAcids",
                table: "QualityMarketQualityScore",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Viscosity",
                table: "QualityMarketQualityScore",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
