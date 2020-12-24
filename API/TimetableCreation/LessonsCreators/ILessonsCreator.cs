using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TimetableAlgorithm;

using UniversityTimetableGenerator.TimetableCreation;

namespace UniversityTimetableGenerator.LessonsCreator
{
    public interface ILessonsCreator
    {
        ILessonsCreator AddTimetableData(TimetableDataContainer timetableInfo);
        ILessonsCreator AppendGroups();
        List<List<Lesson>> Create();
    }
}
