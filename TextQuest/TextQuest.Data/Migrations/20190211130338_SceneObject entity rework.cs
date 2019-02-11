using Microsoft.EntityFrameworkCore.Migrations;

namespace TextQuest.Data.Migrations
{
    public partial class SceneObjectentityrework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AlternativeImageUrl",
                table: "SceneObjects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "SceneObjects",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlternativeImageUrl",
                table: "SceneObjects");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "SceneObjects");
        }
    }
}
