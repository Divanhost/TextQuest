using Microsoft.EntityFrameworkCore.Migrations;

namespace TextQuest.Data.Migrations
{
    public partial class Levelrework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "InventoryObjects",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Scenes_LevelId",
                table: "Scenes",
                column: "LevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scenes_Levels_LevelId",
                table: "Scenes",
                column: "LevelId",
                principalTable: "Levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scenes_Levels_LevelId",
                table: "Scenes");

            migrationBuilder.DropIndex(
                name: "IX_Scenes_LevelId",
                table: "Scenes");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "InventoryObjects",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
