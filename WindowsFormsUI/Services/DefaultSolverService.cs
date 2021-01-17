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

using API.LessonsCreator;
using API.TimetableCreation;
using API.TimetableCreation.TimetableNormalization;

namespace API.Services
{
    public class DefaultSolverService : SolverService
    {
        public override Task<TimetableHandler> CreateAsync()
        {
            if (Generator is null)
                throw new NullReferenceException("Facade isn't loaded");
            return Generator.Create();
        }

        public override async Task<TimetableHandler> TrainAsync(Timetable timetable, int count = 1)
        {
            if (Generator is null)
                throw new NullReferenceException("Facade isn't loaded");
            //bruh
            TimetableHandler handler = null;
            for (int i = 0; i < count; i++)
            {
                handler = await Generator.Train(timetable);
                timetable = handler.RawTimetable;
            }
            return handler;
        }

        protected override TimetableGenerator Init()
        {
            return new TimetableGeneratorBuilder(
                    new TimetableDataBuilder().Build())
                .Build();
        }
    }
}
