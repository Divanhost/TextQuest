﻿using System;
using System.Collections.Generic;
using System.Text;
using TextQuest.Data.Models;

namespace TextQuest.Data
{
    public interface ILevel
    {
        Level GetLevel(int id);
        IEnumerable<Level> GetLevels(string creator);
        IEnumerable<Level> GetLevelsLike(string creator);
        IEnumerable<Scene> GetScenes(int id);
        IEnumerable<Interaction> GetInteractions(int id);
        IEnumerable<InventoryObject> GetItems(int id);
        void AddViewcount(int id);
        void AddLike(int id);
        void AddDislike(int id);
        void SubLike(int id);
        void SubDislike(int id);
        void AddLevel(Level lvl);
        void DeleteLevel(int id);
        string GetName(int id);
        string GetImage(int id);
        string GetCreator(int id);
        int GetViews(int id);
        int ComputeRating(int id);
    }
}
