using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace job_candidates.Models
{
    public class Candidate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Phone]
        public string? PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(50)]
        public string? PreferredCallTime { get; set; }

        [Url]
        public string? LinkedInProfile { get; set; }

        [Url]
        public string? GitHubProfile { get; set; }

        [Required]
        [StringLength(500)]
        public string Comment { get; set; }
    }
}
