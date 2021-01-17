using DataAccess.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetableAlgorithm;

using API.TimetableCreation;

namespace API.LessonsCreator
{
    public abstract class LessonsCreator : ILessonsCreator
    {
        protected TimetableDataContainer DataContainer;
        protected abstract LessonsCreator AddGroups();
        protected abstract List<List<Lesson>> AddLessons();

        protected int GetGroupSemesterId(int groupId, int semesterParts) =>
            groupId / 100 * 2 - 2 / (semesterParts + 1);

        protected IEnumerable<Group> GetGroupsByHourPlan(HourPlan plan)
        {
            for (int i = (int)DataContainer.SemestersPart; i < plan.SemestersCount; i += 2)
            {
                if (plan[i] != 0) yield return DataContainer.Specialties
                        .First(x => x.Id == plan.PlanInformation.SpecialtyId)
                        .Groups.AsEnumerable()
                        .First(x => GetGroupSemesterId(x.Id, (int)DataContainer.SemestersPart) == i);
            }
        }

        protected virtual LessonsCreator AddTimetableData(TimetableDataContainer timetableInfo)
        {
            DataContainer = timetableInfo;
            return this;
        }

        public List<List<Lesson>> Create(TimetableDataContainer timetableInfo)
        {
            return AddTimetableData(timetableInfo).AddGroups().AddLessons();
        }
    }
}
