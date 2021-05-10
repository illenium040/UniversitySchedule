using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Repositories.RepositoryInterfaces;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.RepositoryImplementation
{
    public class LessonsRepository : Repository<TeacherSubject>, ILessonsRepository
    {
        public LessonContext LessonContext { get { return Context as LessonContext; } }
        public LessonsRepository(LessonContext context) : base(context) { }

        public override void Add(TeacherSubject entity)
        {
            LessonContext.Teachers.Add(entity.Teacher);
        }

        public override void Update(TeacherSubject entity)
        {
            LessonContext.Teachers.Update(entity.Teacher);
        }

        public override void Remove(TeacherSubject entity)
        {
            LessonContext.Teachers.Remove(entity.Teacher);
            LessonContext.Subjects.Remove(entity.Subject);
        }

        public IEnumerable<TeacherSubject> GetBySubject(int id)
        {
            return LessonContext.TeacherSubjects
                .Include(x => x.Subject)
                .Include(x => x.Teacher)
                .Where(x => x.SubjectId == id)
                .AsNoTracking()
                .ToList(); 
        }

        public IEnumerable<TeacherSubject> GetByTeacher(int id)
        {
            return LessonContext.TeacherSubjects
                .Include(x => x.Subject)
                .Include(x => x.Teacher)
                .Where(x => x.TeacherId == id)
                .AsNoTracking()
                .ToList();
        }

        public override IEnumerable<TeacherSubject> GetAll()
        {
            return LessonContext.TeacherSubjects
                .Include(x => x.Subject)
                .Include(x => x.Teacher)
                .AsNoTracking()
                .ToList();
        }

        public override IEnumerable<TeacherSubject> Find(Expression<Func<TeacherSubject, bool>> predicate)
        {
            return LessonContext.TeacherSubjects
                .Include(x => x.Subject)
                .Include(x => x.Teacher)
                .AsNoTracking()
                .Where(predicate)
                .ToList();
        }

        public IEnumerable<TeacherSubject> GetWithNamedTeachers()
        {
            return Find(x => x.TeacherId > 0).ToList();
        }

        public IEnumerable<Teacher> GetNamedTeachers()
        {
            return LessonContext.Teachers
                .Include(x => x.TeacherSubject).ThenInclude(x => x.Subject)
                .AsNoTracking()
                .Where(x => x.Id > 0)
                .ToList();
        }
    }
}
