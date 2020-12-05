using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using UniversityTimetableGenerator.Services;

namespace WindowsFormsUI.AdminMainForm
{
    partial class AdminForm
    {
        private SolverService _solver;
        private async Task CreateTimetableAsync()
        {
            await Task.Run(() => { _solver = _services.GetService<DefaultSolverService>(); });
            var result = await _solver.CreateAsync();
            await _solver.TrainAsync(result?.Timetable);
        }
    }
}
