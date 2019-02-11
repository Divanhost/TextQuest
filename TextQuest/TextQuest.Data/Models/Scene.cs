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
        public IEnumerable<SceneObject> SceneObjects { get; set; }
        public int UpperSceneId { get; set; }
        public int DownSceneId { get; set; }
        public int LeftSceneId { get; set; }
        public int RightSceneId { get; set; }
        public int InnerSceneId { get; set; }
    }
}