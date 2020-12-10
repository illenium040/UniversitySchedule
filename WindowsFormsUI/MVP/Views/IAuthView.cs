using System;

namespace WindowsFormsUI.MVP.Views
{
    public interface IAuthView : IView
    {
        string UserName { get; }
        string UserPassword { get; }
        event Action UserAuth;
        void ShowError(string message);
        void ShowAuthState(string message);
        void SetControlsTurnState(bool state);
    }
}
