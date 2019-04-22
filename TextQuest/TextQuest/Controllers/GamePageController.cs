using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
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
    public class GamePageController : Controller
    {
        private IScene _scene;
        private ISceneObject _sceneObject;
        private IInteraction _interaction;
        public IInventory _inventory;
        public IInventory_InventoryObject _inventoryHelper;
        public IInventoryObject _inventoryObject;
        public ILevel _level;
        public IMemoryCache _memoryCache;
        
        public GamePageController(IScene scene,
                                    ISceneObject sceneObject,
                                    IInteraction interaction,
                                    IInventory inventory,
                                    IInventory_InventoryObject inventoryHelper,
                                    IInventoryObject inventoryObject,
                                    ILevel level,
                                    IMemoryCache memoryCache)
        {
            _scene = scene;
            _sceneObject = sceneObject;
            _interaction = interaction;
            _inventory = inventory;
            _inventoryHelper = inventoryHelper;
            _inventoryObject = inventoryObject;
            _level = level;
            _memoryCache = memoryCache;
            
        }
        public LevelModel level;
        public List<InventoryObjectModel> userInventory;
        public IActionResult Index(int? lvlid = 1, int? id = 4)
        {
            level = null;
            userInventory = null;
            CacheLoad(lvlid ?? default(int));
            Inventory inv = new Inventory();
            // Текущая сцена
            var currentScene = level.Scenes.FirstOrDefault(sc => sc.Id == id);

            var model = new SceneListModel()
            {
                Scenes = level.Scenes,
                CurrentScene = currentScene,
                InventoryItems = userInventory,
                Inventory = inv,
                RemainingTime = 900,
                LevelId = lvlid
            };
            return View(model);
        }
        public IActionResult GetSceneObjects()
        {
            return PartialView("_GetSceneObjects");
        }

        // Click handler
        [HttpPost]
        public IActionResult HandleSceneObjectClick()
        {
            // Read request
            StreamReader sr = new StreamReader(Request.Body);
            string data = sr.ReadToEnd();
            var items = data.Split('&');

            //temp Variables
            int id = Int32.Parse(items[0].Split('=')[1]);
            int sceneId = Int32.Parse(items[1].Split('=')[1]);
            int inventoryId = Int32.Parse(items[2].Split('=')[1]);
            int levelId = Int32.Parse(items[3].Split('=')[1]);
            int? selectedInventoryObjectId = null;
            string temp = items[4].Split('=')[1];
            if (temp != "undefined")
            {
                selectedInventoryObjectId = Int32.Parse(temp);
            }
            //
            //
            CacheLoad(levelId);
            //
            //Scene related Variables;
            var scene = level.Scenes.FirstOrDefault(sc => sc.Id == sceneId);
            var sceneObject = scene.SceneObjects.FirstOrDefault(so => so.Id == id);
            if (sceneObject == null)
            {
                return Ok();
            }
            bool isPickable = sceneObject.IsPickable;
            bool hasAction = sceneObject.HasAction;
            bool isInnerPass = sceneObject.IsInnerPass;
            //
            // Responce to client
            var responces = new List<Responce>();
            //
            // Main Logic
            if (isInnerPass)
            {
                int _nextSceneId = sceneObject.InnerPassSceneID;
                responces.Add(new Responce { interactionType = 1, nextSceneId = _nextSceneId });
            }
            if (hasAction || isPickable)
            {
                var interactions = level.Interactions.Where(i => i.TargetObjectId == id);
                foreach (var interaction in interactions)
                {
                    if (interaction.IsAllowed)
                    {
                        if (interaction.InteractingInventoryObjectId != selectedInventoryObjectId)
                        {
                           // responces.Add(new Responce { interactionType = -1 });
                        }
                        else
                        {
                            if (selectedInventoryObjectId != null)
                                userInventory.Remove(level.InventoryObjects.FirstOrDefault(io => io.Id == selectedInventoryObjectId));
                            if (isPickable)
                            {
                                PickItem(sceneObject, scene, interaction, responces);
                            }
                            if (hasAction)
                            {
                                DoActions(sceneObject, scene, interaction, responces);
                            }
                        }
                    }
                    else
                    {
                        responces.Add(new Responce { interactionType = -1 });
                    }
                }
            }
            if (!hasAction && !isInnerPass && !isPickable)
            {
                return Ok(new { interactionType = -1, id, responces });
            }
            return Ok(responces);

        }

        // Side actions handlers
        public IActionResult HandleDescriptionShowing()
        {
            StreamReader sr = new StreamReader(Request.Body);
            string data = sr.ReadToEnd();

            int id = Int32.Parse(data);
            return Ok(_sceneObject.GetSceneObject(id).Description);
        }
        public IActionResult HandleInventoryInfoShowing()
        {
            StreamReader sr = new StreamReader(Request.Body);
            string data = sr.ReadToEnd();

            int id = Int32.Parse(data);
            return Ok(new { name = _inventoryObject.GetName(id), description = _inventoryObject.GetDescription(id) });

        }
        public IActionResult HandleShowInfo()
        {
            StreamReader sr = new StreamReader(Request.Body);
            string data = sr.ReadToEnd();

            int id = Int32.Parse(data);
            return Ok(new { name = _sceneObject.GetName(id), description = _sceneObject.GetDescription(id) });
        }
      

        // Load level from db
        public LevelModel LoadLevel(int? lvlid)
        {
            var tmp = _level.GetLevel(lvlid ?? default(int));
            foreach (var scene in tmp.Scenes)
            {
                scene.SceneObjects = _scene.GetSceneObjects(scene.Id);
            }
            // Преобразование сцен в модель
            var listingScene = tmp.Scenes.Select(sc => new SceneModel
            {
                Id = sc.Id,
                Description = sc.Description,
                BackgroundImageUrl = sc.BackgroundImageUrl,
                SceneObjects = sc.SceneObjects.Where(so => !so.IsSpawned).OrderByDescending(s => s.z).ToList(),
                SpawnedSceneObjects = sc.SceneObjects.Where(so => so.IsSpawned).OrderByDescending(s => s.z).ToList(),
                LevelId = lvlid ?? default(int)
            }).ToList();
            // Преобразование предметов инвенторя в модель
            var listinginventoryObjects = tmp.InventoryObjects.Select(sc => new InventoryObjectModel
            {
                Id = sc.Id,
                Name = sc.Name,
                Decription = sc.Decription,
                IsInfinite = sc.IsInfinite,
                ImageUrl = sc.ImageUrl
            }).ToList();
            // Заполнение модели уровня
            level = new LevelModel
            {
                Id = tmp.Id,
                Name = tmp.Name,
                Creator = tmp.Creator,
                Scenes = listingScene.ToList(),
                InventoryObjects = listinginventoryObjects.ToList(),
                Interactions = tmp.Interactions.ToList()
            };
            // Загрузка в кэш
            /*_memoryCache.Set(CacheKeys.Level, level,
                new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(15)));*/
            return level;
        }

        //  Picking item in inventory
        // Что быстрее: передавать больше данных через аргументы или производить более долгий поиск?
        public void PickItem(SceneObject sceneObject, SceneModel scene, Interaction interaction, List<Responce> responces)//(int id,int sceneId, List<Responce> responces)
        {
            //var interacton = level.Interactions.FirstOrDefault(i => i.TargetObjectId == sceneObject.Id);
            int inventoryItemId = interaction.TargetInventoryObjectId.Value;
            var inventoryObj = level.InventoryObjects.FirstOrDefault(io => io.Id == inventoryItemId);

            if (userInventory.FirstOrDefault(ui => ui.Id == inventoryItemId) == null)
            {
                userInventory.Add(level.InventoryObjects.FirstOrDefault(io => io.Id == inventoryItemId));
            }
            else
            {
                responces.Add(new Responce { interactionType = -1 }); // изменил 1 на -1 потому что ничего же не произойдет
                return;
            }
            var responce = new Responce()
            {
                interactionType = 0,
                oldId = sceneObject.Id,
                newId = inventoryItemId,
                Name = inventoryObj.Name,
                ImageUrl = inventoryObj.ImageUrl
            };
            if (!inventoryObj.IsInfinite)
            {
                scene.SceneObjects.Remove(sceneObject);
                responce.Action = 0;
            }
            else
            {
                responce.Action = 2;
            }
            responces.Add(responce);
        }
        //Do action or sequence of actions
        public void DoActions(SceneObject sceneObject, SceneModel scene, Interaction interacton, List<Responce> responces)
        {
            var associatedSceneObject = scene.SpawnedSceneObjects.FirstOrDefault(sso => sso.Id == interacton.InteractingObjectId);
            if (interacton.InteractingObjectId != sceneObject.Id)
            {
                //and interacting objects exists
                if (interacton.InteractingObjectId.HasValue)
                {
                    var responce = new Responce()
                    {
                        interactionType = 2,
                        oldId = sceneObject.Id,
                        newId = associatedSceneObject.Id,
                        Name = associatedSceneObject.Name,
                        Description = associatedSceneObject.Description,
                        x = associatedSceneObject.x,
                        y = associatedSceneObject.y,
                        z = associatedSceneObject.z,
                        ImageUrl = associatedSceneObject.ImageUrl,
                        Action = 1,
                        isValid = true,
                        isSpawn = interacton.IsSpawn,
                        SpecialEvent = interacton.SpecialEvent
                    };
                    responces.Add(responce);
                    scene.SpawnedSceneObjects.Add(sceneObject);
                    scene.SceneObjects.Add(associatedSceneObject);
                    if (!interacton.IsSpawn)
                        scene.SceneObjects.Remove(sceneObject);
                }
                else
                {
                    var responce = new Responce()
                    {
                        interactionType = 2,
                        Action = 0,
                        isValid = true
                    };
                    responces.Add(responce);
                    scene.SceneObjects.Remove(sceneObject);
                }
            }
            else
            //if interaction does not change object, but does some events
            if (interacton.SpecialEvent != null)
            {
                var responce = new Responce()
                {
                    interactionType = 2,
                    Action = 1,
                    isValid = true,
                    isSpawn = interacton.IsSpawn,
                    SpecialEvent = interacton.SpecialEvent
                };
                responces.Add(responce);
            }
            if (interacton.NextInteractionId.HasValue)
            {
                interacton = level.Interactions.FirstOrDefault(i => i.Id == interacton.NextInteractionId);
                int newId = interacton.TargetObjectId ?? default(int);
                sceneObject = scene.SceneObjects.FirstOrDefault(so => so.Id == newId);
                ; DoActions(sceneObject, scene, interacton, responces);
            }

        }
        public IActionResult Reset()
        {
            //UserSingleton.Reset();
            return Ok();
        }
        public void CacheLoad(int levelId)
        {
          /*  if (HttpContext.Session.Keys.Contains(CacheKeys.Level))
            {
                level = HttpContext.Session.Get<LevelModel>(CacheKeys.Level);
            }
            else
            {
                level = LoadLevel(levelId);
                HttpContext.Session.Set<LevelModel>(CacheKeys.Level, level);
            }
            if (HttpContext.Session.Keys.Contains(CacheKeys.Inventory))
            {
                userInventory = HttpContext.Session.Get<List<InventoryObjectModel>>(CacheKeys.Inventory);
            }
            else
            {
                userInventory = new List<InventoryObjectModel>();
                HttpContext.Session.Set<List<InventoryObjectModel>>(CacheKeys.Inventory, userInventory);
            }

            /**/

            // Кэширование загружаемого уровня и пребразование в LevelModel
            if (!_memoryCache.TryGetValue(CacheKeys.Level, out level))
            {
                level = LoadLevel(levelId);
                // Загрузка в кэш
                _memoryCache.Set(CacheKeys.Level, level,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(15)));
            }
            // Кэширование текущего инвентаря пользователя
            if (!_memoryCache.TryGetValue(CacheKeys.Inventory, out userInventory))
            {
                userInventory = new List<InventoryObjectModel>();
                _memoryCache.Set(CacheKeys.Inventory, userInventory,
               new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(30)));
            }
            
        }
    }

    public class Responce
    {
        public int interactionType { get; set; }
        public int oldId { get; set; }
        public int newId { get; set; }
        public int nextSceneId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
        public string ImageUrl { get; set; }
        public bool isValid { get; set; } //лишнее
        // 0 - remove, 1 -replace -1 -default
        public int Action = -1;
        public bool isSpawn; //лишнее
        public string SpecialEvent;
    }
    public static class CacheKeys
    {
        public static string Level { get { return "_level"; } }
        public static string Scene { get { return "_scene"; } }
        public static string SceneObject { get { return "_sceneObject"; } }
        public static string Interaction { get { return "_interaction"; } }
        public static string Inventory { get { return "_inventory"; } }
        public static string InventoryHelper { get { return "_inventoryHelper"; } }
        public static string InventoryObject { get { return "_inventoryObject"; } }
    }
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}