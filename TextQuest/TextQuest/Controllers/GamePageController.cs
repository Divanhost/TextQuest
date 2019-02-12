using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
                SceneObjects = result.SceneObjects.OrderByDescending(s => s.z),
                UpperSceneId = result.UpperSceneId,
                DownSceneId = result.DownSceneId,
                LeftSceneId = result.LeftSceneId,
                RightSceneId = result.RightSceneId,
                InnerSceneId = result.InnerSceneId
            });
            var model = new SceneListModel()
            {
                Scenes = listingResult,
                CurrentScene = listingResult.FirstOrDefault(s => s.Id == 1)
            };

            return View(model);

        }
        [HttpGet]
        public IActionResult Starting()
        {
            ViewBag.Message = "ZaWarudo";
            return View();
        }
        [HttpPost]
        public void ChangeRoom(int? direction)
        {
            ViewBag.Message = direction.ToString();
            /*switch (direction)
            {
                case 0:
                    {
                        Model.CurrentScene = Scenes.FirstOrDefault(s => s.Id == CurrentScene.LeftSceneId);
                        break;
                    }
                case 1:
                    {
                        CurrentScene = Scenes.FirstOrDefault(s => s.Id == CurrentScene.UpperSceneId);
                        break;
                    }
                case 2:
                    {
                        CurrentScene = Scenes.FirstOrDefault(s => s.Id == CurrentScene.RightSceneId);
                        break;
                    }
                case 3:
                    {
                        CurrentScene = Scenes.FirstOrDefault(s => s.Id == CurrentScene.DownSceneId);
                        break;
                    }
            }*/
        }
    }
}
