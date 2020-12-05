using DataAccess.Entities;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
    public class TimetableViewContext : JetDbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TimetableView> Timetables { get; set; }
        public DbSet<TimetableViewInfo> TimetablesInfo { get; set; }
        public TimetableViewContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TimetableView>()
                .HasKey(keys => new { keys.Id, keys.GroupId, keys.Day, keys.Hour });

            modelBuilder.Entity<TeacherSubject>()
                .HasKey(x => new { x.SubjectId, x.TeacherId });

            modelBuilder.Entity<TimetableViewInfo>()
                .HasMany(x => x.TimetableView)
                .WithOne(x => x.TimetableViewInfo)
                .HasForeignKey(x => x.Id);

            modelBuilder.Entity<TimetableView>()
                .HasOne(x => x.Subject)
                .WithMany()
                .HasForeignKey(x => x.SubjectId);

            modelBuilder.Entity<TimetableView>()
                .HasOne(x => x.Group)
                .WithMany()
                .HasForeignKey(x => x.GroupId);

            modelBuilder.Entity<TimetableView>()
                .HasOne(x => x.Teacher)
                .WithMany()
                .HasForeignKey(x => x.TeacherId);
        }
    }
}
