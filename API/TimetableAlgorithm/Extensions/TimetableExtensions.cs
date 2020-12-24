using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TimetableAlgorithm
{
    internal static class TimetableExtensions
    {
        public static int GetPairsCount(this Timetable timetable, int planId)
        {
            int count = 0;
            var hourPlan = timetable.PlanList[planId];
            for (int i = 0; i < hourPlan.GetLength(0); i++)
                for (int j = 0; j < hourPlan.GetLength(1); j++)
                    if (hourPlan[i, j].GroupTeacher.Item1 != 0) count++;
            return count;
        }

        private static int GetPairsCountByDay(Timetable timetable, TimetableHourPlan[,] hourPlan, byte day)
        {
            int count = 0;
            for (int j = 0; j < timetable.HoursDay; j++)
                if (hourPlan[day, j].GroupTeacher.Item1 != 0) count++;
            return count;
        }

        private static bool FillEmptyDays(Timetable timetable,
            KeyValuePair<byte, int> empty, KeyValuePair<byte, int> notEmpty, int i)
        {
            int shift = i > 20 ? 2 : 1;
            byte startHour = (byte)(shift == 1 ? 0 : 2);
            byte endHour = (byte)(shift == 1 ? 4 : timetable.HoursDay);
            if (empty.Key == notEmpty.Key) return false;
            for (byte hour = startHour; hour < endHour; hour++)
            {
                var hourPlan = timetable.PlanList[i][notEmpty.Key, hour];
                if (hourPlan.GroupTeacher.Item1 == 0) continue;
                var lesson = new Lesson
                {
                    Day = empty.Key,
                    Hour = hour,
                    Group = hourPlan.GroupTeacher.Item1,
                    Teacher = hourPlan.GroupTeacher.Item2,
                    ExtraData = hourPlan.LessonExtraData
                };
                timetable.PlanList[i][notEmpty.Key, hour].RemoveLesson();
                if (!timetable.AddLesson(lesson, i))
                    timetable.PlanList[i][notEmpty.Key, hour].AddLesson(lesson);
                else return true;
            }
            return false;
        }
        public static Timetable TryChange(this Timetable timetable)
        {
            for (int i = 0; i < timetable.PlanList.Length; i++)
            {
                var pairsCountList = new Dictionary<byte, int>();
                for (byte day = 0; day < timetable.DaysWeek; day++)
                    pairsCountList.Add(day, GetPairsCountByDay(timetable, timetable.PlanList[i], day));
                var emptyDays = pairsCountList.Where(x => x.Value < 1);
                foreach (var empty in emptyDays)
                {
                    foreach (var notEmpty in pairsCountList.Where(x => x.Value > 2))
                    {
                        if (FillEmptyDays(timetable, empty, notEmpty, i))
                            break;
                    }
                }
            }
            return timetable;
        }

        private static bool TryAddLessonToHour(Timetable timetable, byte day, UnaddedLesson lesson)
        {
            int shift = lesson.Lesson.ExtraData.Shift;
            byte startHour = (byte)(shift == 1 ? 0 : 2);
            byte endHour = (byte)(shift == 1 ? 5 : timetable.HoursDay);
            for (byte hour = startHour; hour < endHour; hour++)
            {
                if (timetable.AddLesson(new Lesson(day, hour,
                    lesson.Lesson.Group,
                    lesson.Lesson.Teacher,
                    lesson.Lesson.ExtraData),
                    lesson.PlanNum))
                    return true;
            }
            return false;
        }

        public static Timetable TryAddLessons(this Timetable timetable)
        {
            timetable.PlanList.UnaddedLessons.RemoveAll(x =>
            {
                for (byte day = 0; day < timetable.DaysWeek; day++)
                    if (TryAddLessonToHour(timetable, day, x)) return true;
                return false;
            });
            return timetable;
        }
    }
}
