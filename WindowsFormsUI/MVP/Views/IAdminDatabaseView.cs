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

        event Action SetSavePathFromDialog;
        event Action SetDatabasePathFromDialog;
        event Action CreateBackup;
        event Action LoadDatabaseSettings;
        event Action UseDefaultConStringsChecked;
        string DatabasePath { get; set; }
        string DatabaseSavePath { get; set; }
        string DatabaseSavedFileName { get; }

        public void SetDatabaseSettings(DatabaseSettings settings, bool isDefault);


    }
}
