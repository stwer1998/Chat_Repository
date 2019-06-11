using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatModels
{
    public class GroupRepository:IGroupRepository
    {
        private MyDbContext db;
        public GroupRepository()
        {
            db = new MyDbContext();
        }

        public void AddMember(int groupId, User user, User newuser)
        {
            throw new NotImplementedException();
        }

        public void AddModerator(int groupId, User user, User moderatoruser)
        {
            throw new NotImplementedException();
        }

        public void BlockUser(int groupId, User user, User blockuser)
        {
            throw new NotImplementedException();
        }

        public void DeleteMessage(int groupId, User user, int idmessage)
        {
            throw new NotImplementedException();
        }

        public void DropMember(int groupId, User user, User dropuser)
        {
            throw new NotImplementedException();
        }

        public void DropModerator(int groupId, User user, User dropmoderator)
        {
            throw new NotImplementedException();
        }

        public int GreateGroup(User user,string name)
        {
            db.Group.Add(new Group {NameGroup=name,Admin=user});
            db.SaveChanges();
            return db.Group.FirstOrDefault(x => x.NameGroup == name && x.Admin == user).GroupId;
        }

        public void RenameGroup(int groupId, User user, string newname)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(int groupId, User senduser, string message)
        {
            throw new NotImplementedException();
        }

        public void UnlockUser(int groupId, User user, User unlockkuser)
        {
            throw new NotImplementedException();
        }
    }
}
