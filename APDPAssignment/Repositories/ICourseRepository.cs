using APDPAssignment.Models;

namespace APDPAssignment.Repositories
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAllCourses();
        Course GetCourseById(int courseId);
        bool AddCourse(Course course);
        bool EditCourse(Course course);
        bool DeleteCourse(int courseId);
        Course GetCourseByNameAndDescription(string courseName, string courseDescription);
    }
}
