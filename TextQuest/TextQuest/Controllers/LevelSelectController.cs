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


    }
}
