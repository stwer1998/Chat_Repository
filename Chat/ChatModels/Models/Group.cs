using System;
using System.Collections.Generic;
using System.Text;

namespace ChatModels
{
    public class Group
    {
        public int GroupId { get; private set; }
        public string NameGroup { get; set; }
        public List<GroupMember> Members { get; set; }
        public List<Message> Messages { get; set; }
        public Role RoleGroup { get; set; }
    }
}
