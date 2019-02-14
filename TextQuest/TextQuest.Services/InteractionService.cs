using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextQuest.Data;

namespace TextQuest.Services
{
    public class InteractionService:IInteraction
    {
        private TextQuestDbContext _context;

        public InteractionService(TextQuestDbContext context)
        {
            _context = context;
        }

        public int GetInteractedInventoryObjectId(int id)
        {
            return GetInteraction(id).InteractingInventoryObjectId;
        }

        public int GetInteractedSceneObjectId(int id)
        {
            return GetInteraction(id).InteractingSceneObjectId;
        }

        public Interaction GetInteraction(int id)
        {
            return _context.Interactions.FirstOrDefault(i => i.Id == id);
        }

        public Interaction GetInteractionByInventoryObject(int id)
        {
            return _context.Interactions.FirstOrDefault(i => i.InventoryObjectId == id);
        }

        public Interaction GetInteractionBySceneObject(int id)
        {
            return _context.Interactions.FirstOrDefault(i => i.SceneObjectId == id);

        }

        public Interaction GetNextInteraction(int id)
        {
            return GetInteraction(GetInteraction(id).NextInteractionId);
        }
    }
}
