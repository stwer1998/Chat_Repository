using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatModels
{
    public class AccountReposirory : IAccountReposirory
    {
        private MyDbContext db;
        public AccountReposirory()
        {
            db = new MyDbContext();
        }

        public void AddUser(User user)
        {
            db.User.Add(user);
            db.SaveChanges();
        }

        public bool GetLogin(string login)
        {
            var u = db.User.FirstOrDefault(x => x.Name == login);
            if (u!=null) { return true; }
            else return false;
        }

        public bool GetUser(string login, int password)
        {
            var u = db.User.FirstOrDefault(x => x.Name == login && x.PasswordHash == password);
            if (u != null) { return true; }
            else return false;
        }
    }
}
