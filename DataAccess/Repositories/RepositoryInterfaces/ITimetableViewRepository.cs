using DataAccess.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.RepositoryInterfaces
{
    public interface ITimetableViewRepository : IRepository<TimetableViewInfo>
    {
        ITimetableViewRepository AddTimetable(TimetableViewInfo viewInfo, IEnumerable<TimetableView> timetable);
        TimetableViewInfo GetLastUpdated();
    }
}
