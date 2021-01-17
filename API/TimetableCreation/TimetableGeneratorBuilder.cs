using System;
using API.TimetableCreation.TimetableNormalization;

namespace API.TimetableCreation
{
    public class TimetableGeneratorBuilder
    {
        private TimetableData _data;
        private INormalization _normalization;

        public TimetableGeneratorBuilder(TimetableData timetableData)
        {
            _data = timetableData;
        }

        public TimetableGeneratorBuilder AddNormalization<T>()
            where T : INormalization, new()
        {
            _normalization = Activator.CreateInstance<T>();
            return this;
        }

        public TimetableGenerator Build()
        {
            _normalization ??= new Normalization();
            return new TimetableGenerator(_data.LessonsCreator, _data.DataContainer, _normalization);
        }
    }
}
