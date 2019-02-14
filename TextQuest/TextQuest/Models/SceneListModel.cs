using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TextQuest.Data;

namespace TextQuest.Models
{
    public class SceneListModel:PageModel
    {
        public IEnumerable<SceneModel> Scenes;
        public SceneModel CurrentScene;
        public Inventory inventory;
        
    }
}
