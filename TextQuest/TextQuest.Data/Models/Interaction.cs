using System.ComponentModel.DataAnnotations;

namespace TextQuest.Data
{
    public class Interaction
    {
        public int Id { get; set; }
        //Clicked object on the scene
        public int? TargetObjectId { get; set; }
        // Substitutional scene object
        public int? InteractingObjectId { get; set; }
        //Clicked object on the inventory
        public int? TargetInventoryObjectId { get; set; }
        // Substitutional inventory object
        public int? InteractingInventoryObjectId { get; set; }
        // Is interaction allowed on click
        public bool IsAllowed { get; set; }
        // Is it Spawn kind interaction
        public bool IsSpawn { get; set; }
        // Next interaction in set of actions
        public int? NextInteractionId { get; set; }
        //Post Interaction function
        public string SpecialEvent { get; set; }
        //Special sound
        public string Sound { get; set; }
        public string SceneId { get; set; }

    }
}