using APDPAssignment.Models;

namespace APDPAssignment.Repositories
{
    public interface IAccountRepository
    {
        bool Register(string username, string email, string password, string fullname, int role);
        bool Login(string username, string password);
        string GetUserRole(string username);
        Account GetAccountByUsername(string username);
    }
}
