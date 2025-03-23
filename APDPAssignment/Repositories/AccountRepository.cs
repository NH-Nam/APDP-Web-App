using APDPAssignment.Data;
using APDPAssignment.Models;

namespace APDPAssignment.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            try
            {
                return _context.Account.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public Account GetAccountById(int id)
        {
            try
            {
                return _context.Account.Find(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool AddAccount(Account account)
        {
            try
            {
                _context.Account.Add(account);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool UpdateAccount(Account account)
        {
            try
            {
                _context.Account.Update(account);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool DeleteAccount(int accountId)
        {
            var account = _context.Account.Find(accountId);
            try
            {
                _context.Account.Remove(account);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public Account GetAccountByUsername(string username)
        {
            try
            {
                return _context.Account.Where(a => a.Username == username).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
