using DataAccess.Entities;

using EntityFrameworkCore.Jet;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
    public class SpecialtyContext : JetDbContext
    {
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Group> Groups { get; set; }
        public SpecialtyContext() { Database.EnsureCreated();  }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Specialty>()
                .HasMany(x => x.Groups)
                .WithOne(x => x.Specialty);
        }
    }
}
