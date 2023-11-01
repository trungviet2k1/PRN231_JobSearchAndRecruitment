using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BusinessObject.Commons;

namespace BusinessObject.Models
{
    public class Account
    {
        [Key]
        [Column("acc_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("user_name")]
        public string? Username { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("password")]
        public string? Password { get; set; }

        [Required]
        [MaxLength(255)]
        [EmailAddress]
        [Column("email_address")]
        public string? Email { get; set; }

        [Required]
        [Column("user_type")]
        public UserType UserType { get; set; }

        [ForeignKey("job_seeker_id")]
        public JobSeeker? JobSeeker { get; set; }

        [ForeignKey("comp_id")]
        public Employer? Employer { get; set; }
    }
}