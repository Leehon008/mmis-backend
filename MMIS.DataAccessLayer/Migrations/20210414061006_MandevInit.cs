using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class MandevInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MandevAuditProtocol",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Attendant = table.Column<string>(nullable: true),
                    DocumentTitle = table.Column<string>(nullable: true),
                    DocumentNumber = table.Column<string>(nullable: true),
                    DocumentType = table.Column<string>(nullable: true),
                    IssueDate = table.Column<DateTime>(nullable: false),
                    RevisionNumber = table.Column<string>(nullable: true),
                    TotalWeight = table.Column<decimal>(nullable: false),
                    TotalRated = table.Column<decimal>(nullable: false),
                    TotalScore = table.Column<decimal>(nullable: false),
                    OverallPerformance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MandevAuditProtocol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MandevPlantRanking",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Attendant = table.Column<string>(nullable: true),
                    LTI = table.Column<decimal>(nullable: false),
                    DIFR = table.Column<decimal>(nullable: false),
                    EnvironmentalLegalNonCompliances = table.Column<decimal>(nullable: false),
                    CoalUsageRatio = table.Column<decimal>(nullable: false),
                    ElectricityUsageRatio = table.Column<decimal>(nullable: false),
                    WaterUsageRatio = table.Column<decimal>(nullable: false),
                    PQI = table.Column<decimal>(nullable: false),
                    BPI = table.Column<decimal>(nullable: false),
                    MQI = table.Column<decimal>(nullable: false),
                    TasteScoreMarket = table.Column<decimal>(nullable: false),
                    CustomerComplaints = table.Column<decimal>(nullable: false),
                    SalesVolumes = table.Column<decimal>(nullable: false),
                    AFE = table.Column<decimal>(nullable: false),
                    ME = table.Column<decimal>(nullable: false),
                    ABT = table.Column<decimal>(nullable: false),
                    Overtime = table.Column<decimal>(nullable: false),
                    HLSSoldPerVehiclePerMonth = table.Column<decimal>(nullable: false),
                    VehicleCapacityUtilisation = table.Column<decimal>(nullable: false),
                    BalanceBacks = table.Column<decimal>(nullable: false),
                    TCD = table.Column<decimal>(nullable: false),
                    TCM = table.Column<decimal>(nullable: false),
                    EBIT = table.Column<decimal>(nullable: false),
                    EBITMargin = table.Column<decimal>(nullable: false),
                    GEMScore = table.Column<decimal>(nullable: false),
                    CAPScore = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MandevPlantRanking", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Scoping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    APId = table.Column<int>(nullable: true),
                    Parameter = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(nullable: false),
                    Rating = table.Column<decimal>(nullable: false),
                    TotalScore = table.Column<decimal>(nullable: false),
                    AuditFindings = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scoping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scoping_MandevAuditProtocol_APId",
                        column: x => x.APId,
                        principalTable: "MandevAuditProtocol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Scoping_APId",
                table: "Scoping",
                column: "APId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MandevPlantRanking");

            migrationBuilder.DropTable(
                name: "Scoping");

            migrationBuilder.DropTable(
                name: "MandevAuditProtocol");
        }
    }
}
