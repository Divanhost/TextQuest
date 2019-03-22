using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TextQuest.Data
{
    public class Scene
    {
        public int Id { get; set; }
        [Required]
        public string BackgroundImageUrl { get; set; }
        [Required]
        public string Description { get; set; }
        // Set of objects, that belongs to the scene
        public IEnumerable<SceneObject> SceneObjects { get; set; }
        public int LevelId { get; set; }
    }
}