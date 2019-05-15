using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TextQuest.Data;
using TextQuest.Data.Models;

namespace TextQuest.Services
{
    public class AuthenticationService : IAuthentication
    {
        private TextQuestDbContext _context;

        public AuthenticationService(TextQuestDbContext context)
        {
            _context = context;
        }
        public void AddLevelToFavourites(int id)
        {
            throw new NotImplementedException();
        }

        public void AddUser(string login, string password, string acesslevel)
        {
            throw new NotImplementedException();
        }

        public void AddUser(Authentication user)
        {
             _context.Authentications.Add(user);
             _context.SaveChanges();
        }

        public void AddUserLevel(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Inventory GetInventory(int id)
        {
            throw new NotImplementedException();
        }

        public string GetLogin(int id)
        {
            throw new NotImplementedException();
        }

        public Authentication GetUser(int id)
        {
            return _context.Authentications.FirstOrDefault(u =>u.Id == id);
        }

        public Authentication GetUser(string login, string password)
        {
            return _context.Authentications.FirstOrDefault(u => u.Login == login && u.Password == password);
        }

        public IEnumerable<Level> GetUsersFavouriteLevels(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Level> GetUsersLevels(int id)
        {
            throw new NotImplementedException();
        }

        public bool LoginIsValid(string log, string pas)
        {
           return _context.Authentications.FirstOrDefault(user => user.Login == log && user.Password == pas) is null?false:true;
        }
    }
}