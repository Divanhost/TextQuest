using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TextQuest.Data
{
    public class InventoryObject
    {
        public int Id { get; set; }
        //Name of Inventory object
        [Required]
        public string Name { get; set; }
        //Description of Inventory object
        [Required]
        public string Decription { get; set; }
        // Can we pick it infinitely many times
        [Required]
        public bool IsInfinite { get; set; }
        public string ImageUrl { get; set; }
        public int LevelId { get; set; }
        public int? Type { get; set; }
    }
}