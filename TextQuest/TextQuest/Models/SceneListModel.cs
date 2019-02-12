using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextQuest.Models
{
    public class SceneListModel
    {
        public IEnumerable<SceneModel> Scenes;
        public SceneModel CurrentScene;
        public string Message { get; set; }
        public void OnGet()
        {
            Message = "Введите число";
        }
        
    }
}
