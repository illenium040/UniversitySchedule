using DataAccess.RepositoryUsage;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UniversityTimetableGenerator.LessonsCreator;

namespace UniversityTimetableGenerator.TimetableCreation
{
    public class TimetableData
    {
        public ILessonsCreator LessonsCreator { get; set; }
        public ITimetableViewData ViewData { get; set; }
        public TimetableDataContainer DataContainer { get; set; }
    }
}
