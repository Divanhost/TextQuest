using Microsoft.EntityFrameworkCore.Migrations;

namespace TextQuest.Data.Migrations
{
    public partial class Multipleinnerscenesincoming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InnerSceneId",
                table: "Scenes");

            migrationBuilder.AddColumn<int>(
                name: "SceneId",
                table: "Scenes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InnerPassSceneID",
                table: "SceneObjects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Scenes_SceneId",
                table: "Scenes",
                column: "SceneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scenes_Scenes_SceneId",
                table: "Scenes",
                column: "SceneId",
                principalTable: "Scenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scenes_Scenes_SceneId",
                table: "Scenes");

            migrationBuilder.DropIndex(
                name: "IX_Scenes_SceneId",
                table: "Scenes");

            migrationBuilder.DropColumn(
                name: "SceneId",
                table: "Scenes");

            migrationBuilder.DropColumn(
                name: "InnerPassSceneID",
                table: "SceneObjects");

            migrationBuilder.AddColumn<int>(
                name: "InnerSceneId",
                table: "Scenes",
                nullable: false,
                defaultValue: 0);
        }
    }
}
