using APDPAssignment.Models;

namespace APDPAssignment.Services
{
    public interface ICourseService
    {
        bool AddCourse(Course course);
        bool EditCourse(Course course);
        bool DeleteCourse(int courseId);
        bool AssignCourseToStudent(int courseId, int studentId);
    }
}
