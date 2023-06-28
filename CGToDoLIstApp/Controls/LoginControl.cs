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
    public partial class LoginControl : UserControl
    {
        private MainForm _mainForm;
        public LoginControl(MainForm mainForm)
        {
            InitializeComponent();

            _mainForm = mainForm;

            Dock = DockStyle.Fill;

            lblError.Visible = false;
        }

        private void OnSingUpClick(object sender, EventArgs e)
        {
            _mainForm.ShowRegisterControl();
        }

        private void OnSingInClick(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblError.Visible = true;
            }
            else
            {
                User _CurrentUser = _mainForm._userManager.FindUser(txtUsername.Text, txtPassword.Text);

                if (_CurrentUser != null)
                {
                    lblError.Visible = false;
                    _mainForm.ShowTasksControl(_CurrentUser);
                }
                else 
                {
                    lblError.Visible = true;
                }
            }
        }
    }
}
