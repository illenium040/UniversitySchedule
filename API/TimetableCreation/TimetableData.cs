using DataAccess.RepositoryUsage;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using API.LessonsCreator;

namespace API.TimetableCreation
{
    public class TimetableData
    {
        public ILessonsCreator LessonsCreator { get; set; }
        public ITimetableViewData ViewData { get; set; }
        public TimetableDataContainer DataContainer { get; set; }
    }
}
