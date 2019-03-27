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
        // Location of Object
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
        // Can we pick it in inventory
        public bool IsPickable { get; set; }
        // Is It spawned object / replacing object
        public bool IsSpawned { get; set; }
        // Is it way in another scene
        public bool IsInnerPass { get; set; }
        // Does it have action
        public bool HasAction { get; set; }
        // Next scene id
        public int InnerPassSceneID { get; set; }
        public string ImageUrl { get; set; }
        public int? SceneId { get; set; }
    }
}