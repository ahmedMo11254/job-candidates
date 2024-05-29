using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace job_candidates.Models
{
    public class Candidate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? PreferredCallTime { get; set; }
        public string? LinkedInProfile { get; set; }
        public string? GitHubProfile { get; set; }
        public string Comment { get; set; }
    }
}
