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
        public static int DaysWeek { get; set; } = 6;
        public static int HoursDay { get; set; } = 7;

        public static int PartOfBest { get; set; } = 4;
        public static int PopulationCount { get; set; } = 100;
        public static int MaxIterations { get; set; } = 1000;

        public static SemestersParts SemestersPart { get; set; } = 0;
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
