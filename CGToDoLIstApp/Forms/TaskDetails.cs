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
    public partial class TaskDetails : Form
    {
        public ToDoTask TodoTask;
        public bool IsSaved;

        public TaskDetails(ToDoTask task)
        {
            InitializeComponent();
            TodoTask = task;
            lblbNumber.Text = task.Id.ToString();
            txtTitle.Text = task.Title;
            txtDescription.Text = task.Description;
            cbxFinished.Checked = task.IsFinished;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TodoTask.Description = txtDescription.Text;
            TodoTask.Title = txtTitle.Text;
            TodoTask.IsFinished = cbxFinished.Checked;
            IsSaved = true;
            Close();
        }
    }
}
