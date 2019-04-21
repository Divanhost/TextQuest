using System;
using System.Collections.Generic;
using System.Text;

namespace TextQuest.Data.Models
{
    public class Authentication
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int AccessLevel { get; set; }
        IEnumerable<Level> UserLevels { get; set; }
        IEnumerable<Level> UserFavoriteLevels { get; set; }
        public int AssociatedInventory { get; set; }
    }
}
