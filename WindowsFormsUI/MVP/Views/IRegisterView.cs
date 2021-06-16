using System;
using System.Collections.Generic;
using System.Text;

using WindowsFormsUI.Services;

namespace WindowsFormsUI.MVP.Views
{
    public interface IRegisterView : IView
    {
        string Login { get; }
        string Password { get; }
        string PasswordCheck { get; }
        event Action Register;
    }
}
