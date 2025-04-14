using Xunit;
using APDPAssignment.Models;
using APDPAssignment.Services;
using APDPAssignment.Repositories;
using Microsoft.EntityFrameworkCore;
using APDPAssignment.Data;

namespace APDPAssignment.Tests
{
    public class UnitTest1 : IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly IAccountService _accountService;
        private readonly IStudentService _studentService;
        private readonly CourseFacade _courseFacade;
        private readonly ICourseRepository _courseRepository;
        private readonly IAccountRepository _accountRepository;

        public UnitTest1()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=APDPAssignment;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options;
            _context = new ApplicationDbContext(options);

            // Initialize repositories
            _accountRepository = new AccountRepository(_context);
            var studentRepo = new StudentRepository(_context);
            var courseRepo = new CourseRepository(_context);
            var academicRepo = new AcademicRecordsRepository(_context);

            // Initialize services
            _accountService = new AccountService(_accountRepository);
            _studentService = new StudentService(studentRepo);
            _courseFacade = new CourseFacade(courseRepo, academicRepo, studentRepo);
            _courseRepository = courseRepo;

            // Setup initial test data
            SetupTestData();
        }

        private void SetupTestData()
        {
            try
            {
                // Clear existing test data
                var studentCourses = _context.StudentCourses.ToList();
                var academicRecords = _context.AcademicRecords.ToList();
                var students = _context.Student.ToList();
                var courses = _context.Course.ToList();
                var accounts = _context.Account.ToList();

                _context.StudentCourses.RemoveRange(studentCourses);
                _context.AcademicRecords.RemoveRange(academicRecords);
                _context.Student.RemoveRange(students);
                _context.Course.RemoveRange(courses);
                _context.Account.RemoveRange(accounts);
                _context.SaveChanges();

                // Add roles if they don't exist
                if (!_context.Roles.Any())
                {
                    var roles = new List<Roles>
                    {
                        new Roles { RoleId = 1, RoleName = "Admin" },
                        new Roles { RoleId = 2, RoleName = "Lecturer" },
                        new Roles { RoleId = 3, RoleName = "Student" }
                    };
                    _context.Roles.AddRange(roles);
                    _context.SaveChanges();
                }

                // Add test account
                var account = new Account
                {
                    Username = "testuser",
                    Password = "Test@123",
                    Email = "test@example.com",
                    RoleId = 3
                };
                _context.Account.Add(account);
                _context.SaveChanges();

                // Add test student
                var student = new Student
                {
                    StudentId = account.AccountId,
                    StudentName = "Test Student",
                    StudentEmail = "student@test.com",
                    StudentPhone = "1234567890",
                    StudentDoB = DateTime.Now.AddYears(-20),
                    StudentGender = "Male"
                };
                _context.Student.Add(student);
                _context.SaveChanges();

                // Add test course
                var course = new Course
                {
                    CourseName = "Test Course",
                    CourseDescription = "Test Description"
                };
                _context.Course.Add(course);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                throw new Exception($"Failed to setup test data: {ex.Message}. Inner exception: {innerException}");
            }
        }

        public void Dispose()
        {
            // Cleanup after all tests
            try
            {
                var studentCourses = _context.StudentCourses.ToList();
                var academicRecords = _context.AcademicRecords.ToList();
                var students = _context.Student.ToList();
                var courses = _context.Course.ToList();
                var accounts = _context.Account.ToList();

                _context.StudentCourses.RemoveRange(studentCourses);
                _context.AcademicRecords.RemoveRange(academicRecords);
                _context.Student.RemoveRange(students);
                _context.Course.RemoveRange(courses);
                _context.Account.RemoveRange(accounts);
                _context.SaveChanges();
            }
            catch
            {
                // Ignore cleanup errors
            }
            _context.Dispose();
        }

        [Fact]
        public void UT_ACC_001_Login_ValidCredentials()
        {
            // Arrange - using test data already setup
            string username = "testuser";
            string password = "Test@123";

            // Act
            bool result = _accountService.Login(username, password);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void UT_ACC_002_GetUserRole()
        {
            // Arrange - using test data already setup
            string username = "testuser";

            // Act
            string role = _accountService.GetUserRole(username);

            // Assert
            Assert.Equal("Student", role);
        }

        [Fact]
        public void UT_ACC_003_Register()
        {
            // Arrange
            string username = "newuser";
            string password = "Test@123";
            string email = "new@example.com";
            string fullname = "New User";
            int role = 3;

            // Act
            bool result = _accountRepository.Register(username, password, email, fullname, role);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void UT_STD_001_AssignCourseToStudent()
        {
            // Arrange
            var student = _context.Student.First();
            var course = _context.Course.First();

            // Act
            bool result = _studentService.AssignCourseToStudent(student.StudentId, course.CourseId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void UT_STD_002_GetStudentById()
        {
            // Arrange
            var existingStudent = _context.Student.First();

            // Act
            var student = _studentService.GetStudentById(existingStudent.StudentId);

            // Assert
            Assert.NotNull(student);
        }

        [Fact]
        public void UT_STD_003_AssignCourseToStudent_Facade()
        {
            // Arrange
            var student = _context.Student.First();
            var course = _context.Course.First();

            // Act
            bool result = _courseFacade.AssignCourseToStudent(student.StudentId, course.CourseId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void UT_CRS_001_AssignCourseToStudent_Facade()
        {
            // Arrange
            var student = _context.Student.First();
            var course = _context.Course.First();

            // Act
            bool result = _courseFacade.AssignCourseToStudent(student.StudentId, course.CourseId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void UT_CRS_002_DeleteCourse()
        {
            // Arrange
            var newCourse = new Course
            {
                CourseName = "Course to Delete",
                CourseDescription = "Will be deleted"
            };
            _context.Course.Add(newCourse);
            _context.SaveChanges();

            // Act
            bool result = _courseFacade.DeleteCourse(newCourse.CourseId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void UT_CRS_003_GetAllCourses()
        {
            // Act
            var courses = _courseRepository.GetAllCourses();

            // Assert
            Assert.NotNull(courses);
            Assert.NotEmpty(courses);
        }

        [Fact]
        public void UT_ACD_001_GetAcademicRecordsByStudentId()
        {
            // Arrange
            var student = _context.Student.First();
            var academicRecord = new AcademicRecords
            {
                StudentId = student.StudentId,
                grade = "A",
                status = "Completed"
            };
            _context.AcademicRecords.Add(academicRecord);
            _context.SaveChanges();

            // Act
            var records = _studentService.GetAcademicRecordsByStudentId(student.StudentId);

            // Assert
            Assert.NotNull(records);
            Assert.NotEmpty(records);
        }
    }
}