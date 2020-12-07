#define DBG_USER
//#define DBG_ADMIN
using DataAccess;
using DataAccess.Entities;
using DataAccess.Loggers;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Windows.Forms;

using TimetableAlgorithm;

using UniversityTimetableGenerator;
using UniversityTimetableGenerator.Services;

using WindowsFormsUI.AdminMainForm;
using WindowsFormsUI.UserMainForm;

namespace WindowsFormsUI
{
    public partial class MainForm : Form
    {
        private AuthForm _authForm;
        private Form _userForm;
        public MainForm()
        {
            InitializeComponent();
            DataAccessSettings.ConnectionString
                = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\illenium\Desktop\ScheduleProject\UniversitySchedule.accdb;";

            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
#if DBG_USER
            _userForm = new UserForm(this, new User
            {
                Id = "1",
                Login = "user",
                Password = "user",
                IsAdmin = false
            });
            _userForm.Show();
#elif DBG_ADMIN
            _userForm = new AdminForm(this, new User
            {
                Id = "2",
                Login = "admin",
                Password = "admin",
                IsAdmin = true
            });
            _userForm.Show();
#else
            _authForm = new AuthForm();
            _authForm.Show();
            _authForm.UserCreatedEvent += Authorized;
            _authForm.FormClosed += _authForm_FormClosed;
#endif
        }

        private void _authForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void Authorized(User user)
        {
            if (user.IsAdmin) _userForm = new AdminForm(this, user);
            else _userForm = new UserForm(this, user);
            _authForm.FormClosed -= _authForm_FormClosed;
            _authForm.Close();

            _userForm.Show();
        }
    }
}
