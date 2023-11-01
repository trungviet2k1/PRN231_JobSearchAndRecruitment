using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Models
{
    public class Resume
    {
        [Key]
        [Column("resume_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("resume_title")]
        public string? Title { get; set; }

        [Column("resume_content")]
        public string? Content { get; set; }

        [Column("resume_url")]
        public string? ResumeUrl { get; set; }

        [ForeignKey("job_seeker_id")]
        public JobSeeker? JobSeeker { get; set; }
    }
}