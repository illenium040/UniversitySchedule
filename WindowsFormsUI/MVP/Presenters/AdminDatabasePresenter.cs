using DataAccess;
using DataAccess.Entities;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using WindowsFormsUI.MVP.Views;

namespace WindowsFormsUI.MVP.Presenters
{
    public class AdminDatabasePresenter : BasePartialPresenter<IAdminDatabaseView, User>
    {
        private User _user;
        public AdminDatabasePresenter(IApplicationController controller,
            IAdminDatabaseView view) : base(controller, view)
        {
            View.SetDatabasePathFromDialog += () => View.DatabasePath = WinFormStaticHelper.GetFileDialogResult("accdb");
            View.SetSavePathFromDialog += () => View.DatabaseSavePath = WinFormStaticHelper.GetFolderDialogResult();
            View.CreateBackup += () => CreateBackup();
            View.SaveDatabaseConStrings += SaveConnectionStrings;
            View.LoadDatabaseSettings += LoadSettings;
            View.UseDefaultConStringsChecked += UseDefaultConnectionStrings;
            
        }

        private void UseDefaultConnectionStrings()
        {

            if (View.IsDefaultConnectionStrings)
                View.SetDatabaseSettings( new DatabaseSettings
                {
                    AdminConnectionString = Properties.Settings.Default.DefaultConString,
                    UserConnectionString = Properties.Settings.Default.DefaultConString
                }, true);
            else 
                View.SetDatabaseSettings(new DatabaseSettings
                {
                    AdminConnectionString = Properties.Settings.Default.DatabaseAdminConString,
                    UserConnectionString = Properties.Settings.Default.DatabaseUserConString
                }, false);
        }

        private void LoadSettings()
        {
            View.SetDatabaseSettings(new DatabaseSettings
            {
                AdminConnectionString = Properties.Settings.Default.DatabaseAdminConString,
                UserConnectionString = Properties.Settings.Default.DatabaseUserConString
            }, false);
            View.DatabasePath = Properties.Settings.Default.DatabaseSoursePath;
            View.DatabaseSavePath = Properties.Settings.Default.DatabaseBackupsPath;
        }

        private void SaveConnectionStrings()
        {
            Properties.Settings.Default.DatabaseAdminConString = View.AdminDatabaseConnectionString;
            Properties.Settings.Default.DatabaseUserConString = View.UserDatabaseConnectionString;
            Properties.Settings.Default.Save();
            DataAccessSettings.ConnectionString = Properties.Settings.Default.DatabaseAdminConString;
        }

        private void CreateBackup()
        {
            try
            {
                Properties.Settings.Default.DatabaseBackupsPath = View.DatabaseSavePath;
                Properties.Settings.Default.DatabaseSoursePath = View.DatabasePath;
                Properties.Settings.Default.Save();
                if (Directory.Exists(View.DatabaseSavePath))
                    Directory.CreateDirectory(View.DatabaseSavePath);
                if (Directory.GetFiles(View.DatabaseSavePath)
                    .Select(x => x.Substring(x.LastIndexOf('\\') + 1))
                    .Contains($"{View.DatabaseSavedFileName}.accdb"))
                {
                    if (MessageBox.Show("Файл с таким именем уже существует. Перезаписать?", "Бэкап базы данных",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                }
                File.Copy(View.DatabasePath, $"{View.DatabaseSavePath}\\{View.DatabaseSavedFileName}.accdb", true);
                MessageBox.Show("Бэкап базы данных завершен успешно", "Бэкап базы данных",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch(Exception e)
            {
                WinFormStaticHelper.ShowErrorMsgBox(e.Message);
            }
        }

        public override void Run(User argument)
        {
            _user = argument;
        }
    }
}
