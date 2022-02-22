using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class MWSTLineItemsUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MWSTsEmpowermentId",
                table: "ManWaySTHeader",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MWSTsEmpowerment",
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
                    AreaofAccountability = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FacilitiesNeeded = table.Column<string>(nullable: true),
                    InformationNeeded = table.Column<string>(nullable: true),
                    TrainingRequired = table.Column<string>(nullable: true),
                    TrainingStartDate = table.Column<DateTime>(nullable: false),
                    TrainingEndDate = table.Column<DateTime>(nullable: false),
                    TranferStartDate = table.Column<DateTime>(nullable: false),
                    TransferEndDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Changedby = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MWSTsEmpowerment", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ManWaySTHeader_MWSTsEmpowermentId",
                table: "ManWaySTHeader",
                column: "MWSTsEmpowermentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ManWaySTHeader_MWSTsEmpowerment_MWSTsEmpowermentId",
                table: "ManWaySTHeader",
                column: "MWSTsEmpowermentId",
                principalTable: "MWSTsEmpowerment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManWaySTHeader_MWSTsEmpowerment_MWSTsEmpowermentId",
                table: "ManWaySTHeader");

            migrationBuilder.DropTable(
                name: "MWSTsEmpowerment");

            migrationBuilder.DropIndex(
                name: "IX_ManWaySTHeader_MWSTsEmpowermentId",
                table: "ManWaySTHeader");

            migrationBuilder.DropColumn(
                name: "MWSTsEmpowermentId",
                table: "ManWaySTHeader");
        }
    }
}
