using System;
using System.Collections.Generic;
using System.Text;

namespace TextQuest.Data
{
    public interface IScene
    {
        /*public string BackgroundImageUrl { get; set; }
        [Required]
        public string Description { get; set; }
        // Set of objects, that belongs to the scene
        public IEnumerable<SceneObject> SceneObjects { get; set; }
        public int LevelId { get; set; }*/
        Scene GetScene(int id);
        void AddScene(Scene scene);
        void DeleteScene(int id);
        IEnumerable<Scene> GetAll();
        string GetBackground(int id);
        string GetDescription(int id);
       
        IEnumerable<SceneObject> GetSceneObjects(int id);
        //void AddSceneObject(int id,SceneObject sceneObject);
        IEnumerable<SceneObject> GetSpawnedSceneObjects(int id);

    }
}

