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

        public IEnumerable<Lecturer> GetAllLecturers()
        {
            try
            {
                return _context.Lecturer.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

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
                return _context.SaveChanges() > 0;
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
                return _context.SaveChanges() > 0;
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
                return _context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
