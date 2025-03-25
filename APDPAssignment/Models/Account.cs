using System.ComponentModel.DataAnnotations;

namespace APDPAssignment.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        // Foreign key for Student
        public int? StudentId { get; set; }
        public virtual Student Student { get; set; }

        // Foreign key for Admin
        public int? AdminId { get; set; }
        public virtual Admin Admin { get; set; }

        // Foreign key for Lecturer
        public int? LecturerId { get; set; }
        public virtual Lecturer Lecturer { get; set; }

        // Foreign key for Roles
        public int RoleId { get; set; }
        public virtual Roles Role { get; set; }
    }
}
