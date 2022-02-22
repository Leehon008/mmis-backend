using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class QualityFermentationChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QualityFermentationScud",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Analyst = table.Column<string>(nullable: true),
                    Tank = table.Column<string>(nullable: true),
                    BrewNo = table.Column<int>(nullable: false),
                    BrixAtWort = table.Column<decimal>(nullable: false),
                    YeastBatch = table.Column<string>(nullable: true),
                    MaltBatch = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Time = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Viscosity = table.Column<decimal>(nullable: false),
                    TotalAcid = table.Column<decimal>(nullable: false),
                    Alcohol = table.Column<decimal>(nullable: false),
                    Temp = table.Column<decimal>(nullable: false),
                    pH = table.Column<decimal>(nullable: false),
                    Ref = table.Column<decimal>(nullable: false),
                    Head = table.Column<decimal>(nullable: false),
                    Settling = table.Column<decimal>(nullable: false),
                    TRS = table.Column<decimal>(nullable: false),
                    Taste = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityFermentationScud", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityFermentationSuper",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Analyst = table.Column<string>(nullable: true),
                    Tank = table.Column<string>(nullable: true),
                    BrewNo = table.Column<int>(nullable: false),
                    BrixAtWort = table.Column<decimal>(nullable: false),
                    YeastBatch = table.Column<string>(nullable: true),
                    MaltBatch = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Time = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Viscosity = table.Column<decimal>(nullable: false),
                    TotalAcid = table.Column<decimal>(nullable: false),
                    Alcohol = table.Column<decimal>(nullable: false),
                    Temp = table.Column<decimal>(nullable: false),
                    pH = table.Column<decimal>(nullable: false),
                    Ref = table.Column<decimal>(nullable: false),
                    Brix = table.Column<decimal>(nullable: false),
                    SG = table.Column<decimal>(nullable: false),
                    OE = table.Column<decimal>(nullable: false),
                    RDF = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityFermentationSuper", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QualityFermentationScud");

            migrationBuilder.DropTable(
                name: "QualityFermentationSuper");
        }
    }
}
