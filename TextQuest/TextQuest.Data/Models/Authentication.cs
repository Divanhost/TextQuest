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
        public IEnumerable<Level> UserFavoriteLevels { get; set; }
        public IEnumerable<Level> UserDislikedLevels { get; set; }
        public int AssociatedInventory { get; set; }
    }
}
