using System.ComponentModel.DataAnnotations;

namespace APDPAssignment.Models
{
    public class EnrollmentList
    {
        [Key]
        public int EnrollmentId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string EnrollmentDate { get; set; } 
           
        public int StudentId { get; set; }
        public Student Student { get; set; }

        // Foreign key for Course
        public int CourseId { get; set; }
        public Course Course { get; set; }

        // Foreign key for Semester
        public int SemesterId { get; set; }
        public Semester Semester { get; set; }

    }
}
