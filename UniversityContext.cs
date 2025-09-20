using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLab1
{
    public class UniversityContext : DbContext
    {
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=UniversityDB;Username=postgres;Password=test");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Связь Faculty -> Groups (1 ко многим)
            modelBuilder.Entity<Group>()
                .HasOne(g => g.Faculty)
                .WithMany(f => f.Groups)
                .HasForeignKey(g => g.FacultyId);

            // Связь Group -> Students (1 ко многим)
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Group)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.GroupId);

            // Связь многие-ко-многим через промежуточную таблицу
            modelBuilder.Entity<StudentSubject>()
                .HasKey(ss => new { ss.StudentId, ss.SubjectId });

            modelBuilder.Entity<StudentSubject>()
                .HasOne(ss => ss.Student)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(ss => ss.StudentId);

            modelBuilder.Entity<StudentSubject>()
                .HasOne(ss => ss.Subject)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(ss => ss.SubjectId);
        }
    }
}
