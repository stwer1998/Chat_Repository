using System;
using System.Collections.Generic;
using System.Text;

namespace ChatModels
{
    public class FirstDates
    {
        private MyDbContext db;
        public FirstDates()
        {
            db = new MyDbContext();
        }

        public void AddingRoles()
        {
            db.Roles.AddRange(new Role[] { new Role {UserRole="admin" }, new Role { UserRole = "moderator" }, new Role { UserRole = "active" },
                new Role { UserRole = "blocked" } });
            db.SaveChanges();
        }
    }
}
