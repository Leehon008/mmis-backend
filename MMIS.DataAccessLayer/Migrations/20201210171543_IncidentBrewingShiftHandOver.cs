using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class IncidentBrewingShiftHandOver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IncidentNumber",
                table: "IncidentInvestigation",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BrewerShiftHandOver",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    ShiftNo = table.Column<string>(nullable: true),
                    OutgoingShiftName = table.Column<string>(nullable: true),
                    ShiftDate = table.Column<DateTime>(nullable: false),
                    SiloInUse = table.Column<string>(nullable: true),
                    MaltBatch = table.Column<string>(nullable: true),
                    YeastBatch = table.Column<string>(nullable: true),
                    BrewNumber = table.Column<string>(nullable: true),
                    MPVs = table.Column<string>(nullable: true),
                    Cs = table.Column<string>(nullable: true),
                    Fs = table.Column<string>(nullable: true),
                    FermentPackagingPlan = table.Column<string>(nullable: true),
                    TankOnline = table.Column<string>(nullable: true),
                    NextOnline = table.Column<string>(nullable: true),
                    BlendingPlan = table.Column<string>(nullable: true),
                    StrainingPlan = table.Column<string>(nullable: true),
                    FaulSignalOccured = table.Column<string>(nullable: true),
                    BreakDownOccurred = table.Column<string>(nullable: true),
                    Water = table.Column<string>(nullable: true),
                    Cooling = table.Column<string>(nullable: true),
                    PowerSource = table.Column<string>(nullable: true),
                    Steam = table.Column<string>(nullable: true),
                    OutgoingBrewer = table.Column<string>(nullable: true),
                    IncomingBrewer = table.Column<string>(nullable: true),
                    IncomingShiftName = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewerShiftHandOver", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrewingPAShiftHandOver",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    ShiftNo = table.Column<string>(nullable: true),
                    SHEConcerns = table.Column<string>(nullable: true),
                    ShiftDate = table.Column<DateTime>(nullable: false),
                    UnSafeCondtions = table.Column<string>(nullable: true),
                    MeetingRoom = table.Column<string>(nullable: true),
                    Tanks = table.Column<string>(nullable: true),
                    FloorsWalls = table.Column<string>(nullable: true),
                    SiloInUse = table.Column<string>(nullable: true),
                    MaltBatch = table.Column<string>(nullable: true),
                    YeastBatch = table.Column<string>(nullable: true),
                    MPVs = table.Column<string>(nullable: true),
                    TransferLinesTOOBH = table.Column<string>(nullable: true),
                    TransferLinesToFerment = table.Column<string>(nullable: true),
                    BreakDownOccurred = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewingPAShiftHandOver", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnvironmentalIncident",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    IncidentNumber = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    Centre = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    DateTimeOfIncident = table.Column<string>(nullable: true),
                    DescriptionOfIncident = table.Column<string>(nullable: true),
                    EquipmentInvolved = table.Column<string>(nullable: true),
                    ImpactOnEnvironment = table.Column<string>(nullable: true),
                    ImpactOnEnvironmentOther = table.Column<string>(nullable: true),
                    IncidentClassification = table.Column<string>(nullable: true),
                    FacilityStoppage = table.Column<string>(nullable: true),
                    DurationOfShutdown = table.Column<string>(nullable: true),
                    MediaCoverage = table.Column<string>(nullable: true),
                    CrisisTeam = table.Column<string>(nullable: true),
                    CrisisTeamDetail = table.Column<string>(nullable: true),
                    AuthoritiesInvolved = table.Column<string>(nullable: true),
                    AuthoritiesInvolvedDetail = table.Column<string>(nullable: true),
                    ImmediateActions = table.Column<string>(nullable: true),
                    InvestigationStarted = table.Column<string>(nullable: true),
                    HumanBehavior = table.Column<string>(nullable: true),
                    BehaviorExplanation = table.Column<string>(nullable: true),
                    PsmRecordableIncident = table.Column<string>(nullable: true),
                    Damage = table.Column<string>(nullable: true),
                    NaturalDisaster = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnvironmentalIncident", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnvironmentalIncidentInvestigation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    IncidentNumber = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    FinalIncidentClassification = table.Column<string>(nullable: true),
                    ViolationOfLegalRequirements = table.Column<string>(nullable: true),
                    PermitExcursion = table.Column<string>(nullable: true),
                    NotificationToAuthorities = table.Column<string>(nullable: true),
                    NotificationToAuthoritiesDetail = table.Column<string>(nullable: true),
                    NotificationDateTime = table.Column<string>(nullable: true),
                    ExternalNotification = table.Column<string>(nullable: true),
                    AgencyNotification = table.Column<string>(nullable: true),
                    CaInvolvement = table.Column<string>(nullable: true),
                    ImpactOnDailyOperation = table.Column<string>(nullable: true),
                    ReleaseBeyondFacility = table.Column<string>(nullable: true),
                    ReleaseBeyondFacilityDetails = table.Column<string>(nullable: true),
                    KpiImpact = table.Column<string>(nullable: true),
                    EquipmentFailure = table.Column<string>(nullable: true),
                    MaintenanceIssue = table.Column<string>(nullable: true),
                    HazMatTeam = table.Column<string>(nullable: true),
                    HazMatLocation = table.Column<string>(nullable: true),
                    HazMatDescription = table.Column<string>(nullable: true),
                    HazmatActions = table.Column<string>(nullable: true),
                    HazMatReasons = table.Column<string>(nullable: true),
                    IncidentviolationOfVpo = table.Column<string>(nullable: true),
                    VpoIdentified = table.Column<string>(nullable: true),
                    ViolationOfVpoOther = table.Column<string>(nullable: true),
                    RootCauseFailureAnalysis = table.Column<string>(nullable: true),
                    NonComplianceClosed = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnvironmentalIncidentInvestigation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncidentCauses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    IncidentNumber = table.Column<string>(nullable: true),
                    IndividualsInvolved = table.Column<string>(nullable: true),
                    WorkEnvironment = table.Column<string>(nullable: true),
                    Equipment = table.Column<string>(nullable: true),
                    Methods = table.Column<string>(nullable: true),
                    Organization = table.Column<string>(nullable: true),
                    ImmediateCause = table.Column<string>(nullable: true),
                    VpoType = table.Column<string>(nullable: true),
                    DpoType = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentCauses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncidentCorrectiveMeasures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    IncidentNumber = table.Column<string>(nullable: true),
                    IncidentType = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    AssignedTo = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentCorrectiveMeasures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncidentDocumentDescription",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    IncidentNumber = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentDocumentDescription", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncidentVehicleInformation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    IncidentNumber = table.Column<string>(nullable: true),
                    DriverName = table.Column<string>(nullable: true),
                    LicenseNumber = table.Column<string>(nullable: true),
                    LicenseType = table.Column<string>(nullable: true),
                    LicenseTypeOther = table.Column<string>(nullable: true),
                    StateOfIssue = table.Column<string>(nullable: true),
                    DateOfExpiration = table.Column<DateTime>(nullable: false),
                    DateOfLastDefensive = table.Column<DateTime>(nullable: false),
                    CompanyVehicle = table.Column<string>(nullable: true),
                    TypeOfCar = table.Column<string>(nullable: true),
                    TypeOfCarOther = table.Column<string>(nullable: true),
                    YearOfVehicle = table.Column<string>(nullable: true),
                    SeatsAvailable = table.Column<int>(nullable: false),
                    Capacity = table.Column<string>(nullable: true),
                    LastInspection = table.Column<DateTime>(nullable: false),
                    NumberOfOccupants = table.Column<int>(nullable: false),
                    SeatBeltsUsed = table.Column<string>(nullable: true),
                    OccupantOne = table.Column<string>(nullable: true),
                    OccupantTwo = table.Column<string>(nullable: true),
                    Authorized = table.Column<string>(nullable: true),
                    Maintenance = table.Column<string>(nullable: true),
                    WithinHoursOfService = table.Column<string>(nullable: true),
                    SafeDrivingPractices = table.Column<string>(nullable: true),
                    Distracted = table.Column<string>(nullable: true),
                    RollOver = table.Column<string>(nullable: true),
                    SpeedLimit = table.Column<string>(nullable: true),
                    TravellingSpeed = table.Column<string>(nullable: true),
                    LoadWeight = table.Column<string>(nullable: true),
                    WeatherConditions = table.Column<string>(nullable: true),
                    RoadConditions = table.Column<string>(nullable: true),
                    AccidentDescription = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentVehicleInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrewingPlan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Vessel = table.Column<string>(nullable: true),
                    Plan = table.Column<string>(nullable: true),
                    BrewerShiftHandOverId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewingPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrewingPlan_BrewerShiftHandOver_BrewerShiftHandOverId",
                        column: x => x.BrewerShiftHandOverId,
                        principalTable: "BrewerShiftHandOver",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BrewingRawMatQuanties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    RawMaterial = table.Column<string>(nullable: true),
                    Open = table.Column<int>(nullable: false),
                    Received = table.Column<int>(nullable: false),
                    Transfer = table.Column<int>(nullable: false),
                    Used = table.Column<int>(nullable: false),
                    Theoretical = table.Column<int>(nullable: false),
                    ActualStock = table.Column<int>(nullable: false),
                    GainLoss = table.Column<int>(nullable: false),
                    BrewingPAShiftHandOverId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewingRawMatQuanties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrewingRawMatQuanties_BrewingPAShiftHandOver_BrewingPAShiftHandOverId",
                        column: x => x.BrewingPAShiftHandOverId,
                        principalTable: "BrewingPAShiftHandOver",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BrewingTankStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Tank = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    BrewingPAShiftHandOverId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewingTankStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrewingTankStatus_BrewingPAShiftHandOver_BrewingPAShiftHandOverId",
                        column: x => x.BrewingPAShiftHandOverId,
                        principalTable: "BrewingPAShiftHandOver",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EnvironmentalIncidentMedia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    IncidentNumber = table.Column<string>(nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    EnvironmentalIncidentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnvironmentalIncidentMedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnvironmentalIncidentMedia_EnvironmentalIncident_EnvironmentalIncidentId",
                        column: x => x.EnvironmentalIncidentId,
                        principalTable: "EnvironmentalIncident",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EnvironmentalIncidentDeviationFromVpo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    IncidentNumber = table.Column<string>(nullable: true),
                    Deviation = table.Column<string>(nullable: true),
                    EnvironmentalIncidentInvestigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnvironmentalIncidentDeviationFromVpo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnvironmentalIncidentDeviationFromVpo_EnvironmentalIncidentInvestigation_EnvironmentalIncidentInvestigationId",
                        column: x => x.EnvironmentalIncidentInvestigationId,
                        principalTable: "EnvironmentalIncidentInvestigation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IncidentImmediateCauseConditions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Condition = table.Column<string>(nullable: true),
                    IncidentCausesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentImmediateCauseConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncidentImmediateCauseConditions_IncidentCauses_IncidentCausesId",
                        column: x => x.IncidentCausesId,
                        principalTable: "IncidentCauses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IncidentRootCauseActions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    RootCause = table.Column<string>(nullable: true),
                    IncidentCausesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentRootCauseActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncidentRootCauseActions_IncidentCauses_IncidentCausesId",
                        column: x => x.IncidentCausesId,
                        principalTable: "IncidentCauses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IncidentRootCauseConditions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    RootCauseCondition = table.Column<string>(nullable: true),
                    IncidentCausesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentRootCauseConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncidentRootCauseConditions_IncidentCauses_IncidentCausesId",
                        column: x => x.IncidentCausesId,
                        principalTable: "IncidentCauses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IncidentWhys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Why = table.Column<string>(nullable: true),
                    IncidentCausesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentWhys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncidentWhys_IncidentCauses_IncidentCausesId",
                        column: x => x.IncidentCausesId,
                        principalTable: "IncidentCauses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrewingPlan_BrewerShiftHandOverId",
                table: "BrewingPlan",
                column: "BrewerShiftHandOverId");

            migrationBuilder.CreateIndex(
                name: "IX_BrewingRawMatQuanties_BrewingPAShiftHandOverId",
                table: "BrewingRawMatQuanties",
                column: "BrewingPAShiftHandOverId");

            migrationBuilder.CreateIndex(
                name: "IX_BrewingTankStatus_BrewingPAShiftHandOverId",
                table: "BrewingTankStatus",
                column: "BrewingPAShiftHandOverId");

            migrationBuilder.CreateIndex(
                name: "IX_EnvironmentalIncidentDeviationFromVpo_EnvironmentalIncidentInvestigationId",
                table: "EnvironmentalIncidentDeviationFromVpo",
                column: "EnvironmentalIncidentInvestigationId");

            migrationBuilder.CreateIndex(
                name: "IX_EnvironmentalIncidentMedia_EnvironmentalIncidentId",
                table: "EnvironmentalIncidentMedia",
                column: "EnvironmentalIncidentId");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentImmediateCauseConditions_IncidentCausesId",
                table: "IncidentImmediateCauseConditions",
                column: "IncidentCausesId");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentRootCauseActions_IncidentCausesId",
                table: "IncidentRootCauseActions",
                column: "IncidentCausesId");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentRootCauseConditions_IncidentCausesId",
                table: "IncidentRootCauseConditions",
                column: "IncidentCausesId");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentWhys_IncidentCausesId",
                table: "IncidentWhys",
                column: "IncidentCausesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrewingPlan");

            migrationBuilder.DropTable(
                name: "BrewingRawMatQuanties");

            migrationBuilder.DropTable(
                name: "BrewingTankStatus");

            migrationBuilder.DropTable(
                name: "EnvironmentalIncidentDeviationFromVpo");

            migrationBuilder.DropTable(
                name: "EnvironmentalIncidentMedia");

            migrationBuilder.DropTable(
                name: "IncidentCorrectiveMeasures");

            migrationBuilder.DropTable(
                name: "IncidentDocumentDescription");

            migrationBuilder.DropTable(
                name: "IncidentImmediateCauseConditions");

            migrationBuilder.DropTable(
                name: "IncidentRootCauseActions");

            migrationBuilder.DropTable(
                name: "IncidentRootCauseConditions");

            migrationBuilder.DropTable(
                name: "IncidentVehicleInformation");

            migrationBuilder.DropTable(
                name: "IncidentWhys");

            migrationBuilder.DropTable(
                name: "BrewerShiftHandOver");

            migrationBuilder.DropTable(
                name: "BrewingPAShiftHandOver");

            migrationBuilder.DropTable(
                name: "EnvironmentalIncidentInvestigation");

            migrationBuilder.DropTable(
                name: "EnvironmentalIncident");

            migrationBuilder.DropTable(
                name: "IncidentCauses");

            migrationBuilder.DropColumn(
                name: "IncidentNumber",
                table: "IncidentInvestigation");
        }
    }
}
