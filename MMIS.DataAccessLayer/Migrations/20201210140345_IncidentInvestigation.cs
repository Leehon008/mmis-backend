using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class IncidentInvestigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IncidentInvestigation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Treatment = table.Column<string>(nullable: true),
                    TreatmentOther = table.Column<string>(nullable: true),
                    IncidentOccurrence = table.Column<string>(nullable: true),
                    IncidentPeriodPrior = table.Column<string>(nullable: true),
                    IncidentOccurrencePeriod = table.Column<string>(nullable: true),
                    Recordable = table.Column<string>(nullable: true),
                    KpiReportable = table.Column<string>(nullable: true),
                    TaskBeingDoneAction = table.Column<string>(nullable: true),
                    TaskBeingDoneObject = table.Column<string>(nullable: true),
                    TaskFrequency = table.Column<string>(nullable: true),
                    HighRisk = table.Column<string>(nullable: true),
                    WrittenProcedure = table.Column<string>(nullable: true),
                    ProcedureIdentification = table.Column<string>(nullable: true),
                    PersonTrained = table.Column<string>(nullable: true),
                    TaskDoneBefore = table.Column<string>(nullable: true),
                    SimilarSituations = table.Column<string>(nullable: true),
                    OtherPertinentInformation = table.Column<string>(nullable: true),
                    WorkPermits = table.Column<string>(nullable: true),
                    EorrectTools = table.Column<string>(nullable: true),
                    EquipmentInvolved = table.Column<string>(nullable: true),
                    EquipmentMaintenance = table.Column<string>(nullable: true),
                    StartUpPhase = table.Column<string>(nullable: true),
                    WhyWorkContinued = table.Column<string>(nullable: true),
                    Indication = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentInvestigation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncidentInvestigationDoneDifferent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Step = table.Column<string>(nullable: true),
                    Reason = table.Column<string>(nullable: true),
                    IncidentInvestigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentInvestigationDoneDifferent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncidentInvestigationDoneDifferent_IncidentInvestigation_IncidentInvestigationId",
                        column: x => x.IncidentInvestigationId,
                        principalTable: "IncidentInvestigation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IncidentInvestigationPPEList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Ppe = table.Column<string>(nullable: true),
                    IncidentInvestigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentInvestigationPPEList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncidentInvestigationPPEList_IncidentInvestigation_IncidentInvestigationId",
                        column: x => x.IncidentInvestigationId,
                        principalTable: "IncidentInvestigation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IncidentInvestigationSteps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    IncidentInvestigationId = table.Column<int>(nullable: true),
                    StepDate = table.Column<DateTime>(nullable: false),
                    StepDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentInvestigationSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncidentInvestigationSteps_IncidentInvestigation_IncidentInvestigationId",
                        column: x => x.IncidentInvestigationId,
                        principalTable: "IncidentInvestigation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IncidentInvestigationToolCondition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Tool = table.Column<string>(nullable: true),
                    Condition = table.Column<string>(nullable: true),
                    IncidentInvestigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentInvestigationToolCondition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncidentInvestigationToolCondition_IncidentInvestigation_IncidentInvestigationId",
                        column: x => x.IncidentInvestigationId,
                        principalTable: "IncidentInvestigation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IncidentInvestigationDoneDifferent_IncidentInvestigationId",
                table: "IncidentInvestigationDoneDifferent",
                column: "IncidentInvestigationId");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentInvestigationPPEList_IncidentInvestigationId",
                table: "IncidentInvestigationPPEList",
                column: "IncidentInvestigationId");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentInvestigationSteps_IncidentInvestigationId",
                table: "IncidentInvestigationSteps",
                column: "IncidentInvestigationId");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentInvestigationToolCondition_IncidentInvestigationId",
                table: "IncidentInvestigationToolCondition",
                column: "IncidentInvestigationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncidentInvestigationDoneDifferent");

            migrationBuilder.DropTable(
                name: "IncidentInvestigationPPEList");

            migrationBuilder.DropTable(
                name: "IncidentInvestigationSteps");

            migrationBuilder.DropTable(
                name: "IncidentInvestigationToolCondition");

            migrationBuilder.DropTable(
                name: "IncidentInvestigation");
        }
    }
}
