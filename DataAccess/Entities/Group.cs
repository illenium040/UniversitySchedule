
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public int CurrentShift { get; set; }
        public int ReceiptYear { get; set; }
        public int SpecialtyId { get; set; }
        public virtual Specialty Specialty { get; set; }

        [NotMapped]
        public virtual List<TeacherSubject> TeacherSubjects { get; set; }
            = new List<TeacherSubject>();
    }
}