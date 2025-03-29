using APDPAssignment.Models;

namespace APDPAssignment.Services
{
    public interface IAccountService
    {
        bool Register(string username, string email, string password, string fullname, int role);
        bool Login(string username, string password);
        string GetUserRole(string username);

    }
}
