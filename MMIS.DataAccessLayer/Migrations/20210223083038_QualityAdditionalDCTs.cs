using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class QualityAdditionalDCTs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QualityBlownBottles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Analyst = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Line = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityBlownBottles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityBottleSectionWeight",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Analyst = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Line = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityBottleSectionWeight", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityBottleVisualInspection",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Analyst = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    FlashOvalNeck = table.Column<bool>(nullable: false),
                    ShortShot = table.Column<bool>(nullable: false),
                    Bridging = table.Column<bool>(nullable: false),
                    OffCentre = table.Column<bool>(nullable: false),
                    Haziness = table.Column<bool>(nullable: false),
                    UnderBlown = table.Column<bool>(nullable: false),
                    Stability = table.Column<bool>(nullable: false),
                    Craters = table.Column<bool>(nullable: false),
                    HolesCracks = table.Column<bool>(nullable: false),
                    Partingline = table.Column<bool>(nullable: false),
                    Threadformation = table.Column<bool>(nullable: false),
                    Misalignment = table.Column<bool>(nullable: false),
                    Contamination = table.Column<bool>(nullable: false),
                    Colour = table.Column<bool>(nullable: false),
                    GoNoGoGauge = table.Column<bool>(nullable: false),
                    Degating = table.Column<bool>(nullable: false),
                    Capfit = table.Column<bool>(nullable: false),
                    Height = table.Column<bool>(nullable: false),
                    BBTViscosity = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityBottleVisualInspection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityMarketQualityScore",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Analyst = table.Column<string>(nullable: true),
                    BeerStorageArea = table.Column<string>(nullable: true),
                    ProductAvailability125L = table.Column<string>(nullable: true),
                    BeerAvailability1LSuper = table.Column<string>(nullable: true),
                    StockRotation = table.Column<string>(nullable: true),
                    ProductPresentation = table.Column<string>(nullable: true),
                    Shrinkfilm = table.Column<decimal>(nullable: false),
                    Bottles = table.Column<decimal>(nullable: false),
                    Closures = table.Column<decimal>(nullable: false),
                    Accessibility = table.Column<string>(nullable: true),
                    PackSize = table.Column<string>(nullable: true),
                    TotalAcids = table.Column<decimal>(nullable: false),
                    Viscosity = table.Column<decimal>(nullable: false),
                    Alcohol = table.Column<decimal>(nullable: false),
                    Colour = table.Column<string>(nullable: true),
                    Co2 = table.Column<decimal>(nullable: false),
                    Organoleptic = table.Column<string>(nullable: true),
                    Bite = table.Column<string>(nullable: true),
                    Torque = table.Column<decimal>(nullable: false),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityMarketQualityScore", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityPPQA",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Analyst = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    PackSize = table.Column<string>(nullable: true),
                    Shrinkpacks = table.Column<int>(nullable: false),
                    Bottles = table.Column<int>(nullable: false),
                    SFPAFaulty = table.Column<decimal>(nullable: false),
                    SFPAMoisture = table.Column<decimal>(nullable: false),
                    SFABurnHoles = table.Column<decimal>(nullable: false),
                    SFADefacedSoiled = table.Column<decimal>(nullable: false),
                    SFAWrinkles = table.Column<decimal>(nullable: false),
                    ContentsMDC = table.Column<decimal>(nullable: false),
                    ShrinkPackDefects = table.Column<decimal>(nullable: false),
                    ClosureLDD = table.Column<decimal>(nullable: false),
                    ClosureIPG = table.Column<decimal>(nullable: false),
                    BottleForeignObjects = table.Column<decimal>(nullable: false),
                    BottleSoiled = table.Column<decimal>(nullable: false),
                    BottleFillLevel = table.Column<decimal>(nullable: false),
                    BottleStructure = table.Column<decimal>(nullable: false),
                    Bottlecolour = table.Column<decimal>(nullable: false),
                    DateCodingLegibility = table.Column<decimal>(nullable: false),
                    CorrectDateCode = table.Column<decimal>(nullable: false),
                    IceProofingTest = table.Column<decimal>(nullable: false),
                    LabelDressMEL = table.Column<decimal>(nullable: false),
                    LabelDressHeight = table.Column<decimal>(nullable: false),
                    LabelDressSkew = table.Column<decimal>(nullable: false),
                    LAPrintLRC = table.Column<decimal>(nullable: false),
                    LADamaged = table.Column<decimal>(nullable: false),
                    LATorn = table.Column<decimal>(nullable: false),
                    LAWrinkled = table.Column<decimal>(nullable: false),
                    LAFolded = table.Column<decimal>(nullable: false),
                    LABlistersBubbles = table.Column<decimal>(nullable: false),
                    LAUnbondedEdges = table.Column<decimal>(nullable: false),
                    LALooseCorners = table.Column<decimal>(nullable: false),
                    ClosureRemovalEase = table.Column<decimal>(nullable: false),
                    BottleDefects = table.Column<decimal>(nullable: false),
                    DPMO = table.Column<decimal>(nullable: false),
                    PPQAScore = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityPPQA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityPQIOther",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Analyst = table.Column<string>(nullable: true),
                    Age035acids = table.Column<decimal>(nullable: false),
                    Colour = table.Column<string>(nullable: true),
                    Creaminess = table.Column<string>(nullable: true),
                    PackagingAge = table.Column<decimal>(nullable: false),
                    BBTViscosity = table.Column<decimal>(nullable: false),
                    PIP_pH = table.Column<decimal>(nullable: false),
                    PIP_TotalAcids = table.Column<decimal>(nullable: false),
                    PIP_Brix = table.Column<decimal>(nullable: false),
                    PIP_Alcohol = table.Column<decimal>(nullable: false),
                    PIP_SpecificGravity = table.Column<decimal>(nullable: false),
                    PIP_Viscosity = table.Column<decimal>(nullable: false),
                    PIP_Co2 = table.Column<decimal>(nullable: false),
                    PIP_FillVolume = table.Column<decimal>(nullable: false),
                    PIP_Torque = table.Column<decimal>(nullable: false),
                    MP_pH = table.Column<decimal>(nullable: false),
                    MP_TotalAcids = table.Column<decimal>(nullable: false),
                    MP_Alcohol = table.Column<decimal>(nullable: false),
                    MP_SpecificGravity = table.Column<decimal>(nullable: false),
                    MP_Viscosity = table.Column<decimal>(nullable: false),
                    MP_CO2 = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityPQIOther", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityPQIOtherScud",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Analyst = table.Column<string>(nullable: true),
                    Age045acids = table.Column<decimal>(nullable: false),
                    Colour = table.Column<string>(nullable: true),
                    Organoleptic72 = table.Column<decimal>(nullable: false),
                    PackagingAge = table.Column<decimal>(nullable: false),
                    MP_TotalAcids = table.Column<decimal>(nullable: false),
                    MP_Alcohol = table.Column<decimal>(nullable: false),
                    MP_Viscosity = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityPQIOtherScud", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityBlownBottleDim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BBIdId = table.Column<int>(nullable: true),
                    MouldCavity = table.Column<decimal>(nullable: false),
                    NeckShoulder = table.Column<decimal>(nullable: false),
                    LabelPanel = table.Column<decimal>(nullable: false),
                    Heel = table.Column<decimal>(nullable: false),
                    TotalMass = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityBlownBottleDim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QualityBlownBottleDim_QualityBlownBottles_BBIdId",
                        column: x => x.BBIdId,
                        principalTable: "QualityBlownBottles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QualityBSWItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BSWId = table.Column<int>(nullable: true),
                    MouldCavity = table.Column<decimal>(nullable: false),
                    NeckShoulder = table.Column<decimal>(nullable: false),
                    LabelPanel = table.Column<decimal>(nullable: false),
                    Heel = table.Column<decimal>(nullable: false),
                    TotalMass = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityBSWItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QualityBSWItem_QualityBottleSectionWeight_BSWId",
                        column: x => x.BSWId,
                        principalTable: "QualityBottleSectionWeight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QualityMQSCompetitorProduct",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MQSId = table.Column<int>(nullable: true),
                    Accessibility = table.Column<string>(nullable: true),
                    Presentability = table.Column<string>(nullable: true),
                    TotalAcids = table.Column<decimal>(nullable: false),
                    Viscosity = table.Column<decimal>(nullable: false),
                    Alcohol = table.Column<decimal>(nullable: false),
                    Organoleptic = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityMQSCompetitorProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QualityMQSCompetitorProduct_QualityMarketQualityScore_MQSId",
                        column: x => x.MQSId,
                        principalTable: "QualityMarketQualityScore",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QualityBlownBottleDim_BBIdId",
                table: "QualityBlownBottleDim",
                column: "BBIdId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityBSWItem_BSWId",
                table: "QualityBSWItem",
                column: "BSWId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityMQSCompetitorProduct_MQSId",
                table: "QualityMQSCompetitorProduct",
                column: "MQSId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QualityBlownBottleDim");

            migrationBuilder.DropTable(
                name: "QualityBottleVisualInspection");

            migrationBuilder.DropTable(
                name: "QualityBSWItem");

            migrationBuilder.DropTable(
                name: "QualityMQSCompetitorProduct");

            migrationBuilder.DropTable(
                name: "QualityPPQA");

            migrationBuilder.DropTable(
                name: "QualityPQIOther");

            migrationBuilder.DropTable(
                name: "QualityPQIOtherScud");

            migrationBuilder.DropTable(
                name: "QualityBlownBottles");

            migrationBuilder.DropTable(
                name: "QualityBottleSectionWeight");

            migrationBuilder.DropTable(
                name: "QualityMarketQualityScore");
        }
    }
}
