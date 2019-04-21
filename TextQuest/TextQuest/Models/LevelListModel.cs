using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TextQuest.Data;
using TextQuest.Data.Models;

namespace TextQuest.Models
{
    public class LevelListModel:PageModel
    {
        public List<Level> Levels;
    }
}
