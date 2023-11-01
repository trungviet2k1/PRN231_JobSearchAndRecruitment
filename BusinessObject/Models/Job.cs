using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BusinessObject.Commons;

namespace BusinessObject.Models
{
    public class Job
    {
        [Key]
        [Column("job_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("job_title")]
        public string? Title { get; set; }

        [Required]
        [Column("job_description")]
        public string? Description { get; set; }

        [Required]
        [Column("job_requirements")]
        public string? JobRequirements { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("job_location")]
        public string? Location { get; set; }

        [Column("job_salary")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Salary { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Column("application_deadline")]
        public DateTime ApplicationDeadline { get; set; }

        [Required]
        [Column("job_time_type")]
        public TimeType TimeType { get; set; }

        [ForeignKey("comp_id")]
        public Employer? Employer { get; set; }

        public List<JobApplicant>? JobApplicants { get; set; }
    }
}
