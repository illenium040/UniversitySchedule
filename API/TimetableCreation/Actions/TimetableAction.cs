using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TimetableAlgorithm;

using UniversityTimetableGenerator.Actions.ActionsResult;

namespace UniversityTimetableGenerator.Actions
{
    public class TimetableAction : IAction<TimetableResult>
    {
        private Timetable _timetable;
        public TimetableAction(Timetable timetable = null)
        {
            _timetable = timetable;
        }

        public TimetableResult Complete(string message)
        {
            return new TimetableResult(message, true, _timetable);
        }

        public TimetableResult Fault(string message, Exception exception)
        {
            return new TimetableResult(message, false);
        }
    }
}
