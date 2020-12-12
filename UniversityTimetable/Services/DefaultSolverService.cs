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
        public DefaultSolverService(IServiceProvider services) : base(services) { }

        public override Task<TimetableResult> CreateAsync()
        {
            if (TimetableFacade is null)
                throw new NullReferenceException("Facade isn't loaded");
            return TimetableFacade.Generator.Create();
        }

        public override async Task SaveToDatabase(TimetableResult timetableResult)
        {
            if (TimetableFacade is null)
                throw new NullReferenceException("Facade isn't loaded");
            await TimetableFacade.Saver.SaveToDatabase(timetableResult);
        }

        public override async Task<TimetableResult> TrainAsync(Timetable timetable, int count = 1)
        {
            if (TimetableFacade is null)
                throw new NullReferenceException("Facade isn't loaded");
            for (int i = 0; i < count; i++)
            {
                var result = await TimetableFacade.Generator.Train(timetable);
                if (!result.IsCompleted) await Logger?.LogAsync(result.Message);
                else timetable = result.Timetable;
            }
            return new TimetableResult("Timetable is trained", true, timetable);
        }

        protected override TimetableFacade CreateFacade()
        {
            return new TimetableFacadeBuilder(
                    new TimetableDataBuilder().Build())
                .Build()
                .AddLogger(Logger);
        }
    }
}
