using System.ComponentModel.DataAnnotations;

namespace APDPAssignment.Models
{
    public class Lecturer
    {
        [Key]
        public int LecturerId { get; set; }

        [Required]
        [StringLength(50)]
        public string LecturerName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        public string LecturerEmail { get; set; }

        [StringLength(50)]
        public string LecturerPhone { get; set; }


        // Navigation property
        public virtual Account Account { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
