using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TextQuest.Data;
using TextQuest.Data.Models;
using TextQuest.Models;

namespace TextQuest.Controllers
{
    public class LevelSelectController : Controller
    {

        public ILevel _level;
        public LevelSelectController(
                                    ILevel level)
        {
            _level = level;
        }

        public IActionResult Index()
        {
            UserSingleton user = UserSingleton.getInstance();
            
            var model = new LevelListModel()
            {
                Levels = _level.GetLevelsLike("Ivanov").ToList()

            };

            return View(model);

        }

        public IActionResult GetLevelObjects()
        {
            return PartialView("_GetLevelObjects");
        }

        public IActionResult HandleLevelEntering()
        {

            StreamReader sr = new StreamReader(Request.Body);
            string data = sr.ReadToEnd();
            int lvlId = Int32.Parse(data);
            int _id = _level.GetLevel(lvlId).Scenes.OrderBy(s => s.Id).First().Id;
            return Ok(new { id =  _id});
        }

    }
}
