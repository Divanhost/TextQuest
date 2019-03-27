using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextQuest.Data;

namespace TextQuest.Services
{
    public class InventoryObjectService : IInventoryObject
    {
        private TextQuestDbContext _context;

        public InventoryObjectService(TextQuestDbContext context)
        {
            _context = context;
        }

        public InventoryObject GetInventoryObject(int id)
        {
            return _context.InventoryObjects.FirstOrDefault(io => io.Id == id);
        }

        public string GetName(int id)
        {
            return GetInventoryObject(id).Name;
        }

        public string GetDescription(int id)
        {
            return GetInventoryObject(id).Decription;
        }

        public string GetImage(int id)
        {
            return GetInventoryObject(id).ImageUrl;
        }

        public bool CheckInfinite(int id)
        {
            return GetInventoryObject(id).IsInfinite;
        }

        public void DeleteInventoryObject(int id)
        {
            _context.Remove(GetInventoryObject(id));
        }

        public void AddInventoryObject(InventoryObject inventoryObject)
        {
            _context.Add(inventoryObject);
            _context.SaveChanges();
        }
    }
}
