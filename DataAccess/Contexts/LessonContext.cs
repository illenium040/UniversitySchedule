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
    public class LessonContext : JetDbContext
    {
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherSubject> TeacherSubjects { get; set; }
        public LessonContext() { Database.EnsureCreated(); }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeacherSubject>()
                .HasKey(ts => new { ts.SubjectId, ts.TeacherId });
            modelBuilder.Entity<TeacherSubject>()
                .HasOne(x => x.Subject)
                .WithMany(x => x.TeacherSubject)
                .HasForeignKey(x => x.SubjectId);
            modelBuilder.Entity<TeacherSubject>()
                .HasOne(x => x.Teacher)
                .WithMany(x => x.TeacherSubject)
                .HasForeignKey(x => x.TeacherId);
        }
    }
}
