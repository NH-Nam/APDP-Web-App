using APDPAssignment.Models;
using APDPAssignment.Repositories;

namespace APDPAssignment.Services
{
    public class AccountService : IAccountService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ILecturerRepository _lecturerRepository;
        private readonly IAdminRepository _adminRepository;
        private readonly IAccountRepository _accountRepository;

        public AccountService(
            IStudentRepository studentRepository,
            ILecturerRepository lecturerRepository,
            IAdminRepository adminRepository,
            IAccountRepository accountRepository)
        {
            _studentRepository = studentRepository;
            _lecturerRepository = lecturerRepository;
            _adminRepository = adminRepository;
            _accountRepository = accountRepository;
        }

        public bool RegisterStudent(Student student)
        {
            try
            {
                student.Account.RoleId = 3; 
                if (_accountRepository.AddAccount(student.Account))
                {
                    _studentRepository.AddStudent(student);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool RegisterLecturer(Lecturer lecturer)
        {
            try
            {
                lecturer.Account.RoleId = 2;
                if (_accountRepository.AddAccount(lecturer.Account))
                {
                    _lecturerRepository.AddLecturer(lecturer);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool RegisterAdmin(Admin admin)
        {
            try
            {
                admin.Account.RoleId = 1;
                if (_accountRepository.AddAccount(admin.Account))
                {
                    _adminRepository.AddAdmin(admin);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Account AuthenticateUser(string username, string password)
        {
            var account = _accountRepository.GetAccountByUsername(username);
            if (account != null && account.Password == password)
            {
                return account;
            }
            return null;
        }

        public string GetUserRole(Account account)
        {
            try
            {
                return account.Role.RoleName;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
