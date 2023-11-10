using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Models
{
    public class RatingsAndReviews
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RatingId { get; set; }

        public int JobSeekerId { get; set; }

        public int EmployerId { get; set; }

        [Range(1, 5)]
        public int? Rating { get; set; }

        [MaxLength(1000)]
        public string? Comment { get; set; }

        [ForeignKey("JobSeekerId")]
        public JobSeeker? JobSeeker { get; set; }

        [ForeignKey("EmployerId")]
        public Employer? Employer { get; set; }

    }
}