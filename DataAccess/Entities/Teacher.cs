using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string ShortFirstname { get; set; }
        public string FullFirstname { get; set; }
        public virtual List<TeacherSubject> TeacherSubject { get; set; }

        [NotMapped]
        public virtual List<Group> Groups { get; set; } = new List<Group>();
        
    }
}
