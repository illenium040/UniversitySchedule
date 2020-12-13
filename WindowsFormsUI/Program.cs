
using DataAccess;
using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.RepositoryUsage;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using WindowsFormsUI.AdminMainForm;
using WindowsFormsUI.MVP.Controllers;
using WindowsFormsUI.MVP.Presenters;
using WindowsFormsUI.MVP.ServiceContainers;
using WindowsFormsUI.MVP.Views;
using WindowsFormsUI.Services;
using WindowsFormsUI.UserMainForm;

namespace WindowsFormsUI
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DataAccessSettings.ConnectionString = Properties.Settings.Default.DatabaseAdminConString;
            

            var controller = new ApplicationController(new LightInjectAdapter())
                .RegisterView<IAuthView, AuthForm>()
                .RegisterView<IUserView, UserForm>()
                .RegisterView<IAdminView, AdminForm>()
                .RegisterService<IAuthService, AuthService>()
                .RegisterInstance(new ApplicationContext())
                .RegisterInstance<ITimetableViewDataLoader>(new TimetableViewDataLoader());

            var vitalikUser = new User
            {
                Id = "777",
                IsAdmin = false,
                Login = "VitalikNotCool2007",
                Password = "777"
            };
            var vitalikAdminUser = new User
            {
                Id = "777",
                IsAdmin = true,
                Login = "VitalikCool2009",
                Password = "777"
            };

            controller.GetPresenter<AdminPresenter, User>().Run(vitalikAdminUser);
            //controller.Run<UserPresenter, User>(vitalikUser);
            //controller.Run<AuthPresenter>();
        }
    }
}
