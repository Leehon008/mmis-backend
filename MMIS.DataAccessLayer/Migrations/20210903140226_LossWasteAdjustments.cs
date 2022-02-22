using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class LossWasteAdjustments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "LossWasteHeader",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Plant",
                table: "LossWasteHeader",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LossWasteIntervals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SHId = table.Column<int>(nullable: true),
                    Interval = table.Column<int>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    Length = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LossWasteIntervals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LossWasteIntervals_ShiftHeader_SHId",
                        column: x => x.SHId,
                        principalTable: "ShiftHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LossWasteIntervals_SHId",
                table: "LossWasteIntervals",
                column: "SHId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LossWasteIntervals");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "LossWasteHeader");

            migrationBuilder.DropColumn(
                name: "Plant",
                table: "LossWasteHeader");
        }
    }
}
