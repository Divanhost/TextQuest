using Microsoft.EntityFrameworkCore.Migrations;

namespace TextQuest.Data.Migrations
{
    public partial class manytomanycreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryObjects_Inventories_InventoryId",
                table: "InventoryObjects");

            migrationBuilder.DropIndex(
                name: "IX_InventoryObjects_InventoryId",
                table: "InventoryObjects");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "InventoryObjects");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                table: "InventoryObjects",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryObjects_InventoryId",
                table: "InventoryObjects",
                column: "InventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryObjects_Inventories_InventoryId",
                table: "InventoryObjects",
                column: "InventoryId",
                principalTable: "Inventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
