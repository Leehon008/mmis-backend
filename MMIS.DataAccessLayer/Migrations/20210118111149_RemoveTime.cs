using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class RemoveTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "AdditionTime",
            //    table: "BrewingMaltAddition");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<decimal>(
            //    name: "AdditionTime",
            //    table: "BrewingMaltAddition",
            //    type: "decimal(18,2)",
            //    nullable: false,
            //    defaultValue: 0m);
        }
    }
}
