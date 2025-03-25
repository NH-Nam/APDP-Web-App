using APDPAssignment.Data;
using APDPAssignment.Models;
using APDPAssignment.Repositories;

namespace APDPAssignment.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;

        public AccountService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Register(string username, string email, string password, string fullname, string role)
        {
            try
            {
                var account = new Account
                {
                    Username = username,
                    Email = email,
                    Password = password,
                    RoleId = GetRoleId(role)
                };

                var student = new Student
                {
                    StudentName = fullname,
                    StudentEmail = email,
                    Account = account
                };

                _context.Student.Add(student);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private int GetRoleId(string role)
        {
            switch (role)
            {
                case "Admin":
                    return 1;
                case "Lecturer":
                    return 2;
                case "Student":
                    return 3;
                default:
                    throw new ArgumentException("Invalid role");
            }
        }
    }
}
