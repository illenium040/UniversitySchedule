using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Repositories.RepositoryInterfaces;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.RepositoryImplementation
{
    public class TimetableViewRepository : Repository<TimetableViewInfo>, ITimetableViewRepository
    {
        public TimetableViewContext TimetableViewContext { get { return Context as TimetableViewContext; } }
        public TimetableViewRepository(DbContext context) : base(context) { }

        public ITimetableViewRepository AddTimetable(TimetableViewInfo viewInfo, IEnumerable<TimetableView> timetable)
        {
            
            Context.Set<TimetableViewInfo>().Add(viewInfo);
            Context.Set<TimetableView>().AddRange(timetable);
            return this;
        }

        public override TimetableViewInfo Get(int id)
        {
            return TimetableViewContext.TimetablesInfo
                .Include(x => x.TimetableView).ThenInclude(x => x.Group)
                .Include(x => x.TimetableView).ThenInclude(x => x.Subject)
                .Include(x => x.TimetableView).ThenInclude(x => x.Teacher)
                .AsNoTracking()
                .First(x => x.Id == id);
        }

        public TimetableViewInfo GetLastUpdated()
        {
            return TimetableViewContext.TimetablesInfo
                .Include(x => x.TimetableView).ThenInclude(x => x.Group)
                .Include(x => x.TimetableView).ThenInclude(x => x.Subject)
                .Include(x => x.TimetableView).ThenInclude(x => x.Teacher)
                .AsNoTracking()
                .First(x => x.DateTime == TimetableViewContext.TimetablesInfo.Max(x => x.DateTime));
        }
    }
}
