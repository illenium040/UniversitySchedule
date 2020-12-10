using DataAccess.Entities;

using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsUI.Services
{
    public interface ITimetableLoaderService
    {
        void Load();
        IEnumerable<Specialty> GetAllSpecialties();
        IEnumerable<Teacher> GetNamedTeachers();
        TimetableViewInfo GetLastUpdatedViewInfo();
        PlanInformation GetPlanBySpecialty(Specialty specialty);
    }
}
