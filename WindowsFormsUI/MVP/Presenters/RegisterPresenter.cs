using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using WindowsFormsUI.MVP.Views;
using WindowsFormsUI.Services;

namespace WindowsFormsUI.MVP.Presenters
{
    public class RegisterPresenter : BasePresenter<IRegisterView>
    {
        private IAuthService _service;
        public RegisterPresenter(IApplicationController controller, IRegisterView view, IAuthService service) 
            : base(controller, view)
        {
            _service = service;
            View.Register += Register;
        }

        private void Register()
        {
            try
            {
                var user = _service.FindUser(View.Login).Result;
                if(user != null)
                {
                    WinFormStaticHelper.ShowErrorMsgBox("Такой пользователь уже существует");
                    return;
                }
                if (!View.Password.Equals(View.PasswordCheck))
                {
                    WinFormStaticHelper.ShowErrorMsgBox("Подтвердите пароль");
                    return;
                }
                _service.RegisterUser(View.Login, View.Password);
                MessageBox.Show("Пользователь создан успешно", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                WinFormStaticHelper.ShowErrorMsgBox(e.Message);
            }
        }
    }
}
