using Microsoft.EntityFrameworkCore.Migrations;

namespace TextQuest.Data.Migrations
{
    public partial class bugfixwithinventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InventoryObject",
                table: "Inventory_InventoryObjects",
                newName: "InventoryObjectId");

            migrationBuilder.RenameColumn(
                name: "Inventory",
                table: "Inventory_InventoryObjects",
                newName: "InventoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InventoryObjectId",
                table: "Inventory_InventoryObjects",
                newName: "InventoryObject");

            migrationBuilder.RenameColumn(
                name: "InventoryId",
                table: "Inventory_InventoryObjects",
                newName: "Inventory");
        }
    }
}
