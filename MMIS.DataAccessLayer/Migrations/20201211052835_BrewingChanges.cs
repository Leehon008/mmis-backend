using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class BrewingChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrewingConversions");

            //migrationBuilder.DropTable(
            //    name: "BrewingCoolTo54");

            migrationBuilder.DropTable(
                name: "BrewingMaltAddition");

            migrationBuilder.CreateTable(
                name: "BrewingConversions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Shift = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    BrewNumber = table.Column<string>(nullable: true),
                    Stage = table.Column<string>(nullable: true),
                    PH = table.Column<decimal>(nullable: false),
                    PresentExtract = table.Column<decimal>(nullable: false),
                    Viscosity = table.Column<decimal>(nullable: false),
                    Attendant = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewingConversions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrewingCoolTo54",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Shift = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    BrewNumber = table.Column<string>(nullable: true),
                    Vessel = table.Column<decimal>(nullable: false),
                    Balling = table.Column<string>(nullable: true),
                    MashThickness = table.Column<decimal>(nullable: false),
                    QuenchingWaterTemp = table.Column<decimal>(nullable: false),
                    FinalTemp = table.Column<decimal>(nullable: false),
                    ExogenousEnzymes = table.Column<string>(nullable: true),
                    RampRate = table.Column<decimal>(nullable: false),
                    Calcium = table.Column<decimal>(nullable: false),
                    CIPEffectiveness = table.Column<string>(nullable: true),
                    Attendant = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewingCoolTo54", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrewingMaltAddition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Shift = table.Column<string>(nullable: true),
                    BrewNumber = table.Column<string>(nullable: true),
                    Mass = table.Column<decimal>(nullable: false),
                    Temp = table.Column<decimal>(nullable: false),
                    AdditionTime = table.Column<decimal>(nullable: false),
                    Attendant = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewingMaltAddition", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrewingConversions");

            migrationBuilder.DropTable(
                name: "BrewingCoolTo54");

            migrationBuilder.DropTable(
                name: "BrewingMaltAddition");
        }
    }
}
