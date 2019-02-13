using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextQuest.Models
{
    public class SceneListModel:PageModel
    {
        public IEnumerable<SceneModel> Scenes;
        public SceneModel CurrentScene;
        public string Message { get; set; }
        public void ChangeState(int id)
        {
            var sobj = CurrentScene.SceneObjects.FirstOrDefault(so => so.Id == id);
            var sobj2 = CurrentScene.SpawnedSceneObjects.FirstOrDefault(so => so.Id == 6);

            
            sobj = sobj2;
        }

        public void IncrementCount()
        {
            int i = 1;
            i++;
        }
    }
}
