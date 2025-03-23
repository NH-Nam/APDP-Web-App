using APDPAssignment.Data;
using APDPAssignment.Models;

namespace APDPAssignment.Repositories
{
    public class ClassroomRepository : IClassroomRepository
    {
        private readonly ApplicationDbContext _context;

        public ClassroomRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Classroom> Classroom => _context.Classroom.ToList();

        public Classroom GetClassroomById(int classroomId)
        {
            try
            {
                return _context.Classroom.Find(classroomId);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool AddClassroom(Classroom classroom)
        {
            try
            {
                _context.Classroom.Add(classroom);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateClassroom(Classroom classroom)
        {
            try
            {
                _context.Classroom.Update(classroom);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteClassroom(int classroomId)
        {
            try
            {
                var classroom = _context.Classroom.Find(classroomId);
                _context.Classroom.Remove(classroom);
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
