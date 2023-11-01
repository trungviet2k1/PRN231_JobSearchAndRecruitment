using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BusinessObject.Commons;

namespace BusinessObject.Models
{
    public class JobApplicant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("job_id")]
        public Job? Job { get; set; }

        [ForeignKey("job_seeker_id")]
        public JobSeeker? JobSeeker { get; set; }

        [Column("application_status")]
        public JobApplicationStatus? Status { get; set; }
    }
}