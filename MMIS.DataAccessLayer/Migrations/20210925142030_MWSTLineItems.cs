using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class MWSTLineItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Question",
                table: "ManWaySTHeader");

            migrationBuilder.DropColumn(
                name: "QuestionType",
                table: "ManWaySTHeader");

            migrationBuilder.DropColumn(
                name: "Response",
                table: "ManWaySTHeader");

            migrationBuilder.CreateTable(
                name: "MWSTsLineItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Personnel = table.Column<string>(nullable: true),
                    STType = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    QuestionType = table.Column<string>(nullable: true),
                    Question = table.Column<string>(nullable: true),
                    Response = table.Column<bool>(nullable: false),
                    Changedby = table.Column<string>(nullable: true),
                    ManWaySTHeaderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MWSTsLineItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MWSTsLineItems_ManWaySTHeader_ManWaySTHeaderId",
                        column: x => x.ManWaySTHeaderId,
                        principalTable: "ManWaySTHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MWSTsLineItems_ManWaySTHeaderId",
                table: "MWSTsLineItems",
                column: "ManWaySTHeaderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MWSTsLineItems");

            migrationBuilder.AddColumn<string>(
                name: "Question",
                table: "ManWaySTHeader",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuestionType",
                table: "ManWaySTHeader",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Response",
                table: "ManWaySTHeader",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
