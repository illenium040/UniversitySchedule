using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Loggers;
using DataAccess.RepositoryUsage;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TimetableAlgorithm;

using UniversityTimetableGenerator.Actions.ActionsResult;
using UniversityTimetableGenerator.LessonsCreator;
using UniversityTimetableGenerator.TimetableCreation;
using UniversityTimetableGenerator.TimetableCreation.Wrappers;
using UniversityTimetableGenerator.TimetableCreation.TimetableNormalization;

namespace UniversityTimetableGenerator.Services
{
    public class DefaultSolverService : SolverService
    {
        public DefaultSolverService(IServiceProvider services)
            : base(services, new TimetableFacadeBuilder(
                    new TimetableDataBuilder().Build()).Build())
        {
            
        }

        public override async Task<TimetableResult> CreateAsync()
        {
            return await TimetableFacade.Generator.Create();
        }

        public override async Task SaveToDatabase(TimetableResult timetableResult)
        {
            await TimetableFacade.Saver.SaveToDatabase(timetableResult);
        }

        public override async Task<TimetableResult> TrainAsync(Timetable timetable, int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                var result = await TimetableFacade.Generator.Train(timetable);
                if (!result.IsCompleted) await Logger?.LogAsync(result.Message);
                else timetable = result.Timetable;
            }
            return new TimetableResult("Timetable is trained", true, timetable);
        }
    }
}
