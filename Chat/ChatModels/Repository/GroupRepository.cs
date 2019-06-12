using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ChatModels
{
    public class GroupRepository:IGroupRepository
    {
        private MyDbContext db;
        public GroupRepository()
        {
            db = new MyDbContext();
        }

        public bool AddMember(int groupId, User user, User newuser)
        {
            if (Check(user, groupId) != "bloced") { return true; }
            else return false;
        }

        public bool AddModerator(int groupId, User user, User moderatoruser)
        {
            if (Check(user, groupId) == "admin") { return true; }
            else return false;
        }

        public bool BlockUser(int groupId, User user, User blockuser)
        {
            if (Check(user,groupId) == "admin" || Check(user, groupId) == "moderator") { return true; }
            else return false;
        }

        public bool DeleteMessage(int groupId, User user, int idmessage)
        {
            if (Check(user, groupId) == "admin" || Check(user, groupId) == "moderator") { return true; }
            else return false;
        }

        public bool DropMember(int groupId, User user, User dropuser)
        {
            if (Check(user,groupId) == "admin"|| Check(user, groupId) == "moderator") { return true; }
            else return false;
        }

        public bool DropModerator(int groupId, User user, User dropmoderator)
        {
            if (Check(user,groupId) == "admin") { return true; }
            else return false;
        }

        public User GetUser(string login)
        {
            return db.User.FirstOrDefault(x=>x.Name==login);
        }

        public List<Group> GetUserGroups(User user)
        {
             return db.Group.Where(x => x.Members.Select(w => w.Member).Contains(new User())).ToList();
        }

        public bool RenameGroup(int groupId, User user, string newname)
        {
            if (Check(user,groupId)=="admin") { return true; }
            else return false;
        }

        public bool SendMessage(int groupId, User senduser, string message)
        {
            if (Check(senduser,groupId)!="blocked") { return true; }
            else return false;
        }

        public bool UnlockUser(int groupId, User user, User unlockkuser)
        {
            var r = db.Group.Include(x => x.Members);
            throw new NotImplementedException();
        }

        public int СreateGroup(User user, string name)
        {
            db.Group.Add(new Group {NameGroup=name,Members=new List<GroupMember>() { new GroupMember {Member=user,RoleInGroup=db.Roles.FirstOrDefault(x=>x.UserRole=="admin") } } });
            db.SaveChanges();
            return db.Group.FirstOrDefault(x=>x.NameGroup==name&&x.Members.First().Member==user).GroupId;
        }

        private string Check(User user,int groupId)
        {
            return db.Group.First(x => x.GroupId == groupId).Members.First(w => w.Member == user).RoleInGroup.UserRole;
        }
    }
}
