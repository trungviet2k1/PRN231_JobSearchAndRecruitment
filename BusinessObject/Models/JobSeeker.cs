using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Models
{
    public class JobSeeker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobSeekerId { get; set; }

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

        public string? Address { get; set; }

        public string? ProfileDescription { get; set; }

        public string? Education { get; set; }

        public string? WorkExperience { get; set; }

        public bool IsEmployer { get; set; }

        public virtual ICollection<JobApplicant>? JobApplications { get; set; }

        public virtual ICollection<SavedJobs>? SavedJobs { get; set; }

        public virtual ICollection<Resume>? Resumes { get; set; }
    }
}