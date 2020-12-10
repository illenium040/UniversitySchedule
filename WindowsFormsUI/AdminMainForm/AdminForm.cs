using DataAccess.Entities;
using DataAccess.Loggers;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TimetableAlgorithm;

using UniversityTimetableGenerator.Actions.ActionsResult;
using UniversityTimetableGenerator.Services;

using WindowsFormsUI.UserMainForm;

namespace WindowsFormsUI.AdminMainForm
{
    public partial class AdminForm : Form
    {
        private ActionProxy _actionProxy;
        private User _admin;
        private UserForm _userTimetableTestForm;
        private IServiceProvider _services;
        public AdminForm(User user)
        {
            InitializeComponent();
            _admin = user;
            _services = RegisterServices();
            _actionProxy = new ActionProxy();
            _timetableResult = new Stack<TimetableResult>();
            btnCreateTimetable.Click += CreateTimetable;
            btnCancelTimetableCreation.Click += CacncelTimetableCreation;
            btnTimetableTrain.Click += TrainTimetable;

            btnShowUserForm.Click += ShowTimetableInUserForm;
            btnSaveToDatabase.Click += SaveToDatabase;

            checkBoxDefaultSettings.CheckedChanged += IsDefaultSettings;
            SetDefaultAlgSettings();
        }

        private void IsDefaultSettings(object sender, EventArgs e)
        {
            if (checkBoxDefaultSettings.Checked)
            {
                SetAlgNumericReadOnlyState(true);
                SetDefaultAlgSettings();
            }
            else SetAlgNumericReadOnlyState(false);
            
        }

        private async void SaveToDatabase(object sender, EventArgs e)
        {
            await _actionProxy.InvokeAsync(SaveToDatabase);
        }

        private async void TrainTimetable(object sender, EventArgs e)
        {
            await _actionProxy.InvokeAsync(TrainTimetable);
        }

        private void CacncelTimetableCreation(object sender, EventArgs e)
        {
           _solver?.Cancel();
        }

        private async void ShowTimetableInUserForm(object sender, EventArgs e)
        {
            await _actionProxy.InvokeAsync(() =>
            {
                this.Invoke(() => 
                {
                    //_userTimetableTestForm = CreateUserForm();
                    AddOwnedForm(_userTimetableTestForm);
                    _userTimetableTestForm.FormClosed += (s, e) => this.Invoke(() => RemoveOwnedForm(s as Form));
                    _userTimetableTestForm.Show();
                });
            });
            
        }

        private async void CreateTimetable(object sender, EventArgs e)
        {
            await _actionProxy.InvokeAsync(() => CreateTimetableAsync().GetAwaiter().GetResult());
        }

        private IServiceProvider RegisterServices()
        {
            return new ServiceCollection()
                .AddSingleton(typeof(ILogger), new TimetableFormLogger(lblSolverLog))
                .AddScoped<DefaultSolverService>()
                .BuildServiceProvider();
        }
    }
}
