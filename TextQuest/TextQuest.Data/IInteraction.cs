using System;
using System.Collections.Generic;
using System.Text;

namespace TextQuest.Data
{
    public interface IInteraction
    {
        Interaction GetInteraction(int id);
        Interaction GetNextInteraction(int id);
        SceneObject GetInteractedSceneObject { get; set; }
        InventoryObject GetInteractedInventoryObject { get; set; }

    }
}
