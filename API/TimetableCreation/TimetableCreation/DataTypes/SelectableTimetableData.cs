using DataAccess.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityTimetableGenerator.TimetableCreation.DataTypes
{
    public class SelectableTimetableData
    {
        public IEnumerable<Specialty> Specialties { get; set; }
        public IEnumerable<PlanInformation> Plans { get; set; }
    }
}
