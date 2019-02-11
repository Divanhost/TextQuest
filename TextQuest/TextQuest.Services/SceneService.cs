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

        public int GetBackground(int id)
        {
            throw new NotImplementedException();
        }

        public string GetDescription(int id)
        {
            throw new NotImplementedException();
        }

        public int GetDownScene(int id)
        {
            throw new NotImplementedException();
        }

        public int GetLeftScene(int id)
        {
            throw new NotImplementedException();
        }

        public int GetRightScene(int id)
        {
            throw new NotImplementedException();
        }

        public Scene GetScene(int id)
        {
            return _context.Scenes.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<SceneObject> GetSceneObjects(int id)
        {
            return GetScene(id).SceneObjects;
        }

        public int GetUpperScene(int id)
        {
            throw new NotImplementedException();
        }
    }
}
