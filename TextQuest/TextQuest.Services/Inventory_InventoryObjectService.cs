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
            // Как ты работаешь, чудовище
            _context.Add(new Inventory_InventoryObject { InventoryId = id, InventoryObjectId = itemId });
            _context.SaveChanges();
        }

        public void ClearInventory(int id)
        {
            var garbage = _context.Inventory_InventoryObjects.Where(o => o.InventoryId == id);
            foreach(var item in garbage)
            {
                _context.Inventory_InventoryObjects.Remove(item);
            }
            _context.SaveChanges();

        }

        public IEnumerable<InventoryObject> GetItems(int id)
        {
            //TODO refactor
            var help = _context.Inventory_InventoryObjects.Where(io => io.InventoryId == id);
            var Inven = _context.InventoryObjects.Where(io => help.Any(hpl => hpl.InventoryObjectId == io.Id));
            return Inven;
        }

        public void RemoveItem(int id, int itemId)
        {
            var removingItem = _context.Inventory_InventoryObjects.Where(ri => ri.InventoryId == id && ri.InventoryObjectId == itemId);
            _context.Remove(removingItem.First());
            _context.SaveChanges();

        }
    }
}
