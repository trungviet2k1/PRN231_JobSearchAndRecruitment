﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BusinessObject.Commons;

namespace BusinessObject.Models
{
    public class JobApplicant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobApplicationId { get; set; }

        public int JobSeekerId { get; set; }

        public int JobId { get; set; }

        public JobApplicationStatus ApplicationStatus { get; set; }

        [ForeignKey("JobSeekerId")]
        public JobSeeker? JobSeeker { get; set; }

        [ForeignKey("JobId")]
        public Job? Job { get; set; }
    }
}