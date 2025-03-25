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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var success = _courseService.AddCourse(course);
                    if (success)
                    {
                        return RedirectToAction("Index");
                    }
                    ModelState.AddModelError(string.Empty, "Failed to create course.");
                }
                return View(course);
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var course = _courseService.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost]
        public IActionResult Edit(Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var success = _courseService.EditCourse(course);
                    if (success)
                    {
                        return RedirectToAction("Index");
                    }
                    ModelState.AddModelError(string.Empty, "Failed to update course.");
                }
                return View(course);
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var course = _courseService.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var success = _courseService.DeleteCourse(id);
                if (success)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, "Failed to delete course.");
                return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Assign(int courseId)
        {
            ViewBag.CourseId = courseId;
            return View();
        }

        [HttpPost]
        public IActionResult Assign(int courseId, int studentId)
        {
            try
            {
                var success = _courseService.AssignCourseToStudent(courseId, studentId);
                if (success)
                {
                    return RedirectToAction("Details", new { id = courseId });
                }
                ModelState.AddModelError(string.Empty, "Failed to assign course to student.");
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
