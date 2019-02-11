using System;
using System.Collections.Generic;
using System.Text;

namespace TextQuest.Data
{
    public interface IInventory
    {
        void Add(Inventory inventory);
        void Delete(int id);
        IEnumerable<InventoryObject> GetInventoryObjects(int id);
    }
}
