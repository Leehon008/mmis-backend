using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class removeShiftInterval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShiftInterval",
                table: "LossWasteHeader");
        }

        //protected override void Down(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.AddColumn<int>(
        //        name: "ShiftInterval",
        //        table: "LossWasteHeader",
        //        type: "int",
        //        nullable: false,
        //        defaultValue: 0);
        //}
    }
}
