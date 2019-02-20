using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TextQuest.Data;

namespace TextQuest.Services
{
    public class SceneService : IScene
    {
        private TextQuestDbContext _context;

        public SceneService(TextQuestDbContext context)
        {
            _context = context;
        }

        public Scene GetScene(int id)
        {
            return _context.Scenes
                .Include(s=>s.SceneObjects)
                .FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<SceneObject> GetSceneObjects(int id)
        {
            return GetScene(id).SceneObjects;
        }

        public IEnumerable<SceneObject> GetSpawnedSceneObjects(int id)
        {
            return GetSceneObjects(id).Where(so=>so.IsSpawned);
        }
        
        public string GetDescription(int id)
        {
            return GetScene(id).Description;
        }

        public string GetBackground(int id)
        {
            return GetScene(id).BackgroundImageUrl;
        }
       
        public IEnumerable<Scene> GetAll()
        {
            return _context.Scenes.Include(s => s.SceneObjects);
        }
    }
}
