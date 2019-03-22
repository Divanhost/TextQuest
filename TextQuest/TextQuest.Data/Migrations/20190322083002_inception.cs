using Microsoft.EntityFrameworkCore.Migrations;

namespace TextQuest.Data.Migrations
{
    public partial class inception : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LevelId",
                table: "Scenes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LevelId",
                table: "InventoryObjects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SceneId",
                table: "Interactions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LevelId",
                table: "Scenes");

            migrationBuilder.DropColumn(
                name: "LevelId",
                table: "InventoryObjects");

            migrationBuilder.DropColumn(
                name: "SceneId",
                table: "Interactions");
        }
    }
}
