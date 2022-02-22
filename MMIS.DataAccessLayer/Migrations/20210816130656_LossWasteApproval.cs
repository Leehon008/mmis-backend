using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class LossWasteApproval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApprovalStatus",
                table: "LossWasteHeader",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApprovedBy",
                table: "LossWasteHeader",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedOn",
                table: "LossWasteHeader",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovalStatus",
                table: "LossWasteHeader");

            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "LossWasteHeader");

            migrationBuilder.DropColumn(
                name: "ApprovedOn",
                table: "LossWasteHeader");
        }
    }
}
