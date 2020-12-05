using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class TimetableView
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual TimetableViewInfo TimetableViewInfo { get; set; }
    }
}
