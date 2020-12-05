using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Specialty
    {
        public int Id { get; set; }
        public string Index { get; set; }

        [Column("SpecialtyName")]
        public string Name { get; set; }

        [Column("SpecialtyCode")]
        public string Code { get; set; }
        public virtual List<Group> Groups { get; set; } = new List<Group>();
    }
}
