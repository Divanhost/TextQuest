using Microsoft.AspNetCore.Mvc;
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
        public LogController(
                                    IAuthentication authentication)
        {
            _authentication = authentication;
        }
        [HttpGet]
        public IActionResult Index()
        {
            //  UserSingleton user = UserSingleton.getInstance();
            Random rnd = new Random((int)DateTime.Now.Ticks);
            int id = rnd.Next(1000000);
            HttpContext.Session.Set<int>(CacheKeys.SessionId, id);
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
                return RedirectToAction("Index", "LevelSelect");
            }
            else
            {
                return RedirectToAction("Index", "Log");
            }
        }
    }
}
