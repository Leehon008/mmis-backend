using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class CentralLab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QualityCLRIMaize",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Analyst = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    TestDensity = table.Column<decimal>(nullable: false),
                    Extract = table.Column<decimal>(nullable: false),
                    Fats = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityCLRIMaize", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityCLRISorghum",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Analyst = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    BatchNumber = table.Column<string>(nullable: true),
                    Moisture = table.Column<decimal>(nullable: false),
                    SDU = table.Column<decimal>(nullable: false),
                    Solubility = table.Column<decimal>(nullable: false),
                    MaltActivity = table.Column<decimal>(nullable: false),
                    Extract = table.Column<decimal>(nullable: false),
                    FAN = table.Column<decimal>(nullable: false),
                    TBC = table.Column<decimal>(nullable: false),
                    Sand = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityCLRISorghum", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityCLRIYeast",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Analyst = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    BatchNumber = table.Column<string>(nullable: true),
                    Moisture = table.Column<decimal>(nullable: false),
                    Liveyeast = table.Column<decimal>(nullable: false),
                    TBC = table.Column<decimal>(nullable: false),
                    Lactobacilli = table.Column<decimal>(nullable: false),
                    WildYeast = table.Column<decimal>(nullable: false),
                    Coliforms = table.Column<decimal>(nullable: false),
                    EColi = table.Column<string>(nullable: true),
                    Viability = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityCLRIYeast", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QualityCLRIMaize");

            migrationBuilder.DropTable(
                name: "QualityCLRISorghum");

            migrationBuilder.DropTable(
                name: "QualityCLRIYeast");
        }
    }
}
