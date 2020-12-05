using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class TimetableViewInfo
    {
        public int Id { get; set; }
        public virtual List<TimetableView> TimetableView { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsVerified { get; set; }
        public int Days { get; set; }
        public int Hours { get; set; }
    }
}
