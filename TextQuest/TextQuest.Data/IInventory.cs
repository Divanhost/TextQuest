using System;
using System.Collections.Generic;
using System.Text;

namespace TextQuest.Data
{
    public interface IInventory
    {
        Inventory GetInventory(int id);
        void Add(Inventory inventory);
        void Delete(int id);
    }
}
