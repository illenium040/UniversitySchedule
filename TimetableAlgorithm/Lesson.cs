using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableAlgorithm
{
    public class Lesson
    {
        public byte Day;
        public byte Hour;
        public int Teacher;
        public int Group;
        public LessonExtraData ExtraData;
        public Lesson() { }
        public Lesson(byte day, byte hour, int group, int teacher, LessonExtraData data)
        {
            Day = day;
            Hour = hour;
            Group = group;
            Teacher = teacher;
            ExtraData = data;
        }

        public Lesson(int group, int teacher, LessonExtraData data)
        {
            Day = 255;
            Hour = 255;
            Group = group;
            Teacher = teacher;
            ExtraData = data;
        }
    }
}
