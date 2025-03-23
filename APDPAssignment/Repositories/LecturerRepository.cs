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

        // New method to update academic record for a student in a course
        public bool UpdateStudentScore(int studentId, int courseId, string grade, string status)
        {
            try
            {
                var academicRecord = _context.AcademicRecords
                    .FirstOrDefault(ar => ar.StudentId == studentId && ar.CourseId == courseId);

                if (academicRecord == null)
                {
                    return false;
                }

                academicRecord.grade = grade;
                academicRecord.status = status;
                _context.AcademicRecords.Update(academicRecord);
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
