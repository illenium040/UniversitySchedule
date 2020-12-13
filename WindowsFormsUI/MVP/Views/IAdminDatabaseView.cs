using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsUI.MVP.Views
{
    public interface IAdminDatabaseView : IPartialView
    {
        event Action SaveDatabaseConStrings;
        string AdminDatabaseConnectionString { get; }
        string UserDatabaseConnectionString { get; }
        public bool IsDefaultConnectionStrings { get; }

        event Action GetSavePathFromDialog;
        event Action GetDatabasePathFromDialog;
        event Action CreateBackup;
        string DatabasePath { get; }
        string DatabaseSavePath { get; }
        string SavedFileName { get; }

    }
}
