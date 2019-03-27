using System;
using System.Collections.Generic;
using System.Text;

namespace TextQuest.Data
{
    public interface IInteraction
    {
        Interaction GetInteraction(int? id);
        // void AddInteraction(int targetSc,int interactingSc,int targetInv,int interactingInv,int nextId,bool isAllowed,string specEvent,bool isSpawn,int lvlId);
        void AddInteraction(Interaction interaction);
        void DeleteInteraction(int id);
        IEnumerable<Interaction> GetInteractionsBySceneObject(int id);
        Interaction GetInteractionByInventoryObject(int id);
        Interaction GetNextInteraction(int id);
        int? GetTargetSceneObjectId(int id);
        int? GetInteractingSceneObjectId(int id);
        int? GetTargetInventoryObjectId(int id);
        int? GetInteractingInventoryObjectId(int id);
    }
}
