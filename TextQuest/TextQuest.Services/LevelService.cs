using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextQuest.Data;
using TextQuest.Data.Models;

namespace TextQuest.Services
{
    public class LevelService : ILevel
    {
        private TextQuestDbContext _context;

        public LevelService(TextQuestDbContext context)
        {
            _context = context;
        }

        public void AddLevel(Level lvl)
        {
            _context.Add(lvl);
            _context.SaveChanges();
        }

        public int ComputeRating(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteLevel(int id)
        {
            _context.Remove(GetLevel(id));
            _context.SaveChanges();
        }

        public string GetCreator(int id)
        {
            throw new NotImplementedException();
        }

        public string GetImage(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Interaction> GetInteractions(int id)
        {
            return _context.Interactions.Where(inter => inter.LevelId == id);
        }

        public IEnumerable<InventoryObject> GetItems(int id)
        {
            return _context.InventoryObjects.Where(inv => inv.LevelId == id);
        }

        public Level GetLevel(int id)
        {
            return _context.Levels.FirstOrDefault(lvl => lvl.Id == id);
        }

        public IEnumerable<Level> GetLevels(string creator)
        {
            return _context.Levels.Where(lvl => lvl.Creator == creator);
        }

        public string GetName(int id)
        {
            return GetLevel(id).Name;
        }

        public IEnumerable<Scene> GetScenes(int id)
        {
            return _context.Scenes
                .Include(sc => sc.SceneObjects)
                .Where(sc => sc.LevelId == id);
               
        }

        public int GetViews(int id)
        {
            return GetLevel(id).Views;
        }
    }
}
