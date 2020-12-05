using System;
using UniversityTimetableGenerator.TimetableCreation.Wrappers;
using UniversityTimetableGenerator.TimetableCreation.Saver;

namespace UniversityTimetableGenerator.TimetableCreation
{
    public class TimetableFacadeBuilder
    {
        private TimetableData _data;
        private TimetableGeneratorWrapper _generatorWrapper;
        private TimetableSaver _saver;

        public TimetableFacadeBuilder(TimetableData timetableData)
        {
            _data = timetableData;
        }

        public TimetableFacadeBuilder AddGeneratorExecutor<T>()
            where  T : TimetableGeneratorWrapper
        {
            _generatorWrapper = (T)Activator.CreateInstance(typeof(T),
                new TimetableGenerator(_data.LessonsCreator, _data.DataContainer));
            return this;
        }

        public TimetableFacadeBuilder AddSaver<T>()
            where T : TimetableSaver
        {
            _saver = (T)Activator.CreateInstance(typeof(T), _data.DataContainer);
            return this;
        }

        public TimetableFacade Build()
        {

            _generatorWrapper ??= new DefaultGeneratorWrapper(
                    new TimetableGenerator(_data.LessonsCreator, _data.DataContainer));

            _saver ??= new DefaultTimetableSaver(_data.DataContainer);

            return new TimetableFacade(_data.DataContainer, _saver, _generatorWrapper);
            
        }
    }
}
