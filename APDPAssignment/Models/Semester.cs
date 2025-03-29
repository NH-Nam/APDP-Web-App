using System.ComponentModel.DataAnnotations;

namespace APDPAssignment.Models
{
    public class Semester
    {
        public int SemesterId { get; set; }
        public string SemesterName { get; set; }
        public string? SemesterStartDate { get; set; }
        public string? SemesterEndDate { get; set; }
        public string? AcademicYear { get; set; }
        public virtual ICollection<AcademicRecords> AcademicRecords { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
