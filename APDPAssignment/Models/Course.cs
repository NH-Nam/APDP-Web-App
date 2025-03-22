using System.ComponentModel.DataAnnotations;

namespace APDPAssignment.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        [StringLength(50)]
        public string CourseName { get; set; }

        [Required]
        [StringLength(200)]
        public string CourseDescription { get; set; }

        // Foreign key for Semester
        public int SemesterId { get; set; }
        public Semester Semester { get; set; }

        // Foreign key for Lecturer
        public int LecturerId { get; set; }
        public Lecturer Lecturer { get; set; }

        // Navigation property
        public virtual ICollection<EnrollmentList> EnrollmentLists { get; set; }
        public virtual ICollection<AcademicRecords> AcademicRecords { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }

    }
}
