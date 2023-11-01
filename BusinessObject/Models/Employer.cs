using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Models
{
    public class Employer
    {
        [Key]
        [Column("comp_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("comp_name")]
        public string? CompanyName { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("comp_address")]
        public string? CompanyAddress { get; set; }

        [Phone]
        [Column("comp_phone")]
        public string? CompanyPhoneNumber { get; set; }

        [Column("comp_logoURL")]
        public string? CompanyLogoUrl { get; set; }

        public List<Job>? Jobs { get; set; }
    }
}
