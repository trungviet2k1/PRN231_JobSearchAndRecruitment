using BusinessObject.Commons;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.DTOs
{
    public class JobDTO
    {
        public int JobId { get; set; }

        [Required(ErrorMessage = "Please enter a job title!")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Please enter job description!")]
        public string? Description { get; set; }

        public string? Industry { get; set; }

        public string? Location { get; set; }

        [Required(ErrorMessage = "Please enter the application deadline!")]
        public DateTime? ApplicationDeadline { get; set; }

        public string? RequiredSkills { get; set; }

        public string? RequiredEducation { get; set; }

        public decimal Salary { get; set; }

        public TimeType? TimeType { get; set; }

        public int EmployerId { get; set; }
    }
}
