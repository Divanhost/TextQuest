using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TextQuest.Data;
using TextQuest.Data.Models;

namespace TextQuest.Models
{
    public class SceneListModel:PageModel
    {
        public List<SceneModel> Scenes;
        public SceneModel CurrentScene;
        public Inventory Inventory;
        public List<InventoryObjectModel> InventoryItems;
        public int RemainingTime;
        public int? LevelId;
    }
}
