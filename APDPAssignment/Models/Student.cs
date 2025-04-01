using System.ComponentModel.DataAnnotations;

namespace APDPAssignment.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [StringLength(50)]
        public string StudentName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        public string StudentEmail { get; set; }

        [StringLength(50)]
        public string? StudentPhone { get; set; }

        [DataType(DataType.Date)]
        public DateTime StudentDoB { get; set; }

        public string? StudentGender { get; set; }

        // Navigation property
        public virtual Account Account { get; set; }
        public virtual ICollection<AcademicRecords> AcademicRecords { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}
