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

        public override void Add(Specialty entity)
        {
            SpecialtyContext.Specialties.Add(entity);
            Context.SaveChanges();
            DetachAll();
        }

        public override void Update(Specialty entity)
        {
            SpecialtyContext.Specialties.Update(entity);
            Context.SaveChanges();
            DetachAll();
        }

        public override void Remove(Specialty entity)
        {
            SpecialtyContext.Specialties.Remove(entity);
        }

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

        public void RemoveGroup(Group g)
        {
            SpecialtyContext.Groups.Remove(SpecialtyContext.Groups.FirstOrDefault(x => x.Id == g.Id));
            Context.SaveChanges();
            DetachAll();
        }

        public void AddGroup(Group g)
        {
            SpecialtyContext.Groups.Add(g);
            Context.SaveChanges();
            DetachAll();
        }

        public void UpdateGroup(Group g)
        {
            SpecialtyContext.Groups.Update(g);
            Context.SaveChanges();
            DetachAll();
        }
    }
}
