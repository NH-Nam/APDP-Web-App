using APDPAssignment.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace APDPAssignment.ViewModels
{
    public class AssignCourseViewModel
    {
        public int? StudentId { get; set; }
        public int? CourseId { get; set; }
        public IEnumerable<SelectListItem> Students { get; set; }
        public IEnumerable<SelectListItem> Courses { get; set; }
    }
}
