using DataAccess.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TimetableAlgorithm;

namespace API.TimetableCreation.TimetableNormalization
{
    public class Normalization : INormalization
    {
        public NormalizedTimetable Normalize(Timetable timetable, TimetableDataContainer data)
        {
            var normalized = new NormalizedTimetable(timetable).Init();
            for (int i = 0; i < normalized.Length; i++)
            {
                var groupCode = GetGroupCodeFromPlanList(timetable.PlanList[i]);
                var group = data.Specialties
                    .Select(x => x.Groups.FirstOrDefault(y => y.Id == groupCode))
                    .Where(result => result != default)
                    .First();
                for (int day = 0; day < timetable.DaysWeek; day++)
                {
                    for (int hour = 0; hour < timetable.HoursDay; hour++)
                    {
                        if (timetable.PlanList[i][day, hour].IsEmpty()) continue;
                        var subject = group.TeacherSubjects
                            .First(x => x.SubjectId == timetable.PlanList[i][day, hour].LessonExtraData.SubjectId)
                            .Subject;
                        var teacher = group.TeacherSubjects
                            .First(x => x.TeacherId == timetable.PlanList[i][day, hour].TeacherGroup.Teacher)
                            .Teacher;
                        normalized[i, day, hour] = new NormalizedTimetableCell()
                        {
                            Subject = subject,
                            Teacher = teacher,
                            Group = group
                        };
                    }
                }
            }
            return normalized;
        }

        private int GetGroupCodeFromPlanList(TimetableHourPlan[,] data)
        {
            for (int day = 0; day < data.GetLength(0); day++)
                for (int hour = 0; hour < data.GetLength(1); hour++)
                    if (!data[day, hour].IsEmpty()) return data[day, hour].GroupTeacher.Group;
            return 0;
        }
    }
}
