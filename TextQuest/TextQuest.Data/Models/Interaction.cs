using System.ComponentModel.DataAnnotations;

namespace TextQuest.Data
{
    public class Interaction
    {
        public int Id { get; set; }
        public int? TargetObjectId { get; set; }
        public int? InteractingObjectId { get; set; }
        public int? TargetInventoryObjectId { get; set; }
        public int? InteractingInventoryObjectId { get; set; }
        public bool IsAllowed { get; set; }
        public int? NextInteractionId { get; set; }

    }
}