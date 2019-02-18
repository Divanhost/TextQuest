using System.ComponentModel.DataAnnotations;

namespace TextQuest.Data
{
    public class SceneObject
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
        public bool IsPickable { get; set; }
        public bool IsSpawned { get; set; }
        public bool IsInnerPass { get; set; }
        public bool HasAction { get; set; }
        public int InnerPassSceneID { get; set; }
        public InventoryObject AssociatedInventoryObject { get; set; }
        public SceneObject AssociatedSceneObject { get; set; }
        public string ImageUrl { get; set; }
    }
}