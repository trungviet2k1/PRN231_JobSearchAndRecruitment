using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BusinessObject.Commons;

namespace BusinessObject.Models
{
    public class Employer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployerId { get; set; }

        [Required]
        [MaxLength(100)]
        public string? CompanyName { get; set; }

        [Required]
        [MaxLength(100)]
        public string? FullName { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Password { get; set; }

        [Phone]
        [MaxLength(15)]
        public string? PhoneNumber { get; set; }

        [MaxLength(200)]
        public string? CompanyWebsite { get; set; }

        [MaxLength(200)]
        public string? Industry { get; set; }

        [MaxLength(1000)]
        public string? CompanyDescription { get; set; }

        public virtual ICollection<Job>? Jobs { get; set; }

        public virtual ICollection<JobApplicant>? JobApplications { get; set; }

        public virtual ICollection<RatingsAndReviews>? RatingsAndReviews { get; set; }
    }
}
