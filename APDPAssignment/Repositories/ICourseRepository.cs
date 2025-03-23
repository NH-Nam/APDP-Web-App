using APDPAssignment.Models;

namespace APDPAssignment.Repositories
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAllCourses();
        Course GetCourseById(int courseId);
        bool AddCourse(Course course);
        bool UpdateCourse(Course course);
        bool DeleteCourse(int courseId);
    }
}
