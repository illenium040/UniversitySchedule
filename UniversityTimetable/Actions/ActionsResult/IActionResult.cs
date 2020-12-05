using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityTimetableGenerator.Actions.ActionsResult
{
    public interface IActionResult
    {
        string Message { get; }
        bool IsCompleted { get; }
    }
}
