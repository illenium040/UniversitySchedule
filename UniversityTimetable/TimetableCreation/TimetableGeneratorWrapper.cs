using DataAccess.Loggers;

using System.Threading.Tasks;

using TimetableAlgorithm;

using UniversityTimetableGenerator.Actions.ActionsResult;

namespace UniversityTimetableGenerator.TimetableCreation
{
    public abstract class TimetableGeneratorWrapper
    {
        protected TimetableResult LastResult;
        protected TimetableGenerator Generator { get; }

        public TimetableGeneratorWrapper(TimetableGenerator generator)
        {
            Generator = generator;
        }

        public abstract Task<TimetableResult> Create();
        public abstract Task<TimetableResult> Train(Timetable timetable);

        public TimetableGeneratorWrapper AddLogger(ILogger logger)
        {
            Generator.AddLogger(logger);
            return this;
        }

        public TimetableGeneratorWrapper AddSettings(TimetableSettings settings)
        {
            Generator.AddSeetings(settings);
            return this;
        }

        public void Cancel()
        {
            Generator.Cancel();
        }

    }
}
