using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Repositories.RepositoryInterfaces;
using DataAccess.RepositoryUsage;

using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsUI.MVP.Views
{
    public interface IAdminFormUpdateDB : IPartialView
    {
        public bool IsSavedSuccesfully { get; set; }
        public bool IsPreLoading { get; set; }
        public bool IsConfirmationRequired { get; }
        public event Action SaveChanges;
        public event Action LoadData;

        public IEnumerable<string> TableNameList { get; set; }
        public string SelectedTable { get; }

        public int SelectedIndex { get; }
        public void SetUpdateEvents();

        public void SetData(ITimetableViewData data);

    }
}
