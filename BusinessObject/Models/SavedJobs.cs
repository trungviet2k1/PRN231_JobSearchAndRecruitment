using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Models
{
    public class SavedJobs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SavedJobId { get; set; }

        public int JobSeekerId { get; set; }

        public int JobId { get; set; }

        [ForeignKey("JobSeekerId")]
        public JobSeeker? JobSeeker { get; set; }

        [ForeignKey("JobId")]
        public Job? Job { get; set; }
    }
}
