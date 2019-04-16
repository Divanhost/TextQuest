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
        private ISceneObject _sceneObject;
        private IInteraction _interaction;
        public IInventory _inventory;
        public IInventory_InventoryObject _inventoryHelper;
        public IInventoryObject _inventoryObject;
        public ILevel _level;
        public GamePageController(IScene scene,
                                    ISceneObject sceneObject,
                                    IInteraction interaction,
                                    IInventory inventory,
                                    IInventory_InventoryObject inventoryHelper,
                                    IInventoryObject inventoryObject,
                                    ILevel level)
        {
            _scene = scene;
            _sceneObject = sceneObject;
            _interaction = interaction;
            _inventory = inventory;
            _inventoryHelper = inventoryHelper;
            _inventoryObject = inventoryObject;
            _level = level;
        }

      
        public IActionResult Index(int? lvlid =1,int? id =4)
        {
            UserSingleton user = UserSingleton.getInstance();
            Inventory inventory = UserSingleton.getInventory();
            
            if (UserSingleton.GetScenes() == null)
            {
                var tmp = _level.GetLevel(lvlid ?? default(int));
                foreach(var scene in tmp.Scenes)
                {
                    scene.SceneObjects = _scene.GetSceneObjects(scene.Id);
                }
                var lsttmp = new LevelModel
                {
                    Id = tmp.Id,
                    Name = tmp.Name,
                    Creator = tmp.Creator,
                    Scenes = tmp.Scenes.ToList(),
                    InventoryObjects = tmp.InventoryObjects.ToList(),
                    Interactions = tmp.Interactions.ToList()
                };
                UserSingleton.AddLevel(lsttmp);
                UserSingleton.LoadScenes(lvlid ?? default(int));
                UserSingleton.LoadItems(lvlid ?? default(int));
                UserSingleton.LoadIteractions(lvlid ?? default(int));
            }

            var currentScene = UserSingleton.GetScene(id ?? default(int));
           
            var model = new SceneListModel()
            {
                Scenes = UserSingleton.GetScenes(),
                CurrentScene = currentScene,
                Inventory = inventory,
                InventoryItems = UserSingleton.GetInventoryItems(),
                RemainingTime = UserSingleton.remainingTime
            };

            return View(model);

        }
        public IActionResult GetSceneObjects()
        {
            return PartialView("_GetSceneObjects");
        }
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
            int? selectedInventoryObjectId = null;

            string temp = items[3].Split('=')[1];
            if(temp != "undefined")
            {
                selectedInventoryObjectId = Int32.Parse(temp);
            }

            var responces = new List<Responce>();
            
            //Scene object related Variables;
            var sceneObject = UserSingleton.GetScene(sceneId).SceneObjects.FirstOrDefault(so => so.Id == id);
            if (sceneObject == null)
            {
                return Ok();
            }
            bool isPickable = sceneObject.IsPickable;
            bool hasAction = sceneObject.HasAction;
            bool isInnerPass = sceneObject.IsInnerPass;
            if (isPickable)
            {
               // PickItem(sceneObject.Id,sceneId,responces);
            }
            if (isInnerPass)
            {
                int _nextSceneId = sceneObject.InnerPassSceneID;
                responces.Add(new Responce { interactionType =1,nextSceneId = _nextSceneId});
            }
            if (hasAction || isPickable)
            {
                var interactions = UserSingleton.GetInteractionsBySceneObject(id);
                foreach (var interaction in interactions)
                {
                    if (interaction.IsAllowed)
                    {
                        if (interaction.InteractingInventoryObjectId != selectedInventoryObjectId)
                        {
                            responces.Add(new Responce { interactionType = -1 });
                        }
                        else
                        {
                            if (selectedInventoryObjectId != null)
                                UserSingleton.RemoveInventoryItem(selectedInventoryObjectId ?? default(int));
                            if (isPickable)
                            {
                                PickItem(sceneObject.Id, sceneId, responces);
                            }
                            if (hasAction)
                            {
                                DoActions(responces, id, sceneId, interaction.Id);
                            }
                        }
                    }
                    else
                    {
                        responces.Add(new Responce { interactionType = -1 });
                    }
                }
               // return Ok(new { interactionType = 2, id, responces });
            }
            if(!hasAction&&!isInnerPass&&!isPickable) //
            {
                
                return Ok(new { interactionType = -1, id, responces });
            }
            return Ok(responces);
            //Choose the way
            // We can pick item in inventory
            /*
            if (isPickable)
            {
                var interacton = _interaction.GetInteractionsBySceneObject(id).First(); ///////////////
                int inventoryItemId = interacton.InteractingInventoryObjectId.Value;
                if (UserSingleton.GetInventoryObject(inventoryItemId) == null)
                {
                    UserSingleton.AddInventoryObject(_inventoryObject.GetInventoryObject(inventoryItemId));
                }
                else
                {
                    var responces = new List<Responce>();
                    return Ok(new { interactionType = 2, id, responces });
                }
                var responce = new Responce()
                {
                    oldId = id,
                    newId = inventoryItemId,
                    ImageUrl = UserSingleton.GetInventoryObject(inventoryItemId).ImageUrl,
                    Name = UserSingleton.GetInventoryObject(inventoryItemId).Name
                };
                if (!UserSingleton.GetInventoryObject(inventoryItemId).IsInfinite)
                {
                    UserSingleton.GetScene(sceneId).SceneObjects.Remove(UserSingleton.GetScene(sceneId).SceneObjects.FirstOrDefault(so => so.Id == id));
                    return Ok(new { interactionType = 0, id,remove=true, responce });
                }
                else
                {
                    return Ok(new { interactionType = 0, id,remove = false, responce });
                }
            }
            
            // It is the pass into a new Scene
            else if (isInnerPass)
            {
                int nextSceneId = UserSingleton.GetScene(sceneId).SceneObjects.FirstOrDefault(s=>s.Id ==id).InnerPassSceneID;
                return Ok(new { interactionType = 1, nextSceneId });
            }
            
            //It has action 
            else if (hasAction)
            {
                var responces = new List<Responce>();
                var interactions = _interaction.GetInteractionsBySceneObject(id);
                foreach (var interaction in interactions)
                {
                    if (interaction.IsAllowed)
                    {
                        if (interaction.InteractingInventoryObjectId != selectedInventoryObjectId)
                        {
                            responces.Add(new Responce { isValid = false });
                        }
                        else
                        {
                            if (selectedInventoryObjectId != null)
                                UserSingleton.RemoveInventoryObject(selectedInventoryObjectId ?? default(int));

                            DoActions(responces, id, sceneId,interaction.Id);
                        }
                    }
                }
                return Ok(new { interactionType = 2, id, responces });
            }*/
          /*  else
            {
                var responces = new List<Responce>();
                return Ok(new { interactionType = 2, id, responces});
            }*/
        }

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
            return Ok(new { name = _sceneObject.GetName(id),description = _sceneObject.GetDescription(id)});
        }
        public IActionResult HandleRemainingTime()
        {
            StreamReader sr = new StreamReader(Request.Body);
            string data = sr.ReadToEnd();

            int rt = Int32.Parse(data);
            UserSingleton.remainingTime = rt;
            return Ok();
        }
        public void PickItem(int id,int sceneId, List<Responce> responces)
        {
            var interacton = UserSingleton.GetInteractionsBySceneObject(id).First();
            int inventoryItemId = interacton.TargetInventoryObjectId.Value;
            if (UserSingleton.GetInventoryItem(inventoryItemId) == null)
            {
                UserSingleton.AddInventoryItem(UserSingleton.GetInventoryObject(inventoryItemId));
            }
            else
            {
                responces.Add(new Responce { interactionType = 1});
            }
            var responce = new Responce()
            {
                interactionType = 0,
                oldId = id,
                newId = inventoryItemId,
                ImageUrl = UserSingleton.GetInventoryObject(inventoryItemId).ImageUrl,
                Name = UserSingleton.GetInventoryObject(inventoryItemId).Name
            };
            if (!UserSingleton.GetInventoryObject(inventoryItemId).IsInfinite)
            {
                UserSingleton.GetScene(sceneId).SceneObjects.Remove(UserSingleton.GetScene(sceneId).SceneObjects.FirstOrDefault(so => so.Id == id));
                //return Ok(new { interactionType = 0, id, remove = true, responce });
                responce.Action = 0;
            }
            else
            {
                responce.Action = 2;
               // return Ok(new { interactionType = 0, id, remove = false, responce });
            }
            responces.Add(responce);
        }
        //Do action or sequence of actions
        public void DoActions(List<Responce> responces,int id,int sceneId,int interactionId)
        {
            var sceneObject = UserSingleton.GetScene(sceneId).SceneObjects.FirstOrDefault(so => so.Id == id);
            var interacton = UserSingleton.GetInteraction(interactionId); /////////
            var associatedSceneObject = UserSingleton.GetScene(sceneId).SpawnedSceneObjects.FirstOrDefault(sso => sso.Id == _interaction.GetInteractingSceneObjectId(interacton.Id));
            //if interaction change object
            if (interacton.InteractingObjectId != id)
            {
                //and interactingobjects exists
                if (interacton.InteractingObjectId.HasValue)
                {
                    var responce = new Responce()
                    {
                        interactionType =2,
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
                    UserSingleton.GetScene(sceneId).SpawnedSceneObjects.Add(UserSingleton.GetScene(sceneId).SceneObjects.FirstOrDefault(so => so.Id == id));
                    UserSingleton.GetScene(sceneId).SceneObjects.Add(UserSingleton.GetScene(sceneId).SpawnedSceneObjects.FirstOrDefault(so => so.Id == associatedSceneObject.Id));
                    if (!interacton.IsSpawn)
                        UserSingleton.GetScene(sceneId).SceneObjects.Remove(UserSingleton.GetScene(sceneId).SceneObjects.FirstOrDefault(so => so.Id == id));
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
                    UserSingleton.GetScene(sceneId).SceneObjects.Remove(UserSingleton.GetScene(sceneId).SceneObjects.FirstOrDefault(so => so.Id == id));
                }
            }
            else
            //if interaction does not change object, but does some events
            if(interacton.SpecialEvent != null)
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
                interacton = _interaction.GetInteraction(interacton.NextInteractionId);
                int newId = interacton.TargetObjectId ?? default(int);
                DoActions(responces, newId,sceneId,interacton.Id);
            }

        }
        public IActionResult Reset()
        {
            UserSingleton.Reset();
            return Ok();
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
    
    public class UserSingleton
    {
        private static UserSingleton instance;
        private static Inventory Inventory;
        private static List<LevelModel> Levels;
        private static List<SceneModel> Scenes;
        private static List<InventoryObjectModel> InventoryObjects;
        private static List<Interaction> Interactions;
        private static List<InventoryObjectModel> InventoryItems;
        public static int remainingTime;
        private UserSingleton() { }
        public static UserSingleton getInstance()
        {
            if (instance == null)
            {
                instance = new UserSingleton();
                Inventory = new Inventory();
                Levels = new List<LevelModel>();
                Scenes = new List<SceneModel>();
                InventoryObjects = new List<InventoryObjectModel>();
                Interactions = new List<Interaction>();
                InventoryItems = new List<InventoryObjectModel>();

                remainingTime = 900;
            }
            return instance;
        }

        public static void AddLevel(LevelModel level)
        {
            Levels.Add(level);
        }
        // Загрузка сцен
        public static void LoadScenes(int lvlid)
        {
            var scenes = Levels.FirstOrDefault(lvl=>lvl.Id == lvlid).Scenes;
            var listingScene = scenes.Select(sc => new SceneModel
            {
                Id = sc.Id,
                Description = sc.Description,
                BackgroundImageUrl = sc.BackgroundImageUrl,
                SceneObjects = sc.SceneObjects.Where(so => !so.IsSpawned).OrderByDescending(s => s.z).ToList(),
                SpawnedSceneObjects = sc.SceneObjects.Where(so => so.IsSpawned).OrderByDescending(s => s.z).ToList()
            }).ToList();
            Scenes.AddRange(listingScene);
        }
        // Загрузка подбираемых предметов
        public static void LoadItems(int lvlid)
        {
            var inventoryObjects = Levels.FirstOrDefault(lvl => lvl.Id == lvlid).InventoryObjects;
            var listinginventoryObjects = inventoryObjects.Select(sc => new InventoryObjectModel
            {
                Id = sc.Id,
                Name = sc.Name,
                Decription = sc.Decription,
                IsInfinite = sc.IsInfinite,
                ImageUrl = sc.ImageUrl
            }).ToList();
            InventoryObjects.AddRange(listinginventoryObjects);
        }
        // Загрузка взаимодействий
        public static void LoadIteractions(int lvlid)
        {
            var interactions = Levels.FirstOrDefault(lvl => lvl.Id == lvlid).Interactions;
            Interactions.AddRange(interactions);
        }
     
        public static SceneModel GetScene(int id)
        {
            if (Scenes.Count > 0)
            {
                if (Scenes.Any(s => s.Id == id))
                {
                    return Scenes.FirstOrDefault(s => s.Id == id);
                }
            }
            return null;
        }
        
        public static List<SceneModel> GetScenes()
        {
            if(Scenes.Count == 0)
            {
                return null;
            }
            return Scenes;
        }
        
        public static List<InventoryObjectModel> GetInventoryItems()
        {
            return InventoryItems;
        }
        public static InventoryObjectModel GetInventoryItem(int id)
        {
            if (InventoryItems.Count > 0)
            {
                if (InventoryItems.Any(s => s.Id == id))
                {
                    return InventoryItems.FirstOrDefault(s => s.Id == id);
                }
            }
            return null;
        }
        public static void AddInventoryItem(InventoryObjectModel io)
        {
            InventoryItems.Add(io);
        }
        public static void RemoveInventoryItem(int id)
        {
            if (InventoryItems.Count > 0)
            {
                InventoryItems.Remove(InventoryItems.FirstOrDefault(io => io.Id == id));
            }
        }
        public static List<Interaction> GetInteractionsBySceneObject(int id)
        {
            return Interactions.Where(inter => inter.TargetObjectId == id).ToList();
        }


        public static Interaction GetInteraction(int id)
        {
            return Interactions.FirstOrDefault(i => i.Id == id);
        }
        public static InventoryObjectModel GetInventoryObject(int id)
        {
            if (InventoryObjects.Count > 0)
            {
                if (InventoryObjects.Any(s => s.Id == id))
                {
                    return InventoryObjects.FirstOrDefault(s => s.Id == id);
                }
            }
            return null;
        }
        public static void AddInventoryObject(InventoryObjectModel io)
        {
            InventoryObjects.Add(io);
        }
        public static List<InventoryObjectModel> GetInventoryObjects()
        {
            return InventoryObjects;
        }
        public static void RemoveInventoryObject(int id)
        {
            if (InventoryObjects.Count > 0)
            {
                InventoryObjects.Remove(InventoryObjects.FirstOrDefault(io => io.Id == id));
            }
        }
        public static Inventory getInventory()
        {
            if (Inventory == null)
            {
                Inventory = new Inventory();

            }
            return Inventory;
        }
        public static void Reset()
        {
            InventoryObjects.Clear();
            Scenes.Clear();
            instance = null;
            Inventory = null;
            remainingTime = 900;
        }
    }

}

