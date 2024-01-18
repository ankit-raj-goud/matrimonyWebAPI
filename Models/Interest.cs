using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatrimonyWebApi.Models
{
    public class Interest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InterestId { get; set; }

        //sender ref
        public Guid SenderIdRef { get; set; }
        public Candidate SenderCandidate { get; set; }

        //receiver ref
        public Guid ReceiverIdRef { get; set; }
        public Candidate ReceiverCandidate { get; set; }

        //interest status
        public int InterestStatusId { get; set; }
        public InterestStatusMaster InterestStatusMaster { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
