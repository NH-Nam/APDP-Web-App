using APDPAssignment.Models;
using APDPAssignment.Services;
using APDPAssignment.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace APDPAssignment.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseFacade _courseFacade;

        public CourseController(CourseFacade courseFacade)
        {
            _courseFacade = courseFacade;
        }

        public CourseController()
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            var courses = _courseFacade.GetAllCourses();
            return View(courses);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            try
            {
                var course = _courseFacade.GetCourseById(id);
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
                    var success = _courseFacade.AddCourse(course);
                    if (success)
                    {
                        return RedirectToAction("CourseManagement");
                    }
                    ModelState.AddModelError(string.Empty, "Failed to create course.");
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
            var course = _courseFacade.GetCourseById(id);
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
                    var success = _courseFacade.EditCourse(course);
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
                var success = _courseFacade.DeleteCourse(id);
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
            var courses = _courseFacade.GetAllCourses();
            return View(courses);
        }

        [HttpGet]
        public IActionResult AssignCourse()
        {
            var model = new AssignCourseViewModel
            {
                Students = _courseFacade.GetAllStudents().Select(s => new SelectListItem
                {
                    Value = s.StudentId.ToString(),
                    Text = s.StudentName
                }),
                Courses = _courseFacade.GetAllCourses().Select(c => new SelectListItem
                {
                    Value = c.CourseId.ToString(),
                    Text = c.CourseName
                })
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AssignCourse(AssignCourseViewModel model)
        {
            if (model.StudentId.HasValue && model.CourseId.HasValue)
            {
                var success = _courseFacade.AssignCourseToStudent(model.StudentId.Value, model.CourseId.Value);
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

            model = new AssignCourseViewModel
            {
                Students = _courseFacade.GetAllStudents().Select(s => new SelectListItem
                {
                    Value = s.StudentId.ToString(),
                    Text = s.StudentName
                }),
                Courses = _courseFacade.GetAllCourses().Select(c => new SelectListItem
                {
                    Value = c.CourseId.ToString(),
                    Text = c.CourseName
                })
            };
            return View(model);
        }
    }
}
