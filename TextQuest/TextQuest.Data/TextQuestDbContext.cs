using Microsoft.EntityFrameworkCore;
using System;

namespace TextQuest.Data
{
    public class TextQuestDbContext:DbContext
    {
        public TextQuestDbContext(DbContextOptions options) : base(options){ }
        public DbSet<Scene> Scenes { get; set; }
        public DbSet<SceneObject> SceneObjects { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<InventoryObject> InventoryObjects { get; set; }

        public void FirstOrDefault()
        {
            throw new NotImplementedException();
        }

        public DbSet<Interaction> Interactions { get; set; }

    }
}
