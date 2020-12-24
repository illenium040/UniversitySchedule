using Newtonsoft.Json;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableAlgorithm
{
    public class TimetablePlansContainer
    {
        private TimetableHourPlan[][,] _plans;
        public List<List<Lesson>> Lessons { get; private set; }
        public List<UnaddedLesson> UnaddedLessons { get; set; }
        public TimetableSettings Settings { get; private set; }
        public int[] PairsCount { get; private set; }

        public TimetablePlansContainer(List<List<Lesson>> lessons, TimetableSettings settings)
        {
            Settings = settings;
            Lessons = lessons;
            UnaddedLessons = new List<UnaddedLesson>();
        }

        public TimetablePlansContainer(List<List<Lesson>> lessons,
            List<UnaddedLesson> unaddedLessons,
            TimetableSettings settings)
        {
            Settings = settings;
            Lessons = lessons;
            UnaddedLessons = unaddedLessons;
        }

        public TimetableHourPlan[,] this[int index]
        {
            get { return _plans[index];}
            set { _plans[index] = value; }
        }

        public int Length
        {
            get { return _plans.Length; }
        }

        public TimetablePlansContainer InitPlans()
        {
            _plans = new TimetableHourPlan[Lessons.Count][,];
            for (int i = 0; i < Lessons.Count; i++)
            {
                _plans[i] = new TimetableHourPlan[Settings.DaysWeek, Settings.HoursDay];
                for (int d = 0; d < Settings.DaysWeek; d++)
                    for (int h = 0; h < Settings.HoursDay; h++)
                        _plans[i][d, h] = new TimetableHourPlan();
            }
            return this;
        }

        public TimetablePlansContainer InitPairsCounter()
        {
            PairsCount = new int[Lessons.Count];
            for (int i = 0; i < Lessons.Count; i++)
                PairsCount[i] = Lessons[i].Count;
            return this;
        }
    }
}
