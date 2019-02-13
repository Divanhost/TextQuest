using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TextQuest.Data;

namespace TextQuest.Models
{
    public class SceneModel : PageModel
    {
        public int Id;
        public string BackgroundImageUrl;
        public string Description;
        public IEnumerable<SceneObject> SceneObjects;
        public IEnumerable<SceneObject> SpawnedSceneObjects;
        public int UpperSceneId;
        public int DownSceneId;
        public int LeftSceneId;
        public int RightSceneId;
        public int InnerSceneId;
    }
}
