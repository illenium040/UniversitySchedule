using DataAccess.Entities;

using System;
using System.Collections.Generic;
using System.Text;

using WindowsFormsUI.MVP.Views;

namespace WindowsFormsUI.MVP.Presenters
{
    public class AdminDatabasePresenter : BasePartialPresenter<IAdminDatabaseView, User>
    {
        private User _user;
        public AdminDatabasePresenter(IApplicationController controller,
            IAdminDatabaseView view) : base(controller, view)
        {
        }

        public override void Run(User argument)
        {
            _user = argument;
        }
    }
}
