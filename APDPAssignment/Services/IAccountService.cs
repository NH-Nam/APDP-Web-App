using APDPAssignment.Models;

namespace APDPAssignment.Services
{
    public interface IAccountService
    {
        bool RegisterStudentAsync(Student student);
        bool RegisterLecturerAsync(Lecturer lecturer);
        bool RegisterAdminAsync(Admin admin);
        Account AuthenticateUser(string username, string password);
    }
}
