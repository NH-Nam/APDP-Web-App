using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APDPAssignment.Models;
using APDPAssignment.Data;
using System.Security.Claims;
using APDPAssignment.ViewModels;

namespace APDPAssignment.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult MyAcademicInfo()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }

            var student = _context.Student
                .Include(s => s.StudentCourses)
                    .ThenInclude(sc => sc.Course)
                .Include(s => s.AcademicRecords)
                .FirstOrDefault(s => s.Account.AccountId == int.Parse(userId));

            if (student == null)
            {
                return NotFound();
            }

            var viewModel = new StudentAcademicInfoViewModel
            {
                Courses = student.StudentCourses.Select(sc => sc.Course).ToList(),
                AcademicRecords = student.AcademicRecords.ToList()
            };

            return View(viewModel);
        }
    }
} 