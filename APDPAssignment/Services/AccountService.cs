using APDPAssignment.Models;
using APDPAssignment.Repositories;

namespace APDPAssignment.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public bool Register(string username, string email, string password, string role,
            string firstName, string lastName, string phoneNumber, DateTime dob, string gender)
        {
            return _accountRepository.Register(username, email, password, role,
                firstName, lastName, phoneNumber, dob, gender);
        }
    }
}
