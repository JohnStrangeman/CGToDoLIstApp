using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGToDoLIstApp.Classes
{
    public class User
    {
        public string Name;
        public string Username;
        public string Password;
        public Guid Id;

        public User(string name, string username, string password, Guid id)
        {
            this.Name = name;
            this.Username = username;
            this.Password = password;
            this.Id = id;
        }
    }
}
