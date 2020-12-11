using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsUI.MVP
{
    public interface IView
    {
        void Show();
        DialogResult ShowDialog();
        void FromThread(Action action);
        void Close();
    }
}
