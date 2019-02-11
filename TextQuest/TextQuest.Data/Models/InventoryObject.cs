using System.ComponentModel.DataAnnotations;

namespace TextQuest.Data
{
    public class InventoryObject
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Decription { get; set; }
        [Required]
        public bool IsInfinite { get; set; }
        public string ImageUrl { get; set; }
    }
}