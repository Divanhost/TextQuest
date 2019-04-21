using Microsoft.EntityFrameworkCore.Migrations;

namespace TextQuest.Data.Migrations
{
    public partial class Sceneentityrework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DownSceneId",
                table: "Scenes");

            migrationBuilder.DropColumn(
                name: "LeftSceneId",
                table: "Scenes");

            migrationBuilder.DropColumn(
                name: "RightSceneId",
                table: "Scenes");

            migrationBuilder.DropColumn(
                name: "UpperSceneId",
                table: "Scenes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DownSceneId",
                table: "Scenes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LeftSceneId",
                table: "Scenes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RightSceneId",
                table: "Scenes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpperSceneId",
                table: "Scenes",
                nullable: false,
                defaultValue: 0);
        }
    }
}
