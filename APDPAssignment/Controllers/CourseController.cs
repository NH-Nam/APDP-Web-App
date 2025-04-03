using APDPAssignment.Models;
using APDPAssignment.Services;
using APDPAssignment.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace APDPAssignment.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;


        public CourseController(ICourseService courseService, IStudentService studentService)
        {
            _courseService = courseService;
            _studentService = studentService;
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

        private AssignCourseViewModel CreateAssignCourseViewModel()
        {
            return new AssignCourseViewModel
            {
                Students = _studentService.GetAllStudents().Select(s => new SelectListItem
                {
                    Value = s.StudentId.ToString(),
                    Text = s.StudentName
                }),
                Courses = _courseService.GetAllCourses().Select(c => new SelectListItem
                {
                    Value = c.CourseId.ToString(),
                    Text = c.CourseName
                })
            };
        }

        [HttpGet]
        public IActionResult AssignCourse()
        {
            var model = CreateAssignCourseViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AssignCourse(AssignCourseViewModel model)
        {
            if (model.StudentId.HasValue && model.CourseId.HasValue)
            {
                var success = _studentService.AssignCourseToStudent(model.StudentId.Value, model.CourseId.Value);
                if (success)
                {
                    return RedirectToAction("CourseManagement");
                }
                ModelState.AddModelError(string.Empty, "Failed to assign course.");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Student and Course are required.");
            }

            model = CreateAssignCourseViewModel();
            return View(model);
        }
    }
}
