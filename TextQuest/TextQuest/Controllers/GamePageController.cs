using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TextQuest.Data;
using TextQuest.Models;

namespace TextQuest.Controllers
{
    public class GamePageController : Controller
    {
        private IScene _scene;
        public GamePageController(IScene scene)
        {
            _scene = scene;
        }

      
        
        public IActionResult Index()
        {
            var scenes = _scene.GetAll();
            var listingResult = scenes.Select(result => new SceneModel
            {
                Id = result.Id,
                Description = result.Description,
                BackgroundImageUrl = result.BackgroundImageUrl,
                SceneObjects = result.SceneObjects.Where(so => !so.IsSpawned).OrderByDescending(s => s.z),
                SpawnedSceneObjects = result.SceneObjects.Where(so => so.IsSpawned).OrderByDescending(s => s.z),
                UpperSceneId = result.UpperSceneId,
                DownSceneId = result.DownSceneId,
                LeftSceneId = result.LeftSceneId,
                RightSceneId = result.RightSceneId,
                InnerSceneId = result.InnerSceneId
            });
            var curScene = listingResult.FirstOrDefault(s => s.Id == 1);

            var model = new SceneListModel()
            {
                Scenes = listingResult,
                CurrentScene = curScene,
            };

            return View(model);

        }
        public IActionResult GetSceneObjects()
        {
            ViewBag.Title = "Smth";
            return PartialView("_GetSceneObjects");
        }
        public void IncrementCount(int? iq)
        {
            int i = 0;
            i++;
        }

        [HttpPost]
        public IActionResult DisplaySpawn()
        {
            // 
            StreamReader sr = new StreamReader(Request.Body);
            string data = sr.ReadToEnd();

            string result = "Сообщение " + data;
            return Ok(result);

        }

    }
}
