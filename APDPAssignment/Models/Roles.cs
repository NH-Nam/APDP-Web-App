using System.ComponentModel.DataAnnotations;

namespace APDPAssignment.Models
{
    public class Roles
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        [StringLength(50)]
        public string RoleName { get; set; }

        // Navigation property
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
