using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TextQuest.Data;
using TextQuest.Models;

namespace TextQuest.Controllers
{
    public class GamePageController:Controller
    {
        private IScene _scene;

        public GamePageController(IScene scene )
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
                SceneObjects = result.SceneObjects,
                UpperSceneId = result.UpperSceneId,
                DownSceneId = result.DownSceneId,
                LeftSceneId = result.LeftSceneId,
                RightSceneId = result.RightSceneId,
                InnerSceneId = result.InnerSceneId
            });
            var model = new SceneListModel()
            {
                Scenes = listingResult
            };
            return View(model);
        }
    }
}
