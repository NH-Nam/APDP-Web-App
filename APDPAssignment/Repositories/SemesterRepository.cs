using APDPAssignment.Data;
using APDPAssignment.Models;

namespace APDPAssignment.Repositories
{
    public class SemesterRepository : ISemesterRepository
    {
        private readonly ApplicationDbContext _context;

        public SemesterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Semester> GetAllSemesters()
        {
            try
            {
                return _context.Semesters.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Semester GetSemesterById(int id)
        {
            try
            {
                return _context.Semesters.Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool AddSemester(Semester semester)
        {
            try
            {
                _context.Semesters.Add(semester);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateSemester(Semester semester)
        {
            try
            {
                _context.Semesters.Update(semester);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteSemester(int id)
        {
            try
            {
                var semester = _context.Semesters.Find(id);
                _context.Semesters.Remove(semester);
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
