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
            return GetInteraction(id).InventoryObjectId;
        }

        public int GetInteractedSceneObjectId(int id)
        {
            return GetInteraction(id).SceneObjectId;
        }

        public Interaction GetInteraction(int id)
        {
            return _context.Interactions.FirstOrDefault(i => i.Id == id);
        }

        public Interaction GetNextInteraction(int id)
        {
            return GetInteraction(GetInteraction(id).NextInteractionId);
        }
    }
}
