using APDPAssignment.Data;
using APDPAssignment.Models;

namespace APDPAssignment.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Course> GetAllCourses()
        {
            try
            {
                return _context.Course.ToList();
            }
            catch
            {
                return null;
            }
        }

        public Course GetCourseById(int courseId)
        {
            try
            {
                return _context.Course.Find(courseId);
            }
            catch
            {
                return null;
            }
        }

        public bool AddCourse(Course course)
        {
            try
            {
                _context.Course.Add(course);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateCourse(Course course)
        {
            try
            {
                _context.Course.Update(course);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCourse(int courseId)
        {
            try
            {
                var course = _context.Course.Find(courseId);
                _context.Course.Remove(course);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
