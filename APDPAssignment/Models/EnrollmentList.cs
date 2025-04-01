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
          

    }
}
