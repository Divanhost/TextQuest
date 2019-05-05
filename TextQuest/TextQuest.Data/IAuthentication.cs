using System;
using System.Collections.Generic;
using System.Text;
using TextQuest.Data.Models;

namespace TextQuest.Data
{
    public interface IAuthentication
    {
        Authentication GetUser(int id);
        void AddUser(string login,string password,string acesslevel);
        void AddUser(Authentication user);
        void DeleteUser(int id);
        string GetLogin(int id);
        IEnumerable<Level> GetUsersLevels(int id);
        void AddUserLevel(int id);
        IEnumerable<Level> GetUsersFavouriteLevels(int id);
        void AddLevelToFavourites(int id);
        Inventory GetInventory(int id);
        bool LoginIsValid(string log, string pas);
    }
}
