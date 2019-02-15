﻿using Microsoft.AspNetCore.Mvc;
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

            Inventory userInventory = InventorySingleton.getInstance();
            //This is quite bad
            try
            {
                _inventory.Add(userInventory);
            }
            catch (Exception e)
            {

            }
            // Model assembly
            var scenes = _scene.GetAll();
            var listingResult = scenes.Select(result => new SceneModel
            {
                Id = result.Id,
                Description = result.Description,
                BackgroundImageUrl = result.BackgroundImageUrl,
                SceneObjects = result.SceneObjects.Where(so => !so.IsSpawned).OrderByDescending(s => s.z),
                SpawnedSceneObjects = result.SceneObjects.Where(so => so.IsSpawned).OrderByDescending(s => s.z),
                UpperSceneId = result.UpperSceneId,
                DownSceneId = result.DownSceneId,
                LeftSceneId = result.LeftSceneId,
                RightSceneId = result.RightSceneId,
                InnerSceneId = result.InnerSceneId
            });
            var curScene = listingResult.FirstOrDefault(s => s.Id == id);

            var model = new SceneListModel()
            {
                Scenes = listingResult,
                CurrentScene = curScene,
                Inventory = userInventory,
                InventoryItems = _inventoryHelper.GetItems(userInventory.Id)
            };

            return View(model);

        }



        public IActionResult GetSceneObjects()
        {
            ViewBag.Title = "Smth";
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
            var sceneObject = _sceneObject.GetSceneObject(id);
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
                    oldId =id,
                    newId = inventoryItemId,
                    ImageUrl = _inventoryObject.GetImage(inventoryItemId),
                    Name = _inventoryObject.GetName(inventoryItemId)
                };
                return Ok(new { interactionType = 0,id, responce});
            }
            // It is the pass into a new Scene
            else if (isInnerPass)
            {
                var nextSceneId = _scene.GetScene(sceneId).InnerSceneId;
              
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
                        DoActions(responces, id);
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
        public IActionResult HandleInventoryDescriptionShowing()
        {
            StreamReader sr = new StreamReader(Request.Body);
            string data = sr.ReadToEnd();

            int id = Int32.Parse(data);
            return Ok(_inventoryObject.GetDescription(id));
        }

        //Do action or sequence of actions
        public void DoActions(List<Responce> responces,int id)
        {
            
            var sceneObject = _sceneObject.GetSceneObject(id);
            var interacton = _interaction.GetInteractionBySceneObject(id);
            var associatedSceneObject = _sceneObject.GetSceneObject(interacton.InteractingObjectId ?? default(int));


     
            if(interacton.InteractingObjectId != id)
            {
                var responce = new Responce()
                {
                    oldId = sceneObject.Id,
                    newId = associatedSceneObject.Id,
                    Name =associatedSceneObject.Name,
                    Description = associatedSceneObject.Description,
                    x = associatedSceneObject.x,
                    y = associatedSceneObject.y,
                    ImageUrl = associatedSceneObject.ImageUrl,

                };
                responces.Add(responce);
                
            }
            if (interacton.NextInteractionId.HasValue)
            {
                interacton = _interaction.GetInteraction(interacton.NextInteractionId);
                int newId = interacton.TargetObjectId ?? default(int);
                DoActions(responces, newId);
            }

        }

        
        public void SaveChanges()
        {

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
    }
    
    class InventorySingleton
    {
        private static Inventory instance;

        private InventorySingleton()
        { }

        public static Inventory getInstance()
        {
            if (instance == null)
            {
                instance = new Inventory();

            }
            return instance;
        }
    }
}
