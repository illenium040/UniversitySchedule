using DataAccess.Entities;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using WindowsFormsUI.MVP.Views;
using WindowsFormsUI.Services;

namespace WindowsFormsUI.MVP.Presenters
{
    public class AuthPresenter : BasePresenter<IAuthView>
    {
        private readonly IAuthService _authService;
        public AuthPresenter(IApplicationController appController, IAuthService authService, IAuthView authView)
            : base(appController, authView)
        {
            _authService = authService;
            View.UserAuth += () => Login();
        }

        private void Login()
        {
            if (string.IsNullOrEmpty(View.UserName))
                throw new ArgumentNullException("username");
            if (string.IsNullOrEmpty(View.UserPassword))
                throw new ArgumentNullException("password");

            View.SetControlsTurnState(false);
            View.ShowAuthState("Авторизация...");
            try
            {
                var user = _authService.Auth(View.UserName, View.UserPassword).Result;
                if(user.IsAdmin) View.FromThread(() => Controller.Run<AdminPresenter, User>(user));
                else View.FromThread(() => Controller.Run<UserPresenter, User>(user));
                View.Close();
            }
            catch (UnauthorizedAccessException exception)
            {
                View.ShowAuthState(exception.Message);
                View.SetControlsTurnState(true);
            }
            catch (InvalidOperationException exc)
            {
                if (exc.Message.Contains("Microsoft.ACE.OLEDB") && exc.Source == "System.Data.OleDb")
                    View.ShowError("Необходимо установить AccessDatabaseEngine x86 или x64");
                View.ShowAuthState("");
                View.SetControlsTurnState(true);
            }
            catch (Exception exc)
            {
                View.ShowAuthState($"Произошла непредвиденная ошибка: {exc.Message}");
                View.SetControlsTurnState(true);
            }
            
        }
    }
}
