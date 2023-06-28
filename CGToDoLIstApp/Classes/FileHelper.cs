using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGToDoLIstApp.Classes
{
    public static class FileHelper
    {
        private static string _basePath = $@"{AppDomain.CurrentDomain.BaseDirectory}/data/";


        public static List<ToDoTask> LoadTasks(Guid userId)
        {
            List<ToDoTask> toDoTasks = new List<ToDoTask>();
            
            string filePath = $@"{_basePath}{userId}.txt";

            if (File.Exists(filePath))
            {
                StreamReader reader = new StreamReader(filePath);

                string line;
                while((line = reader.ReadLine()) != null)
                {
                    string[] columns = line.Split('|');
                    int id = int.Parse(columns[0]);
                    string title = columns[1];
                    bool isFinished = bool.Parse(columns[2]);
                    string description = columns[3];

                    ToDoTask task = new ToDoTask(userId, id, title, description);
                    task.IsFinished = isFinished;
                    toDoTasks.Add(task);
                }
                reader.Close();
            }
            return toDoTasks;
        }

        public static void SaveTasks(List<ToDoTask> tasks, Guid userId)
        {
            string filePath = $@"{_basePath}{userId}.txt";

            StringBuilder builder = new StringBuilder();

            foreach(var task in tasks)
            {
                builder.AppendLine($"{task.Id}|{task.Title}|{task.IsFinished}|{task.Description}");

                File.WriteAllText(filePath, builder.ToString());
            }
        }

        public static void SaveUser(User user)
        {
            string filePath = $"{_basePath}users.txt";

            string line = $"{user.Id}|{user.Name}|{user.Username}|{user.Password}{Environment.NewLine}";

            if(!Directory.Exists($@"{AppDomain.CurrentDomain.BaseDirectory}/data"))
            {
                Directory.CreateDirectory($@"{AppDomain.CurrentDomain.BaseDirectory}/data");
            }
            File.AppendAllText(filePath, line);
        }

        public static List<User> LoadUsers()
        {
            List<User> users = new List<User>();
            string filePath = $"{_basePath}users.txt";
            if(File.Exists(filePath))
            {
                StreamReader reader = new StreamReader(filePath);
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    string[] columns = line.Split('|');
                    Guid id = Guid.Parse(columns[0]);
                    string name = columns[1];
                    string username = columns[2];
                    string password = columns[3];

                    User user = new User(name, username, password, id);
                    users.Add(user);
                }
                reader.Close();
            }
            return users;
        }
    }
}
