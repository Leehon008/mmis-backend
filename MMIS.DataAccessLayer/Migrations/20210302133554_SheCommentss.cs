using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class SheCommentss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Medicals",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Medicals");
        }
    }
}
