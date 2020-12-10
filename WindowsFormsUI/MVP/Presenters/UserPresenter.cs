using DataAccess.Entities;

using System;
using System.Collections.Generic;
using System.Text;

using WindowsFormsUI.MVP.Views;

namespace WindowsFormsUI.MVP.Presenters
{
    public class UserPresenter : BasePresenter<IUserView, User>
    {
        private User _user;
        public UserPresenter(IApplicationController controller, IUserView view) : base(controller, view)
        {
        }

        public override void Run(User argument)
        {
            _user = argument;
            View.Show();
        }
    }
}
