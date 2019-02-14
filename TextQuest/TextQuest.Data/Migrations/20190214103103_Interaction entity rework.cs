using Microsoft.EntityFrameworkCore.Migrations;

namespace TextQuest.Data.Migrations
{
    public partial class Interactionentityrework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InteractingInventoryObjectId",
                table: "Interactions");

            migrationBuilder.DropColumn(
                name: "InteractingSceneObjectId",
                table: "Interactions");

            migrationBuilder.DropColumn(
                name: "InventoryObjectId",
                table: "Interactions");

            migrationBuilder.DropColumn(
                name: "SceneObjectId",
                table: "Interactions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InteractingInventoryObjectId",
                table: "Interactions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InteractingSceneObjectId",
                table: "Interactions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InventoryObjectId",
                table: "Interactions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SceneObjectId",
                table: "Interactions",
                nullable: false,
                defaultValue: 0);
        }
    }
}
