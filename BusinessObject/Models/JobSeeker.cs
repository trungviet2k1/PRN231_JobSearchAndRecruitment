using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Models
{
    public class JobSeeker
    {
        [Key]
        [Column("job_seeker_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("full_name")]
        public string? FullName { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("address")]
        public string? Address { get; set; }

        [Phone]
        [Column("phone")]
        public string? PhoneNumber { get; set; }

        [Column("resume_url")]
        public string? ResumeUrl { get; set; }

        [Column("skills")]
        public string? Skills { get; set; }

        public List<Resume>? Resumes { get; set; }
    }
}