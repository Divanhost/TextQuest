using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextQuest.Data;

namespace TextQuest.Services
{
    public class SceneObjectService : ISceneObject
    {

        private TextQuestDbContext _context;

        public SceneObjectService(TextQuestDbContext context)
        {
            _context = context;
        }

        public SceneObject GetSceneObject(int id)
        {
            return _context.SceneObjects
                .Include(so=>so.AssociatedInventoryObject)
                .Include(so=>so.AssociatedSceneObject)
                .FirstOrDefault(so => so.Id == id);
        }

        public string GetName(int id)
        {
           return GetSceneObject(id).Name;
        }

        public Location GetLocation(int id)
        {
            SceneObject so = GetSceneObject(id);
            return new Location(so.x, so.y, so.z);
        }

        public InventoryObject GetAssociatedInventoryObject(int id)
        {
            return GetSceneObject(id).AssociatedInventoryObject;

        }


        public bool CheckAction(int id)
        {
            return GetSceneObject(id).HasAction;

        }

        public bool CheckPickable(int id)
        {
            return GetSceneObject(id).IsPickable;
            
        }

        public void SetLocation(int id, Location location)
        {
            GetSceneObject(id).x = location.x;
            GetSceneObject(id).y = location.y;
            GetSceneObject(id).z = location.z;
        }
    }
}
