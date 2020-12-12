using DataAccess.RepositoryUsage;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsUI.Services
{
    public interface ITimetableViewDataLoader
    {
        public ITimetableViewData Load();
        public Task<ITimetableViewData> LoadAsync();
    }
}
