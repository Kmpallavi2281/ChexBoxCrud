﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace login.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Reqierd]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}