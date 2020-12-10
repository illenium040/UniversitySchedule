using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsUI.MVP
{
    public interface IPresenter
    {
        void Run();
    }

    public interface IPresenter<in TArg>
    {
        void Run(TArg argument);
    }
}
