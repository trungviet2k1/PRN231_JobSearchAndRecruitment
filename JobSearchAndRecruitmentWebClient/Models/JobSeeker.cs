﻿namespace JobSearchAndRecruitmentWebClient.Models
{
    public class JobSeeker
    {
        public int JobSeekerId { get; set; }

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? PhoneNumber { get; set; }

        public bool IsEmployer { get; set; }
    }
}
