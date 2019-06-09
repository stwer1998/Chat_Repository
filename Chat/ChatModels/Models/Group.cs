using System;
using System.Collections.Generic;
using System.Text;

namespace ChatModels
{
    public class Group
    {
        public int GroupId { get; private set; }
        public List<Message> Messages { get; set; }
        public List<User> Members { get; set; }
        public User Admin { get; set; }
        public List<User> Moderators { get; set; }
    }
}
