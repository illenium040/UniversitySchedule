using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.RepositoryUsage;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UniversityTimetableGenerator.Actions.ActionsResult;
using UniversityTimetableGenerator.TimetableCreation.TimetableNormalization;

namespace UniversityTimetableGenerator.TimetableCreation.Saver
{
    public class DefaultTimetableSaver : TimetableSaver
    {
        public DefaultTimetableSaver(TimetableDataContainer container): base(container)
        {
        }

        public override async Task SaveToDatabase(TimetableResult timetable)
        {
            await AddToDatabase(new NormalizedTimetableContainer(timetable, DataContainer));
        }
    }
}
