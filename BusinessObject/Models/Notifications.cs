using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Models
{
    public class Notifications
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NotificationId { get; set; }

        public int RecipientId { get; set; }

        public string? Content { get; set; }

        public DateTime SentDate { get; set; }

        public bool IsRead { get; set; }

        [ForeignKey("RecipientId")]
        public JobSeeker? JobSeeker { get; set; }
    }
}