using APDPAssignment.Data;
using APDPAssignment.Models;

namespace APDPAssignment.Repositories
{
    public class EnrollmentListRepository : IEnrollmentListRepository
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentListRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<EnrollmentList> EnrollmentLists => _context.EnrollmentList.ToList();

        public EnrollmentList GetEnrollmentListById(int enrollmentId)
        {
            try
            {
                return _context.EnrollmentList.Find(enrollmentId);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool AddEnrollmentList(EnrollmentList enrollmentList)
        {
            try
            {
                _context.EnrollmentList.Add(enrollmentList);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateEnrollmentList(EnrollmentList enrollmentList)
        {
            try
            {
                _context.EnrollmentList.Update(enrollmentList);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteEnrollmentList(int enrollmentId)
        {
            try
            {
                var enrollmentList = _context.EnrollmentList.Find(enrollmentId);
                _context.EnrollmentList.Remove(enrollmentList);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // New method to get EnrollmentLists by CourseId
        public IEnumerable<EnrollmentList> GetEnrollmentListsByCourseId(int courseId)
        {
            try
            {
                return _context.EnrollmentList.Where(e => e.CourseId == courseId).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // New method to add EnrollmentList to a Course
        public bool AddEnrollmentListToCourse(int courseId, EnrollmentList enrollmentList)
        {
            try
            {
                var course = _context.Course.Find(courseId);
                if (course == null)
                {
                    return false;
                }

                enrollmentList.CourseId = courseId;
                _context.EnrollmentList.Add(enrollmentList);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
