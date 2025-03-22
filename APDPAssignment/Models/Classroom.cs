using System.ComponentModel.DataAnnotations;

namespace APDPAssignment.Models
{
    public class Classroom
    {
        [Key]
        public int ClassroomId { get; set; }

        [Required]
        [StringLength(50)]
        public string ClassroomName { get; set; }

        // Navigation property
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
