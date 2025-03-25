using APDPAssignment.Models;
using APDPAssignment.Repositories;
using System;

namespace APDPAssignment.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IEnrollmentListRepository _enrollmentListRepository;

        public CourseService(ICourseRepository courseRepository, IStudentRepository studentRepository, IEnrollmentListRepository enrollmentListRepository)
        {
            _courseRepository = courseRepository;
            _studentRepository = studentRepository;
            _enrollmentListRepository = enrollmentListRepository;
        }

        public bool AddCourse(Course course)
        {
            try
            {
                _courseRepository.AddCourse(course);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditCourse(Course course)
        {
            try
            {
                _courseRepository.UpdateCourse(course);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCourse(int courseId)
        {
            try
            {
                _courseRepository.DeleteCourse(courseId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AssignCourseToStudent(int courseId, int studentId)
        {
            try
            {
                var course = _courseRepository.GetCourseById(courseId);
                var student = _studentRepository.GetStudentById(studentId);

                if (course != null && student != null)
                {
                    var enrollment = new EnrollmentList
                    {
                        CourseId = courseId,
                        StudentId = studentId,
                        EnrollmentDate = DateTime.Now.ToString("yyyy-MM-dd")
                    };
                    return _enrollmentListRepository.AddEnrollmentList(enrollment);
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
