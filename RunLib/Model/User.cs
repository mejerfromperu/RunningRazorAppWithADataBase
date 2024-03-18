using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunLib.Model
{
    public class User
    {

        public String Name { get; set; }
        public bool Admin { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public User(string name, string username, string password, bool admin = false)
        {
            Name = name;
            Admin = admin;
            Username = username;
            Password = password;
        }

        public User()
        {
        }

        
    }
}
