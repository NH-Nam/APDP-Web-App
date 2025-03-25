using APDPAssignment.Models;

namespace APDPAssignment.Services
{
    public interface IAccountService
    {
        bool Register(string username, string email, string password, string fullname, string role);
        bool Login(string username, string password);
    }
}
