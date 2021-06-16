using DataAccess;
using System;
using System.Windows.Forms;
using API.Services;
using WindowsFormsUI.AdminMainForm;
using WindowsFormsUI.MVP.Controllers;
using WindowsFormsUI.MVP.Presenters;
using WindowsFormsUI.MVP.ServiceContainers;
using WindowsFormsUI.MVP.Views;
using WindowsFormsUI.Services;
using WindowsFormsUI.UserMainForm;
using WindowsFormsUI.AuthMainForm;
using DataAccess.Entities;
using iTextSharp.text.pdf;
using iTextSharp.text;

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

            DataAccessSettings.ConnectionString = ConfigIni.GetConnectionString();
            
            var controller = new ApplicationController(new LightInjectAdapter())
                .RegisterView<IAuthView, AuthForm>()
                .RegisterView<IUserView, UserForm>()
                .RegisterView<IAdminView, AdminForm>()
                .RegisterView<IRegisterView, RegisterForm>()
                .RegisterService<IAuthService, AuthService>()
                .RegisterInstance(new ApplicationContext())
                .RegisterService<SolverService, DefaultSolverService>()
                .RegisterInstance<ITimetableViewDataLoader>(new TimetableViewDataLoader());

           
            controller.GetPresenter<AuthPresenter>().Run();
        }
    }
}
