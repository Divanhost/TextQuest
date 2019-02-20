using System;
using System.Collections.Generic;
using System.Text;

namespace TextQuest.Data
{
    public interface IScene
    {
        Scene GetScene(int id);
        IEnumerable<Scene> GetAll();
        string GetBackground(int id);
        string GetDescription(int id);
       
        IEnumerable<SceneObject> GetSceneObjects(int id);
        IEnumerable<SceneObject> GetSpawnedSceneObjects(int id);
    }
}

