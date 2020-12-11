﻿using DataAccess.Entities;

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using WindowsFormsUI.FormCommands;
using WindowsFormsUI.MVP.Views;

namespace WindowsFormsUI.UserMainForm
{
    partial class UserForm
    {
        public Group SelectedGroupForTimetable
        {
            get { return groupsList.GetSelectedItem<GroupWrapper>()?.Group; }
        }

        public Specialty SelectedSpecialtyForPlan
        {
            get { return specialtyList.GetSelectedItem<SpecialtyWrapper>()?.Specialty; }
        }

        public Teacher SelectedTeacherAbout
        {
            get { return teacherList.GetSelectedItem<TeacherWrapper>()?.Teacher; }
        }

        public Teacher SelectedTeacherForTimetable
        {
            get { return timetableTeacherList.GetSelectedItem<TeacherWrapper>()?.Teacher; }
        }

        public TimetableViewInfo TimetableViewInfo { get; private set; }

        public bool IsPreLoading
        {
            get { return preDataLoaderPanel.Visible; }
            set { preDataLoaderPanel.Invoke(() => preDataLoaderPanel.Visible = value); }
        }

        public void VisualizeGrid(DataGridViewCommand command)
        {
            if (command != null)
            {
                VisualizeGridView(() =>
                    _gridCommandInvoker.SetCommand(
                        command.AddReceiver(_gridCommandReceiver))
                        .Run());
            }
            else IdkHelper.ShowErrorMsgBox("Параметр не задан или задан неверно");
        }


        public void InitControlsData(IEnumerable<Specialty> specialties, IEnumerable<Teacher> teachers)
        {
            InitSpecialtiesAndGroups(specialties);
            InitTeachers(teachers);
        }

        public void SetPreLoadState(string message)
        {
            preDataLoadStateText.Invoke(() => preDataLoadStateText.Text = message);
        }

        public IUserView GridOnLoad()
        {
            dataLoadStatePanel.Invoke(() => dataLoadStatePanel.Visible = true);
            return this;
        }
    }
}
