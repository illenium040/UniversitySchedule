using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableAlgorithm
{
    public sealed class TimetableHourPlan
    {
        public (int Group, int Teacher) GroupTeacher = (0, 0);
        public (int Teacher, int Group) TeacherGroup = (0, 0);
        public LessonExtraData LessonExtraData;
        public bool AddLesson(Lesson les)
        {
            if (ContainsLesson(les)) return false;

            GroupTeacher = (les.Group, les.Teacher);
            TeacherGroup = (les.Teacher, les.Group);
            LessonExtraData = les.ExtraData;
            return true;
        }

        public bool ContainsLesson(Lesson les)
        {
            if (GroupTeacher.Group == les.Group || TeacherGroup.Teacher == les.Teacher) return true;
            return false;
        }

        public void RemoveLesson()
        {
            GroupTeacher = (0, 0);
            TeacherGroup = (0, 0);
            LessonExtraData.PlanId = 0;
            LessonExtraData.Shift = 0;
            LessonExtraData.SubjectId = 0;
        }

        public bool IsEmpty()
        {
            return GroupTeacher == (0, 0) && TeacherGroup == (0, 0);
        }

        public TimetableHourPlan Clone()
        {
            var result = new TimetableHourPlan();

            result.GroupTeacher.Group = GroupTeacher.Group;
            result.GroupTeacher.Teacher = GroupTeacher.Teacher;
            result.TeacherGroup.Teacher = TeacherGroup.Teacher;
            result.TeacherGroup.Group = TeacherGroup.Group;
            result.LessonExtraData = LessonExtraData;
            return result;
        }
    }
}
