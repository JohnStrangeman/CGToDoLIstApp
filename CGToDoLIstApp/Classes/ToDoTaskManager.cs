using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGToDoLIstApp.Classes
{
    public class ToDoTaskManager
    {
        private List<ToDoTask> _allTasks;

        public ToDoTaskManager()
        {
            _allTasks = new List<ToDoTask>();
        }

        public ToDoTask FindTask(int id)
        {
            foreach(ToDoTask task in _allTasks)
            {
                if(task.Id == id)
                {
                    return task;
                }
            }
            return null;
        }

        public void AddTask(ToDoTask task)
        {
            _allTasks.Add(task);
            UpdateUserTasks(task.UserId);
        }

        public void DeleteTask(int id)
        {
            ToDoTask task = FindTask(id);
            _allTasks.Remove(task);
            UpdateUserTasks(task.UserId);
        }

        public List<ToDoTask> GetTasks(Guid userId)
        {
            List<ToDoTask> loggedTasks = new List<ToDoTask>();
            foreach (ToDoTask task in _allTasks)
            {
                if (task.UserId == userId)
                {
                    loggedTasks.Add(task);
                }
            }
            return loggedTasks;
        }

        public int GetNextId()
        {
            int max = 0;
            foreach(ToDoTask task in _allTasks)
            {
                if (task.Id > max)
                {
                    max = task.Id;
                }
            }
            return max + 1;
        }

        public void LoadUserTasks(Guid userId)
        {
            _allTasks = FileHelper.LoadTasks(userId);
        }
        
        public void UpdateUserTasks(Guid userId)
        {
            FileHelper.SaveTasks(_allTasks, userId);
        }
    }
}
