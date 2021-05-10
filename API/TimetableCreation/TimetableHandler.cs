using API.TimetableCreation.TimetableNormalization;

using DataAccess.Entities;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using TimetableAlgorithm;

namespace API.TimetableCreation
{
    public class TimetableHandler
    {
        private TimetableDataContainer _data;
        public Timetable RawTimetable { get; }
        private INormalization _normalization;
        public TimetableHandler(
            Timetable timetable,
            INormalization normalization,
            TimetableDataContainer data)
        {
            _data = data;
            RawTimetable = timetable;
            _normalization = normalization;
        }

        public bool IsValid()
        {
            //if (RawTimetable.Exception != null) return false;
            return true;
        }

        public NormalizedTimetable GetNormalized()
        {
            return _normalization.Normalize(RawTimetable, _data);
        }

        public async Task SaveToDatabase()
        {
            if (!IsValid()) return; 
            await Task.Run(() =>
            {
                var normalized = _normalization.Normalize(RawTimetable, _data);
                _data.TimetableView.AddTimetable(new TimetableViewInfo()
                {
                    Id = normalized.GetHashCode(),
                    DateTime = DateTime.Now,
                    Days = normalized.DaysWeek,
                    Hours = normalized.HoursDay,
                    IsVerified = false
                }, normalized.AsTimetableView());
                _data.SaveChanges();
            });
        }
    }
}
