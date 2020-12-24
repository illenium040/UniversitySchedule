using DataAccess.Entities;

using System;
using System.Collections.Generic;
using System.Text;

using WindowsFormsUI.MVP.Views;

namespace WindowsFormsUI.MVP.Presenters
{
    public class AdminPresenter : BasePresenter<IAdminView, User>
    {
        private User _user;
        private List<IPresenter<User>> _partialViews;
        public AdminPresenter(IApplicationController controller, IAdminView view) : base(controller, view)
        {
            _partialViews = new List<IPresenter<User>>()
            {
                new AdminCreateTimetablePresenter(controller, view as IAdminCreateTimetableView),
                new AdminDatabasePresenter(controller, view as IAdminDatabaseView)
            };
        }

        public override void Run(User argument)
        {
            _user = argument;
            foreach (var presenter in _partialViews)
                presenter.Run(_user);
            View.Show();
        }
    }
}
