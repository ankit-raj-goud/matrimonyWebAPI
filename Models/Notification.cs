using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatrimonyWebApi.Models
{
    public class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NotificationId { get; set; }

        public string Message { get; set; }

        //candidate ref
        public Guid CandidateIdRef { get; set; }
        public Candidate Candidate { get; set; }

        public DateTime Time { get; set; }

        public bool IsRead { get; set; } = false;
    }
}
