using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class HourPlan
    {
        [Column("PlanId")]
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public string Code { get; set; }
        public virtual PlanInformation PlanInformation { get; set; }
        protected int? _semester1 { get; set; }
        protected int? _semester2 { get; set; }
        protected int? _semester3 { get; set; }
        protected int? _semester4 { get; set; }
        protected int? _semester5 { get; set; }
        protected int? _semester6 { get; set; }
        protected int? _semester7 { get; set; }
        protected int? _semester8 { get; set; }

        [NotMapped]
        public int SemestersCount { get; private set; } = 8;

        public int? this[int id]
        {
            get
            {
                return id switch
                {
                    0 => _semester1,
                    1 => _semester2,
                    2 => _semester3,
                    3 => _semester4,
                    4 => _semester5,
                    5 => _semester6,
                    6 => _semester7,
                    7 => _semester8,
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
            set
            {
                switch(id)
                {
                    case 0: _semester1 = value; break;
                    case 1: _semester2 = value; break;
                    case 2: _semester3 = value; break;
                    case 3: _semester4 = value; break;
                    case 4: _semester5 = value; break;
                    case 5: _semester6 = value; break;
                    case 6: _semester7 = value; break;
                    case 7: _semester8 = value; break;
                    default: throw new ArgumentOutOfRangeException();
                };
            }
        }
        

    }
}
