using System;
using System.Collections.Generic;
using System.Text;

using WindowsFormsUI.MVP.Views;

namespace WindowsFormsUI.AdminMainForm
{
    public partial class AdminForm : IAdminDatabaseView
    {
        public string AdminDatabaseConnectionString => throw new NotImplementedException();

        public string UserDatabaseConnectionString => throw new NotImplementedException();

        public bool IsDefaultConnectionStrings => throw new NotImplementedException();

        public string DatabasePath => throw new NotImplementedException();

        public string DatabaseSavePath => throw new NotImplementedException();

        public string SavedFileName => throw new NotImplementedException();

        public event Action SaveDatabaseConStrings;
        public event Action GetSavePathFromDialog;
        public event Action GetDatabasePathFromDialog;
        public event Action CreateBackup;
    }
}
