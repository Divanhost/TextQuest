using System.Collections.Generic;

namespace TextQuest.Data
{
    public class Inventory
    {
        public int Id { get; set; }
        public IEnumerable<InventoryObject> InventoryObjects { get; set; }
    }
}