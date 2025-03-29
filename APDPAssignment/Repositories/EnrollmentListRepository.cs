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
    }
}
