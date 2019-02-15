namespace TextQuest.Models
{
    public class InventoryObjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Decription { get; set; }
        public bool IsInfinite { get; set; }
        public string ImageUrl { get; set; }
        public bool IsSelected { get; set; }
    }
}