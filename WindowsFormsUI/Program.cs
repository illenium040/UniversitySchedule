
using DataAccess;
using DataAccess.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            DataAccessSettings.ConnectionString
               = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\illenium\Desktop\ScheduleProject\UniversitySchedule.accdb;";

            var controller = new ApplicationController(new LightInjectAdapter())
                .RegisterView<IAuthView, AuthForm>()
                .RegisterView<IUserView, UserForm>()
                .RegisterService<IAuthService, AuthService>()
                .RegisterService<ITimetableLoaderService, TimetableLoaderService>()
                .RegisterInstance(new ApplicationContext());

            //controller.Run<UserPresenter, User>(new User());
            controller.Run<AuthPresenter>();
        }
    }
}
