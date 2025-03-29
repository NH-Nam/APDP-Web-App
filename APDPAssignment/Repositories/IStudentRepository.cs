using APDPAssignment.Models;

namespace APDPAssignment.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<Student> Students { get; }
        Student GetStudentById(int studentId);
        bool AddStudent(Student student);
        bool UpdateStudent(Student student);
        bool DeleteStudent(int studentId);

        IEnumerable<AcademicRecords> GetAcademicRecordsByStudentId(int studentId);
    }
}
