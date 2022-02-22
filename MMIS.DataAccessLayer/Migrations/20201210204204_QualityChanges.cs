using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class QualityChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnalystInitials",
                table: "QualityRIYeast");

            migrationBuilder.DropColumn(
                name: "BatchNumber",
                table: "QualityRIYeast");

            migrationBuilder.DropColumn(
                name: "SupplierName",
                table: "QualityRIYeast");

            migrationBuilder.DropColumn(
                name: "AnalystInitials",
                table: "QualityRIStretchfilm");

            migrationBuilder.DropColumn(
                name: "AnalystInitials",
                table: "QualityRIShrinkfilm");

            migrationBuilder.DropColumn(
                name: "AnalystInitials",
                table: "QualityRIPreform");

            migrationBuilder.DropColumn(
                name: "AnalystInitials",
                table: "QualityRIMalt");

            migrationBuilder.DropColumn(
                name: "BatchNumber",
                table: "QualityRIMalt");

            migrationBuilder.DropColumn(
                name: "SupplierName",
                table: "QualityRIMalt");

            migrationBuilder.DropColumn(
                name: "AnalystInitials",
                table: "QualityRIMaize");

            migrationBuilder.DropColumn(
                name: "BatchNumber",
                table: "QualityRIMaize");

            migrationBuilder.DropColumn(
                name: "SupplierName",
                table: "QualityRIMaize");

            migrationBuilder.DropColumn(
                name: "AnalystInitials",
                table: "QualityRILacticAcid");

            migrationBuilder.DropColumn(
                name: "BatchNumber",
                table: "QualityRILacticAcid");

            migrationBuilder.DropColumn(
                name: "SupplierName",
                table: "QualityRILacticAcid");

            migrationBuilder.DropColumn(
                name: "AnalystInitials",
                table: "QualityRILabel");

            migrationBuilder.DropColumn(
                name: "AnalystInitials",
                table: "QualityRIGlue");

            migrationBuilder.DropColumn(
                name: "AnalystInitials",
                table: "QualityRIClosure");

            migrationBuilder.DropColumn(
                name: "AnalystInitials",
                table: "QualityRICarbonDioxide");

            migrationBuilder.DropColumn(
                name: "BatchNumber",
                table: "QualityRICarbonDioxide");

            migrationBuilder.DropColumn(
                name: "SupplierName",
                table: "QualityRICarbonDioxide");

            migrationBuilder.AddColumn<string>(
                name: "Plant",
                table: "Utilities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plant",
                table: "QualityWort",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Analyst",
                table: "QualityVUsage",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "QualityVUsage",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "QualityVUsage",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Analyst",
                table: "QualityShelflife",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plant",
                table: "QualityShelflife",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Analyst",
                table: "QualityRIYeast",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BatchNo",
                table: "QualityRIYeast",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plant",
                table: "QualityRIYeast",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier",
                table: "QualityRIYeast",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Analyst",
                table: "QualityRIStretchfilm",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plant",
                table: "QualityRIStretchfilm",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Analyst",
                table: "QualityRIShrinkfilm",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plant",
                table: "QualityRIShrinkfilm",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Analyst",
                table: "QualityRIPreform",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plant",
                table: "QualityRIPreform",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Analyst",
                table: "QualityRIMalt",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BatchNo",
                table: "QualityRIMalt",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plant",
                table: "QualityRIMalt",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier",
                table: "QualityRIMalt",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Analyst",
                table: "QualityRIMaize",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BatchNo",
                table: "QualityRIMaize",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plant",
                table: "QualityRIMaize",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier",
                table: "QualityRIMaize",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Analyst",
                table: "QualityRILacticAcid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BatchNo",
                table: "QualityRILacticAcid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plant",
                table: "QualityRILacticAcid",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "QualityRILacticAcid",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Supplier",
                table: "QualityRILacticAcid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Analyst",
                table: "QualityRILabel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plant",
                table: "QualityRILabel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Analyst",
                table: "QualityRIGlue",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plant",
                table: "QualityRIGlue",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Mass",
                table: "QualityRIClosure",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Height",
                table: "QualityRIClosure",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Diameter",
                table: "QualityRIClosure",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Analyst",
                table: "QualityRIClosure",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plant",
                table: "QualityRIClosure",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Analyst",
                table: "QualityRICarbonDioxide",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BatchNo",
                table: "QualityRICarbonDioxide",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plant",
                table: "QualityRICarbonDioxide",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier",
                table: "QualityRICarbonDioxide",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plant",
                table: "QualityPIP",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plant",
                table: "QualityMarketDispatched",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Analyst",
                table: "QualityFermentation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plant",
                table: "QualityFermentation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plant",
                table: "QualityCustomerComplaint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Analyst",
                table: "QualityCIPTracker",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plant",
                table: "QualityCIPTracker",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FParametersScud",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Time = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Viscosity = table.Column<decimal>(nullable: false),
                    pH = table.Column<decimal>(nullable: false),
                    Ref = table.Column<decimal>(nullable: false),
                    TotalAcid = table.Column<decimal>(nullable: false),
                    Head = table.Column<decimal>(nullable: false),
                    Settling = table.Column<decimal>(nullable: false),
                    Alcohol = table.Column<decimal>(nullable: false),
                    TRS = table.Column<decimal>(nullable: false),
                    Taste = table.Column<decimal>(nullable: false),
                    Analyst = table.Column<string>(nullable: true),
                    FIdId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FParametersScud", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FParametersScud_QualityFermentation_FIdId",
                        column: x => x.FIdId,
                        principalTable: "QualityFermentation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QualityBulkWater",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Analyst = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Supplier = table.Column<string>(nullable: true),
                    TruckNumber = table.Column<string>(nullable: true),
                    pH = table.Column<decimal>(nullable: false),
                    TDS = table.Column<decimal>(nullable: false),
                    Hardness = table.Column<decimal>(nullable: false),
                    Turbidity = table.Column<decimal>(nullable: false),
                    Taintnetting = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityBulkWater", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityCalibrations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Analyst = table.Column<string>(nullable: true),
                    ShiftStartDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityCalibrations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityPIPScud",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Analyst = table.Column<string>(nullable: true),
                    DateOfPacking = table.Column<DateTime>(nullable: false),
                    DetergentDosageBW = table.Column<decimal>(nullable: false),
                    DetergentDosageCW = table.Column<decimal>(nullable: false),
                    PHBottleWasher = table.Column<decimal>(nullable: false),
                    PHCrateWasher = table.Column<decimal>(nullable: false),
                    TCBottleWasher = table.Column<decimal>(nullable: false),
                    TCCrateWasher = table.Column<decimal>(nullable: false),
                    BottleCleanliness = table.Column<decimal>(nullable: false),
                    CrateCleanliness = table.Column<decimal>(nullable: false),
                    Viscosity = table.Column<decimal>(nullable: false),
                    TotalAcids = table.Column<decimal>(nullable: false),
                    FillVolumes = table.Column<decimal>(nullable: false),
                    PercentCapped = table.Column<decimal>(nullable: false),
                    BestBeforeDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityPIPScud", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityRIScudBottle",
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
                    DateOfManufacture = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    CavityNumber = table.Column<decimal>(nullable: false),
                    Mass = table.Column<decimal>(nullable: false),
                    TotalBottleHeight = table.Column<decimal>(nullable: false),
                    NODPThread = table.Column<decimal>(nullable: false),
                    NODNThread = table.Column<decimal>(nullable: false),
                    NODRatchettoratchet = table.Column<decimal>(nullable: false),
                    Neckheightratchet = table.Column<decimal>(nullable: false),
                    Neck = table.Column<decimal>(nullable: false),
                    RatchetHeight = table.Column<decimal>(nullable: false),
                    NeckInsidediameter = table.Column<decimal>(nullable: false),
                    Bottleridgediameter = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityRIScudBottle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityRIScudClosure",
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
                    DateOfManufacture = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    CavityNumber = table.Column<decimal>(nullable: false),
                    Mass = table.Column<decimal>(nullable: false),
                    TotalInsideDiameter = table.Column<decimal>(nullable: false),
                    BandOutsideDiameter = table.Column<decimal>(nullable: false),
                    OutsideDiameter = table.Column<decimal>(nullable: false),
                    TotalClosureHeight = table.Column<decimal>(nullable: false),
                    BandHeight = table.Column<decimal>(nullable: false),
                    SlitSize = table.Column<decimal>(nullable: false),
                    InsideDiameterToFeathering = table.Column<decimal>(nullable: false),
                    FeatheringExternalDiameter = table.Column<decimal>(nullable: false),
                    VisualInspection = table.Column<string>(nullable: true),
                    Colour = table.Column<int>(nullable: false),
                    ColourDispersion = table.Column<int>(nullable: false),
                    Trimming = table.Column<int>(nullable: false),
                    Cracks = table.Column<int>(nullable: false),
                    symmetry = table.Column<int>(nullable: false),
                    Contaminants = table.Column<int>(nullable: false),
                    Embossing = table.Column<int>(nullable: false),
                    Dating = table.Column<int>(nullable: false),
                    Leaktest = table.Column<int>(nullable: false),
                    ClosureBottlefit = table.Column<int>(nullable: false),
                    ClosureBottleGrip = table.Column<int>(nullable: false),
                    DropTest = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityRIScudClosure", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityTasteTest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Analyst = table.Column<string>(nullable: true),
                    BatchNo = table.Column<string>(nullable: true),
                    TasteDate = table.Column<DateTime>(nullable: false),
                    BBDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityTasteTest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityWaterTreatment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Analyst = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Source = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityWaterTreatment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alcolyser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CId = table.Column<int>(nullable: true),
                    Water = table.Column<decimal>(nullable: false),
                    PreCalibration = table.Column<decimal>(nullable: false),
                    WaterandAirAdjustment = table.Column<decimal>(nullable: false),
                    AlcoholAdjustment = table.Column<decimal>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alcolyser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alcolyser_QualityCalibrations_CId",
                        column: x => x.CId,
                        principalTable: "QualityCalibrations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PHMeter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CId = table.Column<int>(nullable: true),
                    ElectrodeCleaning = table.Column<string>(nullable: true),
                    BufferpH7 = table.Column<decimal>(nullable: false),
                    BufferpH4 = table.Column<decimal>(nullable: false),
                    BufferpH10 = table.Column<decimal>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHMeter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PHMeter_QualityCalibrations_CId",
                        column: x => x.CId,
                        principalTable: "QualityCalibrations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Refractometer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CId = table.Column<int>(nullable: true),
                    Cleaning = table.Column<string>(nullable: true),
                    Calibration = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refractometer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Refractometer_QualityCalibrations_CId",
                        column: x => x.CId,
                        principalTable: "QualityCalibrations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Viscometer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CId = table.Column<int>(nullable: true),
                    SpindleCleaning = table.Column<string>(nullable: true),
                    ViscometerStandard100 = table.Column<decimal>(nullable: false),
                    ViscometerStandard500 = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viscometer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Viscometer_QualityCalibrations_CId",
                        column: x => x.CId,
                        principalTable: "QualityCalibrations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PIPBadClosures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Shift = table.Column<string>(nullable: true),
                    ShortMoulds = table.Column<int>(nullable: false),
                    Flashes = table.Column<int>(nullable: false),
                    Dimensions = table.Column<int>(nullable: false),
                    Other = table.Column<int>(nullable: false),
                    PIPId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PIPBadClosures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PIPBadClosures_QualityPIPScud_PIPId",
                        column: x => x.PIPId,
                        principalTable: "QualityPIPScud",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PIPBrewScud",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrewNumber = table.Column<int>(nullable: false),
                    PIPId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PIPBrewScud", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PIPBrewScud_QualityPIPScud_PIPId",
                        column: x => x.PIPId,
                        principalTable: "QualityPIPScud",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PIPDamagedBottles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Shift = table.Column<string>(nullable: true),
                    ChippedNeck = table.Column<int>(nullable: false),
                    ForeignBodies = table.Column<int>(nullable: false),
                    FirtyBottles = table.Column<int>(nullable: false),
                    BrokenBottles = table.Column<int>(nullable: false),
                    RodentDamaged = table.Column<int>(nullable: false),
                    Other = table.Column<int>(nullable: false),
                    PIPId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PIPDamagedBottles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PIPDamagedBottles_QualityPIPScud_PIPId",
                        column: x => x.PIPId,
                        principalTable: "QualityPIPScud",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PIPMaterialsScud",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Material = table.Column<string>(nullable: true),
                    BatchNumber = table.Column<string>(nullable: true),
                    PIPId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PIPMaterialsScud", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PIPMaterialsScud_QualityPIPScud_PIPId",
                        column: x => x.PIPId,
                        principalTable: "QualityPIPScud",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tester",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TTId = table.Column<int>(nullable: true),
                    TesterNo = table.Column<int>(nullable: false),
                    Carbonation = table.Column<int>(nullable: false),
                    Bite = table.Column<int>(nullable: false),
                    AlcoholContent = table.Column<int>(nullable: false),
                    Thickness = table.Column<int>(nullable: false),
                    SourAcetic = table.Column<int>(nullable: false),
                    Alkaline = table.Column<int>(nullable: false),
                    Chlorophenol = table.Column<int>(nullable: false),
                    Earthy = table.Column<int>(nullable: false),
                    Metallic = table.Column<int>(nullable: false),
                    Musty = table.Column<int>(nullable: false),
                    Phenolic = table.Column<int>(nullable: false),
                    RancidOil = table.Column<int>(nullable: false),
                    Sulphury = table.Column<int>(nullable: false),
                    Other = table.Column<int>(nullable: false),
                    Sliminess = table.Column<int>(nullable: false),
                    Colour = table.Column<int>(nullable: false),
                    Mouthfeel = table.Column<int>(nullable: false),
                    Sweetness = table.Column<int>(nullable: false),
                    Texture = table.Column<int>(nullable: false),
                    Cracking = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tester", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tester_QualityTasteTest_TTId",
                        column: x => x.TTId,
                        principalTable: "QualityTasteTest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostChlorination",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WaterId = table.Column<int>(nullable: true),
                    Chlorine = table.Column<decimal>(nullable: false),
                    Turbidity = table.Column<decimal>(nullable: false),
                    Taintnetting = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostChlorination", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostChlorination_QualityWaterTreatment_WaterId",
                        column: x => x.WaterId,
                        principalTable: "QualityWaterTreatment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostSandFiltration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WaterId = table.Column<int>(nullable: true),
                    Palkalinity = table.Column<decimal>(nullable: false),
                    Malkalinity = table.Column<decimal>(nullable: false),
                    pH = table.Column<decimal>(nullable: false),
                    TDS = table.Column<decimal>(nullable: false),
                    Turbidity = table.Column<decimal>(nullable: false),
                    Taintnetting = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostSandFiltration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostSandFiltration_QualityWaterTreatment_WaterId",
                        column: x => x.WaterId,
                        principalTable: "QualityWaterTreatment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RawWater",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WaterId = table.Column<int>(nullable: true),
                    Palkalinity = table.Column<decimal>(nullable: false),
                    Malkalinity = table.Column<decimal>(nullable: false),
                    pH = table.Column<decimal>(nullable: false),
                    TDS = table.Column<decimal>(nullable: false),
                    Turbidity = table.Column<decimal>(nullable: false),
                    Taintnetting = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawWater", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RawWater_QualityWaterTreatment_WaterId",
                        column: x => x.WaterId,
                        principalTable: "QualityWaterTreatment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TreatedWater",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WaterId = table.Column<int>(nullable: true),
                    Residualchlorine = table.Column<decimal>(nullable: false),
                    pH = table.Column<decimal>(nullable: false),
                    Conductivity = table.Column<decimal>(nullable: false),
                    Malkalinity = table.Column<decimal>(nullable: false),
                    TDS = table.Column<decimal>(nullable: false),
                    Taintnetting = table.Column<decimal>(nullable: false),
                    Taste = table.Column<decimal>(nullable: false),
                    Turbidity = table.Column<decimal>(nullable: false),
                    Totalhardness = table.Column<decimal>(nullable: false),
                    Chloride = table.Column<decimal>(nullable: false),
                    sulphate = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatedWater", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreatedWater_QualityWaterTreatment_WaterId",
                        column: x => x.WaterId,
                        principalTable: "QualityWaterTreatment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alcolyser_CId",
                table: "Alcolyser",
                column: "CId");

            migrationBuilder.CreateIndex(
                name: "IX_FParametersScud_FIdId",
                table: "FParametersScud",
                column: "FIdId");

            migrationBuilder.CreateIndex(
                name: "IX_PHMeter_CId",
                table: "PHMeter",
                column: "CId");

            migrationBuilder.CreateIndex(
                name: "IX_PIPBadClosures_PIPId",
                table: "PIPBadClosures",
                column: "PIPId");

            migrationBuilder.CreateIndex(
                name: "IX_PIPBrewScud_PIPId",
                table: "PIPBrewScud",
                column: "PIPId");

            migrationBuilder.CreateIndex(
                name: "IX_PIPDamagedBottles_PIPId",
                table: "PIPDamagedBottles",
                column: "PIPId");

            migrationBuilder.CreateIndex(
                name: "IX_PIPMaterialsScud_PIPId",
                table: "PIPMaterialsScud",
                column: "PIPId");

            migrationBuilder.CreateIndex(
                name: "IX_PostChlorination_WaterId",
                table: "PostChlorination",
                column: "WaterId");

            migrationBuilder.CreateIndex(
                name: "IX_PostSandFiltration_WaterId",
                table: "PostSandFiltration",
                column: "WaterId");

            migrationBuilder.CreateIndex(
                name: "IX_RawWater_WaterId",
                table: "RawWater",
                column: "WaterId");

            migrationBuilder.CreateIndex(
                name: "IX_Refractometer_CId",
                table: "Refractometer",
                column: "CId");

            migrationBuilder.CreateIndex(
                name: "IX_Tester_TTId",
                table: "Tester",
                column: "TTId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatedWater_WaterId",
                table: "TreatedWater",
                column: "WaterId");

            migrationBuilder.CreateIndex(
                name: "IX_Viscometer_CId",
                table: "Viscometer",
                column: "CId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alcolyser");

            migrationBuilder.DropTable(
                name: "FParametersScud");

            migrationBuilder.DropTable(
                name: "PHMeter");

            migrationBuilder.DropTable(
                name: "PIPBadClosures");

            migrationBuilder.DropTable(
                name: "PIPBrewScud");

            migrationBuilder.DropTable(
                name: "PIPDamagedBottles");

            migrationBuilder.DropTable(
                name: "PIPMaterialsScud");

            migrationBuilder.DropTable(
                name: "PostChlorination");

            migrationBuilder.DropTable(
                name: "PostSandFiltration");

            migrationBuilder.DropTable(
                name: "QualityBulkWater");

            migrationBuilder.DropTable(
                name: "QualityRIScudBottle");

            migrationBuilder.DropTable(
                name: "QualityRIScudClosure");

            migrationBuilder.DropTable(
                name: "RawWater");

            migrationBuilder.DropTable(
                name: "Refractometer");

            migrationBuilder.DropTable(
                name: "Tester");

            migrationBuilder.DropTable(
                name: "TreatedWater");

            migrationBuilder.DropTable(
                name: "Viscometer");

            migrationBuilder.DropTable(
                name: "QualityPIPScud");

            migrationBuilder.DropTable(
                name: "QualityTasteTest");

            migrationBuilder.DropTable(
                name: "QualityWaterTreatment");

            migrationBuilder.DropTable(
                name: "QualityCalibrations");

            migrationBuilder.DropColumn(
                name: "Plant",
                table: "Utilities");

            migrationBuilder.DropColumn(
                name: "Plant",
                table: "QualityWort");

            migrationBuilder.DropColumn(
                name: "Analyst",
                table: "QualityVUsage");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "QualityVUsage");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "QualityVUsage");

            migrationBuilder.DropColumn(
                name: "Analyst",
                table: "QualityShelflife");

            migrationBuilder.DropColumn(
                name: "Plant",
                table: "QualityShelflife");

            migrationBuilder.DropColumn(
                name: "Analyst",
                table: "QualityRIYeast");

            migrationBuilder.DropColumn(
                name: "BatchNo",
                table: "QualityRIYeast");

            migrationBuilder.DropColumn(
                name: "Plant",
                table: "QualityRIYeast");

            migrationBuilder.DropColumn(
                name: "Supplier",
                table: "QualityRIYeast");

            migrationBuilder.DropColumn(
                name: "Analyst",
                table: "QualityRIStretchfilm");

            migrationBuilder.DropColumn(
                name: "Plant",
                table: "QualityRIStretchfilm");

            migrationBuilder.DropColumn(
                name: "Analyst",
                table: "QualityRIShrinkfilm");

            migrationBuilder.DropColumn(
                name: "Plant",
                table: "QualityRIShrinkfilm");

            migrationBuilder.DropColumn(
                name: "Analyst",
                table: "QualityRIPreform");

            migrationBuilder.DropColumn(
                name: "Plant",
                table: "QualityRIPreform");

            migrationBuilder.DropColumn(
                name: "Analyst",
                table: "QualityRIMalt");

            migrationBuilder.DropColumn(
                name: "BatchNo",
                table: "QualityRIMalt");

            migrationBuilder.DropColumn(
                name: "Plant",
                table: "QualityRIMalt");

            migrationBuilder.DropColumn(
                name: "Supplier",
                table: "QualityRIMalt");

            migrationBuilder.DropColumn(
                name: "Analyst",
                table: "QualityRIMaize");

            migrationBuilder.DropColumn(
                name: "BatchNo",
                table: "QualityRIMaize");

            migrationBuilder.DropColumn(
                name: "Plant",
                table: "QualityRIMaize");

            migrationBuilder.DropColumn(
                name: "Supplier",
                table: "QualityRIMaize");

            migrationBuilder.DropColumn(
                name: "Analyst",
                table: "QualityRILacticAcid");

            migrationBuilder.DropColumn(
                name: "BatchNo",
                table: "QualityRILacticAcid");

            migrationBuilder.DropColumn(
                name: "Plant",
                table: "QualityRILacticAcid");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "QualityRILacticAcid");

            migrationBuilder.DropColumn(
                name: "Supplier",
                table: "QualityRILacticAcid");

            migrationBuilder.DropColumn(
                name: "Analyst",
                table: "QualityRILabel");

            migrationBuilder.DropColumn(
                name: "Plant",
                table: "QualityRILabel");

            migrationBuilder.DropColumn(
                name: "Analyst",
                table: "QualityRIGlue");

            migrationBuilder.DropColumn(
                name: "Plant",
                table: "QualityRIGlue");

            migrationBuilder.DropColumn(
                name: "Analyst",
                table: "QualityRIClosure");

            migrationBuilder.DropColumn(
                name: "Plant",
                table: "QualityRIClosure");

            migrationBuilder.DropColumn(
                name: "Analyst",
                table: "QualityRICarbonDioxide");

            migrationBuilder.DropColumn(
                name: "BatchNo",
                table: "QualityRICarbonDioxide");

            migrationBuilder.DropColumn(
                name: "Plant",
                table: "QualityRICarbonDioxide");

            migrationBuilder.DropColumn(
                name: "Supplier",
                table: "QualityRICarbonDioxide");

            migrationBuilder.DropColumn(
                name: "Plant",
                table: "QualityPIP");

            migrationBuilder.DropColumn(
                name: "Plant",
                table: "QualityMarketDispatched");

            migrationBuilder.DropColumn(
                name: "Analyst",
                table: "QualityFermentation");

            migrationBuilder.DropColumn(
                name: "Plant",
                table: "QualityFermentation");

            migrationBuilder.DropColumn(
                name: "Plant",
                table: "QualityCustomerComplaint");

            migrationBuilder.DropColumn(
                name: "Analyst",
                table: "QualityCIPTracker");

            migrationBuilder.DropColumn(
                name: "Plant",
                table: "QualityCIPTracker");

            migrationBuilder.AddColumn<string>(
                name: "AnalystInitials",
                table: "QualityRIYeast",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BatchNumber",
                table: "QualityRIYeast",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupplierName",
                table: "QualityRIYeast",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnalystInitials",
                table: "QualityRIStretchfilm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnalystInitials",
                table: "QualityRIShrinkfilm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnalystInitials",
                table: "QualityRIPreform",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnalystInitials",
                table: "QualityRIMalt",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BatchNumber",
                table: "QualityRIMalt",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupplierName",
                table: "QualityRIMalt",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnalystInitials",
                table: "QualityRIMaize",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BatchNumber",
                table: "QualityRIMaize",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupplierName",
                table: "QualityRIMaize",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnalystInitials",
                table: "QualityRILacticAcid",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BatchNumber",
                table: "QualityRILacticAcid",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupplierName",
                table: "QualityRILacticAcid",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnalystInitials",
                table: "QualityRILabel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnalystInitials",
                table: "QualityRIGlue",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mass",
                table: "QualityRIClosure",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "Height",
                table: "QualityRIClosure",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "Diameter",
                table: "QualityRIClosure",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<string>(
                name: "AnalystInitials",
                table: "QualityRIClosure",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnalystInitials",
                table: "QualityRICarbonDioxide",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BatchNumber",
                table: "QualityRICarbonDioxide",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupplierName",
                table: "QualityRICarbonDioxide",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
