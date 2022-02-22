using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class ShiftTeams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QualityRIAttenuzymeRI",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Analyst = table.Column<string>(nullable: true),
                    DateOfDelivery = table.Column<DateTime>(nullable: false),
                    Supplier = table.Column<string>(nullable: true),
                    BatchNo = table.Column<string>(nullable: true),
                    COA = table.Column<string>(nullable: true),

                    DateofManufacture = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<string>(nullable: true),
                    Sample = table.Column<string>(nullable: true),
                    Density = table.Column<string>(nullable: true),
                    ColiformBacteria = table.Column<string>(nullable: true),
                    Ecoli = table.Column<string>(nullable: true),
                    Yeast = table.Column<string>(nullable: true),
                    BeerSpoilageBacteria = table.Column<string>(nullable: true),
                    Mold = table.Column<string>(nullable: true),
                    Visual = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityRIAttenuzymeRI", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityRILayerBoardsRI",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Analyst = table.Column<string>(nullable: true),
                    DateOfDelivery = table.Column<DateTime>(nullable: false),
                    Supplier = table.Column<string>(nullable: true),
                    BatchNo = table.Column<string>(nullable: true),
                    COA = table.Column<string>(nullable: true),
                
                    DateofManufacture = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    Sample = table.Column<double>(nullable: false),
                    Width = table.Column<double>(nullable: false),
                    RepeatLength = table.Column<double>(nullable: false),
                    Colour = table.Column<string>(nullable: true),
                    Shape = table.Column<string>(nullable: true),
                    Visual = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityRILayerBoardsRI", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityRIMealieMeal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Analyst = table.Column<string>(nullable: true),
                    DateOfDelivery = table.Column<DateTime>(nullable: false),
                    Supplier = table.Column<string>(nullable: true),
                    BatchNo = table.Column<string>(nullable: true),
                    COA = table.Column<string>(nullable: true),
                  
                    Quantity = table.Column<double>(nullable: false),
                    Moisture = table.Column<string>(nullable: true),
                    Mesh12 = table.Column<double>(nullable: false),
                    Mesh16 = table.Column<double>(nullable: false),
                    Mesh30 = table.Column<double>(nullable: false),
                    Appearance = table.Column<string>(nullable: true),
                    AnalystInitials = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityRIMealieMeal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityRIShakeShakeSleeve",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Analyst = table.Column<string>(nullable: true),
                    DateOfDelivery = table.Column<DateTime>(nullable: false),
                    BatchNo = table.Column<string>(nullable: true),
                    COA = table.Column<string>(nullable: true),
                  
                    Supplier = table.Column<string>(nullable: true),
                    DateofManufacture = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    Sample = table.Column<string>(nullable: true),
                    CartonAppearance = table.Column<string>(nullable: true),
                    Colour = table.Column<string>(nullable: true),
                    Quality = table.Column<string>(nullable: true),
                    Print = table.Column<string>(nullable: true),
                    CreaseAlignment = table.Column<string>(nullable: true),
                    SideSeam = table.Column<string>(nullable: true),
                    Visual = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityRIShakeShakeSleeve", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShiftTeams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    ShiftName = table.Column<string>(nullable: true),
                    Member = table.Column<string>(nullable: true),
                    Module = table.Column<string>(nullable: true),
                    Plant = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftTeams", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QualityRIAttenuzymeRI");

            migrationBuilder.DropTable(
                name: "QualityRILayerBoardsRI");

            migrationBuilder.DropTable(
                name: "QualityRIMealieMeal");

            migrationBuilder.DropTable(
                name: "QualityRIShakeShakeSleeve");

            migrationBuilder.DropTable(
                name: "ShiftTeams");
        }
    }
}
