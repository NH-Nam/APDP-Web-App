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

        public async Task RegisterStudentAsync(Student student)
        {
            student.Account.RoleId = 3;

            if (_accountRepository.AddAccount(student.Account))
            {
                _studentRepository.AddStudent(student);
            }
        }

        public async Task RegisterLecturerAsync(Lecturer lecturer)
        {
            lecturer.Account.RoleId = 2;

            if (_accountRepository.AddAccount(lecturer.Account))
            {
                _lecturerRepository.AddLecturer(lecturer);
            }
        }

        public async Task RegisterAdminAsync(Admin admin)
        {
            admin.Account.RoleId = 1;

            if (_accountRepository.AddAccount(admin.Account))
            {
                _adminRepository.AddAdmin(admin);
            }
        }
    }
}
