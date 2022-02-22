﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class InspectionsWorkArising : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WorkArising",
                table: "Inspections",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkArising",
                table: "Inspections");
        }
    }
}
