using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using APDPAssignment.Data;
using APDPAssignment.Models;
using APDPAssignment.Services;
using Xunit;
using APDPAssignment.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using APDPAssignment.Repositories;

namespace APDPAssignment.Tests
{
    public class UnitTest2 : IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly IAccountService _accountService;
        private readonly IStudentService _studentService;
        private readonly CourseFacade _courseFacade;
        private readonly ICourseRepository _courseRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IAcademicRecordsRepository _academicRecordsRepository;

        public UnitTest2()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=APDPAssignment;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options;
            _context = new ApplicationDbContext(options);

            // Initialize repositories
            _accountRepository = new AccountRepository(_context);
            var studentRepo = new StudentRepository(_context);
            var courseRepo = new CourseRepository(_context);
            _academicRecordsRepository = new AcademicRecordsRepository(_context);

            // Initialize services
            _accountService = new AccountService(_accountRepository);
            _studentService = new StudentService(studentRepo);
            _courseFacade = new CourseFacade(courseRepo, _academicRecordsRepository, studentRepo);
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
        public void UT_ACC_004_Login_InvalidCredentials()
        {
            // Arrange
            string username = "testuser";
            string password = "WrongPassword";

            // Act
            bool result = _accountService.Login(username, password);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void UT_ACC_005_Register_DuplicateUsername()
        {
            // Arrange
            string username = "testuser"; // Same as in test data
            string password = "Test@123";
            string email = "new@example.com";
            string fullname = "New User";
            int role = 3;

            // Act
            bool result = _accountRepository.Register(username, password, email, fullname, role);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void UT_STD_004_GetStudentCourses()
        {
            // Arrange
            var student = _context.Student.First();
            var course = _context.Course.First();
            _studentService.AssignCourseToStudent(student.StudentId, course.CourseId);

            // Act
            var courses = _courseFacade.GetStudentCourses(student.StudentId);

            // Assert
            Assert.NotNull(courses);
            Assert.NotEmpty(courses);
            Assert.Contains(courses, c => c.CourseId == course.CourseId);
        }

        [Fact]
        public void UT_STD_005_GetStudentById()
        {
            // Arrange
            var existingStudent = _context.Student.First();

            // Act
            var student = _studentService.GetStudentById(existingStudent.StudentId);

            // Assert
            Assert.NotNull(student);
            Assert.Equal(existingStudent.StudentName, student.StudentName);
            Assert.Equal(existingStudent.StudentEmail, student.StudentEmail);
        }

        [Fact]
        public void UT_CRS_004_AddCourse()
        {
            // Arrange
            var course = new Course
            {
                CourseName = "New Course",
                CourseDescription = "New Description"
            };

            // Act
            bool result = _courseFacade.AddCourse(course);

            // Assert
            Assert.True(result);
            var addedCourse = _courseRepository.GetCourseByNameAndDescription(course.CourseName, course.CourseDescription);
            Assert.NotNull(addedCourse);
        }

        [Fact]
        public void UT_CRS_005_EditCourse()
        {
            // Arrange
            var course = _context.Course.First();
            course.CourseName = "Updated Course";
            course.CourseDescription = "Updated Description";

            // Act
            bool result = _courseFacade.EditCourse(course);

            // Assert
            Assert.True(result);
            var updatedCourse = _courseRepository.GetCourseById(course.CourseId);
            Assert.Equal("Updated Course", updatedCourse.CourseName);
            Assert.Equal("Updated Description", updatedCourse.CourseDescription);
        }

        [Fact]
        public void UT_ACD_002_AddAcademicRecord()
        {
            // Arrange
            var student = _context.Student.First();
            var academicRecord = new AcademicRecords
            {
                StudentId = student.StudentId,
                grade = "A",
                status = "Completed"
            };

            // Act
            bool result = _academicRecordsRepository.AddAcademicRecords(academicRecord);

            // Assert
            Assert.True(result);
            var records = _studentService.GetAcademicRecordsByStudentId(student.StudentId);
            Assert.Contains(records, r => r.grade == "A" && r.status == "Completed");
        }

        [Fact]
        public void UT_ACD_003_UpdateAcademicRecord()
        {
            // Arrange
            var student = _context.Student.First();
            var academicRecord = new AcademicRecords
            {
                StudentId = student.StudentId,
                grade = "B",
                status = "In Progress"
            };
            _academicRecordsRepository.AddAcademicRecords(academicRecord);

            // Act
            academicRecord.grade = "A";
            academicRecord.status = "Completed";
            bool result = _academicRecordsRepository.UpdateAcademicRecords(academicRecord);

            // Assert
            Assert.True(result);
            var records = _studentService.GetAcademicRecordsByStudentId(student.StudentId);
            Assert.Contains(records, r => r.grade == "A" && r.status == "Completed");
        }

        [Fact]
        public void UT_ACC_006_GetAccountByUsername()
        {
            // Arrange
            string username = "testuser";

            // Act
            var account = _accountRepository.GetAccountByUsername(username);

            // Assert
            Assert.NotNull(account);
            Assert.Equal(username, account.Username);
        }

        [Fact]
        public void UT_ACC_007_GetAccountByUsername_NotFound()
        {
            // Arrange
            string username = "nonexistentuser";

            // Act
            var account = _accountRepository.GetAccountByUsername(username);

            // Assert
            Assert.Null(account);
        }
    }
} 