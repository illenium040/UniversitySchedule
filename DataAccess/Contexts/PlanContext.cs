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
    public class PlanContext : JetDbContext
    {
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<PlanWeek> PlanWeeks { get; set; }
        public DbSet<HourPlan> HourPlans { get; set; }
        public DbSet<PlanInformation> PlanInformation { get; set; }
        public PlanContext() { Database.EnsureCreated(); }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeacherSubject>()
                .HasKey(ts => new { ts.SubjectId, ts.TeacherId });

            modelBuilder.Entity<HourPlan>()
                .HasKey(hp => new { hp.Id, hp.SubjectId, hp.Code });

            modelBuilder.Entity<HourPlan>()
                .HasOne(x => x.PlanInformation)
                .WithMany(x => x.HourPlans)
                .HasForeignKey(x => x.Id);

            modelBuilder.Entity<HourPlan>()
                .HasOne(x => x.Subject)
                .WithMany()
                .HasForeignKey(x => x.SubjectId);

            modelBuilder.Entity<PlanWeek>()
                .HasOne(x => x.PlanInformation)
                .WithOne(x => x.PlanWeeks)
                .HasForeignKey<PlanInformation>(x => x.WeeksId);

            for (int i = 1; i <= 8; i++)
            {
                modelBuilder.Entity<HourPlan>()
                    .Property($"_semester{i}")
                    .HasColumnName($"Semester{i}")
                    .UsePropertyAccessMode(PropertyAccessMode.Property);
                modelBuilder.Entity<PlanWeek>()
                    .Property($"_semester{i}")
                    .HasColumnName($"Semester{i}")
                    .UsePropertyAccessMode(PropertyAccessMode.Property);
            }  
        }
    }
}
