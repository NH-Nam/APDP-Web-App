using APDPAssignment.Data;
using APDPAssignment.Models;

namespace APDPAssignment.Repositories
{
    public class LecturerRepository : ILecturerRepository
    {
        private readonly ApplicationDbContext _context;

        public LecturerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Lecturer> Lecturers => _context.Lecturer.ToList();

        public Lecturer GetLecturerById(int lecturerId)
        {
            try
            {
                return _context.Lecturer.Find(lecturerId);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool AddLecturer(Lecturer lecturer)
        {
            try
            {
                _context.Lecturer.Add(lecturer);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateLecturer(Lecturer lecturer)
        {
            try
            {
                _context.Lecturer.Update(lecturer);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteLecturer(int lecturerId)
        {
            try
            {
                var lecturer = _context.Lecturer.Find(lecturerId);
                _context.Lecturer.Remove(lecturer);
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
