using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TextQuest.Data;

namespace TextQuest.Models
{
    public class SceneModel
    {
        public int Id;
        public string BackgroundImageUrl;
        public string Description;
        public IEnumerable<SceneObject> SceneObjects;
        public int UpperSceneId;
        public int DownSceneId;
        public int LeftSceneId;
        public int RightSceneId;
        public int InnerSceneId;
    }
}
