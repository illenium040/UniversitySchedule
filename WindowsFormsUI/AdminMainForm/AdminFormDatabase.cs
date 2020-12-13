using System;
using System.Collections.Generic;
using System.Text;

using WindowsFormsUI.MVP.Views;

namespace WindowsFormsUI.AdminMainForm
{
    public partial class AdminForm : IAdminDatabaseView
    {
        public string AdminDatabaseConnectionString
        {
            get { return tbxAdminConString.Text; }
        }

        public string UserDatabaseConnectionString
        { 
            get { return tbxUserConString.Text; }
        }

        public bool IsDefaultConnectionStrings { get { return chbxDefaultConStringSettings.Checked; } }

        public string DatabasePath
        { 
            get { return tbxDatabasePathBackup.Text; }
            set { tbxDatabasePathBackup.Invoke(() => tbxDatabasePathBackup.Text = value); }
        }

        public string DatabaseSavePath
        {
            get { return tbxDatabasePathSaveBackup.Text; }
            set { tbxDatabasePathSaveBackup.Invoke(() => tbxDatabasePathSaveBackup.Text = value); }
        }

        public string DatabaseSavedFileName { get { return tbxBackupFileName.Text; } }

        public event Action SaveDatabaseConStrings;
        public event Action SetSavePathFromDialog;
        public event Action SetDatabasePathFromDialog;
        public event Action CreateBackup;
        public event Action LoadDatabaseSettings;
        public event Action UseDefaultConStringsChecked;

        public void SetDatabaseSettings(DatabaseSettings settings, bool isDefault)
        {
            tbxAdminConString.Invoke(() => tbxAdminConString.Text = settings.AdminConnectionString);
            tbxUserConString.Invoke(() => tbxUserConString.Text = settings.UserConnectionString);
            SetReadOnlyConStringsState(isDefault);
        }

        private void SetReadOnlyConStringsState(bool state)
        {
            tbxAdminConString.Invoke(() => tbxAdminConString.ReadOnly = state);
            tbxUserConString.Invoke(() => tbxUserConString.ReadOnly = state);
        }

        private void SetEventsDatabaseView()
        {
            btnSaveConStrings.Click += (sender, e) => SaveDatabaseConStrings?.Invoke();
            btnCreateBackup.Click += (sender, e) => CreateBackup?.Invoke();
            btnDatabaseFileDialog.Click += (sender, e) => SetDatabasePathFromDialog?.Invoke();
            btnSaveDatabaseFolderDialog.Click += (sender, e) => SetSavePathFromDialog?.Invoke();
            Load += (sender, e) => LoadDatabaseSettings?.Invoke();
            chbxDefaultConStringSettings.CheckedChanged += (sender, e) => UseDefaultConStringsChecked?.Invoke();
        }
    }
}
