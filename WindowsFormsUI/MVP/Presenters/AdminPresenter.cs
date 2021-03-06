using DataAccess.Entities;

using System;
using System.Collections.Generic;
using System.Text;

using WindowsFormsUI.MVP.Views;
using WindowsFormsUI.Services;

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
                new AdminTimetableCreationPresenter(controller, view as ITimetableCreationView),
                new AdminDatabasePresenter(controller, view as IAdminDatabaseView),
                new AdminUpdateDBPresenter(controller, controller.GetService<ITimetableViewDataLoader>(), view as IAdminFormUpdateDB)
            };
        }

        public override void Run(User argument)
        {
            _user = argument;
            View.Title = $"Администратор - {_user.Login}";
            foreach (var presenter in _partialViews)
                presenter.Run(_user);
            View.Show();
        }
    }
}
