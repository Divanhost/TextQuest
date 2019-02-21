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
        public GamePageController(IScene scene,ISceneObject sceneObject,IInteraction interaction, IInventory inventory,IInventory_InventoryObject inventoryHelper, IInventoryObject inventoryObject)
        {
            _scene = scene;
            _sceneObject = sceneObject;
            _interaction = interaction;
            _inventory = inventory;
            _inventoryHelper = inventoryHelper;
            _inventoryObject = inventoryObject;
        }

      
        public IActionResult Index(int? id =4)
        {
            UserSingleton user = UserSingleton.getInstance();
            Inventory inventory = UserSingleton.getInventory();
            //This is quite bad
            try
            {
                _inventory.Add(inventory);
            }
            catch (Exception e)
            {

            }
            // Model assembly
            var currentScene = UserSingleton.GetScene(id ?? default(int));
            if (currentScene == null)
            {
                var sc = _scene.GetScene(id ?? default(int));
                currentScene = new SceneModel
                {
                    Id = sc.Id,
                    Description = sc.Description,
                    BackgroundImageUrl = sc.BackgroundImageUrl,
                    SceneObjects = sc.SceneObjects.Where(so => !so.IsSpawned).OrderByDescending(s => s.z).ToList(),
                    SpawnedSceneObjects = sc.SceneObjects.Where(so => so.IsSpawned).OrderByDescending(s => s.z).ToList(),
                    
            };
                UserSingleton.AddScene(currentScene);
            }
            var model = new SceneListModel()
            {
                Scenes = UserSingleton.GetScenes(),
                CurrentScene = currentScene,
                Inventory = inventory,
                InventoryItems = UserSingleton.GetInventoryObjects(),
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

            //Scene object related Variables;
            var sceneObject = UserSingleton.GetScene(sceneId).SceneObjects.FirstOrDefault(so => so.Id == id);
            bool isPickable = sceneObject.IsPickable;
            bool hasAction = sceneObject.HasAction;
            bool isInnerPass = sceneObject.IsInnerPass;

            //Choose the way
            // We can pick item in inventory
            if (isPickable)
            {
                var interacton = _interaction.GetInteractionBySceneObject(id);
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
                var interacton = _interaction.GetInteractionBySceneObject(id);
                if (interacton.IsAllowed)
                {
                    if(interacton.InteractingInventoryObjectId != selectedInventoryObjectId)
                    {
                        responces.Add(new Responce { isValid = false });
                    }
                    else
                    {
                        if (selectedInventoryObjectId != null)
                            UserSingleton.RemoveInventoryObject(selectedInventoryObjectId ?? default(int));
                       
                        DoActions(responces, id,sceneId);
                    }
                }
                return Ok(new { interactionType = 2, id, responces });
            }
            else
            {
                var responces = new List<Responce>();
                return Ok(new { interactionType = 2, id, responces});
            }
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
        //Do action or sequence of actions
        public void DoActions(List<Responce> responces,int id,int sceneId)
        {
            var sceneObject = UserSingleton.GetScene(sceneId).SceneObjects.FirstOrDefault(so => so.Id == id);
            var interacton = _interaction.GetInteractionBySceneObject(id);
            var associatedSceneObject = UserSingleton.GetScene(sceneId).SpawnedSceneObjects.FirstOrDefault(sso => sso.Id == _interaction.GetInteractingSceneObjectId(interacton.Id));
            //if interaction change object
            if (interacton.InteractingObjectId != id)
            {
                //and interactingobjects exists
                if (interacton.InteractingObjectId.HasValue)
                {
                    var responce = new Responce()
                    {
                        oldId = sceneObject.Id,
                        newId = associatedSceneObject.Id,
                        Name = associatedSceneObject.Name,
                        Description = associatedSceneObject.Description,
                        x = associatedSceneObject.x,
                        y = associatedSceneObject.y,
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
                DoActions(responces, newId,sceneId);
            }

        }
        public IActionResult Reset()
        {
            UserSingleton.Reset();
            Index();
            return View("Index");
        }
        
    }

    public class Responce
    {
        public int oldId { get; set; }
        public int newId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public string ImageUrl { get; set; }
        public bool isValid { get; set; }
        // 0 - remove, 1 -replace -1 -default
        public int Action = -1;
        public bool isSpawn;
        public string SpecialEvent;
    }
    
    class UserSingleton
    {
        private static UserSingleton instance;
        private static Inventory Inventory;
        private static List<InventoryObject> InventoryObjects; 
        private static List<SceneModel> Scenes;
        public static int remainingTime;
        private UserSingleton() { }
        public static UserSingleton getInstance()
        {
            if (instance == null)
            {
                instance = new UserSingleton();
                Inventory = new Inventory();
                Scenes = new List<SceneModel>();
                InventoryObjects = new List<InventoryObject>();
                remainingTime = 900;
            }
            return instance;
        }
        public static IEnumerable<SceneModel> GetScenes()
        {
           return Scenes;
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
        public static void AddScene(SceneModel scene)
        {
            Scenes.Add(scene);
        }
        public static void AddInventoryObject(InventoryObject io)
        {
            InventoryObjects.Add(io);
        }
        public static InventoryObject GetInventoryObject(int id)
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
        public static IEnumerable<InventoryObject> GetInventoryObjects()
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
        }
    }

}

