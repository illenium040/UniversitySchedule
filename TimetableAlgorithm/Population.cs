using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableAlgorithm
{
    public class Population : List<Timetable>
    {
        private TimetableSettings _settings;
        public Population(Timetable mt, TimetableSettings settings)
        {
            _settings = settings;
            Add(mt);
        }
        public Population(List<List<Lesson>> pairs, int count, TimetableSettings settings)
        {
            _settings = settings;
            var maxIterations = count * 2;
            do
            {
                var plan = new Timetable(pairs, _settings);
                for (int groupId = 0; groupId < plan.PlanList.Length; groupId++)
                    plan.Create(groupId);
                Add(plan);
            } while (maxIterations-- > 0 && Count < count);
        }

        public bool AddChildOfParentMem(int parentId, int childId)
        {
            int maxIterations = 10;
            do
            {
                for (int i = 0; i < this[parentId].PlanList.Length; i++)
                    if (this[childId].Create(this[parentId], i)) return true;
            } while (maxIterations-- > 0);
            return false;
        }


        public bool AddChildOfParent(Timetable parent)
        {
            int maxIterations = 10;
            do
            {
                var plan = new Timetable(parent.PlanList.Lessons, _settings);
                for (int groupId = 0; groupId < parent.PlanList.Length; groupId++)
                {
                    if (plan.Create(parent, groupId))
                    {
                        Add(plan);
                        return true;
                    }
                }

            } while (maxIterations-- > 0);
            return false;
        }

    }
}
