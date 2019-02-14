using Microsoft.EntityFrameworkCore.Migrations;

namespace TextQuest.Data.Migrations
{
    public partial class bugfixwithinteraction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
