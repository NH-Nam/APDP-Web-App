using APDPAssignment.Models;

namespace APDPAssignment.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int studentId);
        bool AddStudent(Student student);
        bool UpdateStudent(Student student);
        bool DeleteStudent(int studentId);
        bool AssignCourseToStudent(int studentId, int courseId);
        IEnumerable<AcademicRecords> GetAcademicRecordsByStudentId(int studentId);
    }
}
