using Microsoft.EntityFrameworkCore.Migrations;

namespace TextQuest.Data.Migrations
{
    public partial class Sceneentityrework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Scenes",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "BackgroundImageUrl",
                table: "Scenes",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Scenes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BackgroundImageUrl",
                table: "Scenes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
