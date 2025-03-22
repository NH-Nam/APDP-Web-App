using System.ComponentModel.DataAnnotations;

namespace APDPAssignment.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Required]
        [StringLength(50)]
        public string AdminName { get; set; }

        // Navigation property
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
