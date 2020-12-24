using DataAccess.Loggers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UniversityTimetableGenerator.TimetableCreation.DataContainers;
using UniversityTimetableGenerator.TimetableCreation.Wrappers;
using UniversityTimetableGenerator.TimetableCreation.Saver;

namespace UniversityTimetableGenerator.TimetableCreation
{
    public class TimetableFacade
    {
        public TimetableDataContainer DataContainer { get; private set; }
        public TimetableSaver Saver { get; private set; }
        public TimetableGeneratorWrapper Generator { get; private set; }

        public TimetableFacade(TimetableDataContainer dataContainer, 
            TimetableSaver saver,
            TimetableGeneratorWrapper generator)
        {
            DataContainer = dataContainer;
            Saver = saver;
            Generator = generator;
        }

        public TimetableFacade AddLogger(ILogger logger)
        {
            Generator.AddLogger(logger);
            return this;
        }
    }
}
