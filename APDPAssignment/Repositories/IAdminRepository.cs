using APDPAssignment.Models;

namespace APDPAssignment.Repositories
{
    public interface IAdminRepository
    {
        Admin GetAdmin(int id);
        IEnumerable<Admin> GetAllAdmins();
        bool AddAdmin(Admin admin);
        bool UpdateAdmin(Admin adminChanges);
        bool DeleteAdmin(int id);

        // Methods for assigning courses
        bool AssignCourseToStudent(int studentId, int courseId);
        IEnumerable<Course> GetCoursesByStudent(int studentId);
    }
}
