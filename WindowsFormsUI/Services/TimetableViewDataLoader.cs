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
        private TimetableViewData _data;
        public ITimetableViewData Load()
        {
            if (_data is null)
            {
                _data = new TimetableViewData(
                new LessonContext(),
                new SpecialtyContext(),
                new PlanContext(),
                new TimetableViewContext());
            }
            return _data;
        }

        public async Task<ITimetableViewData> LoadAsync()
        {
            return await Task.Run(() => Load());
        }
    }
}
