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
        public bool HasAction { get; set; }
        public InventoryObject AssociatedInventoryObject { get; set; }
    }
}