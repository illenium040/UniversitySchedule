using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class PlanInformation
    {
        [Column("HourPlanId")]
        public int Id { get; set; }
        public int PlanYear { get; set; }
        public string StudyForm { get; set; }
        public int SpecialtyId { get; set; }
        public int WeeksId { get; set; }
        public virtual List<HourPlan> HourPlans { get; set; }
        public virtual PlanWeek PlanWeeks { get; set; }
    }
}
