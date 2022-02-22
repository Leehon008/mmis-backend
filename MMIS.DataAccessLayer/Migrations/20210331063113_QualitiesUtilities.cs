using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class QualitiesUtilities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Effluent_Utilities_UIdId",
                table: "Effluent");

            migrationBuilder.DropForeignKey(
                name: "FK_QualityUtilitiesBoiler_Utilities_UIdId",
                table: "QualityUtilitiesBoiler");

            migrationBuilder.DropForeignKey(
                name: "FK_QualityUtilitiesCondenser_Utilities_UIdId",
                table: "QualityUtilitiesCondenser");

            migrationBuilder.DropForeignKey(
                name: "FK_QualityUtilitiesCTMPV_Utilities_UIdId",
                table: "QualityUtilitiesCTMPV");

            migrationBuilder.DropForeignKey(
                name: "FK_QualityUtilitiesRefridgeration_Utilities_UIdId",
                table: "QualityUtilitiesRefridgeration");

            migrationBuilder.DropForeignKey(
                name: "FK_QualityUtilitiesSoftner_Utilities_UIdId",
                table: "QualityUtilitiesSoftner");

            migrationBuilder.DropForeignKey(
                name: "FK_QualityUtilitiesWT_Utilities_UIdId",
                table: "QualityUtilitiesWT");

            migrationBuilder.DropTable(
                name: "Utilities");

            migrationBuilder.DropIndex(
                name: "IX_QualityUtilitiesWT_UIdId",
                table: "QualityUtilitiesWT");

            migrationBuilder.DropIndex(
                name: "IX_QualityUtilitiesRefridgeration_UIdId",
                table: "QualityUtilitiesRefridgeration");

            migrationBuilder.DropIndex(
                name: "IX_QualityUtilitiesCondenser_UIdId",
                table: "QualityUtilitiesCondenser");

            migrationBuilder.DropIndex(
                name: "IX_QualityUtilitiesBoiler_UIdId",
                table: "QualityUtilitiesBoiler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QualityUtilitiesSoftner",
                table: "QualityUtilitiesSoftner");

            migrationBuilder.DropIndex(
                name: "IX_QualityUtilitiesSoftner_UIdId",
                table: "QualityUtilitiesSoftner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QualityUtilitiesCTMPV",
                table: "QualityUtilitiesCTMPV");

            migrationBuilder.DropIndex(
                name: "IX_QualityUtilitiesCTMPV_UIdId",
                table: "QualityUtilitiesCTMPV");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Effluent",
                table: "Effluent");

            migrationBuilder.DropIndex(
                name: "IX_Effluent_UIdId",
                table: "Effluent");

            migrationBuilder.DropColumn(
                name: "UIdId",
                table: "QualityUtilitiesWT");

            migrationBuilder.DropColumn(
                name: "UIdId",
                table: "QualityUtilitiesRefridgeration");

            migrationBuilder.DropColumn(
                name: "UIdId",
                table: "QualityUtilitiesCondenser");

            migrationBuilder.DropColumn(
                name: "UIdId",
                table: "QualityUtilitiesBoiler");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "QualityUtilitiesSoftner");

            migrationBuilder.DropColumn(
                name: "UIdId",
                table: "QualityUtilitiesSoftner");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "QualityUtilitiesCTMPV");

            migrationBuilder.DropColumn(
                name: "UIdId",
                table: "QualityUtilitiesCTMPV");

            migrationBuilder.DropColumn(
                name: "UIdId",
                table: "Effluent");

            migrationBuilder.RenameTable(
                name: "QualityUtilitiesSoftner",
                newName: "Vessel");

            migrationBuilder.RenameTable(
                name: "QualityUtilitiesCTMPV",
                newName: "QualityUtilitiesCoolingTower");

            migrationBuilder.RenameTable(
                name: "Effluent",
                newName: "QualityUtilitiesEffluent");

            migrationBuilder.AddColumn<string>(
                name: "Analyst",
                table: "QualityUtilitiesWT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "QualityUtilitiesWT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "QualityUtilitiesWT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "QualityUtilitiesWT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Plant",
                table: "QualityUtilitiesWT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Analyst",
                table: "QualityUtilitiesRefridgeration",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "QualityUtilitiesRefridgeration",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "QualityUtilitiesRefridgeration",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "QualityUtilitiesRefridgeration",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "QualityUtilitiesRefridgeration",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plant",
                table: "QualityUtilitiesRefridgeration",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Analyst",
                table: "QualityUtilitiesCondenser",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "QualityUtilitiesCondenser",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "QualityUtilitiesCondenser",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "QualityUtilitiesCondenser",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "QualityUtilitiesCondenser",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plant",
                table: "QualityUtilitiesCondenser",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Analyst",
                table: "QualityUtilitiesBoiler",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "QualityUtilitiesBoiler",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "QualityUtilitiesBoiler",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "QualityUtilitiesBoiler",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "QualityUtilitiesBoiler",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plant",
                table: "QualityUtilitiesBoiler",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Analyst",
                table: "Vessel",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Vessel",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Vessel",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Vessel",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Vessel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plant",
                table: "Vessel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Analyst",
                table: "QualityUtilitiesCoolingTower",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "QualityUtilitiesCoolingTower",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "QualityUtilitiesCoolingTower",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "QualityUtilitiesCoolingTower",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "QualityUtilitiesCoolingTower",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plant",
                table: "QualityUtilitiesCoolingTower",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Analyst",
                table: "QualityUtilitiesEffluent",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "QualityUtilitiesEffluent",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "QualityUtilitiesEffluent",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "QualityUtilitiesEffluent",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Plant",
                table: "QualityUtilitiesEffluent",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vessel",
                table: "Vessel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QualityUtilitiesCoolingTower",
                table: "QualityUtilitiesCoolingTower",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QualityUtilitiesEffluent",
                table: "QualityUtilitiesEffluent",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Vessel",
                table: "Vessel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QualityUtilitiesEffluent",
                table: "QualityUtilitiesEffluent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QualityUtilitiesCoolingTower",
                table: "QualityUtilitiesCoolingTower");

            migrationBuilder.DropColumn(
                name: "Analyst",
                table: "QualityUtilitiesWT");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "QualityUtilitiesWT");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "QualityUtilitiesWT");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "QualityUtilitiesWT");

            migrationBuilder.DropColumn(
                name: "Plant",
                table: "QualityUtilitiesWT");

            migrationBuilder.DropColumn(
                name: "Analyst",
                table: "QualityUtilitiesRefridgeration");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "QualityUtilitiesRefridgeration");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "QualityUtilitiesRefridgeration");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "QualityUtilitiesRefridgeration");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "QualityUtilitiesRefridgeration");

            migrationBuilder.DropColumn(
                name: "Plant",
                table: "QualityUtilitiesRefridgeration");

            migrationBuilder.DropColumn(
                name: "Analyst",
                table: "QualityUtilitiesCondenser");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "QualityUtilitiesCondenser");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "QualityUtilitiesCondenser");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "QualityUtilitiesCondenser");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "QualityUtilitiesCondenser");

            migrationBuilder.DropColumn(
                name: "Plant",
                table: "QualityUtilitiesCondenser");

            migrationBuilder.DropColumn(
                name: "Analyst",
                table: "QualityUtilitiesBoiler");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "QualityUtilitiesBoiler");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "QualityUtilitiesBoiler");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "QualityUtilitiesBoiler");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "QualityUtilitiesBoiler");

            migrationBuilder.DropColumn(
                name: "Plant",
                table: "QualityUtilitiesBoiler");

            migrationBuilder.DropColumn(
                name: "Analyst",
                table: "Vessel");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Vessel");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Vessel");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Vessel");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Vessel");

            migrationBuilder.DropColumn(
                name: "Plant",
                table: "Vessel");

            migrationBuilder.DropColumn(
                name: "Analyst",
                table: "QualityUtilitiesEffluent");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "QualityUtilitiesEffluent");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "QualityUtilitiesEffluent");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "QualityUtilitiesEffluent");

            migrationBuilder.DropColumn(
                name: "Plant",
                table: "QualityUtilitiesEffluent");

            migrationBuilder.DropColumn(
                name: "Analyst",
                table: "QualityUtilitiesCoolingTower");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "QualityUtilitiesCoolingTower");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "QualityUtilitiesCoolingTower");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "QualityUtilitiesCoolingTower");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "QualityUtilitiesCoolingTower");

            migrationBuilder.DropColumn(
                name: "Plant",
                table: "QualityUtilitiesCoolingTower");

            migrationBuilder.RenameTable(
                name: "Vessel",
                newName: "QualityUtilitiesSoftner");

            migrationBuilder.RenameTable(
                name: "QualityUtilitiesEffluent",
                newName: "Effluent");

            migrationBuilder.RenameTable(
                name: "QualityUtilitiesCoolingTower",
                newName: "QualityUtilitiesCTMPV");

            migrationBuilder.AddColumn<int>(
                name: "UIdId",
                table: "QualityUtilitiesWT",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UIdId",
                table: "QualityUtilitiesRefridgeration",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UIdId",
                table: "QualityUtilitiesCondenser",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UIdId",
                table: "QualityUtilitiesBoiler",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "QualityUtilitiesSoftner",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UIdId",
                table: "QualityUtilitiesSoftner",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UIdId",
                table: "Effluent",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "QualityUtilitiesCTMPV",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UIdId",
                table: "QualityUtilitiesCTMPV",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_QualityUtilitiesSoftner",
                table: "QualityUtilitiesSoftner",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Effluent",
                table: "Effluent",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QualityUtilitiesCTMPV",
                table: "QualityUtilitiesCTMPV",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Utilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Analyst = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Plant = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QualityUtilitiesWT_UIdId",
                table: "QualityUtilitiesWT",
                column: "UIdId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityUtilitiesRefridgeration_UIdId",
                table: "QualityUtilitiesRefridgeration",
                column: "UIdId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityUtilitiesCondenser_UIdId",
                table: "QualityUtilitiesCondenser",
                column: "UIdId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityUtilitiesBoiler_UIdId",
                table: "QualityUtilitiesBoiler",
                column: "UIdId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityUtilitiesSoftner_UIdId",
                table: "QualityUtilitiesSoftner",
                column: "UIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Effluent_UIdId",
                table: "Effluent",
                column: "UIdId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityUtilitiesCTMPV_UIdId",
                table: "QualityUtilitiesCTMPV",
                column: "UIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Effluent_Utilities_UIdId",
                table: "Effluent",
                column: "UIdId",
                principalTable: "Utilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QualityUtilitiesBoiler_Utilities_UIdId",
                table: "QualityUtilitiesBoiler",
                column: "UIdId",
                principalTable: "Utilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QualityUtilitiesCondenser_Utilities_UIdId",
                table: "QualityUtilitiesCondenser",
                column: "UIdId",
                principalTable: "Utilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QualityUtilitiesCTMPV_Utilities_UIdId",
                table: "QualityUtilitiesCTMPV",
                column: "UIdId",
                principalTable: "Utilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QualityUtilitiesRefridgeration_Utilities_UIdId",
                table: "QualityUtilitiesRefridgeration",
                column: "UIdId",
                principalTable: "Utilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QualityUtilitiesSoftner_Utilities_UIdId",
                table: "QualityUtilitiesSoftner",
                column: "UIdId",
                principalTable: "Utilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QualityUtilitiesWT_Utilities_UIdId",
                table: "QualityUtilitiesWT",
                column: "UIdId",
                principalTable: "Utilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
