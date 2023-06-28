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
    public partial class RegisterControl : UserControl
    {
        private MainForm _mainForm;
        public RegisterControl(MainForm mainForm)
        {
            InitializeComponent();

            _mainForm = mainForm;

            Dock = DockStyle.Fill;

            lblWarning1.Visible = false;
            lblWarning2.Visible = false;
            lblWarning3.Visible = false;
            lblWarning4.Visible = false;
        }

        private void OnRegisterClick(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtName.Text)) { lblWarning4.Visible = true; }
            if(string.IsNullOrWhiteSpace(txtUsername.Text)) { lblWarning3.Visible = true; }
            if(string.IsNullOrWhiteSpace(txtPassword.Text)) { lblWarning2.Visible = true; }
            if(string.IsNullOrWhiteSpace(txtConfirmPass.Text)) { lblWarning1.Visible = true; }

            if (_mainForm._userManager.UsernameFree(txtUsername.Text) && txtPassword.Text == txtConfirmPass.Text)
            {
                User NewUser = new User(txtName.Text, txtUsername.Text, txtPassword.Text, Guid.NewGuid());
                _mainForm._userManager.AddUser(NewUser);
                _mainForm.ShowTasksControl(NewUser);
            }
            else if(txtPassword.Text != txtConfirmPass.Text)
            {
                MessageBox.Show("You need to confirm password!", "Failed Password Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnBackClick(object sender, EventArgs e)
        {
            _mainForm.ShowLoginControl();
        }
    }
}
