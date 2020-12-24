﻿using DataAccess.Loggers;

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

        public SolverService()
        {
        }

        protected abstract TimetableFacade CreateFacade();
        public SolverService Load()
        {
            if(TimetableFacade is null)
                TimetableFacade = CreateFacade().AddLogger(Logger);
            return this;
        }
        public abstract Task<TimetableResult> CreateAsync();
        public abstract Task<TimetableResult> TrainAsync(Timetable timetable, int count = 1);
        public virtual void Cancel()
        {
            if (TimetableFacade is null)
                throw new NullReferenceException("Facade isn't loaded");
            TimetableFacade.Generator.Cancel();
        }
        
        public virtual void SetSettings(TimetableSettings settings)
        {
            if (TimetableFacade is null)
                throw new NullReferenceException("Facade isn't loaded");
            TimetableFacade.Generator.AddSettings(settings);
        }

        public abstract Task SaveToDatabase(TimetableResult timetableResult);

        public virtual NormalizedTimetableContainer GetNormalizedView(TimetableResult timetableResult)
        {
            if (TimetableFacade is null)
                throw new NullReferenceException("Facade isn't loaded");
            return new NormalizedTimetableContainer(timetableResult, TimetableFacade.DataContainer);
        }
    }
}