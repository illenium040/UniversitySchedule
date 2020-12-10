using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsUI.MVP
{
    public interface IView
    {
        void Show();
        void FromThread(Action action);
        void Close();
    }
}
