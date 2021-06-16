using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using WindowsFormsUI.MVP.Views;
using WindowsFormsUI.Services;

namespace WindowsFormsUI.AuthMainForm
{
    public partial class RegisterForm : Form, IRegisterView
    {
        private ApplicationContext _context;
        public event Action Register;
        public string Login => tbxLogin.Text;
        public string Password => tbxPassword.Text;
        public string PasswordCheck => tbxPasswordCheck.Text;
        private ActionProxy _actionProxy;
        public RegisterForm(ApplicationContext context)
        {
            _context = context;
            _actionProxy = new ActionProxy();
            InitializeComponent();
            btnRegister.Click += async (sender, e) => await _actionProxy.InvokeAsync(Register);

        }

        public void FromThread(Action action)
        {
            this.Invoke(action);
        }

        public new void Show()
        {
            _context.MainForm = this;
            Application.Run(_context);
        }

        public new void Close()
        {
            if (this.InvokeRequired)
                this.Invoke(base.Close);
            else base.Close();
        }

    }
}
