using APDPAssignment.Data;
using APDPAssignment.Models;
using Microsoft.EntityFrameworkCore;

namespace APDPAssignment.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> Students => _context.Student.ToList();

        public Student GetStudentById(int studentId)
        {
            try
            {
                return _context.Student.Find(studentId);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool AddStudent(Student student)
        {
            try
            {
                _context.Student.Add(student);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateStudent(Student student)
        {
            try
            {
                _context.Student.Update(student);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteStudent(int studentId)
        {
            try
            {
                var student = _context.Student.Find(studentId);
                _context.Student.Remove(student);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // New method to get courses for a student
        public IEnumerable<Course> GetCoursesByStudentId(int studentId)
        {
            try
            {
                return _context.EnrollmentList
                    .Where(e => e.StudentId == studentId)
                    .Include(e => e.Course)
                    .Select(e => e.Course)
                    .ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // New method to get academic records for a student
        public IEnumerable<AcademicRecords> GetAcademicRecordsByStudentId(int studentId)
        {
            try
            {
                return _context.AcademicRecords
                    .Where(ar => ar.StudentId == studentId)
                    .ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // New method to get schedules for a student
        public IEnumerable<Schedule> GetSchedulesByStudentId(int studentId)
        {
            try
            {
                return _context.EnrollmentList
                    .Where(e => e.StudentId == studentId)
                    .Include(e => e.Course)
                    .ThenInclude(c => c.Schedules)
                    .SelectMany(e => e.Course.Schedules)
                    .ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
