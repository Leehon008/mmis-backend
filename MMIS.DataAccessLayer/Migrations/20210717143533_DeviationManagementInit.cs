using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class DeviationManagementInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MandevDeviation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Personnel = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    RootCause = table.Column<string>(nullable: true),
                    Impact = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MandevDeviation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MandevDeviationEmail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Personnel = table.Column<string>(nullable: true),
                    Function = table.Column<string>(nullable: true),
                    DCT = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Sender = table.Column<string>(nullable: true),
                    Receiver = table.Column<string>(nullable: true),
                    Cc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MandevDeviationEmail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MandevNotification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Plant = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Personnel = table.Column<string>(nullable: true),
                    Function = table.Column<string>(nullable: true),
                    DCT = table.Column<string>(nullable: true),
                    Notice = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MandevNotification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MandevDeviationApproval",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    Approve = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    DId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MandevDeviationApproval", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MandevDeviationApproval_MandevDeviation_DId",
                        column: x => x.DId,
                        principalTable: "MandevDeviation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MandevDeviationCorrectiveAction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<string>(nullable: true),
                    When = table.Column<DateTime>(nullable: false),
                    Who = table.Column<string>(nullable: true),
                    DId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MandevDeviationCorrectiveAction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MandevDeviationCorrectiveAction_MandevDeviation_DId",
                        column: x => x.DId,
                        principalTable: "MandevDeviation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MandevDeviationDParam",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Standard = table.Column<string>(nullable: true),
                    Required = table.Column<string>(nullable: true),
                    DId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MandevDeviationDParam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MandevDeviationDParam_MandevDeviation_DId",
                        column: x => x.DId,
                        principalTable: "MandevDeviation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MandevDeviationTechnicalApproval",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Condition = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    DId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MandevDeviationTechnicalApproval", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MandevDeviationTechnicalApproval_MandevDeviation_DId",
                        column: x => x.DId,
                        principalTable: "MandevDeviation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MandevDeviationApproval_DId",
                table: "MandevDeviationApproval",
                column: "DId");

            migrationBuilder.CreateIndex(
                name: "IX_MandevDeviationCorrectiveAction_DId",
                table: "MandevDeviationCorrectiveAction",
                column: "DId");

            migrationBuilder.CreateIndex(
                name: "IX_MandevDeviationDParam_DId",
                table: "MandevDeviationDParam",
                column: "DId");

            migrationBuilder.CreateIndex(
                name: "IX_MandevDeviationTechnicalApproval_DId",
                table: "MandevDeviationTechnicalApproval",
                column: "DId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MandevDeviationApproval");

            migrationBuilder.DropTable(
                name: "MandevDeviationCorrectiveAction");

            migrationBuilder.DropTable(
                name: "MandevDeviationDParam");

            migrationBuilder.DropTable(
                name: "MandevDeviationEmail");

            migrationBuilder.DropTable(
                name: "MandevDeviationTechnicalApproval");

            migrationBuilder.DropTable(
                name: "MandevNotification");

            migrationBuilder.DropTable(
                name: "MandevDeviation");
        }
    }
}
