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

        public bool Register(string username, string email, string password, string role,
            string firstName, string lastName, string phoneNumber, DateTime dob, string gender)
        {
            var account = new Account
            {
                Username = username,
                Email = email,
                Password = password,
                RoleId = GetRoleId(role)
            };

            if (role == "Student")
            {
                var student = new Student
                {
                    StudentName = $"{firstName} {lastName}",
                    StudentEmail = email,
                    StudentPhone = phoneNumber,
                    StudentDoB = dob,
                    StudentGender = gender
                };
                _context.Student.Add(student);
                _context.SaveChanges();

                account.StudentId = student.StudentId;
            }
            else if (role == "Admin")
            {
                var admin = new Admin
                {
                    AdminName = $"{firstName} {lastName}"
                };
                _context.Admin.Add(admin);
                _context.SaveChanges();

                account.AdminId = admin.AdminId;
            }
            else if (role == "Lecturer")
            {
                var lecturer = new Lecturer
                {
                    LecturerName = $"{firstName} {lastName}",
                    LecturerEmail = email,
                    LecturerPhone = phoneNumber
                };
                _context.Lecturer.Add(lecturer);
                _context.SaveChanges();

                account.LecturerId = lecturer.LecturerId;
            }

            _context.Account.Add(account);
            return _context.SaveChanges() > 0;
        }

        private int GetRoleId(string role)
        {
            // Implement logic to get the role ID based on the role name
            var roleEntity = _context.Roles.FirstOrDefault(r => r.RoleName == role);
            return roleEntity?.RoleId ?? 0;
        }
    }
}
