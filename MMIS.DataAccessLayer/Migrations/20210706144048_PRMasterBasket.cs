using Microsoft.EntityFrameworkCore.Migrations;

namespace MMIS.DataAccessLayer.Migrations
{
    public partial class PRMasterBasket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MandevKPIMaster_MandevKPIBasketMaster_KPIBasketMasterId",
                table: "MandevKPIMaster");

            migrationBuilder.DropIndex(
                name: "IX_MandevKPIMaster_KPIBasketMasterId",
                table: "MandevKPIMaster");

            migrationBuilder.DropColumn(
                name: "Basket",
                table: "MandevKPIMaster");

            migrationBuilder.DropColumn(
                name: "KPIBasketMasterId",
                table: "MandevKPIMaster");

            migrationBuilder.AddColumn<int>(
                name: "BasketId",
                table: "MandevKPIMaster",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MandevKPIMaster_BasketId",
                table: "MandevKPIMaster",
                column: "BasketId");

            migrationBuilder.AddForeignKey(
                name: "FK_MandevKPIMaster_MandevKPIBasketMaster_BasketId",
                table: "MandevKPIMaster",
                column: "BasketId",
                principalTable: "MandevKPIBasketMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MandevKPIMaster_MandevKPIBasketMaster_BasketId",
                table: "MandevKPIMaster");

            migrationBuilder.DropIndex(
                name: "IX_MandevKPIMaster_BasketId",
                table: "MandevKPIMaster");

            migrationBuilder.DropColumn(
                name: "BasketId",
                table: "MandevKPIMaster");

            migrationBuilder.AddColumn<string>(
                name: "Basket",
                table: "MandevKPIMaster",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KPIBasketMasterId",
                table: "MandevKPIMaster",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MandevKPIMaster_KPIBasketMasterId",
                table: "MandevKPIMaster",
                column: "KPIBasketMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_MandevKPIMaster_MandevKPIBasketMaster_KPIBasketMasterId",
                table: "MandevKPIMaster",
                column: "KPIBasketMasterId",
                principalTable: "MandevKPIBasketMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
