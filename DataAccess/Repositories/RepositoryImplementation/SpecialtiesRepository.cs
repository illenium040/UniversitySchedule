using DataAccess.Contexts;
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
    public class SpecialtiesRepository : Repository<Specialty>, ISpecialtyRepository
    {
        public SpecialtyContext SpecialtyContext { get { return Context as SpecialtyContext; } }
        public SpecialtiesRepository(SpecialtyContext context) : base(context) { }

        public override IEnumerable<Specialty> GetAll()
        {
            return SpecialtyContext.Specialties
                .Include(x => x.Groups)
                .AsNoTracking()
                .ToList();
        }

        public override Specialty Get(int id)
        {
            return SpecialtyContext.Specialties
                .Include(x => x.Groups)
                .AsNoTracking()
                .First(x => x.Id == id);
        }
    }
}
