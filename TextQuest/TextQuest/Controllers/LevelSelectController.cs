using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Linq;
using System.Threading.Tasks;
using TextQuest.Data;
using TextQuest.Data.Models;
using TextQuest.Models;
using Microsoft.Extensions.Caching.Memory;

namespace TextQuest.Controllers
{
    public class LevelSelectController : Controller
    {

        public ILevel _level;
        public IMemoryCache _memoryCache;
        public IAuthentication _authentication;
        public LevelSelectController(
                                    ILevel level,IMemoryCache memoryCache,IAuthentication authentication)
        {
            _level = level;
            _memoryCache = memoryCache;
            _authentication = authentication;
        }

        public IActionResult Index()
        {
            //  UserSingleton user = UserSingleton.getInstance();
            //Random rnd = new Random((int)DateTime.Now.Ticks);
            //int id = rnd.Next(1000000);
            // HttpContext.Session.Set<int>(CacheKeys.SessionId, id);
            
            // Вот твоя проверка пользователя
            // Id пользователя
            int userId;
            // Id сессии
            string sessionId = HttpContext.Session.Id;
            // Пытаемся получить данные из кэша
            if (!_memoryCache.TryGetValue(CacheKeys.User + sessionId, out userId))
            {
                // если время истекло, то пусть заново входит
                RedirectToAction("Index", "Log");
            } 
            // Вот твой пользователь
           Authentication mainUser =  _authentication.GetUser(userId);
            // Дальше делай то, что тебе нужно
                var model = new LevelListModel()
            {
                Levels = _level.GetLevelsLike("").ToList()

            };

            return View(model);

        }

        public IActionResult GetLevelObjects()
        {
            return PartialView("_GetLevels");
        }

        public IActionResult GetLevelList()
        {
            StreamReader sr = new StreamReader(Request.Body);
            string data = sr.ReadToEnd();
            var items = data.Split('&');

            //temp Variables
            string query = items[0].Split('=')[1];
            int sort = Int32.Parse(items[1].Split('=')[1]);
            int order = Int32.Parse(items[2].Split('=')[1]);
            Encoding e = Encoding.UTF8;
            query = System.Web.HttpUtility.UrlDecode(query, e);
            //string s = Encoding.UTF8.GetString(Encoding.Unicode.GetBytes(query));
            //query = Encoding.UTF8.GetString(array);


            var tempLevels = _level.GetLevelsLike(query).ToList();
            
            if (order == 0)
                switch (sort)
                {
                    case 0:
                        tempLevels = tempLevels.OrderBy(level => level.Name).ToList();
                        break;
                    case 1:
                        tempLevels = tempLevels.OrderBy(level => level.Creator).ToList();
                        break;
                    case 2:
                        tempLevels = tempLevels.OrderBy(level => level.Views).ToList();
                        break;
                    case 3:
                        tempLevels = tempLevels.OrderBy(level => level.Likes).ToList();
                        break;
                    default:
                        tempLevels = tempLevels.OrderBy(level => level.Dislikes).ToList();
                        break;
                }
            else
                switch (sort)
                {
                    case 0:
                        tempLevels = tempLevels.OrderByDescending(level => level.Name).ToList();
                        break;
                    case 1:
                        tempLevels = tempLevels.OrderByDescending(level => level.Creator).ToList();
                        break;
                    case 2:
                        tempLevels = tempLevels.OrderByDescending(level => level.Views).ToList();
                        break;
                    case 3:
                        tempLevels = tempLevels.OrderByDescending(level => level.Likes).ToList();
                        break;
                    default:
                        tempLevels = tempLevels.OrderByDescending(level => level.Dislikes).ToList();
                        break;
                }

            var model = new LevelListModel()
            {
                Levels = tempLevels

            };
            return PartialView("_GetLevels", model);
            //return View(model);
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
