using System;
using System.Collections.Generic;
using System.Text;

namespace TextQuest.Data
{
    public interface ISceneObject
    {
        SceneObject GetSceneObject(int id);
        string GetName(int id);
        string GetDescription(int id);
        Location GetLocation(int id);
        void SetLocation(int id,Location location);
        bool CheckPickable(int id);
        bool CheckAction(int id);
        InventoryObject GetAssociatedInventoryObject(int id);
    }
    public class Location
    {
        public Location(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }

    }
}

