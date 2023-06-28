using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGToDoLIstApp.Classes
{
    public class ToDoTask
    {
        public Guid UserId;
        public int Id;
        public string Title;
        public string Description;
        public bool IsFinished;


        public ToDoTask(Guid userId, int id, string title, string decription)
        {
            UserId = userId;
            Id = id;
            Title = title;
            Description = decription;
            IsFinished = false;
        }
    }
}
