using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetableAlgorithm;

using API.TimetableCreation;

namespace API.LessonsCreator
{
    public class NumeratorOnlyLessons : LessonsCreator
    {
        protected override LessonsCreator AddGroups()
        {
            foreach (var plan in DataContainer.PlansInformation)
            {
                foreach (var hourPlan in plan.HourPlans)
                {
                    var teachers = DataContainer.TeacherSubjects
                        .Where(x => x.SubjectId == hourPlan.SubjectId)
                        .ToList();
                    var teacher = teachers.First(x => x.Teacher.Groups.Count == teachers.Min(y => y.Teacher.Groups.Count));
                    foreach (var group in GetGroupsByHourPlan(hourPlan))
                    {
                        if (!teacher.Teacher.Groups.Contains(group))
                            teacher.Teacher.Groups.Add(group);
                        if (group.TeacherSubjects.Find(x => x.SubjectId == teacher.SubjectId) == default)
                            group.TeacherSubjects.Add(teacher);
                    }
                }
            }
            return this;
        }

        protected override List<List<Lesson>> AddLessons()
        {
            var solverLessons = new List<List<Lesson>>();
            foreach (var specialty in DataContainer.Specialties)
            {
                foreach (var group in specialty.Groups.OrderBy(x => x.Id))
                {
                    solverLessons.Add(new List<Lesson>());
                    var groupSemester = GetGroupSemesterId(group.Id, (int)DataContainer.SemestersPart);
                    var weeksHour = DataContainer.PlansInformation
                            .First(x => x.SpecialtyId == group.Specialty.Id)
                            .PlanWeeks[groupSemester];
                    var currentPlan = DataContainer.PlansInformation
                            .First(x => x.SpecialtyId == group.Specialty.Id);
                    foreach (var ts in group.TeacherSubjects)
                    {
                        var subjectHours = currentPlan.HourPlans.First(x => x.SubjectId == ts.Subject.Id)[groupSemester];
                        var lessonsPerWeek =
                            Math.Round((double)(subjectHours / (double)2 / weeksHour),
                                MidpointRounding.AwayFromZero);
                        for (int i = 0; i < (int)lessonsPerWeek; i++)
                            solverLessons.Last().Add(new Lesson(group.Id, ts.TeacherId, 
                                new LessonExtraData
                                {
                                    Shift = group.CurrentShift,
                                    SubjectId = ts.SubjectId,
                                    PlanId = currentPlan.Id
                                }));
                    }
                }
            }
            return solverLessons;
        }
    }
}
