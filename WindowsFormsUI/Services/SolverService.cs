using DataAccess.Loggers;

using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using API.TimetableCreation;
using TimetableAlgorithm;
using API.TimetableCreation.TimetableNormalization;
using DataAccess.Entities;
using System.Collections.Generic;

namespace API.Services
{
    public abstract class SolverService
    {
        public bool IsCancelRequired { get; private set; }

        protected TimetableGenerator Generator;
        public ILogger Logger { get; private set; }
        protected abstract TimetableGenerator Init();
        public SolverService Load(ILogger logger = null)
        {
            IsCancelRequired = false;
            if (Generator is null)
            {
                Generator = Init();
            }
            Generator.AddLogger(Logger = logger);
            return this;
        }
        public abstract Task<TimetableHandler> CreateAsync();
        public abstract Task<TimetableHandler> TrainAsync(Timetable timetable, int count = 1);
        public virtual void Cancel()
        {
            if(Generator is null)
                IsCancelRequired = true;
            else Generator.Cancel();
        }
        
        public virtual void SetSettings(TimetableSettings settings)
        {
            if (Generator is null)
                throw new NullReferenceException("Generator isn't loaded");
            Generator.AddSettings(settings);
        }
    }
}
