using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TextQuest.Data.Migrations
{
    public partial class manytomanycreation1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Inventory_InventoryObjectId",
                table: "InventoryObjects",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Inventory_InventoryObjectId",
                table: "Inventories",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Inventory_InventoryObjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory_InventoryObjects", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Inventory_InventoryObjects_Inventory_InventoryObjectId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryObjects_Inventory_InventoryObjects_Inventory_InventoryObjectId",
                table: "InventoryObjects");

            migrationBuilder.DropTable(
                name: "Inventory_InventoryObjects");

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
        }
    }
}
