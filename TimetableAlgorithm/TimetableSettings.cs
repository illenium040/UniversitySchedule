using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableAlgorithm
{
    public enum SemestersParts
    {
        First = 0,
        Second = 1
    }

    public static class TimetableDefaultSettings
    {
        public static TimetableSettings Settings { get { return new TimetableSettings(); } }
    }

    public class TimetableSettings
    {
        public int DaysWeek { get; set; } = 6;
        public int HoursDay { get; set; } = 7;
        public int PartOfBest { get; set; } = 4;
        public int PopulationCount { get; set; } = 100;
        public int MaxIterations { get; set; } = 1000;
        public SemestersParts SemestersPart { get; set; } = 0;
    }
}
