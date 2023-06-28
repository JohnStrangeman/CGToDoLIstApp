using CGToDoLIstApp.Classes;
using CGToDoLIstApp.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CGToDoLIstApp
{
    public partial class MainForm : Form
    {
        public UserManager _userManager;

        public MainForm()
        {
            InitializeComponent();
            ShowLoginControl();

            _userManager = new UserManager();
        }

        public void ShowLoginControl() 
        {
            Controls.Clear();

            Controls.Add(new LoginControl(this));
        }
        public void ShowRegisterControl()
        {
            Controls.Clear();

            Controls.Add(new RegisterControl(this));
        }
        public void ShowTasksControl(User user)
        {
            Controls.Clear();

            Controls.Add(new TasksControl(this, user));
        }
    }
}
