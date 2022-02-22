using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class DeviationUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DCT",
                table: "MandevDeviation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Function",
                table: "MandevDeviation",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MandevDeviationMaster",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    Function = table.Column<string>(nullable: true),
                    DCT = table.Column<string>(nullable: true),
                    Param = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Unit = table.Column<string>(nullable: true),
                    LV = table.Column<double>(nullable: false),
                    LS = table.Column<double>(nullable: false),
                    Std = table.Column<double>(nullable: false),
                    HS = table.Column<double>(nullable: false),
                    HV = table.Column<double>(nullable: false),
                    SV = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MandevDeviationMaster", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MandevDeviationMaster");

            migrationBuilder.DropColumn(
                name: "DCT",
                table: "MandevDeviation");

            migrationBuilder.DropColumn(
                name: "Function",
                table: "MandevDeviation");
        }
    }
}
