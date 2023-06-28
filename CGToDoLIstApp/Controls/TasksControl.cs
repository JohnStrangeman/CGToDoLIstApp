using CGToDoLIstApp.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CGToDoLIstApp.Forms
{
    public partial class TasksControl : UserControl
    {
        private MainForm _mainForm;
        private User _logged;
        private ToDoTaskManager _toDoTaskMenager;

        public TasksControl(MainForm mainForm, User user)
        {
            InitializeComponent();

            _mainForm = mainForm;

            Dock = DockStyle.Fill;

            _logged = user;

            lblUserName.Text = _logged.Name;

            _toDoTaskMenager = new ToDoTaskManager();
            _toDoTaskMenager.LoadUserTasks(_logged.Id);

            foreach (var task in _toDoTaskMenager.GetTasks(_logged.Id))
            {
                AddTaskToList(task);
            }
        }

        private void OnLogOutClick(object sender, EventArgs e)
        {
            _mainForm.ShowLoginControl();
        }

        private void AddTaskToList(ToDoTask task)
        {
            ListViewItem item = new ListViewItem(task.Id.ToString());
            item.SubItems.Add(task.Title);

            //? - terrar operator: if left side is true it will output first value, if false it will output second value
            string ready = task.IsFinished ? "✓" : "✕";
            item.SubItems.Add(ready);

            listViewTasks.Items.Add(item);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewTasks.SelectedItems.Count == 0)
            {
                MessageBox.Show("Task to remove is not selected!", "Info", MessageBoxButtons.OK);
            }
            else
            {
                string selectedTasks = listViewTasks.SelectedItems[0].SubItems[0].Text;

                _toDoTaskMenager.DeleteTask(int.Parse(selectedTasks));

                listViewTasks.Items.Remove(listViewTasks.SelectedItems[0]);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int id = _toDoTaskMenager.GetNextId();

            ToDoTask task = new ToDoTask(_logged.Id, id, "New Task", "Description");

            TaskDetails detailsForm = new TaskDetails(task);
            detailsForm.ShowDialog();

            if(detailsForm.IsSaved)
            {
                _toDoTaskMenager.AddTask(task);

                AddTaskToList(task);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(listViewTasks.SelectedItems.Count == 0)
            {
                MessageBox.Show("First select a task!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string selectedTask = listViewTasks.SelectedItems[0].SubItems[0].Text;

                ToDoTask task = _toDoTaskMenager.FindTask(int.Parse(selectedTask));

                TaskDetails detailsForm = new TaskDetails(task);
                detailsForm.ShowDialog();

                if(detailsForm.IsSaved)
                {
                    _toDoTaskMenager.UpdateUserTasks(_logged.Id);

                    listViewTasks.SelectedItems[0].SubItems[1].Text = task.Title;
                    listViewTasks.SelectedItems[0].SubItems[2].Text = task.IsFinished ? "✓" : "✕";
                }
            }
        }
    }
}
