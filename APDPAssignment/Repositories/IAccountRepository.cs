using APDPAssignment.Models;

namespace APDPAssignment.Repositories
{
    public interface IAccountRepository
    {
        bool Register(string username, string email, string password, string role,
            string firstName, string lastName, string phone, DateTime dob, string gender);

    }
}
