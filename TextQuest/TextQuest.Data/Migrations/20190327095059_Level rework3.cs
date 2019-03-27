using Microsoft.EntityFrameworkCore.Migrations;

namespace TextQuest.Data.Migrations
{
    public partial class Levelrework3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_InventoryObjects_LevelId",
                table: "InventoryObjects",
                column: "LevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryObjects_Levels_LevelId",
                table: "InventoryObjects",
                column: "LevelId",
                principalTable: "Levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryObjects_Levels_LevelId",
                table: "InventoryObjects");

            migrationBuilder.DropIndex(
                name: "IX_InventoryObjects_LevelId",
                table: "InventoryObjects");
        }
    }
}
