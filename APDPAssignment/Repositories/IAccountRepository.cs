using APDPAssignment.Models;

namespace APDPAssignment.Repositories
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAllAccounts();
        Account GetAccountById(int id);
        bool AddAccount(Account account);
        bool UpdateAccount(Account account);
        bool DeleteAccount(int accountId);
        Account GetAccountByUsername(string username);

    }
}
