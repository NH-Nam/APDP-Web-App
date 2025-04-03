using APDPAssignment.Models;

namespace APDPAssignment.Services
{
    public interface ICourseService
    {
        IEnumerable<Course> GetAllCourses();
        bool AddCourse(Course course);
        bool EditCourse(Course course);
        bool DeleteCourse(int courseId);
        Course GetCourseById(int courseId);
        Course GetCourseByNameAndDescription(string courseName, string courseDescription);
    }
}
