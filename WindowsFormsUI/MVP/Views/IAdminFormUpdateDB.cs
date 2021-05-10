using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Repositories.RepositoryInterfaces;

using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsUI.MVP.Views
{
    public interface IAdminFormUpdateDB : IPartialView
    {
        public bool IsPreLoading { get; set; }
        public bool IsConfirmationRequired { get; }
        public event Action SaveChanges;
        public event Action LoadData;
        public event Action TableChanged;

        public event Action<TeacherSubject> LessonRemoved;
        public event Action<TeacherSubject> LessonUpdated;
        public event Action<TeacherSubject> LessonAdded;

        public IEnumerable<string> TableNameList { get; set; }
        public string SelectedTable { get; }

        public int SelectedIndex { get; }
        public void SetUpdateEvents();

        public void SetLessons(ILessonsRepository lessonContext);
        public void SetPlan(IPlanInformationRepository planContext);
        public void SetSpecialty(ISpecialtyRepository specialtyContext);

    }
}
