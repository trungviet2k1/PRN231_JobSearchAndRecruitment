using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BusinessObject.Commons;

namespace BusinessObject.Models
{
    public class Job
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobId { get; set; }

        [Required]
        [MaxLength(200)]
        public string? Title { get; set; }

        [Required]
        [MaxLength(1000)]
        public string? Description { get; set; }

        [MaxLength(200)]
        public string? Industry { get; set; }

        [MaxLength(200)]
        public string? Location { get; set; }

        public DateTime? CreateDate { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime? ApplicationDeadline { get; set; }

        [MaxLength(100)]
        public string? RequiredSkills { get; set; }

        [MaxLength(100)]
        public string? RequiredEducation { get; set; }

        [Range(0, Double.MaxValue)]
        public decimal? Salary { get; set; }

        public TimeType TimeType { get; set; }

        public bool? Status { get; set; }

        public int? EmployerId { get; set; }

        [ForeignKey("EmployerId")]
        public Employer? Employer { get; set; }

        public virtual ICollection<JobApplicant>? JobApplications { get; set; }

        public virtual ICollection<SavedJobs>? SavedJobs { get; set; }
    }
}
