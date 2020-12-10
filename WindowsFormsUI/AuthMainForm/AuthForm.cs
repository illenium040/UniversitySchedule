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

using WindowsFormsUI.MVP.Views;

using static WindowsFormsUI.MVP.Views.IAuthView;

namespace WindowsFormsUI
{
    public partial class AuthForm : Form, IAuthView
    {
        private readonly ApplicationContext _applicationContext;
        public string UserName { get { return tbxLogin.Text; } }
        public string UserPassword { get { return tbxPassword.Text; } }
        public event Action UserAuth;

        private ActionProxy _actionProxy;

        public AuthForm(ApplicationContext context)
        {
            _actionProxy = new ActionProxy();
            _applicationContext = context;
            InitializeComponent();
            authBtn.Click += async (sender, e) => await _actionProxy.InvokeAsync(UserAuth);
            
        }

        public void ShowError(string message)
        {
            IdkHelper.ShowErrorMsgBox(message);
        }

        public new void Show()
        {
            _applicationContext.MainForm = this;
            Application.Run(_applicationContext);
        }

        public void ShowAuthState(string message)
        {
            authStateText.Invoke(() => authStateText.Text = message);
        }

        public void SetControlsTurnState(bool state)
        {
            authBtn.Invoke(()=> authBtn.Enabled = state);
            tbxLogin.Invoke(() => tbxLogin.Enabled = state);
            tbxPassword.Invoke(() => tbxPassword.Enabled = state);
        }

        public new void Close()
        {
            if (this.InvokeRequired)
                this.Invoke(base.Close);
            else base.Close();
        }

        public void FromThread(Action action)
        {
            this.Invoke(action);
        }
    }
}
