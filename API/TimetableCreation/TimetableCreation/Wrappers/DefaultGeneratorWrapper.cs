using DataAccess.Loggers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TimetableAlgorithm;

using UniversityTimetableGenerator.Actions.ActionsResult;
using UniversityTimetableGenerator.LessonsCreator;
using UniversityTimetableGenerator.TimetableCreation.DataContainers;

namespace UniversityTimetableGenerator.TimetableCreation.Wrappers
{
    public class DefaultGeneratorWrapper : TimetableGeneratorWrapper
    {
        public DefaultGeneratorWrapper(TimetableGenerator generator) : base(generator)
        {

        }
        public override async Task<TimetableResult> Create()
        {
            return LastResult = await Generator.Create();
        }

        public override async Task<TimetableResult> Train(Timetable timetable)
        {
            return LastResult = await Generator.Train(timetable);
        }
    }
}
