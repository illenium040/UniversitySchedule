using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsUI.MVP.Views
{
    public interface IAdminView : IView
    {
        public string Title { get; set; }
    }
}
