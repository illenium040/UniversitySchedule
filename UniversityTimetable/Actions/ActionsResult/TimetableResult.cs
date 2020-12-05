using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TimetableAlgorithm;

using UniversityTimetableGenerator.TimetableCreation.TimetableNormalization;

namespace UniversityTimetableGenerator.Actions.ActionsResult
{
    public class TimetableResult : IActionResult
    {
        public string Message { get; private set; }
        public bool IsCompleted { get; private set; }
        public Timetable Timetable { get; private set; }
        public TimetableResult(string message, bool isCompleted, Timetable timetable = null)
        {
            Message = message;
            IsCompleted = isCompleted;
            Timetable = timetable;
        }


    }
}
