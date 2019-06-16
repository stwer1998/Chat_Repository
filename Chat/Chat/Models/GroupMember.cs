using System;
using System.Collections.Generic;
using System.Text;

namespace ChatModels
{
    public class GroupMember
    {
        public int GroupMemberId { get; private set; }
        public User Member { get; set; }
        public Role RoleInGroup { get; set; }
        public DateTime BlockedUntil { get; set; }
    }
}
