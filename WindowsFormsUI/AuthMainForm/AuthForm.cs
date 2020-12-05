using DataAccess;
using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.RepositoryUsage;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TimetableAlgorithm;

namespace WindowsFormsUI
{
    public partial class AuthForm : Form
    {
        public delegate void UserCreated(User user);
        public event UserCreated UserCreatedEvent;

        private UserAuthorization _userAuth;

        public AuthForm()
        {
            InitializeComponent();
            authBtn.Click += Auth;
        }

        private async void Auth(object sender, EventArgs e)
        {
            TurnControls(false);
            authStateText.Text = "Авторизация...";
            try
            {
                UserCreatedEvent?.Invoke(await Task.Run(() =>
                {
                    _userAuth ??= new UserAuthorization(new UserContext());
                    return _userAuth.UserRepository.GetUser(tbxLogin.Text, tbxPassword.Text);
                }));
                _userAuth.Dispose();
            }
            catch (UnauthorizedAccessException exception)
            {
                authStateText.Text = exception.Message;
            }
            catch (InvalidOperationException exc)
            {
                if(exc.Message.Contains("Microsoft.ACE.OLEDB") && exc.Source == "System.Data.OleDb")
                    MessageBox.Show($"Необходимо установить AccessDatabaseEngine x86 или x64", "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                authStateText.Text = "";
            }
            catch (Exception exc)
            {
                authStateText.Text = $"Произошла непредвиденная ошибка: {exc.Message}";
            }
            finally
            {
                TurnControls(true);
            }
        }

        private void TurnControls(bool isTurnedOn)
        {
            authBtn.Enabled = isTurnedOn;
            tbxLogin.Enabled = isTurnedOn;
            tbxPassword.Enabled = isTurnedOn;
        }
    }
}
