using System;
using System.Collections.Generic;
using System.Text;

namespace TextQuest.Data
{
    public interface IInteraction
    {
        Interaction GetInteraction(int? id);
        IEnumerable<Interaction> GetInteractionsBySceneObject(int id);
        Interaction GetInteractionByInventoryObject(int id);
        Interaction GetNextInteraction(int id);
        int? GetTargetSceneObjectId(int id);
        int? GetInteractingSceneObjectId(int id);
        int? GetTargetInventoryObjectId(int id);
        int? GetInteractingInventoryObjectId(int id);
    }
}
