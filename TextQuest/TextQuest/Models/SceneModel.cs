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
        public List<SceneObject> SceneObjects;
        public List<SceneObject> SpawnedSceneObjects;
        public int LevelId;
    }
}
