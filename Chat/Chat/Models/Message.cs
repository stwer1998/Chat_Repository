using System;
using System.Collections.Generic;
using System.Text;

namespace ChatModels
{
    public class Message
    {
        public int MessageId { get; private set; }
        public User Owner { get; set; }
        public string Content { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
