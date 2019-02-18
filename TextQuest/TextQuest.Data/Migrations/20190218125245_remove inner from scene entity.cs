using Microsoft.EntityFrameworkCore.Migrations;

namespace TextQuest.Data.Migrations
{
    public partial class removeinnerfromsceneentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SceneId",
                table: "Scenes",
                nullable: true);

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
    }
}
