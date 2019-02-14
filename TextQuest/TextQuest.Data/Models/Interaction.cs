using System.ComponentModel.DataAnnotations;

namespace TextQuest.Data
{
    public class Interaction
    {
        public int Id { get; set; }
        public int SceneObjectId { get; set; }
        public int InteractingSceneObjectId { get; set; }
        public int InventoryObjectId { get; set; }
        public int InteractingInventoryObjectId { get; set; }
        public int NextInteractionId { get; set; }

    }
}