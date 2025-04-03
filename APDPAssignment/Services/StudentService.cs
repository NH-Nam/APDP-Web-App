using APDPAssignment.Models;
using APDPAssignment.Repositories;

namespace APDPAssignment.Services
{
    public class StudentService: IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentRepository.GetAllStudents();
        }

        public Student GetStudentById(int studentId)
        {
            return _studentRepository.GetStudentById(studentId);
        }

        public IEnumerable<AcademicRecords> GetAcademicRecordsByStudentId(int studentId)
        {
            return _studentRepository.GetAcademicRecordsByStudentId(studentId);
        }

        public bool AssignCourseToStudent(int studentId, int courseId)
        {
            return _studentRepository.AssignCourseToStudent(studentId, courseId);
        }
    }
}
