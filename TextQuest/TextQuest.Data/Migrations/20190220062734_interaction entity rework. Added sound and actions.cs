using Microsoft.EntityFrameworkCore.Migrations;

namespace TextQuest.Data.Migrations
{
    public partial class interactionentityreworkAddedsoundandactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sound",
                table: "Interactions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialEvent",
                table: "Interactions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sound",
                table: "Interactions");

            migrationBuilder.DropColumn(
                name: "SpecialEvent",
                table: "Interactions");
        }
    }
}
