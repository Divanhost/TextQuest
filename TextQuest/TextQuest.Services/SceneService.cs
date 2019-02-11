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
            return _context.Scenes.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<SceneObject> GetSceneObjects(int id)
        {
            return GetScene(id).SceneObjects;
        }

        public string GetDescription(int id)
        {
            return GetScene(id).Description;
        }

        public string GetBackground(int id)
        {
            return GetScene(id).BackgroundImageUrl;
        }

       

        public int GetDownScene(int id)
        {
            return GetScene(id).DownSceneId;
        }

        public int GetLeftScene(int id)
        {
            return GetScene(id).LeftSceneId;
        }

        public int GetRightScene(int id)
        {
            return GetScene(id).RightSceneId;
        }

        public int GetUpperScene(int id)
        {
            return GetScene(id).UpperSceneId;
        }

        public int GetInnerScene(int id)
        {
            return GetScene(id).InnerSceneId;
        }

        public IEnumerable<Scene> GetAll()
        {
            return _context.Scenes;
        }
    }
}
