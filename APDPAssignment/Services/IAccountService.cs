using APDPAssignment.Models;

namespace APDPAssignment.Services
{
    public interface IAccountService
    {
        bool Register(string username, string email, string password, string role,
            string firstName, string lastName, string phoneNumber, DateTime dob, string gender);
    }
}
