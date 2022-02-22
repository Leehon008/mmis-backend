using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class QualityIssues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PIPBadClosures");

            migrationBuilder.DropColumn(
                name: "BrewTank",
                table: "QualityShelflifeScud");

            migrationBuilder.DropColumn(
                name: "MaltYeast",
                table: "QualityShelflifeScud");

            migrationBuilder.DropColumn(
                name: "BestBeforeDate",
                table: "QualityPIPScud");

            migrationBuilder.DropColumn(
                name: "BrixAtWort",
                table: "QualityFermentationScud");

            migrationBuilder.DropColumn(
                name: "MaltBatch",
                table: "QualityFermentationScud");

            migrationBuilder.DropColumn(
                name: "TRS",
                table: "QualityFermentationScud");

            migrationBuilder.DropColumn(
                name: "YeastBatch",
                table: "QualityFermentationScud");

            migrationBuilder.AddColumn<string>(
                name: "BestPractice",
                table: "Scoping",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Taste",
                table: "QualitySLParametersScud",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "Brew",
                table: "QualityShelflifeScud",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaltBatch",
                table: "QualityShelflifeScud",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tank",
                table: "QualityShelflifeScud",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YeastBatch",
                table: "QualityShelflifeScud",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Taste",
                table: "QualityFermentationScud",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BestPractice",
                table: "Scoping");

            migrationBuilder.DropColumn(
                name: "Brew",
                table: "QualityShelflifeScud");

            migrationBuilder.DropColumn(
                name: "MaltBatch",
                table: "QualityShelflifeScud");

            migrationBuilder.DropColumn(
                name: "Tank",
                table: "QualityShelflifeScud");

            migrationBuilder.DropColumn(
                name: "YeastBatch",
                table: "QualityShelflifeScud");

            migrationBuilder.AlterColumn<decimal>(
                name: "Taste",
                table: "QualitySLParametersScud",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BrewTank",
                table: "QualityShelflifeScud",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaltYeast",
                table: "QualityShelflifeScud",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BestBeforeDate",
                table: "QualityPIPScud",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<decimal>(
                name: "Taste",
                table: "QualityFermentationScud",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "BrixAtWort",
                table: "QualityFermentationScud",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "MaltBatch",
                table: "QualityFermentationScud",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TRS",
                table: "QualityFermentationScud",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "YeastBatch",
                table: "QualityFermentationScud",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PIPBadClosures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dimensions = table.Column<int>(type: "int", nullable: false),
                    Flashes = table.Column<int>(type: "int", nullable: false),
                    Other = table.Column<int>(type: "int", nullable: false),
                    PIPId = table.Column<int>(type: "int", nullable: true),
                    Shift = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortMoulds = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_PIPBadClosures_PIPId",
                table: "PIPBadClosures",
                column: "PIPId");
        }
    }
}
