using DataAccess.Entities;

using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsUI
{
    class TeacherWrapper
    {
        public Teacher Teacher { get; private set; }
        public TeacherWrapper(Teacher teacher)
        {
            Teacher = teacher;
        }

        public override string ToString()
        {
            return $"{Teacher.ShortFirstname} {Teacher.Lastname}";
        }
    }
}
