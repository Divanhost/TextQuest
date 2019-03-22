using Microsoft.EntityFrameworkCore;
using System;
using TextQuest.Data.Models;

namespace TextQuest.Data
{
    public class TextQuestDbContext:DbContext
    {
        public TextQuestDbContext(DbContextOptions options) : base(options){ }
        public DbSet<Interaction> Interactions { get; set; }
        public DbSet<Scene> Scenes { get; set; }
        public DbSet<SceneObject> SceneObjects { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<InventoryObject> InventoryObjects { get; set; }
        public DbSet<Inventory_InventoryObject> Inventory_InventoryObjects { get; set; }
    }
}
