using DataAccess.Contexts;
using DataAccess.RepositoryUsage;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsUI.Services
{
    public class TimetableViewDataLoader : ITimetableViewDataLoader
    {
        public ITimetableViewData Load()
        {
            return new TimetableViewData(
                new LessonContext(),
                new SpecialtyContext(),
                new PlanContext(),
                new TimetableViewContext());
        }

        public async Task<ITimetableViewData> LoadAsync()
        {
            return await Task.Run(() => Load());
        }
    }
}
