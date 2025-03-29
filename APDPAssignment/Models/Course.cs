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

    }
}
