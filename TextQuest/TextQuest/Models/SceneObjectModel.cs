using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TextQuest.Data;

namespace TextQuest.Models
{
    public class SceneObjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
        public bool IsPickable { get; set; }
        public bool IsSpawned { get; set; }
        public bool IsInnerPass { get; set; }
        public bool HasAction { get; set; }
        public InventoryObject AssociatedInventoryObject { get; set; }
        public SceneObject AssociatedSceneObject { get; set; }
        public string ImageUrl { get; set; }
    }
}
