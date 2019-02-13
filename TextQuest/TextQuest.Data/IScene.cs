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
        int GetLeftScene(int id);
        int GetRightScene(int id);
        int GetUpperScene(int id);
        int GetDownScene(int id);
        int GetInnerScene(int id);

        IEnumerable<SceneObject> GetSceneObjects(int id);
        IEnumerable<SceneObject> GetSpawnedSceneObjects(int id);
    }
}

