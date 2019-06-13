﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ChatModels
{
    public class User
    {
        public int UserId { get;private set; }
        public string Name { get; set; }
        public string PasswordHash { get; set; }
        public Role Role { get; set; }
    }
}
