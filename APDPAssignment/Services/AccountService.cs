using APDPAssignment.Data;
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

        public bool Register(string username, string email, string password, string fullname, int role)
        {
            return _accountRepository.Register(username, email, password, fullname, role);
        }

        public bool Login(string username, string password)
        {
            return _accountRepository.Login(username, password);
        }

        public string GetUserRole(string username)
        {
            return _accountRepository.GetUserRole(username);
        }

        public Account GetAccountByUsername(string username)
        {
            return _accountRepository.GetAccountByUsername(username);
        }
    }
}
