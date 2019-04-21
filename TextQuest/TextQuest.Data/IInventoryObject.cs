using System;
using System.Collections.Generic;
using System.Text;

namespace TextQuest.Data
{
    public interface IInventoryObject
    {
        InventoryObject GetInventoryObject(int id);
        void DeleteInventoryObject(int id);
        void AddInventoryObject(InventoryObject inventoryObject);
        string GetName(int id);
        string GetDescription(int id);
        bool CheckInfinite(int id);
        string GetImage(int id);
    }
}

