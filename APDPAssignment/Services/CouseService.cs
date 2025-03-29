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

        public IEnumerable<Course> GetAllCourses()
        {
            try
            {
                return _courseRepository.GetAllCourses();
            }
            catch (Exception)
            {
                return new List<Course>();
            }
        }

        public Course GetCourseById(int courseId)
        {
            try
            {
                return _courseRepository.GetCourseById(courseId);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool AddCourse(Course course)
        {
            try
            {
                return _courseRepository.AddCourse(course);
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
                return _courseRepository.UpdateCourse(course);
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
                return _courseRepository.DeleteCourse(courseId);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
