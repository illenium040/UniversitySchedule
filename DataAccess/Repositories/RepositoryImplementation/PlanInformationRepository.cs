﻿using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Repositories.RepositoryInterfaces;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.RepositoryImplementation
{
    public class PlanInformationRepository :
        Repository<PlanInformation>, IPlanInformationRepository
    {
        public PlanContext PlanContext { get { return Context as PlanContext; } }
        public PlanInformationRepository(DbContext context) : base(context) { }

        public override PlanInformation Get(int id)
        {
            return PlanContext.PlanInformation
                .Include(x => x.PlanWeeks)
                .Include(x => x.HourPlans)
                .First(x => x.Id == id); 
        }

        public override IEnumerable<PlanInformation> GetAll()
        {
            return PlanContext.PlanInformation
                .Include(x => x.PlanWeeks)
                .Include(x => x.HourPlans)
                .ToList();
        }

        public IEnumerable<PlanInformation> GetAllWithoutPractice()
        {
            foreach (var plan in GetAll())
            {
                plan.HourPlans.RemoveAll(hp => hp.Code.Contains("ПП") || hp.Code.Contains("УП"));
                yield return plan;
            }
        }

        public PlanInformation GetPlanBySpecialty(int specialtyId)
        {
            return PlanContext.PlanInformation
                .Include(x => x.HourPlans).ThenInclude(x => x.Subject)
                .Include(x => x.PlanWeeks)
                .FirstOrDefault(x => x.SpecialtyId == specialtyId);
        }
    }
}
