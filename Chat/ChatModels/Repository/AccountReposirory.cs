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
            var role = db.Roles.FirstOrDefault(x => x.UserRole == "active");
            if (role==null)
            {
                var firsttime = new FirstDates();
                firsttime.AddingRoles();
                role= db.Roles.FirstOrDefault(x => x.UserRole == "active");
            }
            
            var user1 = new User() { Name = user.Name, PasswordHash = user.PasswordHash, Role = role };
            db.User.Add(user1);
            db.SaveChanges();
        }

        public bool GetLogin(string login)
        {
            var u = db.User.FirstOrDefault(x => x.Name == login);
            if (u!=null) { return true; }
            else return false;
        }

        public bool GetUser(string login, string password)
        {
            var u = db.User.FirstOrDefault(x => x.Name == login && x.PasswordHash == password);
            if (u != null) { return true; }
            else return false;
        }
    }
}
