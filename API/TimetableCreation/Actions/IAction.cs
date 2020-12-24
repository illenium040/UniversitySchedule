using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UniversityTimetableGenerator.Actions.ActionsResult;

namespace UniversityTimetableGenerator.Actions
{
    public interface IAction<T> where T : IActionResult
    {
        T Complete(string message);
        T Fault(string message, Exception exception);
    }
}
