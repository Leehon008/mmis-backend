using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class CostCalculator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CostCalculator",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    ReportDate = table.Column<DateTime>(nullable: false),
                    ReportBy = table.Column<string>(nullable: false),
                    NameOfPersonInvolved = table.Column<string>(nullable: false),
                    DateTimeOfIncident = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostCalculator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpensesBreakDown",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    ExpenseGroup = table.Column<string>(nullable: false),
                    ExpenseName = table.Column<string>(nullable: false),
                    TimeSpent = table.Column<int>(nullable: false),
                    Cost = table.Column<int>(nullable: false),
                    CostCalculatorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpensesBreakDown", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpensesBreakDown_CostCalculator_CostCalculatorId",
                        column: x => x.CostCalculatorId,
                        principalTable: "CostCalculator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpensesBreakDown_CostCalculatorId",
                table: "ExpensesBreakDown",
                column: "CostCalculatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpensesBreakDown");

            migrationBuilder.DropTable(
                name: "CostCalculator");
        }
    }
}
