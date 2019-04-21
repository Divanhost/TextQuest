using Microsoft.EntityFrameworkCore.Migrations;

namespace TextQuest.Data.Migrations
{
    public partial class trytobugfix4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SetOfInteractions",
                table: "SetOfInteractions");

            migrationBuilder.RenameTable(
                name: "SetOfInteractions",
                newName: "Interactions");

            migrationBuilder.AlterColumn<int>(
                name: "TargetObjectId",
                table: "Interactions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "TargetInventoryObjectId",
                table: "Interactions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "InteractingObjectId",
                table: "Interactions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "InteractingInventoryObjectId",
                table: "Interactions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Interactions",
                table: "Interactions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_InteractingInventoryObjectId",
                table: "Interactions",
                column: "InteractingInventoryObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_InteractingObjectId",
                table: "Interactions",
                column: "InteractingObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_TargetInventoryObjectId",
                table: "Interactions",
                column: "TargetInventoryObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_TargetObjectId",
                table: "Interactions",
                column: "TargetObjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interactions_InventoryObjects_InteractingInventoryObjectId",
                table: "Interactions",
                column: "InteractingInventoryObjectId",
                principalTable: "InventoryObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Interactions_SceneObjects_InteractingObjectId",
                table: "Interactions",
                column: "InteractingObjectId",
                principalTable: "SceneObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Interactions_InventoryObjects_TargetInventoryObjectId",
                table: "Interactions",
                column: "TargetInventoryObjectId",
                principalTable: "InventoryObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Interactions_SceneObjects_TargetObjectId",
                table: "Interactions",
                column: "TargetObjectId",
                principalTable: "SceneObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interactions_InventoryObjects_InteractingInventoryObjectId",
                table: "Interactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Interactions_SceneObjects_InteractingObjectId",
                table: "Interactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Interactions_InventoryObjects_TargetInventoryObjectId",
                table: "Interactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Interactions_SceneObjects_TargetObjectId",
                table: "Interactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Interactions",
                table: "Interactions");

            migrationBuilder.DropIndex(
                name: "IX_Interactions_InteractingInventoryObjectId",
                table: "Interactions");

            migrationBuilder.DropIndex(
                name: "IX_Interactions_InteractingObjectId",
                table: "Interactions");

            migrationBuilder.DropIndex(
                name: "IX_Interactions_TargetInventoryObjectId",
                table: "Interactions");

            migrationBuilder.DropIndex(
                name: "IX_Interactions_TargetObjectId",
                table: "Interactions");

            migrationBuilder.RenameTable(
                name: "Interactions",
                newName: "SetOfInteractions");

            migrationBuilder.AlterColumn<int>(
                name: "TargetObjectId",
                table: "SetOfInteractions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TargetInventoryObjectId",
                table: "SetOfInteractions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InteractingObjectId",
                table: "SetOfInteractions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InteractingInventoryObjectId",
                table: "SetOfInteractions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SetOfInteractions",
                table: "SetOfInteractions",
                column: "Id");
        }
    }
}
