using DataAccess.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.RepositoryInterfaces
{
    public interface ILessonsRepository : IRepository<TeacherSubject>
    {
        IEnumerable<TeacherSubject> GetBySubject(int id);
        IEnumerable<TeacherSubject> GetByTeacher(int id);
        IEnumerable<TeacherSubject> GetWithNamedTeachers();
        IEnumerable<Teacher> GetNamedTeachers();

    }
}
