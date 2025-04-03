using System.ComponentModel.DataAnnotations;

namespace APDPAssignment.Models
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan EndTime { get; set; }

        // Foreign keys for Classroom
        public int ClassroomId { get; set; }
        public Classroom Classroom { get; set; }

        // Foreign keys for Lecturer
        public int LecturerId { get; set; }
        public Lecturer Lecturer { get; set; }
    }
}
