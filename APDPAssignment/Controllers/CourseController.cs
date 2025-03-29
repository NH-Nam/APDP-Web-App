using APDPAssignment.Models;
using APDPAssignment.Services;
using Microsoft.AspNetCore.Mvc;

namespace APDPAssignment.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var courses = _courseService.GetAllCourses();
            return View(courses);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            try
            {
                var course = _courseService.GetCourseById(id);
                if (course == null)
                {
                    return NotFound();
                }
                return View(course);
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult CreateCourse()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCourse(Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var success = _courseService.AddCourse(course);
                    if (success)
                    {
                        return RedirectToAction("CourseManagement");
                    }
                    ModelState.AddModelError(string.Empty, "Failed to create course.");
                }

                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }

                return View(course);
            }
            catch
            {
                return View(course);
            }
        }

        [HttpGet]
        public IActionResult EditCourse(int id)
        {
            var course = _courseService.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCourse(Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var success = _courseService.EditCourse(course);
                    if (success)
                    {
                        return RedirectToAction("CourseManagement");
                    }
                    ModelState.AddModelError(string.Empty, "Failed to update course.");
                }
                return View(course);
            }
            catch
            {
                return View(course);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            try
            {
                var success = _courseService.DeleteCourse(id);
                if (success)
                {
                    return RedirectToAction("CourseManagement");
                }
                ModelState.AddModelError(string.Empty, "Failed to delete course.");
                return RedirectToAction("CourseManagement");
            }
            catch
            {
                return RedirectToAction("CourseManagement");
            }
        }

        [HttpGet]
        public IActionResult CourseManagement()
        {
            var courses = _courseService.GetAllCourses();
            return View(courses);
        }
    }
}
