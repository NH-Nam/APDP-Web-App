using APDPAssignment.Models;

namespace APDPAssignment.Services
{
    public interface IAccountService
    {
        Task RegisterStudentAsync(Student student);
        Task RegisterLecturerAsync(Lecturer lecturer);
        Task RegisterAdminAsync(Admin admin);
    }
}
