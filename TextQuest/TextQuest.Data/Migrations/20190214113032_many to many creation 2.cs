using Microsoft.EntityFrameworkCore.Migrations;

namespace TextQuest.Data.Migrations
{
    public partial class manytomanycreation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Inventory_InventoryObjects_Inventory_InventoryObjectId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryObjects_Inventory_InventoryObjects_Inventory_InventoryObjectId",
                table: "InventoryObjects");

            migrationBuilder.DropIndex(
                name: "IX_InventoryObjects_Inventory_InventoryObjectId",
                table: "InventoryObjects");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_Inventory_InventoryObjectId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "Inventory_InventoryObjectId",
                table: "InventoryObjects");

            migrationBuilder.DropColumn(
                name: "Inventory_InventoryObjectId",
                table: "Inventories");

            migrationBuilder.AddColumn<int>(
                name: "Inventory",
                table: "Inventory_InventoryObjects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InventoryObject",
                table: "Inventory_InventoryObjects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "NextInteractionId",
                table: "Interactions",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Inventory",
                table: "Inventory_InventoryObjects");

            migrationBuilder.DropColumn(
                name: "InventoryObject",
                table: "Inventory_InventoryObjects");

            migrationBuilder.AddColumn<int>(
                name: "Inventory_InventoryObjectId",
                table: "InventoryObjects",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Inventory_InventoryObjectId",
                table: "Inventories",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NextInteractionId",
                table: "Interactions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryObjects_Inventory_InventoryObjectId",
                table: "InventoryObjects",
                column: "Inventory_InventoryObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_Inventory_InventoryObjectId",
                table: "Inventories",
                column: "Inventory_InventoryObjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Inventory_InventoryObjects_Inventory_InventoryObjectId",
                table: "Inventories",
                column: "Inventory_InventoryObjectId",
                principalTable: "Inventory_InventoryObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryObjects_Inventory_InventoryObjects_Inventory_InventoryObjectId",
                table: "InventoryObjects",
                column: "Inventory_InventoryObjectId",
                principalTable: "Inventory_InventoryObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
