using APDPAssignment.Models;
using APDPAssignment.Repositories;
using System;

namespace APDPAssignment.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
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

        public Course GetCourseByNameAndDescription(string courseName, string courseDescription)
        {
            try
            {
                return _courseRepository.GetCourseByNameAndDescription(courseName, courseDescription);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool EditCourse(Course course)
        {
            try
            {
                return _courseRepository.EditCourse(course);
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
