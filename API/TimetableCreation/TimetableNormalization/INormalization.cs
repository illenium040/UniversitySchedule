using DataAccess.Entities;

using System;
using System.Collections.Generic;
using System.Text;

using TimetableAlgorithm;

namespace API.TimetableCreation.TimetableNormalization
{
    public interface INormalization
    {
        NormalizedTimetable Normalize(Timetable timetable, TimetableDataContainer data);
    }
}
