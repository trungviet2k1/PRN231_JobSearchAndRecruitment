using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Models
{
    public class Resume
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResumeId { get; set; }

        public int JobSeekerId { get; set; }

        [MaxLength(100)]
        public string? DocumentName { get; set; }

        [MaxLength(200)]
        public string? DocumentPath { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        [ForeignKey("JobSeekerId")]
        public JobSeeker? JobSeeker { get; set; }
    }
}