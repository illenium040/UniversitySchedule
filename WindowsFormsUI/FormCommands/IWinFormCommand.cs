using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsUI.FormCommands
{
    public interface IWinFormCommand<T>
    {
        T Execute();
    }
}
