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

        // New methods to get courses, academic records, and schedules for a student
        IEnumerable<Course> GetCoursesByStudentId(int studentId);
        IEnumerable<AcademicRecords> GetAcademicRecordsByStudentId(int studentId);
        IEnumerable<Schedule> GetSchedulesByStudentId(int studentId);
    }
}
