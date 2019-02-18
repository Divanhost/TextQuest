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

      
        public IActionResult Index(int? id =1)
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
                    UpperSceneId = sc.UpperSceneId,
                    DownSceneId = sc.DownSceneId,
                    LeftSceneId = sc.LeftSceneId,
                    RightSceneId = sc.RightSceneId,
                    InnerSceneId = sc.InnerSceneId
                };
                UserSingleton.AddScene(currentScene);
            }
            var model = new SceneListModel()
            {
                Scenes = UserSingleton.GetScenes(),
                CurrentScene = currentScene,
                Inventory = inventory,
                InventoryItems = _inventoryHelper.GetItems(inventory.Id)
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
            //var sceneObject = _sceneObject.GetSceneObject(id);
            bool isPickable = sceneObject.IsPickable;
            bool hasAction = sceneObject.HasAction;
            bool isInnerPass = sceneObject.IsInnerPass;

            //Choose the way
            // We can pick item in inventory
            if (isPickable)
            {
                var interacton = _interaction.GetInteractionBySceneObject(id);
                int inventoryItemId = interacton.InteractingInventoryObjectId.Value;
                _inventoryHelper.AddItem(inventoryId, inventoryItemId);
                var responce = new Responce()
                {
                    oldId = id,
                    newId = inventoryItemId,
                    ImageUrl = _inventoryObject.GetImage(inventoryItemId),
                    Name =  _inventoryObject.GetName(inventoryItemId)
                };
                UserSingleton.GetScene(sceneId).SceneObjects.Remove(UserSingleton.GetScene(sceneId).SceneObjects.FirstOrDefault(so=>so.Id ==id));
                return Ok(new { interactionType = 0,id, responce});
            }
            // It is the pass into a new Scene
            else if (isInnerPass)
            {
                var nextSceneId = UserSingleton.GetScene(sceneId).InnerSceneId;//_scene.GetScene(sceneId).InnerSceneId;
                return Ok(new { interactionType = 1, nextRoomId = id});
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
                        if(selectedInventoryObjectId != null)
                        _inventoryHelper.RemoveItem(inventoryId, selectedInventoryObjectId??default(int));
                        DoActions(responces, id,sceneId);
                    }
                }
                return Ok(new { interactionType = 2, id, responces });
            }
            else
            {
                return Ok();
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
        //Do action or sequence of actions
        public void DoActions(List<Responce> responces,int id,int sceneId)
        {
            
            var sceneObject = _sceneObject.GetSceneObject(id);
            var interacton = _interaction.GetInteractionBySceneObject(id);
            var associatedSceneObject = _sceneObject.GetSceneObject(interacton.InteractingObjectId ?? default(int));


     
            if(interacton.InteractingObjectId != id)
            {
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
                        isValid = true
                    };
                    responces.Add(responce);
                    UserSingleton.GetScene(sceneId).SpawnedSceneObjects.Add(UserSingleton.GetScene(sceneId).SceneObjects.FirstOrDefault(so => so.Id == id));
                    UserSingleton.GetScene(sceneId).SceneObjects.Remove(UserSingleton.GetScene(sceneId).SceneObjects.FirstOrDefault(so => so.Id == id));
                    UserSingleton.GetScene(sceneId).SceneObjects.Add(UserSingleton.GetScene(sceneId).SpawnedSceneObjects.FirstOrDefault(so => so.Id == associatedSceneObject.Id));
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
            if (interacton.NextInteractionId.HasValue)
            {
                interacton = _interaction.GetInteraction(interacton.NextInteractionId);
                int newId = interacton.TargetObjectId ?? default(int);
                DoActions(responces, newId,sceneId);
            }

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
    }
    
    class UserSingleton
    {
        private static UserSingleton instance;
        private static Inventory Inventory;
        private static List<SceneModel> Scenes;
        private UserSingleton() { }
        public static UserSingleton getInstance()
        {
            if (instance == null)
            {
                instance = new UserSingleton();
                Inventory = new Inventory();
                Scenes = new List<SceneModel>();
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
        public static Inventory getInventory()
        {
            if (Inventory == null)
            {
                Inventory = new Inventory();

            }
            return Inventory;
        }
    }

}

