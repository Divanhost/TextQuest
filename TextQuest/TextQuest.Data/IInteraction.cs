using System;
using System.Collections.Generic;
using System.Text;

namespace TextQuest.Data
{
    public interface IInteraction
    {
        Interaction GetInteraction(int id);
        Interaction GetInteractionBySceneObject(int id);
        Interaction GetInteractionByInventoryObject(int id);
        Interaction GetNextInteraction(int id);
        int GetInteractedSceneObjectId(int id);
        int GetInteractedInventoryObjectId(int id);

    }
}
