using DataAccess.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TimetableAlgorithm;

namespace UniversityTimetableGenerator.TimetableCreation.TimetableNormalization
{
    public class NormalizedTimetable
    {
        public Group Group { get; private set; }
        public NormalizedTimetableCell[][] Timetable { get; private set; }
        public NormalizedTimetable(Group group, int days, int hours)
        {
            Group = group;
            Timetable = new NormalizedTimetableCell[days][];
            for (int day = 0; day < days; day++)
                Timetable[day] = new NormalizedTimetableCell[hours];
        }
    }
}
