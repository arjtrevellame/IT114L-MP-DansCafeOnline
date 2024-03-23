using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Login.App.Users
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }

    public class currentUser
    {
        public string Username { get; set; }
    }
}