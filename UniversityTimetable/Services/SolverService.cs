using DataAccess.Loggers;

using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using UniversityTimetableGenerator.TimetableCreation;
using UniversityTimetableGenerator.Actions.ActionsResult;
using TimetableAlgorithm;
using UniversityTimetableGenerator.TimetableCreation.TimetableNormalization;
using DataAccess.Entities;
using System.Collections.Generic;

namespace UniversityTimetableGenerator.Services
{
    public abstract class SolverService
    {
        protected TimetableFacade TimetableFacade;
        protected ILogger Logger;
        protected IServiceProvider ServiceProvider;

        public SolverService(IServiceProvider serviceProvider, TimetableFacade timetableFacade)
        {
            ServiceProvider = serviceProvider;
            Logger = serviceProvider.GetService<ILogger>();
            TimetableFacade = timetableFacade.AddLogger(Logger);
            TimetableFacade.Generator.AddLogger(Logger);
        }
        public abstract Task<TimetableResult> CreateAsync();
        public abstract Task<TimetableResult> TrainAsync(Timetable timetable, int count = 1);
        public abstract Task SaveToDatabase(TimetableResult timetableResult);

        public virtual async Task<NormalizedTimetableContainer> GetNormalizedView(TimetableResult timetableResult)
        {
            return await Task.Run(() => new NormalizedTimetableContainer(timetableResult, TimetableFacade.DataContainer));
        }
    }
}
