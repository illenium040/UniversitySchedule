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
        public virtual void Cancel()
        {
            TimetableFacade.Generator.Cancel();
        }
        
        public virtual void SetSettings(TimetableSettings settings)
        {
            TimetableFacade.Generator.AddSettings(settings);
        }

        public abstract Task SaveToDatabase(TimetableResult timetableResult);

        public virtual NormalizedTimetableContainer GetNormalizedView(TimetableResult timetableResult)
        {
            return new NormalizedTimetableContainer(timetableResult, TimetableFacade.DataContainer);
        }
    }
}
