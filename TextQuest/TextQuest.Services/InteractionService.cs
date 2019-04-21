using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextQuest.Data;

namespace TextQuest.Services
{
    public class InteractionService : IInteraction
    {
        private TextQuestDbContext _context;

        public InteractionService(TextQuestDbContext context)
        {
            _context = context;
        }

        public Interaction GetInteraction(int? id)
        {
            return _context.Interactions.FirstOrDefault(i => i.Id == id);
        }

        public Interaction GetInteractionByInventoryObject(int id)
        {
            return _context.Interactions.FirstOrDefault(i => i.TargetInventoryObjectId == id);
        }

        public IEnumerable<Interaction> GetInteractionsBySceneObject(int id)
        {
            return _context.Interactions.Where(i => i.TargetObjectId == id);

        }

        public Interaction GetNextInteraction(int id)
        {
            return GetInteraction(GetInteraction(id).NextInteractionId);
        }

        public int? GetTargetInventoryObjectId(int id)
        {
            return GetInteraction(id).TargetInventoryObjectId;
        }

        public int? GetTargetSceneObjectId(int id)
        {
            return GetInteraction(id).TargetObjectId;

        }

        public int? GetInteractingInventoryObjectId(int id)
        {
            return GetInteraction(id).InteractingInventoryObjectId;
        }

        public int? GetInteractingSceneObjectId(int id)
        {
            return GetInteraction(id).InteractingObjectId;
        }

     

        public void DeleteInteraction(int id)
        {
            _context.Remove(GetInteraction(id));
            _context.SaveChanges();
        }

        public void AddInteraction(Interaction interaction)
        {
            _context.Interactions.Add(interaction);
            _context.SaveChanges();
        }
    }
}
