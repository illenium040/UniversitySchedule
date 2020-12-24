using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.RepositoryUsage;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UniversityTimetableGenerator.TimetableCreation.TimetableNormalization;

using UniversityTimetableGenerator.Actions.ActionsResult;

namespace UniversityTimetableGenerator.TimetableCreation
{
    public abstract class TimetableSaver
    {
        protected TimetableDataContainer DataContainer;
        public TimetableSaver(TimetableDataContainer dataContainer)
        {
            DataContainer = dataContainer;
        }

        public abstract Task SaveToDatabase(TimetableResult timetable);

        protected async Task AddToDatabase(NormalizedTimetableContainer timetableContainer)
        {
            await Task.Run(() =>
            {
                DataContainer.TimetableView.AddTimetable(new TimetableViewInfo()
                {
                    Id = timetableContainer.GetHashCode(),
                    DateTime = DateTime.Now,
                    Days = timetableContainer.RawTimetable.DaysWeek,
                    Hours = timetableContainer.RawTimetable.HoursDay,
                    IsVerified = false
                }, timetableContainer.GetAsTimetableView());
                DataContainer.SaveChanges();
            });
        }
    }
}
