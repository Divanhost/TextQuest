using Microsoft.EntityFrameworkCore.Migrations;

namespace TextQuest.Data.Migrations
{
    public partial class trytobugfix3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Interactions",
                table: "Interactions");

            migrationBuilder.RenameTable(
                name: "Interactions",
                newName: "SetOfInteractions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SetOfInteractions",
                table: "SetOfInteractions",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SetOfInteractions",
                table: "SetOfInteractions");

            migrationBuilder.RenameTable(
                name: "SetOfInteractions",
                newName: "Interactions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Interactions",
                table: "Interactions",
                column: "Id");
        }
    }
}
