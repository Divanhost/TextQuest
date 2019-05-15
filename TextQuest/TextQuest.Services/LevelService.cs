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


        public void AddViewcount(int id)
        {
            GetLevel(id).Views += 1;
            _context.SaveChanges();
        }

        public void AddLike(int id)
        {
            GetLevel(id).Likes += 1;
            _context.SaveChanges();
        }

        public void AddDislike(int id)
        {
            GetLevel(id).Dislikes += 1;
            _context.SaveChanges();
        }

        public void SubLike(int id)
        {
            GetLevel(id).Likes -= 1;
            _context.SaveChanges();
        }

        public void SubDislike(int id)
        {
            GetLevel(id).Dislikes -= 1;
            _context.SaveChanges();
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
            return _context.Levels
                .Include(lvl=>lvl.Scenes)
                .Include(lvl=>lvl.Interactions)
                .Include(lvl=>lvl.InventoryObjects)
                .FirstOrDefault(lvl => lvl.Id == id);
        }

        public IEnumerable<Level> GetLevels(string creator)
        {
            return _context.Levels.Where(lvl => lvl.Creator == creator);
        }

        public IEnumerable<Level> GetLevelsLike(string str)
        {
            return _context.Levels.Where(lvl => lvl.Creator.Contains(str) || lvl.Name.Contains(str));
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
