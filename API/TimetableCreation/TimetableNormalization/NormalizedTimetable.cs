using DataAccess.Entities;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TimetableAlgorithm;

namespace API.TimetableCreation.TimetableNormalization
{
    public class NormalizedTimetableCell
    {
        public Group Group { get; set; }
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
    }

    public class NormalizedTimetable
    {
        protected int _id;
        protected List<NormalizedTimetableCell[][]> _timetable;
        protected Timetable _rawTimetable;
        public NormalizedTimetable(Timetable timetable)
        {
            _id = this.GetHashCode();
            _timetable = new List<NormalizedTimetableCell[][]>();
            _rawTimetable = timetable;
        }

        public virtual NormalizedTimetable Init()
        {
            for (int groups = 0; groups < _rawTimetable.PlanList.Length; groups++)
            {
                var groupColumn = new NormalizedTimetableCell[_rawTimetable.DaysWeek][];
                for (int day = 0; day < _rawTimetable.DaysWeek; day++)
                    groupColumn[day] = new NormalizedTimetableCell[_rawTimetable.HoursDay];
                _timetable.Add(groupColumn);
            }
            return this;
        }

        public int Length { get => _timetable.Count; }
        public int DaysWeek { get => _rawTimetable.DaysWeek; }
        public int HoursDay { get => _rawTimetable.HoursDay; }

        public IEnumerable<TimetableView> AsTimetableView()
        {
            for (int i = 0; i < Length; i++)
                for (int day = 0; day < DaysWeek; day++)
                    for (int hour = 0; hour < HoursDay; hour++)
                    {
                        var cell = _timetable[i][day][hour];
                        if (cell != null)
                            yield return new TimetableView
                            {
                                Id = _id,
                                Day = day,
                                Hour = hour,
                                //Group = _timetable[i][day][hour].Group,
                                GroupId = _timetable[i][day][hour].Group.Id,
                                //Subject = cell.Subject,
                                SubjectId = cell.Subject.Id,
                                //Teacher = cell.Teacher,
                                TeacherId = cell.Teacher.Id
                            };
                    }
        }

        public IEnumerable<TimetableView> AsJoinedTimetableView()
        {
            for (int i = 0; i < Length; i++)
                for (int day = 0; day < DaysWeek; day++)
                    for (int hour = 0; hour < HoursDay; hour++)
                    {
                        var cell = _timetable[i][day][hour];
                        if (cell != null)
                            yield return new TimetableView
                            {
                                Id = _id,
                                Day = day,
                                Hour = hour,
                                Group = _timetable[i][day][hour].Group,
                                GroupId = _timetable[i][day][hour].Group.Id,
                                Subject = cell.Subject,
                                SubjectId = cell.Subject.Id,
                                Teacher = cell.Teacher,
                                TeacherId = cell.Teacher.Id
                            };
                    }
        }

        public NormalizedTimetableCell this[int group, int day, int hour]
        {
            get => _timetable[group][day][hour];
            set => _timetable[group][day][hour] = value;
        }
    }
}
