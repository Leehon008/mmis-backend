using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    Centre = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    EmployeeNo = table.Column<string>(nullable: true),
                    EmployeementStatus = table.Column<string>(nullable: true),
                    AppointmentLetter = table.Column<string>(nullable: true),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Createdby = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuditRecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    RefNo = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: false),
                    Centre = table.Column<string>(nullable: false),
                    Auditor = table.Column<string>(nullable: false),
                    Auditee = table.Column<string>(nullable: false),
                    AuditDate = table.Column<DateTime>(nullable: false),
                    AuditScore = table.Column<double>(nullable: false),
                    AuditDue = table.Column<string>(nullable: false),
                    FilePath = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    Plant = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrewingBrews",
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
                    RawMaterialSapWorkOrder = table.Column<string>(nullable: true),
                    MaltPieceNumber = table.Column<string>(nullable: true),
                    YeastBatchNumber = table.Column<string>(nullable: true),
                    WaterSource = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewingBrews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrewingConversionPE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Shift = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Vessel = table.Column<decimal>(nullable: false),
                    VesselHeadspace = table.Column<decimal>(nullable: false),
                    TempProbe = table.Column<decimal>(nullable: false),
                    TempControlTolerance = table.Column<decimal>(nullable: false),
                    HeatingMediumTemp = table.Column<decimal>(nullable: false),
                    RampRateTolerance = table.Column<decimal>(nullable: false),
                    HeatingJackets = table.Column<string>(nullable: true),
                    HeatControl = table.Column<string>(nullable: true),
                    AgitatorStart = table.Column<decimal>(nullable: false),
                    SamplingPoint = table.Column<string>(nullable: true),
                    TempControlVariation = table.Column<decimal>(nullable: false),
                    HomogenousMash = table.Column<string>(nullable: true),
                    AgitatorTipSpeed = table.Column<decimal>(nullable: false),
                    TransferTime = table.Column<decimal>(nullable: false),
                    MashTransferVelocity = table.Column<decimal>(nullable: false),
                    CIP = table.Column<decimal>(nullable: false),
                    CIPEffectiveness = table.Column<string>(nullable: true),
                    Safety = table.Column<string>(nullable: true),
                    Attendant = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewingConversionPE", x => x.Id);
                });

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
                    Vessel = table.Column<decimal>(nullable: false),
                    Balling = table.Column<string>(nullable: true),
                    MashThickness = table.Column<decimal>(nullable: false),
                    QuenchingWaterTemp = table.Column<decimal>(nullable: false),
                    FinalTemp = table.Column<decimal>(nullable: false),
                    ExogenousEnzymes = table.Column<string>(nullable: true),
                    RampRate = table.Column<decimal>(nullable: false),
                    Calcium = table.Column<decimal>(nullable: false),
                    PH = table.Column<decimal>(nullable: false),
                    PresentExtract = table.Column<decimal>(nullable: false),
                    Viscosity = table.Column<decimal>(nullable: false),
                    CIP = table.Column<decimal>(nullable: false),
                    CIPEffectiveness = table.Column<string>(nullable: true),
                    Attendant = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewingConversions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrewingCooking",
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
                    Vessel = table.Column<string>(nullable: true),
                    Balling = table.Column<string>(nullable: true),
                    MashTemp = table.Column<decimal>(nullable: false),
                    CookerPressure = table.Column<decimal>(nullable: false),
                    HeatToBoil = table.Column<decimal>(nullable: false),
                    TempRampRate = table.Column<decimal>(nullable: false),
                    PostBoilHoldingTime = table.Column<decimal>(nullable: false),
                    StandTemp1 = table.Column<decimal>(nullable: false),
                    CIP = table.Column<decimal>(nullable: false),
                    Attendant = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewingCooking", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrewingCookingPE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Shift = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Vessel = table.Column<decimal>(nullable: false),
                    Headspace = table.Column<decimal>(nullable: false),
                    TempProbeAccuracy = table.Column<decimal>(nullable: false),
                    TempControlTolerance = table.Column<decimal>(nullable: false),
                    RampRateTolerance = table.Column<decimal>(nullable: false),
                    TempVariation = table.Column<decimal>(nullable: false),
                    HeatingMediumTemp = table.Column<decimal>(nullable: false),
                    HeatingJackets = table.Column<string>(nullable: true),
                    AgitatorStart = table.Column<string>(nullable: true),
                    AgitatorTopSpeed = table.Column<decimal>(nullable: false),
                    HeatLossControl = table.Column<string>(nullable: true),
                    HomogenousMash = table.Column<string>(nullable: true),
                    SamplePoint = table.Column<string>(nullable: true),
                    CIPEffectiveness = table.Column<string>(nullable: true),
                    Safety = table.Column<string>(nullable: true),
                    Attendant = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewingCookingPE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrewingCycles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Shift = table.Column<string>(nullable: true),
                    BrewId = table.Column<int>(nullable: false),
                    TotalCycleTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewingCycles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrewingEndMilling",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Shift = table.Column<string>(nullable: true),
                    BrewNumber = table.Column<string>(nullable: true),
                    StartId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    MashinginVolume = table.Column<decimal>(nullable: false),
                    MashinginTemperature = table.Column<decimal>(nullable: false),
                    Mashingintime = table.Column<decimal>(nullable: false),
                    MashResidenceCooker = table.Column<decimal>(nullable: false),
                    Attendant = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewingEndMilling", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrewingFermentation",
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
                    Vessel = table.Column<string>(nullable: true),
                    FermentationTemp = table.Column<decimal>(nullable: false),
                    Volume = table.Column<decimal>(nullable: false),
                    Age = table.Column<decimal>(nullable: false),
                    ColdCIP = table.Column<string>(nullable: true),
                    Temperature = table.Column<decimal>(nullable: false),
                    Taste = table.Column<decimal>(nullable: false),
                    Occupancy = table.Column<decimal>(nullable: false),
                    FPMDeviation = table.Column<decimal>(nullable: false),
                    FPMPresentExtract = table.Column<decimal>(nullable: false),
                    Attendant = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewingFermentation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrewingFermentationPE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Shift = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Vessel = table.Column<string>(nullable: true),
                    HeightToDiameter = table.Column<decimal>(nullable: false),
                    MaxFVDiameter = table.Column<decimal>(nullable: false),
                    TempProbePA = table.Column<decimal>(nullable: false),
                    NumberTempProbes = table.Column<decimal>(nullable: false),
                    PositionTempProbes = table.Column<decimal>(nullable: false),
                    NumberCoolingJackets = table.Column<decimal>(nullable: false),
                    PositionCoolingJackets = table.Column<decimal>(nullable: false),
                    Agitation = table.Column<string>(nullable: true),
                    SamplePoint = table.Column<string>(nullable: true),
                    CIPEffectiveness = table.Column<string>(nullable: true),
                    Safety = table.Column<string>(nullable: true),
                    Attendant = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewingFermentationPE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrewingHeaderTank",
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
                    Vessel = table.Column<string>(nullable: true),
                    BeerTemp = table.Column<decimal>(nullable: false),
                    CIP = table.Column<decimal>(nullable: false),
                    pH = table.Column<decimal>(nullable: false),
                    Alcohol = table.Column<decimal>(nullable: false),
                    PresentExtract = table.Column<decimal>(nullable: false),
                    SpecificGravity = table.Column<decimal>(nullable: false),
                    Viscosity = table.Column<decimal>(nullable: false),
                    Colour = table.Column<string>(nullable: true),
                    AceticAcid = table.Column<decimal>(nullable: false),
                    TitratableAcidity = table.Column<decimal>(nullable: false),
                    Taste = table.Column<string>(nullable: true),
                    DissolvedOxygen = table.Column<decimal>(nullable: false),
                    Agitation = table.Column<string>(nullable: true),
                    SamplePoint = table.Column<string>(nullable: true),
                    Attendant = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewingHeaderTank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrewingHeaderTankPE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Shift = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Vessel = table.Column<string>(nullable: true),
                    Precision = table.Column<decimal>(nullable: false),
                    Accuracy = table.Column<decimal>(nullable: false),
                    Alcohol = table.Column<decimal>(nullable: false),
                    TempProbes = table.Column<decimal>(nullable: false),
                    CoolingJackets = table.Column<decimal>(nullable: false),
                    Agitation = table.Column<string>(nullable: true),
                    SamplePoint = table.Column<string>(nullable: true),
                    Attendant = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewingHeaderTankPE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrewingInspections",
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
                    Tank = table.Column<string>(nullable: true),
                    MainValveStatus = table.Column<string>(nullable: true),
                    MainValveComment = table.Column<string>(nullable: true),
                    ByPassValveStatus = table.Column<string>(nullable: true),
                    ByPassValveComment = table.Column<string>(nullable: true),
                    ValveLeaksStatus = table.Column<string>(nullable: true),
                    ValveLeaksComment = table.Column<string>(nullable: true),
                    WaterLeaksStatus = table.Column<string>(nullable: true),
                    WaterLeaksComment = table.Column<string>(nullable: true),
                    JacketsLeaksStatus = table.Column<string>(nullable: true),
                    JacketsLeaksComment = table.Column<string>(nullable: true),
                    SaggingCoilsStatus = table.Column<string>(nullable: true),
                    SaggingCoilsComment = table.Column<string>(nullable: true),
                    BladesAndShaftStatus = table.Column<string>(nullable: true),
                    BladesAndShaftComment = table.Column<string>(nullable: true),
                    GearboxOilLeaksStatus = table.Column<string>(nullable: true),
                    GearboxOilLeaksComment = table.Column<string>(nullable: true),
                    SpeedStatus = table.Column<string>(nullable: true),
                    SpeedComment = table.Column<string>(nullable: true),
                    SpeedOfRotationStatus = table.Column<string>(nullable: true),
                    SpeedOfRotationComment = table.Column<string>(nullable: true),
                    KitchenCleanStatus = table.Column<string>(nullable: true),
                    KitchenCleanComment = table.Column<string>(nullable: true),
                    NoRustStatus = table.Column<string>(nullable: true),
                    NoRustComment = table.Column<string>(nullable: true),
                    MashStonesStatus = table.Column<string>(nullable: true),
                    MashStonesComment = table.Column<string>(nullable: true),
                    LastDateOfCIP = table.Column<DateTime>(nullable: false),
                    LastDateOfCIPComment = table.Column<string>(nullable: true),
                    SIFunctionalStatus = table.Column<string>(nullable: true),
                    SIFunctionalComment = table.Column<string>(nullable: true),
                    SISecuredStatus = table.Column<string>(nullable: true),
                    SISecuredComment = table.Column<string>(nullable: true),
                    BottomTankValveStatus = table.Column<string>(nullable: true),
                    BottomTankValveComment = table.Column<string>(nullable: true),
                    MashLineValveStatus = table.Column<string>(nullable: true),
                    MashLineValveComment = table.Column<string>(nullable: true),
                    StrainingLineValveStatus = table.Column<string>(nullable: true),
                    StrainingLineValveComment = table.Column<string>(nullable: true),
                    MainsWaterValveStatus = table.Column<string>(nullable: true),
                    MainsWaterValveComment = table.Column<string>(nullable: true),
                    SwingBendStatus = table.Column<string>(nullable: true),
                    SwingBendComment = table.Column<string>(nullable: true),
                    ProcessAttendant = table.Column<string>(nullable: true),
                    Brewer = table.Column<string>(nullable: true),
                    Maintenance = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewingInspections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrewingIPC",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Shift = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    BrewNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewingIPC", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrewingMaltAddition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Plant = table.Column<string>(nullable: true),
                    Shift = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false),
                    Mass = table.Column<decimal>(nullable: false),
                    ViscosityOfMash = table.Column<decimal>(nullable: false),
                    TempOfMash = table.Column<decimal>(nullable: false),
                    PHOfMash = table.Column<decimal>(nullable: false),
                    QuantityOfWater = table.Column<decimal>(nullable: false),
                    FinalVolume = table.Column<decimal>(nullable: false),
                    Attendant = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewingMaltAddition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrewingStartMilling",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Shift = table.Column<string>(nullable: true),
                    BrewNumber = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    AdjunctMassRedSorghum = table.Column<decimal>(nullable: false),
                    MashliquorTemperature = table.Column<decimal>(nullable: false),
                    MashVolume = table.Column<decimal>(nullable: false),
                    Attendant = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewingStartMilling", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrewingStrain",
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
                    Vessel = table.Column<string>(nullable: true),
                    DecanterCIP = table.Column<decimal>(nullable: false),
                    SpentGrainsMoisture = table.Column<decimal>(nullable: false),
                    SpentGrainsMass = table.Column<decimal>(nullable: false),
                    TotalStrainingTime = table.Column<decimal>(nullable: false),
                    CIPEffectiveness = table.Column<string>(nullable: true),
                    Throughput = table.Column<decimal>(nullable: false),
                    StrainingTemp = table.Column<decimal>(nullable: false),
                    VibroScreenSize = table.Column<decimal>(nullable: false),
                    Safety = table.Column<string>(nullable: true),
                    Attendant = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewingStrain", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrewingSuperBBT",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Plant = table.Column<string>(nullable: true),
                    Shift = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false),
                    TTTime = table.Column<decimal>(nullable: false),
                    BeerAges = table.Column<decimal>(nullable: false),
                    BlendingTime = table.Column<decimal>(nullable: false),
                    BlendVolume = table.Column<decimal>(nullable: false),
                    BeerLoss = table.Column<decimal>(nullable: false),
                    BeerTemp = table.Column<decimal>(nullable: false),
                    Attendant = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewingSuperBBT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrewingVibro",
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
                    Vessel = table.Column<string>(nullable: true),
                    PriorBeerTemp = table.Column<decimal>(nullable: false),
                    VibroScreenCIP = table.Column<decimal>(nullable: false),
                    PostBeerTemp = table.Column<decimal>(nullable: false),
                    MicrobiologicalControl = table.Column<decimal>(nullable: false),
                    Attendant = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewingVibro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrewingVibroPE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Shift = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Vessel = table.Column<string>(nullable: true),
                    Throughput = table.Column<decimal>(nullable: false),
                    StrainingTemp = table.Column<decimal>(nullable: false),
                    VibroScreenSize = table.Column<decimal>(nullable: false),
                    CIPEffectiveness = table.Column<string>(nullable: true),
                    Safety = table.Column<string>(nullable: true),
                    Attendant = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewingVibroPE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrewingWortCooling",
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
                    Vessel = table.Column<string>(nullable: true),
                    Duration = table.Column<decimal>(nullable: false),
                    CoolingRate = table.Column<decimal>(nullable: false),
                    CoolingTemp = table.Column<decimal>(nullable: false),
                    HWMnHECIP = table.Column<decimal>(nullable: false),
                    CollectedWortTemp = table.Column<decimal>(nullable: false),
                    WortPH = table.Column<decimal>(nullable: false),
                    PresentExtract = table.Column<decimal>(nullable: false),
                    SpecificGravity = table.Column<decimal>(nullable: false),
                    Viscosity = table.Column<decimal>(nullable: false),
                    TitratableAcidity = table.Column<decimal>(nullable: false),
                    TotalSolids = table.Column<decimal>(nullable: false),
                    MicrobiologicalContent = table.Column<decimal>(nullable: false),
                    Attendant = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewingWortCooling", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrewingWortCoolingPE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Shift = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Vessel = table.Column<string>(nullable: true),
                    Velocity = table.Column<decimal>(nullable: false),
                    FlowMeterAccuracy = table.Column<decimal>(nullable: false),
                    CoolingCoils = table.Column<decimal>(nullable: false),
                    WaterTemp = table.Column<decimal>(nullable: false),
                    SamplePoint = table.Column<string>(nullable: true),
                    CIPEffectiveness = table.Column<string>(nullable: true),
                    Safety = table.Column<string>(nullable: true),
                    Attendant = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewingWortCoolingPE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrewingYeastHandling",
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
                    Vessel = table.Column<string>(nullable: true),
                    Strain = table.Column<string>(nullable: true),
                    StorageTemp = table.Column<decimal>(nullable: false),
                    PitchingRate = table.Column<decimal>(nullable: false),
                    PitchingTime = table.Column<decimal>(nullable: false),
                    AdditionPoint = table.Column<decimal>(nullable: false),
                    MaxStorageTime = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewingYeastHandling", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChangeRequest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    ProjectName = table.Column<string>(nullable: true),
                    DateDubmitted = table.Column<DateTime>(nullable: false),
                    ChangeInitiator = table.Column<string>(nullable: false),
                    ChangeSponsor = table.Column<string>(nullable: false),
                    ProjectManager = table.Column<string>(nullable: false),
                    ChangeType = table.Column<string>(nullable: false),
                    ChangeTypeOther = table.Column<string>(nullable: false),
                    ChangeReason = table.Column<string>(nullable: true),
                    ChangeReasonOther = table.Column<string>(nullable: false),
                    ChangeImpact = table.Column<string>(nullable: true),
                    RequestedCompletionDate = table.Column<string>(nullable: false),
                    TitleOfChange = table.Column<string>(nullable: false),
                    DescriptionOfBusinessProblem = table.Column<string>(nullable: false),
                    ImpactOfNoChange = table.Column<string>(nullable: false),
                    SystemBehaviour = table.Column<string>(nullable: false),
                    ChangeRequiremenets = table.Column<string>(nullable: false),
                    CostImpact = table.Column<string>(nullable: false),
                    ResourceImpact = table.Column<string>(nullable: false),
                    ReviewDate = table.Column<DateTime>(nullable: false),
                    ReviewdBy = table.Column<string>(nullable: false),
                    Recommendation = table.Column<string>(nullable: false),
                    RecommendationNotes = table.Column<string>(nullable: false),
                    Priority = table.Column<string>(nullable: false),
                    FilePath = table.Column<string>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    AssignedTo = table.Column<string>(nullable: true),
                    ExpectedResolutionDate = table.Column<DateTime>(nullable: false),
                    Escalation = table.Column<string>(nullable: true),
                    ActionSteps = table.Column<string>(nullable: true),
                    ActualResolutionDate = table.Column<DateTime>(nullable: false),
                    FinalResolution = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChemicalCompatibility",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    StorageGroup = table.Column<string>(nullable: false),
                    Temperature = table.Column<string>(nullable: false),
                    AverageHumidity = table.Column<string>(nullable: false),
                    ChemicalName = table.Column<string>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    PhysicalForm = table.Column<string>(nullable: false),
                    Toxic = table.Column<string>(nullable: false),
                    Corrosive = table.Column<string>(nullable: false),
                    Flammable = table.Column<string>(nullable: false),
                    Properties = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    msds = table.Column<string>(nullable: false),
                    RouteOfExposure = table.Column<string>(nullable: false),
                    Hazard = table.Column<string>(nullable: false),
                    CompatibilityStatus = table.Column<string>(nullable: false),
                    recommendations = table.Column<string>(nullable: false),
                    responsibility = table.Column<string>(nullable: false),
                    ClosureStatus = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChemicalCompatibility", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CMArtisanInput",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDNo = table.Column<string>(nullable: true, computedColumnSql: "+ 'ID' + cast([Id] as varchar)"),
                    ShiftNo = table.Column<string>(nullable: true),
                    Artisan = table.Column<string>(nullable: true),
                    Machine = table.Column<string>(nullable: true),
                    Issue = table.Column<string>(nullable: true),
                    WoNumber = table.Column<string>(nullable: true),
                    completion = table.Column<string>(nullable: true),
                    duration = table.Column<double>(nullable: false),
                    Notification = table.Column<string>(nullable: true),
                    sparesCost = table.Column<double>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Createdby = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CMArtisanInput", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CMPlannerInput",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDNo = table.Column<string>(nullable: true, computedColumnSql: "+ 'ID' + cast([Id] as varchar)"),
                    ShiftNo = table.Column<string>(nullable: true),
                    area = table.Column<string>(nullable: true),
                    location = table.Column<string>(nullable: true),
                    Issue = table.Column<string>(nullable: true),
                    WoNumber = table.Column<string>(nullable: true),
                    notification = table.Column<string>(nullable: true),
                    byWho = table.Column<string>(nullable: true),
                    byWhen = table.Column<DateTime>(nullable: false),
                    planner = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Createdby = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CMPlannerInput", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommunicationPlan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CommunicationType = table.Column<string>(nullable: false),
                    Information = table.Column<string>(nullable: false),
                    Recipient = table.Column<string>(nullable: false),
                    WhenToCommunicate = table.Column<string>(nullable: false),
                    ModeOfCommunication = table.Column<string>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    FeedBackChannel = table.Column<string>(nullable: false),
                    Initiator = table.Column<string>(nullable: false),
                    Communicator = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunicationPlan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConfinedSpaces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    NumberOfEntryPoints = table.Column<int>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    ContinuousOccupancy = table.Column<string>(nullable: false),
                    RestrictedAccess = table.Column<string>(nullable: false),
                    LargeEnough = table.Column<string>(nullable: false),
                    SeriousHazards = table.Column<string>(nullable: false),
                    Pwt = table.Column<string>(nullable: false),
                    DateReviewed = table.Column<DateTime>(nullable: false),
                    DateAccessed = table.Column<DateTime>(nullable: false),
                    PotentialHazards = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfinedSpaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DIArtisanInput",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDNo = table.Column<string>(nullable: true, computedColumnSql: "+ 'ID' + cast([Id] as varchar)"),
                    ShiftNo = table.Column<string>(nullable: true),
                    Artisan = table.Column<string>(nullable: true),
                    Machine = table.Column<string>(nullable: true),
                    TagNo = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Notification = table.Column<string>(nullable: true),
                    IdentifiedOn = table.Column<DateTime>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Createdby = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DIArtisanInput", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DIPlannerInput",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDNo = table.Column<string>(nullable: true, computedColumnSql: "+ 'ID' + cast([Id] as varchar)"),
                    ShiftNo = table.Column<string>(nullable: true),
                    Planner = table.Column<string>(nullable: true),
                    Machine = table.Column<string>(nullable: true),
                    TagNo = table.Column<string>(nullable: true),
                    TagLevel = table.Column<string>(nullable: true),
                    TagBy = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    Issue = table.Column<string>(nullable: true),
                    Notification = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    ByWho = table.Column<string>(nullable: true),
                    ByWhen = table.Column<DateTime>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Createdby = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DIPlannerInput", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnvironmentalImpactRAHeader",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Center = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: false),
                    Section = table.Column<string>(nullable: false),
                    Task = table.Column<string>(nullable: false),
                    AspectInvolved = table.Column<string>(nullable: false),
                    AssociatedImpact = table.Column<string>(nullable: false),
                    Category = table.Column<string>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Severity = table.Column<int>(nullable: false),
                    Probability = table.Column<int>(nullable: false),
                    Impact = table.Column<int>(nullable: false),
                    ResidualProbability = table.Column<int>(nullable: false),
                    ResidualImpact = table.Column<int>(nullable: false),
                    Condition = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnvironmentalImpactRAHeader", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FRAHeader",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Centre = table.Column<string>(nullable: false),
                    Department = table.Column<string>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    FireHazard = table.Column<string>(nullable: false),
                    IgnitionSource = table.Column<string>(nullable: false),
                    Class = table.Column<string>(nullable: false),
                    AssociatedRisks = table.Column<string>(nullable: false),
                    NoOfExposedPeople = table.Column<int>(nullable: false),
                    Severity = table.Column<int>(nullable: false),
                    probability = table.Column<int>(nullable: false),
                    RiskScore = table.Column<int>(nullable: false),
                    Exposure = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ResidualProbability = table.Column<int>(nullable: false),
                    ResidualRiskScore = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FRAHeader", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeightWork",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Area = table.Column<string>(nullable: false),
                    Rating = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    Plant = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeightWork", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HighRiskTaskObservationRecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    DateObserved = table.Column<DateTime>(nullable: false),
                    SopTitled = table.Column<string>(nullable: false),
                    SopNumberd = table.Column<string>(nullable: false),
                    Departmentd = table.Column<string>(nullable: false),
                    PersonObserved = table.Column<string>(nullable: false),
                    Designationd = table.Column<string>(nullable: false),
                    Observed = table.Column<string>(nullable: false),
                    ReasonForObservationd = table.Column<string>(nullable: false),
                    FilePath = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    Plant = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HighRiskTaskObservationRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HRAHeader",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    ProductName = table.Column<string>(nullable: false),
                    ProductCode = table.Column<string>(nullable: false),
                    Manufacturer = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Center = table.Column<string>(nullable: false),
                    Department = table.Column<string>(nullable: false),
                    Section = table.Column<string>(nullable: false),
                    DateOfSDS = table.Column<DateTime>(nullable: false),
                    SDSHeld = table.Column<string>(nullable: false),
                    Path = table.Column<string>(nullable: false),
                    ProcessDescription = table.Column<string>(nullable: false),
                    QuantitiesUsed = table.Column<double>(nullable: false),
                    MaxTemperature = table.Column<double>(nullable: false),
                    Unit = table.Column<string>(nullable: false),
                    ExposurePeriod = table.Column<int>(nullable: false),
                    OveralUasgeAssement = table.Column<string>(nullable: false),
                    CurrentControlEffective = table.Column<bool>(nullable: false),
                    SDsControlsNotInPlace = table.Column<bool>(nullable: false),
                    AirMonitoringConsidered = table.Column<bool>(nullable: false),
                    ProcessReengineered = table.Column<bool>(nullable: false),
                    LessDangerousSubConsidered = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Eyes = table.Column<string>(nullable: true),
                    Skin = table.Column<string>(nullable: true),
                    Ingestion = table.Column<string>(nullable: true),
                    Inhalation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HRAHeader", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HRATeams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    JobTitle = table.Column<string>(nullable: false),
                    Function = table.Column<string>(nullable: false),
                    EmploymentNumber = table.Column<string>(nullable: false),
                    RAType = table.Column<string>(nullable: false),
                    Centre = table.Column<string>(nullable: false),
                    Department = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Createdby = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HRATeams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HzSubstancesInventory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Section = table.Column<string>(nullable: false),
                    Product = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    CorrectMSDS = table.Column<string>(nullable: false),
                    Hazardous = table.Column<string>(nullable: false),
                    Dangerous = table.Column<string>(nullable: false),
                    MaxQuantity = table.Column<string>(nullable: false),
                    Uses = table.Column<string>(nullable: false),
                    Manufacturer = table.Column<string>(nullable: false),
                    createdBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HzSubstancesInventory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncidentLogging",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    createdBy = table.Column<string>(nullable: false),
                    EmployeeNumber = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: false),
                    JobTitle = table.Column<string>(nullable: false),
                    FacilityWhereIncidentOcurred = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    Centre = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: false),
                    DepartmentAssignedToNon = table.Column<string>(nullable: false),
                    Supervisor = table.Column<string>(nullable: false),
                    HomeAddress = table.Column<string>(nullable: true),
                    MobilePhoneNumber = table.Column<string>(nullable: false),
                    HomePhone = table.Column<string>(nullable: true),
                    OtherPhone = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    EmploymentStatus = table.Column<string>(nullable: false),
                    ShiftDay = table.Column<string>(nullable: false),
                    ShiftTime = table.Column<string>(nullable: false),
                    DateTimeOcurred = table.Column<DateTime>(nullable: false),
                    DateTimeReported = table.Column<DateTime>(nullable: false),
                    DepartmentWhereOcurred = table.Column<string>(nullable: false),
                    InjuryClassification = table.Column<string>(nullable: false),
                    VehicleRelated = table.Column<string>(nullable: false),
                    InjuryOnCompanyBusiness = table.Column<string>(nullable: false),
                    InjuryWhileCommuting = table.Column<string>(nullable: false),
                    IncidentCause = table.Column<string>(nullable: false),
                    IncidentSubCategory = table.Column<string>(nullable: false),
                    IncidentResult = table.Column<string>(nullable: true),
                    IncidentResultOther = table.Column<string>(nullable: true),
                    LocalAuthorities = table.Column<string>(nullable: false),
                    MediaInvolvement = table.Column<string>(nullable: false),
                    RegulatoryAgency = table.Column<string>(nullable: false),
                    RegulatoryAgencyInvolved = table.Column<string>(nullable: false),
                    RegulatoryFines = table.Column<string>(nullable: true),
                    AmountOfFines = table.Column<double>(nullable: false),
                    FinesCurrency = table.Column<string>(nullable: true),
                    ManagerDescription = table.Column<string>(nullable: false),
                    EmployeeDescription = table.Column<string>(nullable: true),
                    StepsToPreventIncident = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentLogging", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InductionInventory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: false),
                    CompanyNumber = table.Column<string>(nullable: false),
                    Department = table.Column<string>(nullable: false),
                    DateOfInduction = table.Column<DateTime>(nullable: false),
                    departmentAssignedTo = table.Column<string>(nullable: false),
                    InductionDoneBy = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    Plant = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InductionInventory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InductionInventoryContractors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: false),
                    IdNumber = table.Column<string>(nullable: false),
                    Company = table.Column<string>(nullable: false),
                    DepartmentAssignedTo = table.Column<string>(nullable: false),
                    Expiry = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    InductionDoneBy = table.Column<string>(nullable: false),
                    DateOfInduction = table.Column<DateTime>(nullable: false),
                    DateOfMeedicalExamination = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Plant = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InductionInventoryContractors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InductionRequest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    InductionRequestTo = table.Column<string>(nullable: true),
                    InductionRequestFrom = table.Column<string>(nullable: false),
                    Department = table.Column<string>(nullable: false),
                    SheReceivedBY = table.Column<string>(nullable: false),
                    ScheduledDate = table.Column<DateTime>(nullable: false),
                    NoOfInductees = table.Column<double>(nullable: false),
                    WorkstationLocation = table.Column<string>(nullable: false),
                    Plant = table.Column<string>(nullable: false),
                    JobFunction = table.Column<string>(nullable: true),
                    Duration = table.Column<double>(nullable: false),
                    Hazards = table.Column<string>(nullable: false),
                    HODApproval = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    DateReceived = table.Column<DateTime>(nullable: false),
                    DateToSupervisor = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InductionRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inspections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftNo = table.Column<string>(nullable: true),
                    LineId = table.Column<string>(nullable: true),
                    Machine = table.Column<string>(nullable: true),
                    WODescription = table.Column<string>(nullable: true),
                    WONumber = table.Column<string>(nullable: true),
                    WOLevel = table.Column<string>(nullable: true),
                    AssignedTo = table.Column<string>(nullable: true),
                    TargetDuration = table.Column<double>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Createdby = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IssueBasedRAHeader",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentNo = table.Column<string>(nullable: true, computedColumnSql: "+ 'IBRA' + cast([Id] as varchar)"),
                    Location = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Task = table.Column<string>(nullable: true),
                    AssessmentNumber = table.Column<string>(nullable: true),
                    Plant = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueBasedRAHeader", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LegalOtherHeader",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Center = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: false),
                    Section = table.Column<string>(nullable: false),
                    Task = table.Column<string>(nullable: false),
                    Category = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    Plant = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalOtherHeader", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    LineId = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    LineName = table.Column<string>(nullable: true),
                    LineGroupId = table.Column<string>(nullable: true),
                    LineRating = table.Column<double>(nullable: false),
                    PlantId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lines", x => new { x.Id, x.LineId });
                });

            migrationBuilder.CreateTable(
                name: "LossWasteHeader",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LWId = table.Column<string>(nullable: true, computedColumnSql: "+ 'LW' + cast([Id] as varchar)"),
                    ShiftNo = table.Column<string>(nullable: true),
                    ReportingLine = table.Column<string>(nullable: true),
                    LineStatus = table.Column<string>(nullable: true),
                    HourlyTPV = table.Column<double>(nullable: false),
                    LostTime = table.Column<double>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    DateModified = table.Column<DateTime>(nullable: false),
                    TimeEntered = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ShiftStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LossWasteHeader", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalData",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false),
                    EmployeeNumber = table.Column<string>(nullable: false),
                    JobTitle = table.Column<string>(nullable: false),
                    Department = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    Plant = table.Column<string>(nullable: false),
                    Centre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonitoringPlan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    NosaElement = table.Column<string>(nullable: true),
                    Activity = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    SapScheduleNo = table.Column<string>(nullable: false),
                    ResponsiblePerson = table.Column<string>(nullable: false),
                    Frequency = table.Column<string>(nullable: false),
                    DocumentRetentionPlace = table.Column<string>(nullable: false),
                    Vendor = table.Column<string>(nullable: false),
                    CurrentDate = table.Column<string>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    cost = table.Column<double>(nullable: false),
                    Comments = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    Plant = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonitoringPlan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OccupationalHeader",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Centre = table.Column<string>(nullable: false),
                    Department = table.Column<string>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: false),
                    Task = table.Column<string>(nullable: false),
                    Hazard = table.Column<string>(nullable: false),
                    Category = table.Column<string>(nullable: false),
                    AssociatedRisk = table.Column<string>(nullable: false),
                    NoOfShifts = table.Column<int>(nullable: false),
                    HoursExposed = table.Column<int>(nullable: false),
                    RequiredOEL = table.Column<int>(nullable: false),
                    MeasuredOEL = table.Column<int>(nullable: false),
                    OperationalCondition = table.Column<string>(nullable: false),
                    Severity = table.Column<int>(nullable: false),
                    Frequency = table.Column<int>(nullable: false),
                    NoOfPeopleExposed = table.Column<int>(nullable: false),
                    Probability = table.Column<int>(nullable: false),
                    ResidualFrequency = table.Column<int>(nullable: false),
                    ResidualProbability = table.Column<int>(nullable: false),
                    ResidualRiskScore = table.Column<int>(nullable: false),
                    ResidualNoOfExposedPeople = table.Column<int>(nullable: false),
                    RiskScore = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccupationalHeader", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operators",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    OperatorId = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    OperatorName = table.Column<string>(nullable: true),
                    OperatorGroupId = table.Column<string>(nullable: true),
                    PlantId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operators", x => new { x.Id, x.OperatorId });
                });

            migrationBuilder.CreateTable(
                name: "PermitsAndLicenses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Sbu = table.Column<string>(nullable: true),
                    Site = table.Column<string>(nullable: false),
                    LicenceRequired = table.Column<string>(nullable: false),
                    WhereLicenseObtained = table.Column<string>(nullable: false),
                    CostOfLicense = table.Column<double>(nullable: false),
                    ModeOfPayment = table.Column<string>(nullable: false),
                    Process = table.Column<string>(nullable: false),
                    ContactEmployee = table.Column<string>(nullable: false),
                    IntermediaryInvolved = table.Column<string>(nullable: false),
                    Intermediary = table.Column<string>(nullable: false),
                    IntermediaryRole = table.Column<string>(nullable: false),
                    IntermediaryFeeStructure = table.Column<string>(nullable: false),
                    FrequencyOfRenewal = table.Column<string>(nullable: false),
                    AntiCorruptionTraining = table.Column<string>(nullable: false),
                    LicenseStatus = table.Column<string>(nullable: false),
                    FinesLevied = table.Column<double>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    Plant = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermitsAndLicenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PIMsPOMs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftNo = table.Column<string>(nullable: true),
                    Machine = table.Column<string>(nullable: true),
                    Dimension = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    UoM = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PIMsPOMs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PIMsPOMsBlowMoulder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftNo = table.Column<string>(nullable: true),
                    AirPressure = table.Column<double>(nullable: false),
                    ChillerWaterLevel = table.Column<double>(nullable: false),
                    BlowingPressure = table.Column<double>(nullable: false),
                    AmbientRoomTemp = table.Column<double>(nullable: false),
                    LampStatus = table.Column<string>(nullable: true),
                    ChillerOutTemp = table.Column<double>(nullable: false),
                    IncomingBarPressure = table.Column<double>(nullable: false),
                    OvenTemp = table.Column<double>(nullable: false),
                    NoWaterLeaks = table.Column<double>(nullable: false),
                    NoAirLeaks = table.Column<double>(nullable: false),
                    BottleChecksDone = table.Column<double>(nullable: false),
                    NoPreformsIn = table.Column<double>(nullable: false),
                    NoPreformsOut = table.Column<double>(nullable: false),
                    NoPreformsRejected = table.Column<double>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PIMsPOMsBlowMoulder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PIMsPOMsCompressor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftNo = table.Column<string>(nullable: true),
                    FirstStagePressure = table.Column<double>(nullable: false),
                    BarCompressorPressure = table.Column<double>(nullable: false),
                    UoM = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PIMsPOMsCompressor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PIMsPOMsFiller",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftNo = table.Column<string>(nullable: true),
                    FillerBeerTemperature = table.Column<double>(nullable: false),
                    AirControlPressure = table.Column<double>(nullable: false),
                    BottleNeckRinser = table.Column<double>(nullable: false),
                    FillerBowlCounterPressure = table.Column<double>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PIMsPOMsFiller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PIMsPOMShrinkPacker",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftNo = table.Column<string>(nullable: true),
                    BladeCutting = table.Column<double>(nullable: false),
                    SensorPositioning = table.Column<double>(nullable: false),
                    ShrinkpackerMachineSpeedLine2 = table.Column<double>(nullable: false),
                    BarCompressorPressure = table.Column<double>(nullable: false),
                    ShrinkpackerMachineSpeedLine3 = table.Column<double>(nullable: false),
                    SkewedPacks = table.Column<double>(nullable: false),
                    ElectricalCabinets = table.Column<double>(nullable: false),
                    OvenTemperature = table.Column<double>(nullable: false),
                    UnevenEyes = table.Column<double>(nullable: false),
                    UnwrappedBottles = table.Column<double>(nullable: false),
                    CasesProduced = table.Column<double>(nullable: false),
                    NoCasesRejected = table.Column<double>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PIMsPOMShrinkPacker", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PIMsPOMsPasteurizer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftNo = table.Column<string>(nullable: true),
                    PasterisationUnits = table.Column<double>(nullable: false),
                    IncomingGlycolTemperature = table.Column<double>(nullable: false),
                    IncomingCo2Pressure = table.Column<double>(nullable: false),
                    IncomingSteamPressure = table.Column<double>(nullable: false),
                    PasteurisingTemperatures = table.Column<double>(nullable: false),
                    BufferLevel = table.Column<double>(nullable: false),
                    BeerViscosity = table.Column<double>(nullable: false),
                    Torques = table.Column<double>(nullable: false),
                    Co2InBottle = table.Column<double>(nullable: false),
                    PasteuriserBeerTemperature = table.Column<double>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PIMsPOMsPasteurizer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PIMsPOMsRobobox",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftNo = table.Column<string>(nullable: true),
                    StretchWrapperTemperature = table.Column<double>(nullable: false),
                    StretchAirPressure = table.Column<double>(nullable: false),
                    PalletiserAirPressure = table.Column<double>(nullable: false),
                    PalletsOnPalletMagazine = table.Column<double>(nullable: false),
                    LayerpadQuality = table.Column<double>(nullable: false),
                    RoboboxMachineSpeed = table.Column<double>(nullable: false),
                    PalletsProduced = table.Column<double>(nullable: false),
                    NoPalletsReworked = table.Column<double>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PIMsPOMsRobobox", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlantData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    PlantId = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    PlantName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    RegionMain = table.Column<string>(nullable: true),
                    RegionDistrict = table.Column<string>(nullable: true),
                    SorghumRegion = table.Column<string>(nullable: true),
                    SorghumTerritory = table.Column<string>(nullable: true),
                    LagersTerritory = table.Column<string>(nullable: true),
                    SalesOrg = table.Column<string>(nullable: true),
                    CompanyCode = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantData", x => new { x.Id, x.PlantId });
                });

            migrationBuilder.CreateTable(
                name: "PreTaskRAHeader",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormId = table.Column<string>(nullable: true, computedColumnSql: "+ 'PRA' + cast([Id] as varchar)"),
                    Section = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TeamLeader = table.Column<string>(nullable: true),
                    RefNumber = table.Column<string>(nullable: true),
                    Competence = table.Column<bool>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<string>(nullable: true),
                    supervisor = table.Column<string>(nullable: true),
                    headOfDepartment = table.Column<string>(nullable: true),
                    sheOfficer = table.Column<string>(nullable: true),
                    sheManager = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreTaskRAHeader", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionTimes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    PaidFactoryHours = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionTimes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityCIPTracker",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Class = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    DetergentStrength = table.Column<decimal>(nullable: false),
                    DetergentTemp = table.Column<decimal>(nullable: false),
                    HotWaterTemp = table.Column<decimal>(nullable: false),
                    PhenopthaleinTest = table.Column<string>(nullable: true),
                    TeamLeader = table.Column<string>(nullable: true),
                    QAAnalyst = table.Column<string>(nullable: true),
                    PCA = table.Column<decimal>(nullable: false),
                    SDM = table.Column<decimal>(nullable: false),
                    NBB = table.Column<decimal>(nullable: false),
                    WA = table.Column<decimal>(nullable: false),
                    NBB_B = table.Column<decimal>(nullable: false),
                    WLN = table.Column<decimal>(nullable: false),
                    Microbiologist = table.Column<string>(nullable: true),
                    CleaningAdherance = table.Column<string>(nullable: true),
                    Effectiveness = table.Column<string>(nullable: true),
                    Deviation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityCIPTracker", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityCustomerComplaint",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Driver = table.Column<string>(nullable: true),
                    Route = table.Column<string>(nullable: true),
                    DateofCompaint = table.Column<string>(nullable: true),
                    Customer = table.Column<string>(nullable: true),
                    BatchNumber = table.Column<string>(nullable: true),
                    Line = table.Column<string>(nullable: true),
                    BBDate = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    NatureOfComplaint = table.Column<string>(nullable: true),
                    Confirmation = table.Column<string>(nullable: true),
                    RootCause = table.Column<string>(nullable: true),
                    CorrectiveActions = table.Column<string>(nullable: true),
                    ByWho = table.Column<string>(nullable: true),
                    ByWhen = table.Column<string>(nullable: true),
                    Analyst = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityCustomerComplaint", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityFermentation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Tank = table.Column<string>(nullable: true),
                    BrewNo = table.Column<int>(nullable: false),
                    BrixAtWort = table.Column<decimal>(nullable: false),
                    YeastBatch = table.Column<string>(nullable: true),
                    MaltBatch = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityFermentation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityMarketDispatched",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Driver = table.Column<string>(nullable: true),
                    Route = table.Column<string>(nullable: true),
                    BatchNumber = table.Column<string>(nullable: true),
                    BBDate = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Analyst = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityMarketDispatched", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityParams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class = table.Column<string>(nullable: true),
                    Variable = table.Column<string>(nullable: true),
                    Unit = table.Column<string>(nullable: true),
                    LCL = table.Column<decimal>(nullable: false),
                    Target = table.Column<decimal>(nullable: false),
                    UCL = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityParams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityPIP",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    DateOfPacking = table.Column<DateTime>(nullable: false),
                    CO2content = table.Column<decimal>(nullable: false),
                    Volume = table.Column<decimal>(nullable: false),
                    Torque = table.Column<decimal>(nullable: false),
                    AlcoholContent = table.Column<decimal>(nullable: false),
                    IntankViscosity = table.Column<decimal>(nullable: false),
                    InpackViscosity = table.Column<decimal>(nullable: false),
                    TotalAcids = table.Column<decimal>(nullable: false),
                    pH = table.Column<decimal>(nullable: false),
                    Brix = table.Column<decimal>(nullable: false),
                    SG = table.Column<decimal>(nullable: false),
                    Temperature = table.Column<decimal>(nullable: false),
                    PackaginGage = table.Column<decimal>(nullable: false),
                    BestBeforeDate = table.Column<DateTime>(nullable: false),
                    Analyst = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityPIP", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityRICarbonDioxide",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    DateOfDelivery = table.Column<DateTime>(nullable: false),
                    SupplierName = table.Column<string>(nullable: true),
                    BatchNumber = table.Column<string>(nullable: true),
                    Tank = table.Column<string>(nullable: true),
                    Quantity = table.Column<string>(nullable: true),
                    Taste = table.Column<string>(nullable: true),
                    Odour = table.Column<string>(nullable: true),
                    ApperanceInWater = table.Column<string>(nullable: true),
                    Purity = table.Column<string>(nullable: true),
                    OdourAfterAcidification = table.Column<string>(nullable: true),
                    SnowTest = table.Column<string>(nullable: true),
                    AnalystInitials = table.Column<string>(nullable: true),
                    COA = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityRICarbonDioxide", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityRIClosure",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    DateOfDelivery = table.Column<DateTime>(nullable: false),
                    Supplier = table.Column<string>(nullable: true),
                    BatchNo = table.Column<string>(nullable: true),
                    DateOfManufacture = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Sample = table.Column<int>(nullable: false),
                    Mass = table.Column<string>(nullable: true),
                    Height = table.Column<string>(nullable: true),
                    Diameter = table.Column<string>(nullable: true),
                    TemperEvidenceBand = table.Column<string>(nullable: true),
                    Printing = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    AnalystInitials = table.Column<string>(nullable: true),
                    COA = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityRIClosure", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityRIGlue",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    DateOfDelivery = table.Column<DateTime>(nullable: false),
                    Supplier = table.Column<string>(nullable: true),
                    BatchNo = table.Column<string>(nullable: true),
                    DateOfManufacture = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    GlueCode = table.Column<string>(nullable: true),
                    BucketCondition = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    BucketSize = table.Column<string>(nullable: true),
                    AnalystInitials = table.Column<string>(nullable: true),
                    COA = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityRIGlue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityRILabel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    DateOfDelivery = table.Column<DateTime>(nullable: false),
                    Supplier = table.Column<string>(nullable: true),
                    BatchNo = table.Column<string>(nullable: true),
                    DateOfManufacture = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    Layout = table.Column<string>(nullable: true),
                    Spikes = table.Column<string>(nullable: true),
                    Overlap = table.Column<string>(nullable: true),
                    BarCode = table.Column<string>(nullable: true),
                    Length = table.Column<string>(nullable: true),
                    Width = table.Column<string>(nullable: true),
                    Direction = table.Column<string>(nullable: true),
                    Separation = table.Column<string>(nullable: true),
                    Packing = table.Column<string>(nullable: true),
                    AnalystInitials = table.Column<string>(nullable: true),
                    COA = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityRILabel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityRILacticAcid",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    DateOfDelivery = table.Column<DateTime>(nullable: false),
                    SupplierName = table.Column<string>(nullable: true),
                    BatchNumber = table.Column<string>(nullable: true),
                    ExpiryDate = table.Column<string>(nullable: true),
                    Strength = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    AnalystInitials = table.Column<string>(nullable: true),
                    COA = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityRILacticAcid", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityRIMaize",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    DateOfDelivery = table.Column<DateTime>(nullable: false),
                    SupplierName = table.Column<string>(nullable: true),
                    TruckNum = table.Column<string>(nullable: true),
                    BatchNumber = table.Column<string>(nullable: true),
                    SiloOffloadedInto = table.Column<string>(nullable: true),
                    Quantity = table.Column<decimal>(nullable: false),
                    Moisture = table.Column<decimal>(nullable: false),
                    Chipped = table.Column<decimal>(nullable: false),
                    Defective = table.Column<decimal>(nullable: false),
                    TotalDensity = table.Column<decimal>(nullable: false),
                    Trash = table.Column<decimal>(nullable: false),
                    ExtraMatter = table.Column<decimal>(nullable: false),
                    WeevilsInfestationLive = table.Column<decimal>(nullable: false),
                    WeevilsInfestationDead = table.Column<decimal>(nullable: false),
                    Extract = table.Column<decimal>(nullable: false),
                    Colour = table.Column<string>(nullable: true),
                    Grade = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    AnalystInitials = table.Column<string>(nullable: true),
                    COA = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityRIMaize", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityRIMalt",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    DateOfDelivery = table.Column<DateTime>(nullable: false),
                    SupplierName = table.Column<string>(nullable: true),
                    BatchNumber = table.Column<string>(nullable: true),
                    DateOfManufacture = table.Column<string>(nullable: true),
                    Quantity = table.Column<decimal>(nullable: false),
                    Moisture = table.Column<decimal>(nullable: false),
                    SDU = table.Column<decimal>(nullable: false),
                    Solubility = table.Column<decimal>(nullable: false),
                    MaltActivity = table.Column<decimal>(nullable: false),
                    Extract = table.Column<decimal>(nullable: false),
                    TBC = table.Column<decimal>(nullable: false),
                    SandDetection = table.Column<string>(nullable: true),
                    FreeAminoNitrogen = table.Column<decimal>(nullable: false),
                    AnalystInitials = table.Column<string>(nullable: true),
                    COA = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityRIMalt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityRIPreform",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    DateOfDelivery = table.Column<DateTime>(nullable: false),
                    Supplier = table.Column<string>(nullable: true),
                    BatchNo = table.Column<string>(nullable: true),
                    DateOfManufacture = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Sample = table.Column<int>(nullable: false),
                    Mass = table.Column<string>(nullable: true),
                    Height = table.Column<string>(nullable: true),
                    InternalDiameter = table.Column<string>(nullable: true),
                    ExternalDiameter = table.Column<string>(nullable: true),
                    Neck = table.Column<string>(nullable: true),
                    FinishGoGauge = table.Column<string>(nullable: true),
                    Visual = table.Column<string>(nullable: true),
                    AnalystInitials = table.Column<string>(nullable: true),
                    COA = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityRIPreform", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityRIShrinkfilm",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    DateOfDelivery = table.Column<DateTime>(nullable: false),
                    Supplier = table.Column<string>(nullable: true),
                    BatchNo = table.Column<string>(nullable: true),
                    DateOfManufacture = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    Width = table.Column<string>(nullable: true),
                    Gauge = table.Column<string>(nullable: true),
                    CodeDiameter = table.Column<string>(nullable: true),
                    CodeShape = table.Column<string>(nullable: true),
                    ReelCondition = table.Column<string>(nullable: true),
                    Mass = table.Column<string>(nullable: true),
                    AnalystInitials = table.Column<string>(nullable: true),
                    COA = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityRIShrinkfilm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityRIStretchfilm",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    DateOfDelivery = table.Column<DateTime>(nullable: false),
                    Supplier = table.Column<string>(nullable: true),
                    BatchNo = table.Column<string>(nullable: true),
                    DateOfManufacture = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    Width = table.Column<string>(nullable: true),
                    Gauge = table.Column<string>(nullable: true),
                    CodeDiameter = table.Column<string>(nullable: true),
                    CodeShape = table.Column<string>(nullable: true),
                    ReelCondition = table.Column<string>(nullable: true),
                    Mass = table.Column<string>(nullable: true),
                    AnalystInitials = table.Column<string>(nullable: true),
                    COA = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityRIStretchfilm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityRIYeast",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    DateOfDelivery = table.Column<DateTime>(nullable: false),
                    SupplierName = table.Column<string>(nullable: true),
                    BatchNumber = table.Column<string>(nullable: true),
                    BestBeforeDate = table.Column<string>(nullable: true),
                    Quantity = table.Column<string>(nullable: true),
                    AlcoholProduction = table.Column<string>(nullable: true),
                    FoamFormation = table.Column<string>(nullable: true),
                    Colour = table.Column<string>(nullable: true),
                    MoistureContent = table.Column<string>(nullable: true),
                    ShelfLife = table.Column<string>(nullable: true),
                    TotalBacteria = table.Column<string>(nullable: true),
                    Lactobacillus = table.Column<string>(nullable: true),
                    WildYeast = table.Column<string>(nullable: true),
                    EColi = table.Column<string>(nullable: true),
                    Coliforms = table.Column<string>(nullable: true),
                    LiveCellCount = table.Column<string>(nullable: true),
                    Viability = table.Column<string>(nullable: true),
                    AnalystInitials = table.Column<string>(nullable: true),
                    COA = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityRIYeast", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityShelflife",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    BatchNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityShelflife", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityVUsage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Plant = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Hours = table.Column<int>(nullable: false),
                    LastCIP = table.Column<DateTime>(nullable: false),
                    Empty = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityVUsage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityWort",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    BrewNo = table.Column<int>(nullable: false),
                    MaizeSilo = table.Column<string>(nullable: true),
                    MPV = table.Column<string>(nullable: true),
                    MaltBatch = table.Column<string>(nullable: true),
                    YeastBatch = table.Column<string>(nullable: true),
                    SpentGrainMoisture = table.Column<decimal>(nullable: false),
                    pH = table.Column<decimal>(nullable: false),
                    Ref = table.Column<decimal>(nullable: false),
                    Viscosity = table.Column<decimal>(nullable: false),
                    Brix = table.Column<decimal>(nullable: false),
                    SG = table.Column<decimal>(nullable: false),
                    OE = table.Column<decimal>(nullable: false),
                    TotalAcids = table.Column<decimal>(nullable: false),
                    RDF = table.Column<decimal>(nullable: false),
                    Analyst = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityWort", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceCategoryId = table.Column<string>(nullable: true),
                    ResourceName = table.Column<string>(nullable: true),
                    ResCategory = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SafeWorkMethod",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    ContracterResponsible = table.Column<string>(nullable: true),
                    PersonForSWMS = table.Column<string>(nullable: false),
                    ReviewedBy = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: false),
                    Scope = table.Column<string>(nullable: false),
                    CommunicationProcedure = table.Column<string>(nullable: false),
                    ProjectManagerApproval = table.Column<string>(nullable: false),
                    ContractorSiteApproval = table.Column<string>(nullable: false),
                    ResponsibleManager = table.Column<string>(nullable: false),
                    ResponsibleManagerDate = table.Column<DateTime>(nullable: false),
                    EngineeringManager = table.Column<string>(nullable: true),
                    EngineeringManagerDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SafeWorkMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SHERegistry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Region = table.Column<string>(nullable: false),
                    Center = table.Column<string>(nullable: false),
                    Department = table.Column<string>(nullable: false),
                    JobTitle = table.Column<string>(nullable: false),
                    Function = table.Column<string>(nullable: false),
                    EmploymentNumber = table.Column<string>(nullable: false),
                    EmploymentStatus = table.Column<string>(nullable: false),
                    AppointmentStatus = table.Column<string>(nullable: false),
                    TrainingDue = table.Column<DateTime>(nullable: false),
                    RegistryType = table.Column<string>(nullable: false),
                    Plant = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHERegistry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SHETargetsHeader",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Objective = table.Column<string>(nullable: true),
                    Programme = table.Column<string>(nullable: false),
                    ActionPlan = table.Column<string>(nullable: false),
                    Resources = table.Column<string>(nullable: false),
                    Indicators = table.Column<string>(nullable: false),
                    TargetStartDate = table.Column<DateTime>(nullable: false),
                    TargetEndDate = table.Column<DateTime>(nullable: false),
                    Responsibility = table.Column<string>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHETargetsHeader", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShiftEnd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftNo = table.Column<string>(nullable: true),
                    StatusId = table.Column<string>(nullable: true),
                    carbondioxide = table.Column<double>(nullable: false),
                    beerloss = table.Column<double>(nullable: false),
                    closure = table.Column<double>(nullable: false),
                    preform = table.Column<double>(nullable: false),
                    label = table.Column<double>(nullable: false),
                    glue = table.Column<double>(nullable: false),
                    shrinkwrap = table.Column<double>(nullable: false),
                    stretchwrap = table.Column<double>(nullable: false),
                    ShiftEndTime = table.Column<DateTime>(nullable: false),
                    createdBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftEnd", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShiftHeader",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftNo = table.Column<string>(nullable: true, computedColumnSql: "+ 'SH' + cast([Id] as varchar)"),
                    ReportingLine = table.Column<string>(nullable: true),
                    ShiftName = table.Column<string>(nullable: true),
                    ShiftLeader = table.Column<string>(nullable: true),
                    ShiftGroupId = table.Column<string>(nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    PlantId = table.Column<string>(nullable: true),
                    ShiftStartDate = table.Column<DateTime>(nullable: false),
                    ShiftEndDate = table.Column<DateTime>(nullable: false),
                    ChangedBy = table.Column<string>(nullable: true),
                    TargetVolume = table.Column<double>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "format(GETDATE(),'dddd, dd MMMM yyyy h:mm tt')"),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftHeader", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShiftMaster",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ShiftId = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    ShiftName = table.Column<string>(nullable: true),
                    UserGroupId = table.Column<string>(nullable: true),
                    PlantId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftMaster", x => new { x.Id, x.ShiftId });
                });

            migrationBuilder.CreateTable(
                name: "ShiftStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusId = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SRAHeader",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Centre = table.Column<string>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: false),
                    Section = table.Column<string>(nullable: false),
                    HazardInvolved = table.Column<string>(nullable: false),
                    AssociatedRisk = table.Column<string>(nullable: false),
                    Tasks = table.Column<string>(nullable: false),
                    Category = table.Column<string>(nullable: false),
                    Severity = table.Column<int>(nullable: false),
                    probability = table.Column<int>(nullable: false),
                    RiskScore = table.Column<int>(nullable: false),
                    Condition = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    SRAType = table.Column<string>(nullable: false),
                    ResidualProbability = table.Column<int>(nullable: false),
                    ResidualRiskScore = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SRAHeader", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suggestions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExplanationOfSuggestion = table.Column<string>(nullable: true),
                    benefit = table.Column<string>(nullable: true),
                    Cost = table.Column<string>(nullable: true),
                    EstimatedCost = table.Column<string>(nullable: true),
                    risk = table.Column<string>(nullable: true),
                    RiskExplanation = table.Column<string>(nullable: true),
                    RiskOtherExplanation = table.Column<string>(nullable: true),
                    Explanation = table.Column<string>(nullable: true),
                    Plant = table.Column<string>(nullable: false),
                    Department = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    NameOfSuggestor = table.Column<string>(nullable: true),
                    dateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    ReviewerAdditions = table.Column<string>(nullable: true),
                    RecommendedAction = table.Column<string>(nullable: true),
                    Responsibility = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: false),
                    ClosureStatus = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    ReviewStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suggestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupplierEvaluation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    RefNo = table.Column<string>(nullable: false),
                    ScopingArea = table.Column<string>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    Rating = table.Column<double>(nullable: false),
                    TotalScore = table.Column<double>(nullable: false),
                    AuditFindings = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Plant = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierEvaluation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    SupplierName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    OrderNumber = table.Column<string>(nullable: false),
                    EvaluationScore = table.Column<int>(nullable: false),
                    FilePath = table.Column<string>(nullable: false),
                    Decision = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Plant = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SustainableDevelopment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    RefNo = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    Plant = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SustainableDevelopment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemDocumentation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Category = table.Column<string>(nullable: false),
                    DocumentNumber = table.Column<string>(nullable: false),
                    IssueNumber = table.Column<string>(nullable: false),
                    IssueDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Procedure = table.Column<string>(nullable: true),
                    Plant = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemDocumentation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamLeaders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    TeamLeaderId = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    TeamLeaderName = table.Column<string>(nullable: true),
                    TeamLeaderGroupId = table.Column<string>(nullable: true),
                    PlantId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamLeaders", x => new { x.Id, x.TeamLeaderId });
                });

            migrationBuilder.CreateTable(
                name: "TrainingMatrix",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Ref = table.Column<string>(nullable: true),
                    Center = table.Column<string>(nullable: false),
                    Department = table.Column<string>(nullable: false),
                    EmployeeNumber = table.Column<string>(nullable: false),
                    JobTitle = table.Column<string>(nullable: false),
                    EmployeeName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    Plant = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingMatrix", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingPlan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Course = table.Column<string>(nullable: false),
                    Source = table.Column<string>(nullable: false),
                    TargetGroup = table.Column<string>(nullable: false),
                    NonfinancialResourcesRequired = table.Column<string>(nullable: false),
                    Cost = table.Column<string>(nullable: false),
                    TargetTraining = table.Column<string>(nullable: false),
                    TrainingCycle = table.Column<string>(nullable: false),
                    TrainingDays = table.Column<string>(nullable: false),
                    TrainingOrganisation = table.Column<string>(nullable: false),
                    Plant = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPlan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    UserGroupID = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    GroupName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => new { x.Id, x.UserGroupID });
                });

            migrationBuilder.CreateTable(
                name: "UserRoleMaster",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    RoleId = table.Column<string>(nullable: false),
                    RoleTypeId = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    RoleName = table.Column<string>(nullable: true),
                    RoleTypeDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleMaster", x => new { x.Id, x.RoleId, x.RoleTypeId });
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Cell = table.Column<string>(nullable: true),
                    PlantId = table.Column<string>(nullable: true),
                    UsergroupID = table.Column<string>(nullable: true),
                    UserTypeID = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => new { x.Id, x.UserName });
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    UserTypeId = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    userType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => new { x.Id, x.UserTypeId });
                });

            migrationBuilder.CreateTable(
                name: "Utilities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Analyst = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WasteManagement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    wasteIdentified = table.Column<string>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    wasteFormat = table.Column<string>(nullable: false),
                    wasteType = table.Column<string>(nullable: false),
                    generalWaste = table.Column<string>(nullable: false),
                    hazardousWaste = table.Column<string>(nullable: false),
                    WasteClassification = table.Column<string>(nullable: false),
                    Volume = table.Column<string>(nullable: false),
                    wasteManagement = table.Column<string>(nullable: false),
                    disposalSite = table.Column<string>(nullable: false),
                    Comment = table.Column<string>(nullable: false),
                    wastePosition = table.Column<string>(nullable: false),
                    createdBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WasteManagement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WasteTracking",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    waste = table.Column<string>(nullable: false),
                    collector = table.Column<string>(nullable: false),
                    DateCollected = table.Column<string>(nullable: false),
                    Quantity = table.Column<string>(nullable: false),
                    DisposalCost = table.Column<string>(nullable: false),
                    SellingPrice = table.Column<string>(nullable: false),
                    DisposalSite = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    Plant = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WasteTracking", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Material = table.Column<string>(nullable: true),
                    OpeningStock = table.Column<decimal>(nullable: false),
                    ClosingStock = table.Column<decimal>(nullable: false),
                    BrewId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_BrewingBrews_BrewId",
                        column: x => x.BrewId,
                        principalTable: "BrewingBrews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BrewingProcesses",
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
                    Duration = table.Column<int>(nullable: false),
                    BCId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewingProcesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrewingProcesses_BrewingCycles_BCId",
                        column: x => x.BCId,
                        principalTable: "BrewingCycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BrewingStoppages",
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
                    BCId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewingStoppages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrewingStoppages_BrewingCycles_BCId",
                        column: x => x.BCId,
                        principalTable: "BrewingCycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MillEnd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrushConsistency = table.Column<decimal>(nullable: false),
                    MillPlantCF = table.Column<decimal>(nullable: false),
                    InsectInfestation = table.Column<string>(nullable: true),
                    GistComposition = table.Column<decimal>(nullable: false),
                    GristResidence = table.Column<decimal>(nullable: false),
                    EMId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MillEnd", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MillEnd_BrewingEndMilling_EMId",
                        column: x => x.EMId,
                        principalTable: "BrewingEndMilling",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BrewingStdChecks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Shift = table.Column<string>(nullable: true),
                    BrewNumber = table.Column<string>(nullable: true),
                    Stage = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false),
                    Viscosity = table.Column<decimal>(nullable: false),
                    Brix = table.Column<decimal>(nullable: false),
                    SG = table.Column<decimal>(nullable: false),
                    PH = table.Column<decimal>(nullable: false),
                    Alcohol = table.Column<decimal>(nullable: false),
                    Temperature = table.Column<decimal>(nullable: false),
                    Attendant = table.Column<string>(nullable: true),
                    IPCId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewingStdChecks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrewingStdChecks_BrewingIPC_IPCId",
                        column: x => x.IPCId,
                        principalTable: "BrewingIPC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MillStart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdjunctMassMaizeBuffer = table.Column<decimal>(nullable: false),
                    Mashingtime = table.Column<decimal>(nullable: false),
                    CIP = table.Column<decimal>(nullable: false),
                    MouldGrowth = table.Column<string>(nullable: true),
                    PreingMagnetCF = table.Column<decimal>(nullable: false),
                    Throughput = table.Column<decimal>(nullable: false),
                    Samplingvalve = table.Column<decimal>(nullable: false),
                    SMId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MillStart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MillStart_BrewingStartMilling_SMId",
                        column: x => x.SMId,
                        principalTable: "BrewingStartMilling",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EnvironmentalImpactControls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ControlType = table.Column<string>(nullable: true),
                    Control = table.Column<string>(nullable: true),
                    EnvironmentalImpactRAHeaderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnvironmentalImpactControls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnvironmentalImpactControls_EnvironmentalImpactRAHeader_EnvironmentalImpactRAHeaderId",
                        column: x => x.EnvironmentalImpactRAHeaderId,
                        principalTable: "EnvironmentalImpactRAHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EnvironmentalImpactRequirements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequirementType = table.Column<string>(nullable: true),
                    Requirement = table.Column<string>(nullable: true),
                    EnvironmentalImpactRAHeaderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnvironmentalImpactRequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnvironmentalImpactRequirements_EnvironmentalImpactRAHeader_EnvironmentalImpactRAHeaderId",
                        column: x => x.EnvironmentalImpactRAHeaderId,
                        principalTable: "EnvironmentalImpactRAHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FRAControls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Control = table.Column<string>(nullable: true),
                    Measure = table.Column<string>(nullable: true),
                    ResponsiblePerson = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: false),
                    FRAHeaderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FRAControls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FRAControls_FRAHeader_FRAHeaderId",
                        column: x => x.FRAHeaderId,
                        principalTable: "FRAHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FRAEquipments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequirementType = table.Column<string>(nullable: true),
                    Requirement = table.Column<string>(nullable: true),
                    FRAHeaderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FRAEquipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FRAEquipments_FRAHeader_FRAHeaderId",
                        column: x => x.FRAHeaderId,
                        principalTable: "FRAHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FRARequirements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequirementType = table.Column<string>(nullable: true),
                    Requirement = table.Column<string>(nullable: true),
                    FRAHeaderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FRARequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FRARequirements_FRAHeader_FRAHeaderId",
                        column: x => x.FRAHeaderId,
                        principalTable: "FRAHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HRAAffectedPersons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AffectedPersons = table.Column<string>(nullable: true),
                    HRAHeaderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HRAAffectedPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HRAAffectedPersons_HRAHeader_HRAHeaderId",
                        column: x => x.HRAHeaderId,
                        principalTable: "HRAHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HRAAssociatedRisk",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Risk = table.Column<string>(nullable: true),
                    HRAHeaderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HRAAssociatedRisk", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HRAAssociatedRisk_HRAHeader_HRAHeaderId",
                        column: x => x.HRAHeaderId,
                        principalTable: "HRAHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HRAClassification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Classification = table.Column<string>(nullable: true),
                    HRAHeaderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HRAClassification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HRAClassification_HRAHeader_HRAHeaderId",
                        column: x => x.HRAHeaderId,
                        principalTable: "HRAHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HRAControls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ControlType = table.Column<string>(nullable: true),
                    Control = table.Column<string>(nullable: true),
                    HRAHeaderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HRAControls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HRAControls_HRAHeader_HRAHeaderId",
                        column: x => x.HRAHeaderId,
                        principalTable: "HRAHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HRAEmergencyAction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emergency = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    HRAHeaderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HRAEmergencyAction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HRAEmergencyAction_HRAHeader_HRAHeaderId",
                        column: x => x.HRAHeaderId,
                        principalTable: "HRAHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HRAExposureRoute",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Exposure = table.Column<string>(nullable: true),
                    HRAHeaderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HRAExposureRoute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HRAExposureRoute_HRAHeader_HRAHeaderId",
                        column: x => x.HRAHeaderId,
                        principalTable: "HRAHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HRAHandlingControls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ControlType = table.Column<string>(nullable: true),
                    Control = table.Column<string>(nullable: true),
                    HRAHeaderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HRAHandlingControls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HRAHandlingControls_HRAHeader_HRAHeaderId",
                        column: x => x.HRAHeaderId,
                        principalTable: "HRAHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HRAImprovementSuggestion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SuggestionType = table.Column<string>(nullable: true),
                    Suggestion = table.Column<string>(nullable: true),
                    HRAHeaderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HRAImprovementSuggestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HRAImprovementSuggestion_HRAHeader_HRAHeaderId",
                        column: x => x.HRAHeaderId,
                        principalTable: "HRAHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HRARequirements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequirementType = table.Column<string>(nullable: true),
                    Requirement = table.Column<string>(nullable: true),
                    HRAHeaderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HRARequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HRARequirements_HRAHeader_HRAHeaderId",
                        column: x => x.HRAHeaderId,
                        principalTable: "HRAHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HRASubstancesProduced",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Substance = table.Column<string>(nullable: true),
                    HRAHeaderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HRASubstancesProduced", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HRASubstancesProduced_HRAHeader_HRAHeaderId",
                        column: x => x.HRAHeaderId,
                        principalTable: "HRAHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AffectedBodyPart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    BodyPart = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    IncidentLoggingId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AffectedBodyPart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AffectedBodyPart_IncidentLogging_IncidentLoggingId",
                        column: x => x.IncidentLoggingId,
                        principalTable: "IncidentLogging",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IncidentDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    FilePath = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    IncidentLoggingId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncidentDocuments_IncidentLogging_IncidentLoggingId",
                        column: x => x.IncidentLoggingId,
                        principalTable: "IncidentLogging",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IncidentNatureOfIllness",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Illness = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    IncidentLoggingId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentNatureOfIllness", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncidentNatureOfIllness_IncidentLogging_IncidentLoggingId",
                        column: x => x.IncidentLoggingId,
                        principalTable: "IncidentLogging",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IncidentWitnesses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    WitnessDate = table.Column<DateTime>(nullable: false),
                    WitnessName = table.Column<string>(nullable: true),
                    WitnessPhoneNumber = table.Column<string>(nullable: true),
                    IncidentLoggingId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentWitnesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncidentWitnesses_IncidentLogging_IncidentLoggingId",
                        column: x => x.IncidentLoggingId,
                        principalTable: "IncidentLogging",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobTitle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    InductionRequestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobTitle_InductionRequest_InductionRequestId",
                        column: x => x.InductionRequestId,
                        principalTable: "InductionRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IssueBasedRAAuthorisations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentNo = table.Column<string>(nullable: true, computedColumnSql: "+ 'IBRA' + cast([IssueBasedRAHeaderId] as varchar)"),
                    Supervisor = table.Column<bool>(nullable: false),
                    SHEOfficer = table.Column<bool>(nullable: false),
                    HOD = table.Column<bool>(nullable: false),
                    SHEManager = table.Column<bool>(nullable: false),
                    IssueBasedRAHeaderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueBasedRAAuthorisations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueBasedRAAuthorisations_IssueBasedRAHeader_IssueBasedRAHeaderId",
                        column: x => x.IssueBasedRAHeaderId,
                        principalTable: "IssueBasedRAHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IssueBasedRAItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentNo = table.Column<string>(nullable: true, computedColumnSql: "+ 'IBRA' + cast([IssueBasedRAHeaderId] as varchar)"),
                    PotentialHazard = table.Column<string>(nullable: true),
                    Task = table.Column<string>(nullable: true),
                    Risk = table.Column<string>(nullable: true),
                    AffectedPerson = table.Column<string>(nullable: true),
                    ExistingMeasures = table.Column<string>(nullable: true),
                    RiskRating = table.Column<string>(nullable: true),
                    PreventionMeasures = table.Column<string>(nullable: true),
                    Responsibilities = table.Column<string>(nullable: true),
                    TargetCompletion = table.Column<DateTime>(nullable: false),
                    IssueBasedRAHeaderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueBasedRAItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueBasedRAItems_IssueBasedRAHeader_IssueBasedRAHeaderId",
                        column: x => x.IssueBasedRAHeaderId,
                        principalTable: "IssueBasedRAHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IssueBasedRAMembers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentNo = table.Column<string>(nullable: true, computedColumnSql: "+ 'IBRA' + cast([IssueBasedRAHeaderId] as varchar)"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    IssueBasedRAHeaderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueBasedRAMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueBasedRAMembers_IssueBasedRAHeader_IssueBasedRAHeaderId",
                        column: x => x.IssueBasedRAHeaderId,
                        principalTable: "IssueBasedRAHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LegalOtherRequirements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequirementType = table.Column<string>(nullable: true),
                    Requirement = table.Column<string>(nullable: true),
                    ComplainceMechanism = table.Column<string>(nullable: true),
                    Responsibility = table.Column<string>(nullable: true),
                    LegalOtherHeaderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalOtherRequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LegalOtherRequirements_LegalOtherHeader_LegalOtherHeaderId",
                        column: x => x.LegalOtherHeaderId,
                        principalTable: "LegalOtherHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LossWasteFaults",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LWId = table.Column<string>(nullable: true, computedColumnSql: "+ 'LW' + cast([LWHeaderId] as varchar)"),
                    FaultNo = table.Column<string>(nullable: true, computedColumnSql: "+ 'FN' + cast([Id] as varchar)"),
                    Level1 = table.Column<string>(nullable: true),
                    Level2 = table.Column<string>(nullable: true),
                    Level3 = table.Column<string>(nullable: true),
                    ShiftStatus = table.Column<int>(nullable: false),
                    LostTime = table.Column<double>(nullable: false),
                    Reason1 = table.Column<string>(nullable: true),
                    Reason2 = table.Column<string>(nullable: true),
                    Reason3 = table.Column<string>(nullable: true),
                    Reason4 = table.Column<string>(nullable: true),
                    Reason5 = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedBy = table.Column<string>(nullable: true),
                    LWHeaderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LossWasteFaults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LossWasteFaults_LossWasteHeader_LWHeaderId",
                        column: x => x.LWHeaderId,
                        principalTable: "LossWasteHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medicals",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: false),
                    MedicalDate = table.Column<DateTime>(nullable: false),
                    MedicalDue = table.Column<DateTime>(nullable: false),
                    DaysLeft = table.Column<int>(nullable: false),
                    MedicalDataId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicals_MedicalData_MedicalDataId",
                        column: x => x.MedicalDataId,
                        principalTable: "MedicalData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OccupationalControls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Control = table.Column<string>(nullable: true),
                    ResponsiblePerson = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: false),
                    OccupationalHeaderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccupationalControls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OccupationalControls_OccupationalHeader_OccupationalHeaderId",
                        column: x => x.OccupationalHeaderId,
                        principalTable: "OccupationalHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OccupationalRequirements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequirementType = table.Column<string>(nullable: true),
                    Requirement = table.Column<string>(nullable: true),
                    OccupationalHeaderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccupationalRequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OccupationalRequirements_OccupationalHeader_OccupationalHeaderId",
                        column: x => x.OccupationalHeaderId,
                        principalTable: "OccupationalHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PreTaskRAEquipment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormId = table.Column<string>(nullable: true, computedColumnSql: "+ 'PRA' + cast([PreTaskRAHeaderId] as varchar)"),
                    Headphones = table.Column<bool>(nullable: false),
                    Goggles = table.Column<bool>(nullable: false),
                    Helmet = table.Column<bool>(nullable: false),
                    SafetyShoes = table.Column<bool>(nullable: false),
                    Gloves = table.Column<bool>(nullable: false),
                    Respirator = table.Column<bool>(nullable: false),
                    FaceMask = table.Column<bool>(nullable: false),
                    Vest = table.Column<bool>(nullable: false),
                    FaceShield = table.Column<bool>(nullable: false),
                    Overalls = table.Column<bool>(nullable: false),
                    Harness = table.Column<bool>(nullable: false),
                    WeldingMask = table.Column<bool>(nullable: false),
                    PreTaskRAHeaderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreTaskRAEquipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreTaskRAEquipment_PreTaskRAHeader_PreTaskRAHeaderId",
                        column: x => x.PreTaskRAHeaderId,
                        principalTable: "PreTaskRAHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PreTaskRAHazards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HazardNo = table.Column<string>(nullable: true, computedColumnSql: "+ 'HN' + cast([Id] as varchar)"),
                    FormId = table.Column<string>(nullable: true, computedColumnSql: "+ 'PRA' + cast([PreTaskRAHeaderId] as varchar)"),
                    Hazard = table.Column<string>(nullable: true),
                    Control = table.Column<string>(nullable: true),
                    PreTaskRAHeaderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreTaskRAHazards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreTaskRAHazards_PreTaskRAHeader_PreTaskRAHeaderId",
                        column: x => x.PreTaskRAHeaderId,
                        principalTable: "PreTaskRAHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PreTaskRAMembers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberNo = table.Column<string>(nullable: true, computedColumnSql: "+ 'MN' + cast([Id] as varchar)"),
                    FormId = table.Column<string>(nullable: true, computedColumnSql: "+ 'PRA' + cast([PreTaskRAHeaderId] as varchar)"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Competence = table.Column<bool>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    PreTaskRAHeaderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreTaskRAMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreTaskRAMembers_PreTaskRAHeader_PreTaskRAHeaderId",
                        column: x => x.PreTaskRAHeaderId,
                        principalTable: "PreTaskRAHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PreTaskRAPermisions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionNo = table.Column<string>(nullable: true, computedColumnSql: "+ 'PN' + cast([Id] as varchar)"),
                    FormId = table.Column<string>(nullable: true, computedColumnSql: "+ 'PRA' + cast([PreTaskRAHeaderId] as varchar)"),
                    HotWork = table.Column<bool>(nullable: false),
                    WorkAtHeight = table.Column<bool>(nullable: false),
                    ScaffoldingWork = table.Column<bool>(nullable: false),
                    RoofWork = table.Column<bool>(nullable: false),
                    LockOutTag = table.Column<bool>(nullable: false),
                    PreTaskRAHeaderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreTaskRAPermisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreTaskRAPermisions_PreTaskRAHeader_PreTaskRAHeaderId",
                        column: x => x.PreTaskRAHeaderId,
                        principalTable: "PreTaskRAHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QualityFParameters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Time = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Temp = table.Column<decimal>(nullable: false),
                    pH = table.Column<decimal>(nullable: false),
                    Ref = table.Column<decimal>(nullable: false),
                    Viscosity = table.Column<decimal>(nullable: false),
                    Brix = table.Column<decimal>(nullable: false),
                    SG = table.Column<decimal>(nullable: false),
                    OE = table.Column<decimal>(nullable: false),
                    Alcohol = table.Column<decimal>(nullable: false),
                    TotalAcid = table.Column<decimal>(nullable: false),
                    RDF = table.Column<decimal>(nullable: false),
                    Analyst = table.Column<string>(nullable: true),
                    FIdId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityFParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QualityFParameters_QualityFermentation_FIdId",
                        column: x => x.FIdId,
                        principalTable: "QualityFermentation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QualityPIPBrew",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrewNumber = table.Column<int>(nullable: false),
                    PIPId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityPIPBrew", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QualityPIPBrew_QualityPIP_PIPId",
                        column: x => x.PIPId,
                        principalTable: "QualityPIP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QualityPIPMaterial",
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
                    table.PrimaryKey("PK_QualityPIPMaterial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QualityPIPMaterial_QualityPIP_PIPId",
                        column: x => x.PIPId,
                        principalTable: "QualityPIP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QualitySLParameters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<int>(nullable: false),
                    TotalAcids = table.Column<decimal>(nullable: false),
                    AlcoholContent = table.Column<decimal>(nullable: false),
                    CO2Content = table.Column<decimal>(nullable: false),
                    Analyst = table.Column<string>(nullable: true),
                    SLId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualitySLParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QualitySLParameters_QualityShelflife_SLId",
                        column: x => x.SLId,
                        principalTable: "QualityShelflife",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SwmsTeam",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    SafeWorkMethodId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SwmsTeam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SwmsTeam_SafeWorkMethod_SafeWorkMethodId",
                        column: x => x.SafeWorkMethodId,
                        principalTable: "SafeWorkMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TasksInvolved",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Task = table.Column<string>(nullable: true),
                    WorkMethod = table.Column<string>(nullable: false),
                    Responsibility = table.Column<string>(nullable: false),
                    SafeWorkMethodId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasksInvolved", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TasksInvolved_SafeWorkMethod_SafeWorkMethodId",
                        column: x => x.SafeWorkMethodId,
                        principalTable: "SafeWorkMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SHETargetItems",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Target = table.Column<string>(nullable: true),
                    SHETargetsHeaderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHETargetItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SHETargetItems_SHETargetsHeader_SHETargetsHeaderId",
                        column: x => x.SHETargetsHeaderId,
                        principalTable: "SHETargetsHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShiftAttendence",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftNo = table.Column<string>(nullable: true, computedColumnSql: "+ 'SH' + cast([shiftHeaderId] as varchar)"),
                    OperatorId = table.Column<string>(nullable: true),
                    Attendence = table.Column<string>(nullable: true),
                    ShiftDate = table.Column<DateTime>(nullable: false),
                    TimeIn = table.Column<string>(nullable: true),
                    shiftHeaderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftAttendence", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftAttendence_ShiftHeader_shiftHeaderId",
                        column: x => x.shiftHeaderId,
                        principalTable: "ShiftHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShiftMeetingActionItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingID = table.Column<string>(nullable: true, computedColumnSql: "+ 'MT' + cast([shiftHeaderId] as varchar)"),
                    ShiftNo = table.Column<string>(nullable: true, computedColumnSql: "+ 'SH' + cast([shiftHeaderId] as varchar)"),
                    ShiftName = table.Column<string>(nullable: true),
                    TaskNo = table.Column<string>(nullable: true, computedColumnSql: "+ 'TAS' + cast([Id] as varchar)"),
                    Task = table.Column<string>(nullable: true),
                    AssignedTo = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    ExpectedTime = table.Column<DateTime>(nullable: false),
                    shiftHeaderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftMeetingActionItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftMeetingActionItems_ShiftHeader_shiftHeaderId",
                        column: x => x.shiftHeaderId,
                        principalTable: "ShiftHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SRAControls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Control = table.Column<string>(nullable: true),
                    Measure = table.Column<string>(nullable: true),
                    SRAHeaderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SRAControls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SRAControls_SRAHeader_SRAHeaderId",
                        column: x => x.SRAHeaderId,
                        principalTable: "SRAHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SRARequirements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequirementType = table.Column<string>(nullable: true),
                    Requirement = table.Column<string>(nullable: true),
                    SRAHeaderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SRARequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SRARequirements_SRAHeader_SRAHeaderId",
                        column: x => x.SRAHeaderId,
                        principalTable: "SRAHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SDParameters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    ParameterName = table.Column<string>(nullable: false),
                    ParameterValue = table.Column<string>(nullable: false),
                    ParameterLocation = table.Column<string>(nullable: false),
                    SustainableDevelopmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SDParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SDParameters_SustainableDevelopment_SustainableDevelopmentId",
                        column: x => x.SustainableDevelopmentId,
                        principalTable: "SustainableDevelopment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    TrainingName = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: false),
                    DateTrained = table.Column<DateTime>(nullable: false),
                    RetrainingDue = table.Column<DateTime>(nullable: false),
                    RetrainingDaysLeft = table.Column<int>(nullable: false),
                    TrainingMatrixId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainings_TrainingMatrix_TrainingMatrixId",
                        column: x => x.TrainingMatrixId,
                        principalTable: "TrainingMatrix",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    UserRolesId = table.Column<string>(nullable: true),
                    UserRoleId = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId_UserName",
                        columns: x => new { x.UserId, x.UserName },
                        principalTable: "Users",
                        principalColumns: new[] { "Id", "UserName" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Effluent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UIdId = table.Column<int>(nullable: true),
                    pH = table.Column<decimal>(nullable: false),
                    TSS = table.Column<decimal>(nullable: false),
                    PV = table.Column<decimal>(nullable: false),
                    COD = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Effluent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Effluent_Utilities_UIdId",
                        column: x => x.UIdId,
                        principalTable: "Utilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QualityUtilitiesBoiler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UIdId = table.Column<int>(nullable: true),
                    Hardness = table.Column<decimal>(nullable: false),
                    sulphites = table.Column<decimal>(nullable: false),
                    PAlk = table.Column<decimal>(nullable: false),
                    OHAlk = table.Column<decimal>(nullable: false),
                    MAlk = table.Column<decimal>(nullable: false),
                    Chlorides = table.Column<decimal>(nullable: false),
                    TDS = table.Column<decimal>(nullable: false),
                    Conductivity = table.Column<decimal>(nullable: false),
                    pH = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityUtilitiesBoiler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QualityUtilitiesBoiler_Utilities_UIdId",
                        column: x => x.UIdId,
                        principalTable: "Utilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QualityUtilitiesCondenser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UIdId = table.Column<int>(nullable: true),
                    TDS = table.Column<decimal>(nullable: false),
                    pH = table.Column<decimal>(nullable: false),
                    Alc = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityUtilitiesCondenser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QualityUtilitiesCondenser_Utilities_UIdId",
                        column: x => x.UIdId,
                        principalTable: "Utilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QualityUtilitiesCTMPV",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UIdId = table.Column<int>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    TDS = table.Column<decimal>(nullable: false),
                    pH = table.Column<decimal>(nullable: false),
                    Alc = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityUtilitiesCTMPV", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QualityUtilitiesCTMPV_Utilities_UIdId",
                        column: x => x.UIdId,
                        principalTable: "Utilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QualityUtilitiesRefridgeration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UIdId = table.Column<int>(nullable: true),
                    GlycolStrength = table.Column<decimal>(nullable: false),
                    FreezingPoint = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityUtilitiesRefridgeration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QualityUtilitiesRefridgeration_Utilities_UIdId",
                        column: x => x.UIdId,
                        principalTable: "Utilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QualityUtilitiesSoftner",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UIdId = table.Column<int>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Hardness = table.Column<decimal>(nullable: false),
                    TDS = table.Column<decimal>(nullable: false),
                    pH = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityUtilitiesSoftner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QualityUtilitiesSoftner_Utilities_UIdId",
                        column: x => x.UIdId,
                        principalTable: "Utilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QualityUtilitiesWT",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UIdId = table.Column<int>(nullable: true),
                    Chlorides = table.Column<decimal>(nullable: false),
                    TreatedWaterHaze = table.Column<decimal>(nullable: false),
                    TaintNetting = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityUtilitiesWT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QualityUtilitiesWT_Utilities_UIdId",
                        column: x => x.UIdId,
                        principalTable: "Utilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LossWasteJobCard",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobCardNo = table.Column<string>(nullable: true, computedColumnSql: "+ 'JN' + cast([Id] as varchar)"),
                    WONumber = table.Column<string>(nullable: true),
                    AssignedTo = table.Column<string>(nullable: true),
                    TargetCompTime = table.Column<DateTime>(nullable: false),
                    FaultId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    FaultNo = table.Column<string>(nullable: true, computedColumnSql: "+ 'FN' + cast([FaultId] as varchar)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LossWasteJobCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LossWasteJobCard_LossWasteFaults_FaultId",
                        column: x => x.FaultId,
                        principalTable: "LossWasteFaults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AffectedBodyPart_IncidentLoggingId",
                table: "AffectedBodyPart",
                column: "IncidentLoggingId");

            migrationBuilder.CreateIndex(
                name: "IX_BrewingProcesses_BCId",
                table: "BrewingProcesses",
                column: "BCId");

            migrationBuilder.CreateIndex(
                name: "IX_BrewingStdChecks_IPCId",
                table: "BrewingStdChecks",
                column: "IPCId");

            migrationBuilder.CreateIndex(
                name: "IX_BrewingStoppages_BCId",
                table: "BrewingStoppages",
                column: "BCId");

            migrationBuilder.CreateIndex(
                name: "IX_Effluent_UIdId",
                table: "Effluent",
                column: "UIdId");

            migrationBuilder.CreateIndex(
                name: "IX_EnvironmentalImpactControls_EnvironmentalImpactRAHeaderId",
                table: "EnvironmentalImpactControls",
                column: "EnvironmentalImpactRAHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_EnvironmentalImpactRequirements_EnvironmentalImpactRAHeaderId",
                table: "EnvironmentalImpactRequirements",
                column: "EnvironmentalImpactRAHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_FRAControls_FRAHeaderId",
                table: "FRAControls",
                column: "FRAHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_FRAEquipments_FRAHeaderId",
                table: "FRAEquipments",
                column: "FRAHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_FRARequirements_FRAHeaderId",
                table: "FRARequirements",
                column: "FRAHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_HRAAffectedPersons_HRAHeaderId",
                table: "HRAAffectedPersons",
                column: "HRAHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_HRAAssociatedRisk_HRAHeaderId",
                table: "HRAAssociatedRisk",
                column: "HRAHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_HRAClassification_HRAHeaderId",
                table: "HRAClassification",
                column: "HRAHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_HRAControls_HRAHeaderId",
                table: "HRAControls",
                column: "HRAHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_HRAEmergencyAction_HRAHeaderId",
                table: "HRAEmergencyAction",
                column: "HRAHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_HRAExposureRoute_HRAHeaderId",
                table: "HRAExposureRoute",
                column: "HRAHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_HRAHandlingControls_HRAHeaderId",
                table: "HRAHandlingControls",
                column: "HRAHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_HRAImprovementSuggestion_HRAHeaderId",
                table: "HRAImprovementSuggestion",
                column: "HRAHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_HRARequirements_HRAHeaderId",
                table: "HRARequirements",
                column: "HRAHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_HRASubstancesProduced_HRAHeaderId",
                table: "HRASubstancesProduced",
                column: "HRAHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentDocuments_IncidentLoggingId",
                table: "IncidentDocuments",
                column: "IncidentLoggingId");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentNatureOfIllness_IncidentLoggingId",
                table: "IncidentNatureOfIllness",
                column: "IncidentLoggingId");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentWitnesses_IncidentLoggingId",
                table: "IncidentWitnesses",
                column: "IncidentLoggingId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueBasedRAAuthorisations_IssueBasedRAHeaderId",
                table: "IssueBasedRAAuthorisations",
                column: "IssueBasedRAHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueBasedRAItems_IssueBasedRAHeaderId",
                table: "IssueBasedRAItems",
                column: "IssueBasedRAHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueBasedRAMembers_IssueBasedRAHeaderId",
                table: "IssueBasedRAMembers",
                column: "IssueBasedRAHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTitle_InductionRequestId",
                table: "JobTitle",
                column: "InductionRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalOtherRequirements_LegalOtherHeaderId",
                table: "LegalOtherRequirements",
                column: "LegalOtherHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_LossWasteFaults_LWHeaderId",
                table: "LossWasteFaults",
                column: "LWHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_LossWasteJobCard_FaultId",
                table: "LossWasteJobCard",
                column: "FaultId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medicals_MedicalDataId",
                table: "Medicals",
                column: "MedicalDataId");

            migrationBuilder.CreateIndex(
                name: "IX_MillEnd_EMId",
                table: "MillEnd",
                column: "EMId");

            migrationBuilder.CreateIndex(
                name: "IX_MillStart_SMId",
                table: "MillStart",
                column: "SMId");

            migrationBuilder.CreateIndex(
                name: "IX_OccupationalControls_OccupationalHeaderId",
                table: "OccupationalControls",
                column: "OccupationalHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_OccupationalRequirements_OccupationalHeaderId",
                table: "OccupationalRequirements",
                column: "OccupationalHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_PreTaskRAEquipment_PreTaskRAHeaderId",
                table: "PreTaskRAEquipment",
                column: "PreTaskRAHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_PreTaskRAHazards_PreTaskRAHeaderId",
                table: "PreTaskRAHazards",
                column: "PreTaskRAHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_PreTaskRAMembers_PreTaskRAHeaderId",
                table: "PreTaskRAMembers",
                column: "PreTaskRAHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_PreTaskRAPermisions_PreTaskRAHeaderId",
                table: "PreTaskRAPermisions",
                column: "PreTaskRAHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityFParameters_FIdId",
                table: "QualityFParameters",
                column: "FIdId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityPIPBrew_PIPId",
                table: "QualityPIPBrew",
                column: "PIPId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityPIPMaterial_PIPId",
                table: "QualityPIPMaterial",
                column: "PIPId");

            migrationBuilder.CreateIndex(
                name: "IX_QualitySLParameters_SLId",
                table: "QualitySLParameters",
                column: "SLId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityUtilitiesBoiler_UIdId",
                table: "QualityUtilitiesBoiler",
                column: "UIdId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityUtilitiesCondenser_UIdId",
                table: "QualityUtilitiesCondenser",
                column: "UIdId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityUtilitiesCTMPV_UIdId",
                table: "QualityUtilitiesCTMPV",
                column: "UIdId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityUtilitiesRefridgeration_UIdId",
                table: "QualityUtilitiesRefridgeration",
                column: "UIdId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityUtilitiesSoftner_UIdId",
                table: "QualityUtilitiesSoftner",
                column: "UIdId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityUtilitiesWT_UIdId",
                table: "QualityUtilitiesWT",
                column: "UIdId");

            migrationBuilder.CreateIndex(
                name: "IX_SDParameters_SustainableDevelopmentId",
                table: "SDParameters",
                column: "SustainableDevelopmentId");

            migrationBuilder.CreateIndex(
                name: "IX_SHETargetItems_SHETargetsHeaderId",
                table: "SHETargetItems",
                column: "SHETargetsHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftAttendence_shiftHeaderId",
                table: "ShiftAttendence",
                column: "shiftHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftMeetingActionItems_shiftHeaderId",
                table: "ShiftMeetingActionItems",
                column: "shiftHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_SRAControls_SRAHeaderId",
                table: "SRAControls",
                column: "SRAHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_SRARequirements_SRAHeaderId",
                table: "SRARequirements",
                column: "SRAHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_BrewId",
                table: "Stocks",
                column: "BrewId");

            migrationBuilder.CreateIndex(
                name: "IX_SwmsTeam_SafeWorkMethodId",
                table: "SwmsTeam",
                column: "SafeWorkMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_TasksInvolved_SafeWorkMethodId",
                table: "TasksInvolved",
                column: "SafeWorkMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_TrainingMatrixId",
                table: "Trainings",
                column: "TrainingMatrixId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId_UserName",
                table: "UserRoles",
                columns: new[] { "UserId", "UserName" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AffectedBodyPart");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "AuditRecords");

            migrationBuilder.DropTable(
                name: "BrewingConversionPE");

            migrationBuilder.DropTable(
                name: "BrewingConversions");

            migrationBuilder.DropTable(
                name: "BrewingCooking");

            migrationBuilder.DropTable(
                name: "BrewingCookingPE");

            migrationBuilder.DropTable(
                name: "BrewingFermentation");

            migrationBuilder.DropTable(
                name: "BrewingFermentationPE");

            migrationBuilder.DropTable(
                name: "BrewingHeaderTank");

            migrationBuilder.DropTable(
                name: "BrewingHeaderTankPE");

            migrationBuilder.DropTable(
                name: "BrewingInspections");

            migrationBuilder.DropTable(
                name: "BrewingMaltAddition");

            migrationBuilder.DropTable(
                name: "BrewingProcesses");

            migrationBuilder.DropTable(
                name: "BrewingStdChecks");

            migrationBuilder.DropTable(
                name: "BrewingStoppages");

            migrationBuilder.DropTable(
                name: "BrewingStrain");

            migrationBuilder.DropTable(
                name: "BrewingSuperBBT");

            migrationBuilder.DropTable(
                name: "BrewingVibro");

            migrationBuilder.DropTable(
                name: "BrewingVibroPE");

            migrationBuilder.DropTable(
                name: "BrewingWortCooling");

            migrationBuilder.DropTable(
                name: "BrewingWortCoolingPE");

            migrationBuilder.DropTable(
                name: "BrewingYeastHandling");

            migrationBuilder.DropTable(
                name: "ChangeRequest");

            migrationBuilder.DropTable(
                name: "ChemicalCompatibility");

            migrationBuilder.DropTable(
                name: "CMArtisanInput");

            migrationBuilder.DropTable(
                name: "CMPlannerInput");

            migrationBuilder.DropTable(
                name: "CommunicationPlan");

            migrationBuilder.DropTable(
                name: "ConfinedSpaces");

            migrationBuilder.DropTable(
                name: "DIArtisanInput");

            migrationBuilder.DropTable(
                name: "DIPlannerInput");

            migrationBuilder.DropTable(
                name: "Effluent");

            migrationBuilder.DropTable(
                name: "EnvironmentalImpactControls");

            migrationBuilder.DropTable(
                name: "EnvironmentalImpactRequirements");

            migrationBuilder.DropTable(
                name: "FRAControls");

            migrationBuilder.DropTable(
                name: "FRAEquipments");

            migrationBuilder.DropTable(
                name: "FRARequirements");

            migrationBuilder.DropTable(
                name: "HeightWork");

            migrationBuilder.DropTable(
                name: "HighRiskTaskObservationRecords");

            migrationBuilder.DropTable(
                name: "HRAAffectedPersons");

            migrationBuilder.DropTable(
                name: "HRAAssociatedRisk");

            migrationBuilder.DropTable(
                name: "HRAClassification");

            migrationBuilder.DropTable(
                name: "HRAControls");

            migrationBuilder.DropTable(
                name: "HRAEmergencyAction");

            migrationBuilder.DropTable(
                name: "HRAExposureRoute");

            migrationBuilder.DropTable(
                name: "HRAHandlingControls");

            migrationBuilder.DropTable(
                name: "HRAImprovementSuggestion");

            migrationBuilder.DropTable(
                name: "HRARequirements");

            migrationBuilder.DropTable(
                name: "HRASubstancesProduced");

            migrationBuilder.DropTable(
                name: "HRATeams");

            migrationBuilder.DropTable(
                name: "HzSubstancesInventory");

            migrationBuilder.DropTable(
                name: "IncidentDocuments");

            migrationBuilder.DropTable(
                name: "IncidentNatureOfIllness");

            migrationBuilder.DropTable(
                name: "IncidentWitnesses");

            migrationBuilder.DropTable(
                name: "InductionInventory");

            migrationBuilder.DropTable(
                name: "InductionInventoryContractors");

            migrationBuilder.DropTable(
                name: "Inspections");

            migrationBuilder.DropTable(
                name: "IssueBasedRAAuthorisations");

            migrationBuilder.DropTable(
                name: "IssueBasedRAItems");

            migrationBuilder.DropTable(
                name: "IssueBasedRAMembers");

            migrationBuilder.DropTable(
                name: "JobTitle");

            migrationBuilder.DropTable(
                name: "LegalOtherRequirements");

            migrationBuilder.DropTable(
                name: "Lines");

            migrationBuilder.DropTable(
                name: "LossWasteJobCard");

            migrationBuilder.DropTable(
                name: "Medicals");

            migrationBuilder.DropTable(
                name: "MillEnd");

            migrationBuilder.DropTable(
                name: "MillStart");

            migrationBuilder.DropTable(
                name: "MonitoringPlan");

            migrationBuilder.DropTable(
                name: "OccupationalControls");

            migrationBuilder.DropTable(
                name: "OccupationalRequirements");

            migrationBuilder.DropTable(
                name: "Operators");

            migrationBuilder.DropTable(
                name: "PermitsAndLicenses");

            migrationBuilder.DropTable(
                name: "PIMsPOMs");

            migrationBuilder.DropTable(
                name: "PIMsPOMsBlowMoulder");

            migrationBuilder.DropTable(
                name: "PIMsPOMsCompressor");

            migrationBuilder.DropTable(
                name: "PIMsPOMsFiller");

            migrationBuilder.DropTable(
                name: "PIMsPOMShrinkPacker");

            migrationBuilder.DropTable(
                name: "PIMsPOMsPasteurizer");

            migrationBuilder.DropTable(
                name: "PIMsPOMsRobobox");

            migrationBuilder.DropTable(
                name: "PlantData");

            migrationBuilder.DropTable(
                name: "PreTaskRAEquipment");

            migrationBuilder.DropTable(
                name: "PreTaskRAHazards");

            migrationBuilder.DropTable(
                name: "PreTaskRAMembers");

            migrationBuilder.DropTable(
                name: "PreTaskRAPermisions");

            migrationBuilder.DropTable(
                name: "ProductionTimes");

            migrationBuilder.DropTable(
                name: "QualityCIPTracker");

            migrationBuilder.DropTable(
                name: "QualityCustomerComplaint");

            migrationBuilder.DropTable(
                name: "QualityFParameters");

            migrationBuilder.DropTable(
                name: "QualityMarketDispatched");

            migrationBuilder.DropTable(
                name: "QualityParams");

            migrationBuilder.DropTable(
                name: "QualityPIPBrew");

            migrationBuilder.DropTable(
                name: "QualityPIPMaterial");

            migrationBuilder.DropTable(
                name: "QualityRICarbonDioxide");

            migrationBuilder.DropTable(
                name: "QualityRIClosure");

            migrationBuilder.DropTable(
                name: "QualityRIGlue");

            migrationBuilder.DropTable(
                name: "QualityRILabel");

            migrationBuilder.DropTable(
                name: "QualityRILacticAcid");

            migrationBuilder.DropTable(
                name: "QualityRIMaize");

            migrationBuilder.DropTable(
                name: "QualityRIMalt");

            migrationBuilder.DropTable(
                name: "QualityRIPreform");

            migrationBuilder.DropTable(
                name: "QualityRIShrinkfilm");

            migrationBuilder.DropTable(
                name: "QualityRIStretchfilm");

            migrationBuilder.DropTable(
                name: "QualityRIYeast");

            migrationBuilder.DropTable(
                name: "QualitySLParameters");

            migrationBuilder.DropTable(
                name: "QualityUtilitiesBoiler");

            migrationBuilder.DropTable(
                name: "QualityUtilitiesCondenser");

            migrationBuilder.DropTable(
                name: "QualityUtilitiesCTMPV");

            migrationBuilder.DropTable(
                name: "QualityUtilitiesRefridgeration");

            migrationBuilder.DropTable(
                name: "QualityUtilitiesSoftner");

            migrationBuilder.DropTable(
                name: "QualityUtilitiesWT");

            migrationBuilder.DropTable(
                name: "QualityVUsage");

            migrationBuilder.DropTable(
                name: "QualityWort");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "SDParameters");

            migrationBuilder.DropTable(
                name: "SHERegistry");

            migrationBuilder.DropTable(
                name: "SHETargetItems");

            migrationBuilder.DropTable(
                name: "ShiftAttendence");

            migrationBuilder.DropTable(
                name: "ShiftEnd");

            migrationBuilder.DropTable(
                name: "ShiftMaster");

            migrationBuilder.DropTable(
                name: "ShiftMeetingActionItems");

            migrationBuilder.DropTable(
                name: "ShiftStatus");

            migrationBuilder.DropTable(
                name: "SRAControls");

            migrationBuilder.DropTable(
                name: "SRARequirements");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Suggestions");

            migrationBuilder.DropTable(
                name: "SupplierEvaluation");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "SwmsTeam");

            migrationBuilder.DropTable(
                name: "SystemDocumentation");

            migrationBuilder.DropTable(
                name: "TasksInvolved");

            migrationBuilder.DropTable(
                name: "TeamLeaders");

            migrationBuilder.DropTable(
                name: "TrainingPlan");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "UserGroups");

            migrationBuilder.DropTable(
                name: "UserRoleMaster");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserType");

            migrationBuilder.DropTable(
                name: "WasteManagement");

            migrationBuilder.DropTable(
                name: "WasteTracking");

            migrationBuilder.DropTable(
                name: "BrewingIPC");

            migrationBuilder.DropTable(
                name: "BrewingCycles");

            migrationBuilder.DropTable(
                name: "EnvironmentalImpactRAHeader");

            migrationBuilder.DropTable(
                name: "FRAHeader");

            migrationBuilder.DropTable(
                name: "HRAHeader");

            migrationBuilder.DropTable(
                name: "IncidentLogging");

            migrationBuilder.DropTable(
                name: "IssueBasedRAHeader");

            migrationBuilder.DropTable(
                name: "InductionRequest");

            migrationBuilder.DropTable(
                name: "LegalOtherHeader");

            migrationBuilder.DropTable(
                name: "LossWasteFaults");

            migrationBuilder.DropTable(
                name: "MedicalData");

            migrationBuilder.DropTable(
                name: "BrewingEndMilling");

            migrationBuilder.DropTable(
                name: "BrewingStartMilling");

            migrationBuilder.DropTable(
                name: "OccupationalHeader");

            migrationBuilder.DropTable(
                name: "PreTaskRAHeader");

            migrationBuilder.DropTable(
                name: "QualityFermentation");

            migrationBuilder.DropTable(
                name: "QualityPIP");

            migrationBuilder.DropTable(
                name: "QualityShelflife");

            migrationBuilder.DropTable(
                name: "Utilities");

            migrationBuilder.DropTable(
                name: "SustainableDevelopment");

            migrationBuilder.DropTable(
                name: "SHETargetsHeader");

            migrationBuilder.DropTable(
                name: "ShiftHeader");

            migrationBuilder.DropTable(
                name: "SRAHeader");

            migrationBuilder.DropTable(
                name: "BrewingBrews");

            migrationBuilder.DropTable(
                name: "SafeWorkMethod");

            migrationBuilder.DropTable(
                name: "TrainingMatrix");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "LossWasteHeader");
        }
    }
}
