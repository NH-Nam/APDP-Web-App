using System.Collections.Generic;
using APDPAssignment.Models;

namespace APDPAssignment.ViewModels
{
    public class StudentAcademicInfoViewModel
    {
        public List<Course> Courses { get; set; }
        public List<AcademicRecords> AcademicRecords { get; set; }
    }
} 