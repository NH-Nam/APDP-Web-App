using System.ComponentModel.DataAnnotations;

namespace APDPAssignment.Models
{
    public class Semester
    {
        [Key]
        public int SemesterId { get; set; }

        [Required]
        [StringLength(50)]
        public string SemesterName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string SemesterStartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string SemesterEndDate { get; set; }

        [Required]
        [StringLength(50)]
        public string AcademicYear { get; set; }
    }
}
