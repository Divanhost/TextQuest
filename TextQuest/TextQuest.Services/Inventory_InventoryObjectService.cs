using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextQuest.Data;
using TextQuest.Data.Models;


namespace TextQuest.Services
{
    public class Inventory_InventoryObjectService : IInventory_InventoryObject
    {
        private TextQuestDbContext _context;

        public Inventory_InventoryObjectService(TextQuestDbContext context)
        {
            _context = context;
        }

        public void AddItem(int id,int itemId)
        {
            _context.Inventory_InventoryObjects.Add(new Inventory_InventoryObject { InventoryId = id, InventoryObjectId = itemId });
        }

        public void ClearInventory(int id)
        {
            var garbage = _context.Inventory_InventoryObjects.Where(o => o.InventoryId == id);
            foreach(var item in garbage)
            {
                _context.Inventory_InventoryObjects.Remove(item);
            }
        }

        public IEnumerable<InventoryObject> GetItems(int id)
        {
            throw new NotImplementedException();

        }

        public void RemoveItem(int id, int itemId)
        {
            _context.Inventory_InventoryObjects.Remove(new Inventory_InventoryObject { InventoryId = id, InventoryObjectId = itemId });
        }
    }
}
