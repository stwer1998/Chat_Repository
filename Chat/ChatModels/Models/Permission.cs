using System;
using System.Collections.Generic;
using System.Text;

namespace ChatModels
{
    public class Permission
    {
        public int PermissionId { get; private set; }
        public User User { get; set; }
        public List<Rights> Rights { get; set; }
    }
}
