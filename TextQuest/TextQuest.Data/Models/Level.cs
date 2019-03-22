using System;
using System.Collections.Generic;
using System.Text;

namespace TextQuest.Data.Models
{
    public class Level
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Creator { get; set; }
        public int Views { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }
}
