using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TextQuest.Data;

namespace TextQuest.Models
{
    public class LevelModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Creator { get; set; }
        public List<Scene> Scenes { get; set; }
        public List<InventoryObject> InventoryObjects { get; set; }
        public List<Interaction> Interactions { get; set; }
    }
}
