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

        public bool Register(string username, string email, string password, string fullname, int role)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var account = new Account
                {
                    Username = username,
                    Email = email,
                    Password = password,
                    RoleId = role
                };

                _context.Account.Add(account);
                _context.SaveChanges();

                if (role == 1) // Admin
                {
                    var admin = new Admin
                    {
                        AdminName = fullname,
                        AdminEmail = email,
                        AdminId = account.AccountId
                    };
                    _context.Admin.Add(admin);
                }
                else if (role == 2) // Lecturer
                {
                    var lecturer = new Lecturer
                    {
                        LecturerName = fullname,
                        LecturerEmail = email,
                        LecturerId = account.AccountId
                    };
                    _context.Lecturer.Add(lecturer);
                }
                else if (role == 3) // Student
                {
                    var student = new Student
                    {
                        StudentName = fullname,
                        StudentEmail = email,
                        StudentId = account.AccountId
                    };
                    _context.Student.Add(student);
                }

                _context.SaveChanges();
                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
        }

        public bool Login(string username, string password)
        {
            var account = _context.Account.SingleOrDefault(a => a.Username == username && a.Password == password);
            return account != null;
        }

        public string GetUserRole(string username)
        {
            var account = _context.Account.SingleOrDefault(a => a.Username == username);
            if (account != null)
            {
                var role = _context.Roles.SingleOrDefault(r => r.RoleId == account.RoleId);
                return role?.RoleName;
            }
            return null;
        }

        public Account GetAccountByUsername(string username)
        {
            return _context.Account.SingleOrDefault(a => a.Username == username);
        }
    }
}
