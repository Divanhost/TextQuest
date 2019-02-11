using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TextQuest.Data.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SceneObjectId = table.Column<int>(nullable: false),
                    InventoryObjectId = table.Column<int>(nullable: false),
                    NextInteractionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Scenes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BackgroundImageUrl = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    UpperSceneId = table.Column<int>(nullable: false),
                    DownSceneId = table.Column<int>(nullable: false),
                    LeftSceneId = table.Column<int>(nullable: false),
                    RightSceneId = table.Column<int>(nullable: false),
                    InnerSceneId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scenes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventoryObjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Decription = table.Column<string>(nullable: false),
                    IsInfinite = table.Column<bool>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    InventoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryObjects_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SceneObjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    x = table.Column<int>(nullable: false),
                    y = table.Column<int>(nullable: false),
                    z = table.Column<int>(nullable: false),
                    IsPickable = table.Column<bool>(nullable: false),
                    HasAction = table.Column<bool>(nullable: false),
                    AssociatedInventoryObjectId = table.Column<int>(nullable: true),
                    SceneId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SceneObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SceneObjects_InventoryObjects_AssociatedInventoryObjectId",
                        column: x => x.AssociatedInventoryObjectId,
                        principalTable: "InventoryObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SceneObjects_Scenes_SceneId",
                        column: x => x.SceneId,
                        principalTable: "Scenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryObjects_InventoryId",
                table: "InventoryObjects",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SceneObjects_AssociatedInventoryObjectId",
                table: "SceneObjects",
                column: "AssociatedInventoryObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SceneObjects_SceneId",
                table: "SceneObjects",
                column: "SceneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interactions");

            migrationBuilder.DropTable(
                name: "SceneObjects");

            migrationBuilder.DropTable(
                name: "InventoryObjects");

            migrationBuilder.DropTable(
                name: "Scenes");

            migrationBuilder.DropTable(
                name: "Inventories");
        }
    }
}
