using APDPAssignment.Models;
using Microsoft.EntityFrameworkCore;

namespace APDPAssignment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<AcademicRecords> AcademicRecords { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Classroom> Classroom { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Lecturer> Lecturer { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasOne(a => a.Student)
                .WithOne(s => s.Account)
                .HasForeignKey<Student>(s => s.StudentId);

            modelBuilder.Entity<Account>()
                .HasOne(a => a.Admin)
                .WithOne(ad => ad.Account)
                .HasForeignKey<Admin>(ad => ad.AdminId);

            modelBuilder.Entity<Account>()
                .HasOne(a => a.Role)
                .WithMany(r => r.Accounts)
                .HasForeignKey(a => a.RoleId);

            modelBuilder.Entity<Account>()
                .HasOne(a => a.Lecturer)
                .WithOne(l => l.Account)
                .HasForeignKey<Lecturer>(l => l.LecturerId);

            modelBuilder.Entity<AcademicRecords>()
                .HasOne(ar => ar.Student)
                .WithMany(s => s.AcademicRecords)
                .HasForeignKey(ar => ar.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Classroom>()
                .HasMany(c => c.Schedules)
                .WithOne(s => s.Classroom)
                .HasForeignKey(s => s.ClassroomId);

            modelBuilder.Entity<Lecturer>()
                .HasMany(l => l.Schedules)
                .WithOne(s => s.Lecturer)
                .HasForeignKey(s => s.LecturerId);

            modelBuilder.Entity<Roles>()
                .HasMany(r => r.Accounts)
                .WithOne(a => a.Role)
                .HasForeignKey(a => a.RoleId);

            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Classroom)
                .WithMany(c => c.Schedules)
                .HasForeignKey(s => s.ClassroomId);

            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Lecturer)
                .WithMany(l => l.Schedules)
                .HasForeignKey(s => s.LecturerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.AcademicRecords)
                .WithOne(ar => ar.Student)
                .HasForeignKey(ar => ar.StudentId);

            modelBuilder.Entity<StudentCourse>()
            .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);

            // Roles Id and Names
            modelBuilder.Entity<Roles>().HasData(
                new Roles { RoleId = 1, RoleName = "Admin" },
                new Roles { RoleId = 2, RoleName = "Lecturer" },
                new Roles { RoleId = 3, RoleName = "Student" }
            );
        }
    }
}