﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ChatModels
{
    public class GroupRepository:IGroupRepository
    {
        private MyDbContext db;
        public GroupRepository(MyDbContext _db)
        {
            db = _db;
        }

        public string AddMember(int groupId, User user, User newuser)
        {
            if (Check(user, groupId) != "bloced")
            {
                var role = db.Roles.First(x => x.UserRole == "active");
                db.Group.First(x => x.GroupId == groupId).Members.Add(new GroupMember { Member = newuser, RoleInGroup = role });
                db.SaveChanges();
                return user.Name + " добавил :" + newuser.Name;
            }
            else return "У вас нет прав на это";
        }

        public string AddModerator(int groupId, User user, User moderatoruser)
        {
            if (Check(user, groupId) == "admin")
            {
                var d = db.Group.Include(x => x.Members).First(x => x.GroupId == groupId).Members.First(p => p.Member == moderatoruser);
                var role = db.Roles.First(x => x.UserRole == "moderator");
                db.Group.Include(x => x.Members).First(x => x.GroupId == groupId).Members.First(x => x.Member == moderatoruser).RoleInGroup = role;
                db.SaveChanges();
                return user.Name + " сделал модератором : " + moderatoruser.Name;

            }
            else return "У вас нет прав на это";

        }

        public string BlockUser(int groupId, User user, User blockuser)
        {
            if (Check(user,groupId) == "admin" || Check(user, groupId) == "moderator")
            {
                var d = db.Group.Include(x => x.Members).First(x => x.GroupId == groupId).Members.First(p => p.Member == blockuser);
                var role = db.Roles.First(x=>x.UserRole== "blocked");
                db.Group.Include(x => x.Members).First(x => x.GroupId == groupId).Members.First(x => x.Member == blockuser).RoleInGroup = role;
                db.SaveChanges();
                return user.Name + " заблокировал :" + blockuser.Name;

            }
            else return "У вас нет прав на это";
        }

        public string DeleteMessage(int groupId, User user, int idmessage)
        {
            if (Check(user, groupId) == "admin" || Check(user, groupId) == "moderator") { return null; }
            else return "У вас нет прав на это";
        }

        public string DropMember(int groupId, User user, User dropuser)
        {
            if (Check(user,groupId) == "admin"|| Check(user, groupId) == "moderator")
            {
                var d = db.Group.Include(x => x.Members).First(x => x.GroupId == groupId).Members.First(p => p.Member == dropuser);
                db.Group.Include(x => x.Members).First(x => x.GroupId == groupId).Members.Remove(d);
                db.SaveChanges();
                return user.Name + " удалил :" + dropuser.Name;
            }
            else return "У вас нет прав на это";
        }

        public string DropModerator(int groupId, User user, User dropmoderator)
        {
            if (Check(user, groupId) == "admin")
            {
                var d = db.Group.Include(x => x.Members).First(x => x.GroupId == groupId).Members.First(p => p.Member == dropmoderator);
                var role = db.Roles.First(x => x.UserRole == "active");
                db.Group.Include(x => x.Members).First(x => x.GroupId == groupId).Members.First(x => x.Member == dropmoderator).RoleInGroup = role;
                db.SaveChanges();
                return user.Name + " удалил модератора :" + dropmoderator.Name;

            }
            else return "У вас нет прав на это";
        }

        public User GetUser(string login)
        {
            return db.User.Include(x=>x.Role).FirstOrDefault(x=>x.Name==login);
        }

        public List<Group> GetUserGroups(User user)
        {
            if (user != null)
            {
                return db.Group.Where(x => x.Members.Select(w => w.Member).Contains(user)).ToList();
            }
            else return new List<Group>();
        }

        public string RenameGroup(int groupId, User user, string newname)
        {
            if (Check(user,groupId)=="admin") {
                db.Group.First(x => x.GroupId == groupId).NameGroup = newname;
                db.SaveChanges();
                return user.Name + " переименовал комнату :" + newname;
            }
            else return "У вас нет прав на это";
        }

        public string SendMessage(int groupId, User senduser, string message)
        {
            if (Check(senduser,groupId)!="blocked") { return null; }
            else return null;
        }

        public string UnlockUser(int groupId, User user, User unlockkuser)
        {
            if (Check(user, groupId) == "admin" || Check(user, groupId) == "moderator")
            {
                var d = db.Group.Include(x => x.Members).First(x => x.GroupId == groupId).Members.First(p => p.Member == unlockkuser);
                var role = db.Roles.First(x => x.UserRole == "active");
                db.Group.Include(x => x.Members).First(x => x.GroupId == groupId).Members.First(x => x.Member == unlockkuser).RoleInGroup = role;
                db.SaveChanges();
                return user.Name + " разблокировал :" + unlockkuser.Name;
            }
            return "У вас нет прав на это";

        }

        public int СreateGroup(User user, string name)
        {
            if (user.Role.UserRole == "active")
            {
                Group gr = new Group
                {
                    NameGroup = name,
                    Members = new List<GroupMember>()
                { new GroupMember { Member = user, RoleInGroup = db.Roles.FirstOrDefault(x => x.UserRole == "admin") } }
                };
                db.Group.Add(gr);
                db.SaveChanges();
                return db.Group.FirstOrDefault(x => x.NameGroup == name && x.Members.First().Member == user).GroupId;
            }
            return 0;
        }

        public string Check(User user,int groupId)
        {
            var a=db.Group.Include(x=>x.Members).ThenInclude(p=>p.RoleInGroup).First(x => x.GroupId == groupId)
                .Members.FirstOrDefault(w => w.Member == user);
            if (a.Member == user)
            {
                return a.RoleInGroup.UserRole;
            }
            else return "blocked";
        }
    }
}
