using APDPAssignment.Models;
using Microsoft.EntityFrameworkCore;

namespace APDPAssignment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
        
        public DbSet<AcademicRecords> AcademicRecords { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Classroom> Classroom { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<EnrollmentList> EnrollmentList { get; set; }
        public DbSet<Lecturer> Lecturer { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Student> Student { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasOne(a => a.Student)
                .WithOne(s => s.Account)
                .HasForeignKey<Account>(a => a.StudentId);

            modelBuilder.Entity<Account>()
                .HasOne(a => a.Admin)
                .WithOne(ad => ad.Account)
                .HasForeignKey<Admin>(ad => ad.AdminId);

            modelBuilder.Entity<Account>()
                .HasOne(a => a.Lecturer)
                .WithOne(l => l.Account)
                .HasForeignKey<Lecturer>(l => l.LecturerId);

            modelBuilder.Entity<Account>()
                .HasOne(a => a.Role)
                .WithMany(r => r.Accounts)
                .HasForeignKey(a => a.RoleId);

            modelBuilder.Entity<AcademicRecords>()
                .HasOne(ar => ar.Course)
                .WithMany(c => c.AcademicRecords)
                .HasForeignKey(ar => ar.CourseId);

            modelBuilder.Entity<AcademicRecords>()
                .HasOne(ar => ar.Student)
                .WithMany(s => s.AcademicRecords)
                .HasForeignKey(ar => ar.StudentId);

            modelBuilder.Entity<AcademicRecords>()
                .HasOne(ar => ar.Semester)
                .WithMany(s => s.AcademicRecords)
                .HasForeignKey(ar => ar.SemesterId);

            modelBuilder.Entity<Classroom>()
                .HasMany(c => c.Schedules)
                .WithOne(s => s.Classroom)
                .HasForeignKey(s => s.ClassroomId);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Schedules)
                .WithOne(s => s.Course)
                .HasForeignKey(s => s.CourseId);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.EnrollmentLists)
                .WithOne(e => e.Course)
                .HasForeignKey(e => e.CourseId);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.AcademicRecords)
                .WithOne(ar => ar.Course)
                .HasForeignKey(ar => ar.CourseId);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Semester)
                .WithMany(se => se.Courses)
                .HasForeignKey(c => c.SemesterId);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Lecturer)
                .WithMany(l => l.Courses)
                .HasForeignKey(c => c.LecturerId);

            modelBuilder.Entity<EnrollmentList>()
                .HasOne(e => e.Student)
                .WithMany(s => s.EnrollmentLists)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<EnrollmentList>()
                .HasOne(e => e.Course)
                .WithMany(c => c.EnrollmentLists)
                .HasForeignKey(e => e.CourseId);

            modelBuilder.Entity<Lecturer>()
                .HasMany(l => l.Schedules)
                .WithOne(s => s.Lecturer)
                .HasForeignKey(s => s.LecturerId);

            modelBuilder.Entity<Lecturer>()
                .HasMany(l => l.Courses)
                .WithOne(c => c.Lecturer)
                .HasForeignKey(c => c.LecturerId);

            modelBuilder.Entity<Lecturer>()
                .HasOne(l => l.Account)
                .WithOne(a => a.Lecturer)
                .HasForeignKey<Lecturer>(l => l.LecturerId);

            modelBuilder.Entity<Roles>()
                .HasMany(r => r.Accounts)
                .WithOne(Schedule => Schedule.Role)
                .HasForeignKey(a => a.RoleId);

            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Classroom)
                .WithMany(c => c.Schedules)
                .HasForeignKey(s => s.ClassroomId);

            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Course)
                .WithMany(c => c.Schedules)
                .HasForeignKey(s => s.CourseId);

            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Semester)
                .WithMany(se => se.Schedules)
                .HasForeignKey(s => s.SemesterId);

            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Lecturer)
                .WithMany(l => l.Schedules)
                .HasForeignKey(s => s.LecturerId);

            modelBuilder.Entity<Semester>()
                .HasMany(se => se.Courses)
                .WithOne(c => c.Semester)
                .HasForeignKey(c => c.SemesterId);

            modelBuilder.Entity<Semester>()
                .HasMany(se => se.AcademicRecords)
                .WithOne(ar => ar.Semester)
                .HasForeignKey(ar => ar.SemesterId);

            modelBuilder.Entity<Semester>()
                .HasMany(se => se.Schedules)
                .WithOne(s => s.Semester)
                .HasForeignKey(s => s.SemesterId);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Account)
                .WithOne(a => a.Student)
                .HasForeignKey<Student>(s => s.StudentId);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.EnrollmentLists)
                .WithOne(e => e.Student)
                .HasForeignKey(e => e.StudentId);
        }


    }
}