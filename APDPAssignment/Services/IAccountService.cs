using APDPAssignment.Models;

namespace APDPAssignment.Services
{
    public interface IAccountService
    {
        bool RegisterStudent(Student student);
        bool RegisterLecturer(Lecturer lecturer);
        bool RegisterAdmin(Admin admin);
        Account AuthenticateUser(string username, string password);
        string GetUserRole(Account account);
    }
}
