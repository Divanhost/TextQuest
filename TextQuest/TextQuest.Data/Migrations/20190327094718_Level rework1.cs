using Microsoft.EntityFrameworkCore.Migrations;

namespace TextQuest.Data.Migrations
{
    public partial class Levelrework1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Interactions_LevelId",
                table: "Interactions",
                column: "LevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interactions_Levels_LevelId",
                table: "Interactions",
                column: "LevelId",
                principalTable: "Levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interactions_Levels_LevelId",
                table: "Interactions");

            migrationBuilder.DropIndex(
                name: "IX_Interactions_LevelId",
                table: "Interactions");
        }
    }
}
