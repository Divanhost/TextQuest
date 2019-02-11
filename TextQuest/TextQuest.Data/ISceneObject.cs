using System;
using System.Collections.Generic;
using System.Text;

namespace TextQuest.Data
{
    public interface ISceneObject
    {
        SceneObject GetSceneObject(int id);
        string GetName(int id);
        Location GetLocation(int id);
        bool CheckPickable(int id);
        bool CheckAction(int id);
        InventoryObject GetAssociatedInventoryObject(int id);
    }
    public class Location
    {
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }

    }
}

