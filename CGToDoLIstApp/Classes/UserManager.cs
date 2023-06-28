using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGToDoLIstApp.Classes
{
    public class UserManager
    {
        private List<User> _users;
        public UserManager()
        {
            _users = new List<User>();

            _users.Add(new User("test", "test", "test", Guid.NewGuid()));

            _users = FileHelper.LoadUsers();
        }

        public User FindUser(string Login, string Password)
        {
            foreach(User user in _users)
            {
                if(user.Username == Login && user.Password == Password)
                {
                    return user;
                }
            }
            return null;
        }

        public bool UsernameFree(string Username)
        {
            foreach (User user in _users)
            {
                if(user.Username == Username)
                {
                    return false;
                }
            }
            return true;
        }

        public void AddUser(User user)
        {
            FileHelper.SaveUser(user);
            _users = FileHelper.LoadUsers();
        }
    }
}
