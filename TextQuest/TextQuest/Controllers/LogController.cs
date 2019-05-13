using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TextQuest.Data;
using TextQuest.Data.Models;
using TextQuest.Models;

namespace TextQuest.Controllers
{
    public class LogController:Controller
    {
        public IAuthentication _authentication;
        public IMemoryCache _memoryCache;
        public LogController(
                                    IAuthentication authentication, IMemoryCache memoryCache)
        {
            _authentication = authentication;
            _memoryCache = memoryCache;
        }
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                string sessionId = HttpContext.Session.Id;
                _memoryCache.Remove(CacheKeys.Level + sessionId);
                _memoryCache.Remove(CacheKeys.Inventory + sessionId);
            }
            catch
            {

            }
            //  UserSingleton user = UserSingleton.getInstance();
            Random rnd = new Random((int)DateTime.Now.Ticks);
            int id = rnd.Next(1000000);
            HttpContext.Session.Set<bool>(CacheKeys.LoggedIn, false);
            // HttpContext.Session.LoadAsync();

            return View(new LogModel());

        }


        [HttpPost]
        public IActionResult Index(LogModel model)
        {
            if (ModelState.IsValid && model.Password == model.PasswordConfirm &&model.Password !=null)
            {
                // User user = new User { Email = model.Username, UserName = model.Email, Year = model.Year };
                Authentication user = new Authentication { Login = model.Username, Password = model.Password, AccessLevel = 0, AssociatedInventory = 0 };
                // добавляем пользователя
                _authentication.AddUser(user);
                HttpContext.Session.Set<bool>(CacheKeys.LoggedIn, true);
                return RedirectToAction("Index", "LevelSelect");
            }
            return View(model);
        }
        /// <summary>
        /// ?????????????????????
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Skip()
        {
                return RedirectToAction("Index", "GamePage");
        }
        [HttpPost]
        public IActionResult Enter(LogModel model)
        {
            if (_authentication.LoginIsValid(model.Username, model.Password))
            {
                HttpContext.Session.Set<bool>(CacheKeys.LoggedIn, true);
                return RedirectToAction("Index", "LevelSelect");
            }
            else
            {
                return RedirectToAction("Index", "Log");
            }
        }
    }
}
