using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TimetableAlgorithm;

using API.TimetableCreation;

namespace API.LessonsCreator
{
    public interface ILessonsCreator
    {
        List<List<Lesson>> Create(TimetableDataContainer timetableInfo);
    }
}
