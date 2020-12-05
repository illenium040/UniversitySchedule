using DataAccess.Entities;
using DataAccess.Loggers;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using UniversityTimetableGenerator.Services;

namespace WindowsFormsUI.AdminMainForm
{
    public partial class AdminForm : Form
    {
        private MainForm _mainForm;
        private User _admin;
        private IServiceProvider _services;
        public AdminForm(MainForm form, User user)
        {
            InitializeComponent();
            _admin = user;
            _services = RegisterServices();

            FormClosing += AdminForm_FormClosing;

            button1.Click += Button1_Click;
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _mainForm.Close();
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            await CreateTimetableAsync();
        }

        private IServiceProvider RegisterServices()
        {
            return new ServiceCollection()
                .AddSingleton(typeof(ILogger), new TimetableFormLogger(timetableLogLabel))
                .AddScoped<DefaultSolverService>()
                .BuildServiceProvider();
        }
    }
}
