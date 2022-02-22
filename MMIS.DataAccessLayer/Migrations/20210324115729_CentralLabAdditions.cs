using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class CentralLabAdditions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RegulatoryAgencyInvolved",
                table: "IncidentLogging",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "RegulatoryAgency",
                table: "IncidentLogging",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MediaInvolvement",
                table: "IncidentLogging",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ManagerDescription",
                table: "IncidentLogging",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LocalAuthorities",
                table: "IncidentLogging",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "InjuryWhileCommuting",
                table: "IncidentLogging",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "InjuryOnCompanyBusiness",
                table: "IncidentLogging",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "IncidentCause",
                table: "IncidentLogging",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "QualityCLCIP",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Analyst = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    plant = table.Column<string>(nullable: true),
                    PCA = table.Column<decimal>(nullable: false),
                    NBB = table.Column<decimal>(nullable: false),
                    WA = table.Column<decimal>(nullable: false),
                    WLN = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityCLCIP", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityCLEA",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Analyst = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    plant = table.Column<string>(nullable: true),
                    COD = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityCLEA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityCLFOC",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Analyst = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Reference = table.Column<string>(nullable: true),
                    NatureOfComplaint = table.Column<string>(nullable: true),
                    Result = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityCLFOC", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityCLMDD",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Analyst = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    AflatoxinB1 = table.Column<decimal>(nullable: false),
                    AflatoxinB2 = table.Column<decimal>(nullable: false),
                    AflatoxinG1 = table.Column<decimal>(nullable: false),
                    AflatoxinG2 = table.Column<decimal>(nullable: false),
                    TotalAflatoxin = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityCLMDD", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityCLMicros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Analyst = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    plant = table.Column<string>(nullable: true),
                    PCA = table.Column<decimal>(nullable: false),
                    NBB = table.Column<decimal>(nullable: false),
                    WA = table.Column<decimal>(nullable: false),
                    WLN = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityCLMicros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityCLSMDD",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Analyst = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    AflatoxinB1 = table.Column<decimal>(nullable: false),
                    AflatoxinB2 = table.Column<decimal>(nullable: false),
                    AflatoxinG1 = table.Column<decimal>(nullable: false),
                    AflatoxinG2 = table.Column<decimal>(nullable: false),
                    TotalAflatoxin = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityCLSMDD", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityCLUtilities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Analyst = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    plant = table.Column<string>(nullable: true),
                    LYSINE = table.Column<decimal>(nullable: false),
                    NBB = table.Column<decimal>(nullable: false),
                    WA = table.Column<decimal>(nullable: false),
                    WLN = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityCLUtilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityCLWater",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Analyst = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    plant = table.Column<string>(nullable: true),
                    PlateCount = table.Column<decimal>(nullable: false),
                    Coliforms = table.Column<decimal>(nullable: false),
                    EColi = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityCLWater", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityCLWDD",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Analyst = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    PCA = table.Column<decimal>(nullable: false),
                    Coliforms = table.Column<decimal>(nullable: false),
                    EColi = table.Column<decimal>(nullable: false),
                    STyphi = table.Column<decimal>(nullable: false),
                    VCholerae = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityCLWDD", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityErrorControlScud",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Analyst = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    PAnalyst = table.Column<string>(nullable: true),
                    PH = table.Column<decimal>(nullable: false),
                    REF = table.Column<decimal>(nullable: false),
                    Alcohol = table.Column<decimal>(nullable: false),
                    TAcids = table.Column<decimal>(nullable: false),
                    TRS = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityErrorControlScud", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityErrorControlSuper",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Analyst = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    PAnalyst = table.Column<string>(nullable: true),
                    PH = table.Column<decimal>(nullable: false),
                    REF = table.Column<decimal>(nullable: false),
                    Alcohol = table.Column<decimal>(nullable: false),
                    TAcids = table.Column<decimal>(nullable: false),
                    BRIX = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityErrorControlSuper", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QualityCLCIP");

            migrationBuilder.DropTable(
                name: "QualityCLEA");

            migrationBuilder.DropTable(
                name: "QualityCLFOC");

            migrationBuilder.DropTable(
                name: "QualityCLMDD");

            migrationBuilder.DropTable(
                name: "QualityCLMicros");

            migrationBuilder.DropTable(
                name: "QualityCLSMDD");

            migrationBuilder.DropTable(
                name: "QualityCLUtilities");

            migrationBuilder.DropTable(
                name: "QualityCLWater");

            migrationBuilder.DropTable(
                name: "QualityCLWDD");

            migrationBuilder.DropTable(
                name: "QualityErrorControlScud");

            migrationBuilder.DropTable(
                name: "QualityErrorControlSuper");

            migrationBuilder.AlterColumn<string>(
                name: "RegulatoryAgencyInvolved",
                table: "IncidentLogging",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RegulatoryAgency",
                table: "IncidentLogging",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MediaInvolvement",
                table: "IncidentLogging",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ManagerDescription",
                table: "IncidentLogging",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LocalAuthorities",
                table: "IncidentLogging",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InjuryWhileCommuting",
                table: "IncidentLogging",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InjuryOnCompanyBusiness",
                table: "IncidentLogging",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IncidentCause",
                table: "IncidentLogging",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
