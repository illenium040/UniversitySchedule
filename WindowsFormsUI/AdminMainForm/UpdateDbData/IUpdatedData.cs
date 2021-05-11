using DataAccess.Repositories;

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsUI.AdminMainForm.UpdateDbData
{
    internal interface IUpdateData<T> : IModifyGridDbData
        where T : class
    {
        public UpdatedData<T> UpdatedData { get; }
        public void SetGrid(IRepository<T> repo);
        public bool Save(IRepository<T> repo);
    }

    internal interface IUpdateData<TRepo, TOnUpdate> : IModifyGridDbData
        where TRepo : class
        where TOnUpdate : class
    {
        public UpdatedData<TOnUpdate> UpdatedData { get; }
        public void SetGrid(IRepository<TRepo> repo);
        public bool Save(IRepository<TRepo> repo);
    }

    internal interface IUpdatedDataExtraRepo<TRepo>
         where TRepo : class
    {
        public void SetExtraRepo(IRepository<TRepo> repo);
    }
}
