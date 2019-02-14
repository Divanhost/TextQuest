using System;
using System.Collections.Generic;
using System.Text;

namespace TextQuest.Data.Models
{
    public class Inventory_InventoryObject
    {
        public int Id { get; set; }
        public int InventoryObjectId { get; set; }
        public int InventoryId { get; set; }
    }
}
