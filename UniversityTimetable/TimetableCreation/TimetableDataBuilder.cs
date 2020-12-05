using DataAccess.Contexts;
using DataAccess.Loggers;
using DataAccess.RepositoryUsage;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UniversityTimetableGenerator.LessonsCreator;
using UniversityTimetableGenerator.TimetableCreation.DataContainers;

namespace UniversityTimetableGenerator.TimetableCreation
{
    public class TimetableDataBuilder
    {
        private ILessonsCreator _lessonsCreator;
        private ITimetableViewData _viewData;
        private TimetableDataContainer _dataContainer;
        public TimetableDataBuilder AddLessonsCreator(ILessonsCreator lessonsCreator)
        {
            _lessonsCreator = lessonsCreator;
            return this;
        }

        public TimetableDataBuilder AddPlanData(ITimetableViewData viewData)
        {
            _viewData = viewData;
            return this;
        }

        public TimetableDataBuilder AddDataContainer(TimetableDataContainer dataContainer)
        {
            _dataContainer = dataContainer;
            return this;
        }

        public TimetableData Build()
        {

            _viewData ??= new TimetableViewData(
                new LessonContext(),
                new SpecialtyContext(),
                new PlanContext(),
                new TimetableViewContext());


            _dataContainer ??= new DefaultTimetableDataContainer();
            _dataContainer.Init(_viewData);

            _lessonsCreator ??= new NominatorOnlyLessons();

            return new TimetableData
            {
                DataContainer = _dataContainer,
                LessonsCreator = _lessonsCreator,
                ViewData = _viewData
            };
        }
    }
}
