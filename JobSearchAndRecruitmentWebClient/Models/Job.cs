using BusinessObject.Commons;

namespace JobSearchAndRecruitmentWebClient.Models
{
    public class Job
    {
        public int JobId { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Industry { get; set; }

        public string? Location { get; set; }

        public DateTime? ApplicationDeadline { get; set; }

        public string? RequiredSkills { get; set; }

        public string? RequiredEducation { get; set; }

        public decimal Salary { get; set; }

        public TimeType? TimeType { get; set; }

        public int EmployerId { get; set; }
    }
}
