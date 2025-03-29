using System.ComponentModel.DataAnnotations;

namespace APDPAssignment.Models
{
    public class AcademicRecords
    {
        [Key]
        public int AcademicRecordId { get; set; }

        [Required]
        [StringLength(50)]
        public string grade { get; set; }

        [Required]
        [StringLength(50)]
        public string status { get; set; }

        // Foreign key for Student
        public int StudentId { get; set; }
        public Student Student { get; set; }

        // Foreign key for Semester
        public int SemesterId { get; set; }
        public Semester Semester { get; set; }
    }
}
