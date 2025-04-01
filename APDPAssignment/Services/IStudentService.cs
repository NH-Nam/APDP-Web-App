using APDPAssignment.Models;

namespace APDPAssignment.Services
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int studentId);
        IEnumerable<AcademicRecords> GetAcademicRecordsByStudentId(int studentId);
        bool AssignCourseToStudent(int studentId, int courseId);
    }
}
