using DataAccess.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TimetableAlgorithm;

using UniversityTimetableGenerator.Actions.ActionsResult;


namespace UniversityTimetableGenerator.TimetableCreation.TimetableNormalization
{
    public class NormalizedTimetableContainer
    {
        private int _days;
        private int _hours;

        private TimetableDataContainer _dataContainer;
        private TimetableResult _timetableResult;
        public Timetable RawTimetable { get { return _timetableResult.Timetable; } }

        private NormalizedTimetable[] _timetable;

        public NormalizedTimetableContainer(TimetableResult timetableResult,
            TimetableDataContainer dataContainer)
        {
            _timetableResult = timetableResult;
            _dataContainer = dataContainer;

            _days = RawTimetable.DaysWeek;
            _hours = RawTimetable.HoursDay;

            Normalize();
        }

        public IEnumerable<TimetableView> GetAsTimetableView()
        {
            for (int i = 0; i < Length; i++)
                for (int day = 0; day < this[i].Timetable.Length; day++)
                    for (int hour = 0; hour < this[i].Timetable[day].Length; hour++)
                    {
                        var cell = this[i].Timetable[day][hour];
                        if (cell is null) continue;
                        yield return new TimetableView
                        {
                            Id = this.GetHashCode(),
                            Day = day,
                            Hour = hour,
                            GroupId = this[i].Group.Id,
                            SubjectId = cell.Subject.Id,
                            TeacherId = cell.Teacher.Id
                        };
                    }
        }

        public IEnumerable<TimetableView> AsTimetableViewWithInclude()
        {
            for (int i = 0; i < Length; i++)
                for (int day = 0; day < this[i].Timetable.Length; day++)
                    for (int hour = 0; hour < this[i].Timetable[day].Length; hour++)
                    {
                        var cell = this[i].Timetable[day][hour];
                        if (cell is null) continue;
                        yield return new TimetableView
                        {
                            Id = this.GetHashCode(),
                            Day = day,
                            Hour = hour,
                            Group = this[i].Group,
                            GroupId = this[i].Group.Id,
                            Subject = cell.Subject,
                            SubjectId = cell.Subject.Id,
                            Teacher = cell.Teacher,
                            TeacherId = cell.Teacher.Id
                        };
                    }
        }

        private void Normalize()
        {
            _timetable = new NormalizedTimetable[RawTimetable.PlanList.Length];
            for (int i = 0; i < _timetable.Length; i++)
            {
                var groupCode = GetGroupCodeFromPlanList(RawTimetable.PlanList[i]);
                var group = _dataContainer.Specialties
                    .Select(x => x.Groups.FirstOrDefault(y => y.Id == groupCode))
                    .Where(result => result != default)
                    .First();
                _timetable[i] = new NormalizedTimetable(group, _days, _hours);
                for (int day = 0; day < _days; day++)
                {
                    for (int hour = 0; hour < _hours; hour++)
                    {
                        if (RawTimetable.PlanList[i][day, hour].IsEmpty()) continue;
                        var subject = group.TeacherSubjects
                            .First(x => x.SubjectId == RawTimetable.PlanList[i][day, hour].LessonExtraData.SubjectId)
                            .Subject;
                        var teacher = group.TeacherSubjects
                            .First(x => x.TeacherId == RawTimetable.PlanList[i][day, hour].TeacherGroup.Teacher)
                            .Teacher;
                        _timetable[i].Timetable[day][hour] = new NormalizedTimetableCell()
                        {
                            Subject = subject,
                            Teacher = teacher
                        };
                    }
                }
            }
        }

        private int GetGroupCodeFromPlanList(TimetableHourPlan[,] data)
        {
            for (int day = 0; day < _days; day++)
                for (int hour = 0; hour < _hours; hour++)
                    if (!data[day, hour].IsEmpty()) return data[day, hour].GroupTeacher.Group;
            return 0;
        }

        public NormalizedTimetable this[int index]
        {
            get { return _timetable[index]; }
        }

        public int Length
        {
            get { return _timetable.Length; }
        }
    }
}
