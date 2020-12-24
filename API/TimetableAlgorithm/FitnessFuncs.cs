using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableAlgorithm
{
    public class FitnessFuncs
    {
        public static int GroupWindowPenalty = 10;//штраф за окно у группы
        public static int TeacherWindowPenalty = 7;//штраф за окно у преподавателя
        public static int EmptyDaysPenalty = 15;
        public static int LateLessonPenalty = 1;//штраф за позднюю пару
        public static int OnePairPerDayPenalty = 9;
        public static int LatesetHour = 3;//максимальный час, когда удобно проводить пары

        /// <summary>
        /// Штраф за окна
        /// </summary>
        public static int Windows(Timetable plan)
        {
            var res = 0;
            for (int i = 0; i < plan.PlanList.Length; i++)
            {
                for (byte day = 0; day < plan.DaysWeek; day++)
                {
                    var groupHasLessions = new HashSet<int>();
                    var teacherHasLessions = new HashSet<int>();

                    for (byte hour = 0; hour < plan.HoursDay; hour++)
                    {
                        var group = plan.PlanList[i][day, hour].GroupTeacher.Group;
                        var teacher = plan.PlanList[i][day, hour].TeacherGroup.Teacher;
                        if (group == 0 || teacher == 0) continue;
                        if (groupHasLessions.Contains(group) &&
                            plan.PlanList[i][day, hour - 1].GroupTeacher.Group != group)
                            res += GroupWindowPenalty;
                        if (teacherHasLessions.Contains(teacher) &&
                            plan.PlanList[i][day, hour - 1].TeacherGroup.Teacher != teacher)
                            res += TeacherWindowPenalty;

                        groupHasLessions.Add(group);
                        teacherHasLessions.Add(teacher);

                    }
                }
            }

            return res;
        }

        /// <summary>
        /// Штраф за поздние пары
        /// </summary>
        public static int LateLesson(Timetable plan)
        {
            var res = 0;
            for (int i = 0; i < plan.PlanList.Length; i++)
            {
                foreach (var pair in plan.GetLessons(i))
                    if ((pair.Group != 0 || pair.Teacher != 0) && pair.Hour > LatesetHour)
                        res += LateLessonPenalty;
            }


            return res;
        }

        public static int EmptyDays(Timetable plan)
        {
            var res = 0;

            for (int i = 0; i < plan.PlanList.Length; i++)
            {
                for (int d = 0, hcount = 0; d < plan.DaysWeek; d++)
                {
                    for (int h = 0; h < plan.HoursDay; h++)
                        if (plan.PlanList[i][d, h].GroupTeacher == (0, 0)) hcount++;

                    if (hcount == plan.HoursDay)
                        res += EmptyDaysPenalty;
                    hcount = 0;
                }
            }
                

            return res;
        }

        public static int OnePairPerDay(Timetable plan)
        {
            var res = 0;
            for (int i = 0; i < plan.PlanList.Length; i++)
            {
                var p = plan.PlanList[i];
                for (int d = 0, paircount = 0; d < plan.DaysWeek; d++)
                {
                    for (int h = 0; h < plan.HoursDay; h++)
                        if (p[d, h].GroupTeacher != (0, 0))
                            paircount++;

                    if (paircount == 1)
                        if (i < 30) res += OnePairPerDayPenalty;

                    paircount = 0;
                }
            }
            return res;
        }
    }
}
