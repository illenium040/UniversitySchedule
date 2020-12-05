using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableAlgorithm
{
    public class Timetable
    {
        //private Random rnd = new Random();
        public byte DaysWeek { get; private set; } = (byte)TimetableSettings.DaysWeek;
        public byte HoursDay { get; private set; } = (byte)TimetableSettings.HoursDay;
        public TimetablePlansContainer PlanList { get; private set; }
        public int FitnessValue { get; set; }

        public Timetable(List<List<Lesson>> lessons)
        {
            PlanList = new TimetablePlansContainer(lessons)
                .InitPlans()
                .InitPairsCounter();
        }

        public Timetable(List<List<Lesson>> lessons, List<UnaddedLesson> unaddedLessons)
        {
            PlanList = new TimetablePlansContainer(lessons, unaddedLessons)
                .InitPlans()
                .InitPairsCounter();
        }

        public bool Create(int groupId)
        {
            foreach (var l in PlanList.Lessons[groupId])
                if (!AddToAnyDayAndHour(l, groupId))
                    PlanList.UnaddedLessons.Add(new UnaddedLesson(groupId, l));
            return true;
        }

        private bool AddToAnyDayAndHour(Lesson lesson, int planId)
        {
            int maxIterations = 30;
            do
            {
                var day = (byte)RandomProvider.GetRndValue(0, DaysWeek);
                if (AddToAnyHour(day, lesson, planId)) return true;
            } while (maxIterations-- > 0);
            return false;
        }

        private bool AddToAnyHour(byte day, Lesson lesson, int groupId)
        {
            int shift = lesson.ExtraData.Shift;
            byte startHour = (byte)(shift == 1 ? 0 : 3);
            byte endHour = (byte)(shift == 1 ? 4 : HoursDay);
            for (byte hour = startHour; hour < endHour; hour++)
            {
                var les = new Lesson(day, hour,
                    lesson.Group, lesson.Teacher, lesson.ExtraData);
                if (AddLesson(les, groupId)) return true;
            }
            return false;
        }

        public bool AddLesson(Lesson les, int groupId)
        {
            for (int i = 0; i < PlanList.Length; i++)
                if (PlanList[i][les.Day, les.Hour].ContainsLesson(les))
                    return false;

            if (PlanList.PairsCount[groupId] <= this.GetPairsCount(groupId))
                return false;

            return PlanList[groupId][les.Day, les.Hour].AddLesson(les);
        }

        public void RemoveLesson(Lesson les, int groupId)
        {
            PlanList[groupId][les.Day, les.Hour].RemoveLesson();
        }

        public bool Create(Timetable parent, int groupId)
        {
            //копируем предка
            for (int k = 0; k < PlanList.Length; k++)
            {
                for (int i = 0; i < HoursDay; i++)
                    for (int j = 0; j < DaysWeek; j++)
                    {
                        PlanList[k][j, i].GroupTeacher.Group = parent.PlanList[k][j, i].GroupTeacher.Group;
                        PlanList[k][j, i].GroupTeacher.Teacher = parent.PlanList[k][j, i].GroupTeacher.Teacher;
                        PlanList[k][j, i].TeacherGroup.Teacher = parent.PlanList[k][j, i].TeacherGroup.Teacher;
                        PlanList[k][j, i].TeacherGroup.Group = parent.PlanList[k][j, i].TeacherGroup.Group;
                        PlanList[k][j, i].LessonExtraData = parent.PlanList[k][j, i].LessonExtraData;
                    }
            }

            //выбираем два случайных дня
            var day1 = (byte)RandomProvider.GetRndValue(0, (uint)DaysWeek);//rnd.Next(DaysWeek);
            var day2 = (byte)RandomProvider.GetRndValue(0, (uint)DaysWeek);// rnd.Next(DaysWeek);

            //находим пары в эти дни
            var pairs1 = GetLessonsOfDay(day1, groupId).ToList();
            var pairs2 = GetLessonsOfDay(day2, groupId).ToList();

            //выбираем случайные пары
            if (pairs1.Count == 0 || pairs2.Count == 0) return false;
            var pair1 = pairs1[RandomProvider.GetRndValue(0, (uint)pairs1.Count)];//rnd.Next(pairs1.Count)
            var pair2 = pairs2[RandomProvider.GetRndValue(0, (uint)pairs2.Count)];//rnd.Next(pairs2.Count)

            //создаем мутацию - переставляем случайные пары местами
            RemoveLesson(pair1, groupId);//удаляем
            RemoveLesson(pair2, groupId);//удаляем
            var res1 = AddToAnyHour(pair2.Day, pair1, groupId);//вставляем в случайное место
            var res2 = AddToAnyHour(pair1.Day, pair2, groupId);//вставляем в случайное место
            return res1 && res2;
        }

        public IEnumerable<Lesson> GetLessonsOfDay(byte day, int groupId)
        {
            for (byte hour = 0; hour < HoursDay; hour++)
                yield return new Lesson(day, hour,
                    PlanList[groupId][day, hour].GroupTeacher.Group,
                    PlanList[groupId][day, hour].GroupTeacher.Teacher,
                    PlanList[groupId][day, hour].LessonExtraData);
        }

        public IEnumerable<Lesson> GetLessons(int groupId)
        {
            for (byte day = 0; day < DaysWeek; day++)
                for (byte hour = 0; hour < HoursDay; hour++)
                {
                    yield return new Lesson(day, hour,
                        PlanList[groupId][day, hour].GroupTeacher.Group,
                        PlanList[groupId][day, hour].GroupTeacher.Teacher,
                        PlanList[groupId][day, hour].LessonExtraData);
                }
        }

        public Timetable GetDeepCopy()
        {
            var result = new Timetable(PlanList.Lessons.ToList(), PlanList.UnaddedLessons.ToList());
            for (int i = 0; i < result.PlanList.Length; i++)
                for (int day = 0; day < result.PlanList[i].GetLength(0); day++)
                    for (int hour = 0; hour < result.PlanList[i].GetLength(1); hour++)
                        result.PlanList[i][day, hour] = PlanList[i][day, hour].Clone();
            result.HoursDay = HoursDay;
            result.DaysWeek = DaysWeek;
            result.FitnessValue = FitnessValue;
            return result;
        }
    }
}
