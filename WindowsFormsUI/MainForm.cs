//#define DBG_USER
#define DBG_ADMIN
using DataAccess;
using DataAccess.Entities;

using System.Windows.Forms;

using TimetableAlgorithm;

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
           
            

            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
#if DBG_USER
            _userForm = new UserForm(new User
            {
                Id = "1",
                Login = "user",
                Password = "user",
                IsAdmin = false
            });
            _userForm.Show();
#elif DBG_ADMIN
            _userForm = new AdminForm(new User
            {
                Id = "2",
                Login = "admin",
                Password = "admin",
                IsAdmin = true
            });
            _userForm.AddOwnedForm(this);
            _userForm.Show();
#else
            _authForm = new AuthForm();
            _authForm.AddOwnedForm(this);
            _authForm.Show();
            _authForm.UserCreatedEvent += Authorized;
#endif
        }
    }
}
