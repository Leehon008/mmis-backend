using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class PQI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpiryDate",
                table: "QualityMQSSuper");

            migrationBuilder.DropColumn(
                name: "ExpiryDate",
                table: "QualityMQSScud");

            migrationBuilder.DropColumn(
                name: "AlcoholScore",
                table: "QualityMQSCompetitorProduct");

            migrationBuilder.DropColumn(
                name: "PresentabilityScore",
                table: "QualityMQSCompetitorProduct");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "QualityMQSCompetitorProduct");

            migrationBuilder.DropColumn(
                name: "TasteTestScore",
                table: "QualityMQSCompetitorProduct");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "QualityMQSCompetitorProduct");

            migrationBuilder.DropColumn(
                name: "TotalAcidsScore",
                table: "QualityMQSCompetitorProduct");

            migrationBuilder.DropColumn(
                name: "ViscosityScore",
                table: "QualityMQSCompetitorProduct");

            migrationBuilder.AddColumn<decimal>(
                name: "H120_Alcohol",
                table: "QualityPQIOtherScud",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H120_TotalAcids",
                table: "QualityPQIOtherScud",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H120_Viscosity",
                table: "QualityPQIOtherScud",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H24_Alcohol",
                table: "QualityPQIOtherScud",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H24_ReducingSugars",
                table: "QualityPQIOtherScud",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H24_TotalAcids",
                table: "QualityPQIOtherScud",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H24_Viscosity",
                table: "QualityPQIOtherScud",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H24_pH",
                table: "QualityPQIOtherScud",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H48_Alcohol",
                table: "QualityPQIOtherScud",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H48_HeadSize",
                table: "QualityPQIOtherScud",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H48_Settling",
                table: "QualityPQIOtherScud",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H48_TotalAcids",
                table: "QualityPQIOtherScud",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H48_Viscosity",
                table: "QualityPQIOtherScud",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H48_pH",
                table: "QualityPQIOtherScud",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H72_Alcohol",
                table: "QualityPQIOtherScud",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H72_TotalAcids",
                table: "QualityPQIOtherScud",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H72_Viscosity",
                table: "QualityPQIOtherScud",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H72_pH",
                table: "QualityPQIOtherScud",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WT_ReducingSugars",
                table: "QualityPQIOtherScud",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WT_Ref",
                table: "QualityPQIOtherScud",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WT_TotalAcids",
                table: "QualityPQIOtherScud",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WT_Viscosity",
                table: "QualityPQIOtherScud",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WT_pH",
                table: "QualityPQIOtherScud",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H12_Alcohol",
                table: "QualityPQIOther",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H12_Brix",
                table: "QualityPQIOther",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H12_RDF",
                table: "QualityPQIOther",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H12_Ref",
                table: "QualityPQIOther",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H12_SpecificGravity",
                table: "QualityPQIOther",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H12_TotalAcids",
                table: "QualityPQIOther",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H12_Viscosity",
                table: "QualityPQIOther",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H12_pH",
                table: "QualityPQIOther",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H24_Alcohol",
                table: "QualityPQIOther",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H24_Brix",
                table: "QualityPQIOther",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H24_RDF",
                table: "QualityPQIOther",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H24_Ref",
                table: "QualityPQIOther",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H24_SpecificGravity",
                table: "QualityPQIOther",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H24_TotalAcids",
                table: "QualityPQIOther",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H24_Viscosity",
                table: "QualityPQIOther",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H24_pH",
                table: "QualityPQIOther",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H48_Alcohol",
                table: "QualityPQIOther",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H48_Brix",
                table: "QualityPQIOther",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H48_RDF",
                table: "QualityPQIOther",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H48_SpecificGravity",
                table: "QualityPQIOther",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H48_TotalAcids",
                table: "QualityPQIOther",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H48_Viscosity",
                table: "QualityPQIOther",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H48_pH",
                table: "QualityPQIOther",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H72_Alcohol",
                table: "QualityPQIOther",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H72_Brix",
                table: "QualityPQIOther",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H72_SpecificGravity",
                table: "QualityPQIOther",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H72_TotalAcids",
                table: "QualityPQIOther",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H72_Viscosity",
                table: "QualityPQIOther",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "H72_pH",
                table: "QualityPQIOther",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WT_Brix",
                table: "QualityPQIOther",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WT_Ref",
                table: "QualityPQIOther",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WT_TotalAcids",
                table: "QualityPQIOther",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WT_Viscosity",
                table: "QualityPQIOther",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WT_pH",
                table: "QualityPQIOther",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Expiry",
                table: "QualityMQSSuper",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Expiry",
                table: "QualityMQSScud",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Viscosity",
                table: "QualityMQSCompetitorProduct",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAcids",
                table: "QualityMQSCompetitorProduct",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Alcohol",
                table: "QualityMQSCompetitorProduct",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AlcoholComment",
                table: "QualityMQSCompetitorProduct",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PresentabilityComment",
                table: "QualityMQSCompetitorProduct",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TasteTestComment",
                table: "QualityMQSCompetitorProduct",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TotalAcidsComment",
                table: "QualityMQSCompetitorProduct",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ViscosityComment",
                table: "QualityMQSCompetitorProduct",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Assessor",
                table: "QualityMarketQualityScore",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OverallComments",
                table: "QualityMarketQualityScore",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "H120_Alcohol",
                table: "QualityPQIOtherScud");

            migrationBuilder.DropColumn(
                name: "H120_TotalAcids",
                table: "QualityPQIOtherScud");

            migrationBuilder.DropColumn(
                name: "H120_Viscosity",
                table: "QualityPQIOtherScud");

            migrationBuilder.DropColumn(
                name: "H24_Alcohol",
                table: "QualityPQIOtherScud");

            migrationBuilder.DropColumn(
                name: "H24_ReducingSugars",
                table: "QualityPQIOtherScud");

            migrationBuilder.DropColumn(
                name: "H24_TotalAcids",
                table: "QualityPQIOtherScud");

            migrationBuilder.DropColumn(
                name: "H24_Viscosity",
                table: "QualityPQIOtherScud");

            migrationBuilder.DropColumn(
                name: "H24_pH",
                table: "QualityPQIOtherScud");

            migrationBuilder.DropColumn(
                name: "H48_Alcohol",
                table: "QualityPQIOtherScud");

            migrationBuilder.DropColumn(
                name: "H48_HeadSize",
                table: "QualityPQIOtherScud");

            migrationBuilder.DropColumn(
                name: "H48_Settling",
                table: "QualityPQIOtherScud");

            migrationBuilder.DropColumn(
                name: "H48_TotalAcids",
                table: "QualityPQIOtherScud");

            migrationBuilder.DropColumn(
                name: "H48_Viscosity",
                table: "QualityPQIOtherScud");

            migrationBuilder.DropColumn(
                name: "H48_pH",
                table: "QualityPQIOtherScud");

            migrationBuilder.DropColumn(
                name: "H72_Alcohol",
                table: "QualityPQIOtherScud");

            migrationBuilder.DropColumn(
                name: "H72_TotalAcids",
                table: "QualityPQIOtherScud");

            migrationBuilder.DropColumn(
                name: "H72_Viscosity",
                table: "QualityPQIOtherScud");

            migrationBuilder.DropColumn(
                name: "H72_pH",
                table: "QualityPQIOtherScud");

            migrationBuilder.DropColumn(
                name: "WT_ReducingSugars",
                table: "QualityPQIOtherScud");

            migrationBuilder.DropColumn(
                name: "WT_Ref",
                table: "QualityPQIOtherScud");

            migrationBuilder.DropColumn(
                name: "WT_TotalAcids",
                table: "QualityPQIOtherScud");

            migrationBuilder.DropColumn(
                name: "WT_Viscosity",
                table: "QualityPQIOtherScud");

            migrationBuilder.DropColumn(
                name: "WT_pH",
                table: "QualityPQIOtherScud");

            migrationBuilder.DropColumn(
                name: "H12_Alcohol",
                table: "QualityPQIOther");

            migrationBuilder.DropColumn(
                name: "H12_Brix",
                table: "QualityPQIOther");

            migrationBuilder.DropColumn(
                name: "H12_RDF",
                table: "QualityPQIOther");

            migrationBuilder.DropColumn(
                name: "H12_Ref",
                table: "QualityPQIOther");

            migrationBuilder.DropColumn(
                name: "H12_SpecificGravity",
                table: "QualityPQIOther");

            migrationBuilder.DropColumn(
                name: "H12_TotalAcids",
                table: "QualityPQIOther");

            migrationBuilder.DropColumn(
                name: "H12_Viscosity",
                table: "QualityPQIOther");

            migrationBuilder.DropColumn(
                name: "H12_pH",
                table: "QualityPQIOther");

            migrationBuilder.DropColumn(
                name: "H24_Alcohol",
                table: "QualityPQIOther");

            migrationBuilder.DropColumn(
                name: "H24_Brix",
                table: "QualityPQIOther");

            migrationBuilder.DropColumn(
                name: "H24_RDF",
                table: "QualityPQIOther");

            migrationBuilder.DropColumn(
                name: "H24_Ref",
                table: "QualityPQIOther");

            migrationBuilder.DropColumn(
                name: "H24_SpecificGravity",
                table: "QualityPQIOther");

            migrationBuilder.DropColumn(
                name: "H24_TotalAcids",
                table: "QualityPQIOther");

            migrationBuilder.DropColumn(
                name: "H24_Viscosity",
                table: "QualityPQIOther");

            migrationBuilder.DropColumn(
                name: "H24_pH",
                table: "QualityPQIOther");

            migrationBuilder.DropColumn(
                name: "H48_Alcohol",
                table: "QualityPQIOther");

            migrationBuilder.DropColumn(
                name: "H48_Brix",
                table: "QualityPQIOther");

            migrationBuilder.DropColumn(
                name: "H48_RDF",
                table: "QualityPQIOther");

            migrationBuilder.DropColumn(
                name: "H48_SpecificGravity",
                table: "QualityPQIOther");

            migrationBuilder.DropColumn(
                name: "H48_TotalAcids",
                table: "QualityPQIOther");

            migrationBuilder.DropColumn(
                name: "H48_Viscosity",
                table: "QualityPQIOther");

            migrationBuilder.DropColumn(
                name: "H48_pH",
                table: "QualityPQIOther");

            migrationBuilder.DropColumn(
                name: "H72_Alcohol",
                table: "QualityPQIOther");

            migrationBuilder.DropColumn(
                name: "H72_Brix",
                table: "QualityPQIOther");

            migrationBuilder.DropColumn(
                name: "H72_SpecificGravity",
                table: "QualityPQIOther");

            migrationBuilder.DropColumn(
                name: "H72_TotalAcids",
                table: "QualityPQIOther");

            migrationBuilder.DropColumn(
                name: "H72_Viscosity",
                table: "QualityPQIOther");

            migrationBuilder.DropColumn(
                name: "H72_pH",
                table: "QualityPQIOther");

            migrationBuilder.DropColumn(
                name: "WT_Brix",
                table: "QualityPQIOther");

            migrationBuilder.DropColumn(
                name: "WT_Ref",
                table: "QualityPQIOther");

            migrationBuilder.DropColumn(
                name: "WT_TotalAcids",
                table: "QualityPQIOther");

            migrationBuilder.DropColumn(
                name: "WT_Viscosity",
                table: "QualityPQIOther");

            migrationBuilder.DropColumn(
                name: "WT_pH",
                table: "QualityPQIOther");

            migrationBuilder.DropColumn(
                name: "Expiry",
                table: "QualityMQSSuper");

            migrationBuilder.DropColumn(
                name: "Expiry",
                table: "QualityMQSScud");

            migrationBuilder.DropColumn(
                name: "AlcoholComment",
                table: "QualityMQSCompetitorProduct");

            migrationBuilder.DropColumn(
                name: "PresentabilityComment",
                table: "QualityMQSCompetitorProduct");

            migrationBuilder.DropColumn(
                name: "TasteTestComment",
                table: "QualityMQSCompetitorProduct");

            migrationBuilder.DropColumn(
                name: "TotalAcidsComment",
                table: "QualityMQSCompetitorProduct");

            migrationBuilder.DropColumn(
                name: "ViscosityComment",
                table: "QualityMQSCompetitorProduct");

            migrationBuilder.DropColumn(
                name: "Assessor",
                table: "QualityMarketQualityScore");

            migrationBuilder.DropColumn(
                name: "OverallComments",
                table: "QualityMarketQualityScore");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiryDate",
                table: "QualityMQSSuper",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiryDate",
                table: "QualityMQSScud",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Viscosity",
                table: "QualityMQSCompetitorProduct",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "TotalAcids",
                table: "QualityMQSCompetitorProduct",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "Alcohol",
                table: "QualityMQSCompetitorProduct",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<int>(
                name: "AlcoholScore",
                table: "QualityMQSCompetitorProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PresentabilityScore",
                table: "QualityMQSCompetitorProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Score",
                table: "QualityMQSCompetitorProduct",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "TasteTestScore",
                table: "QualityMQSCompetitorProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Total",
                table: "QualityMQSCompetitorProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalAcidsScore",
                table: "QualityMQSCompetitorProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ViscosityScore",
                table: "QualityMQSCompetitorProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
