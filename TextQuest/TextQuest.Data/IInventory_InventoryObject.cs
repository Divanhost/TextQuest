using System;
using System.Collections.Generic;
using System.Text;

namespace TextQuest.Data
{
    public interface IInventory_InventoryObject
    {
        void AddItem(int id,int itemId);
        void RemoveItem(int id,int itemId);
        IEnumerable<InventoryObject> GetItems(int id, int mode); //Сделай
        void ClearInventory(int id);
    }
}
