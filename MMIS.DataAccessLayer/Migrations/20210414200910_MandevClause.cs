using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class MandevClause : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Attendant",
                table: "MandevPlantRanking");

            migrationBuilder.DropColumn(
                name: "Attendant",
                table: "MandevAuditProtocol");

            migrationBuilder.AddColumn<string>(
                name: "Personnel",
                table: "MandevPlantRanking",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Personnel",
                table: "MandevAuditProtocol",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MandevClause",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Personnel = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MandevClause", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MandevClauseSection",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClauseId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Question = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MandevClauseSection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MandevClauseSection_MandevClause_ClauseId",
                        column: x => x.ClauseId,
                        principalTable: "MandevClause",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MandevClauseSectionEvidence",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    File = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MandevClauseSectionEvidence", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MandevClauseSectionEvidence_MandevClauseSection_SectionId",
                        column: x => x.SectionId,
                        principalTable: "MandevClauseSection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MandevClauseSection_ClauseId",
                table: "MandevClauseSection",
                column: "ClauseId");

            migrationBuilder.CreateIndex(
                name: "IX_MandevClauseSectionEvidence_SectionId",
                table: "MandevClauseSectionEvidence",
                column: "SectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MandevClauseSectionEvidence");

            migrationBuilder.DropTable(
                name: "MandevClauseSection");

            migrationBuilder.DropTable(
                name: "MandevClause");

            migrationBuilder.DropColumn(
                name: "Personnel",
                table: "MandevPlantRanking");

            migrationBuilder.DropColumn(
                name: "Personnel",
                table: "MandevAuditProtocol");

            migrationBuilder.AddColumn<string>(
                name: "Attendant",
                table: "MandevPlantRanking",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Attendant",
                table: "MandevAuditProtocol",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
