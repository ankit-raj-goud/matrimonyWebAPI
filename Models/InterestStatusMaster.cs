using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatrimonyWebApi.Models
{
    public class InterestStatusMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InterestStatusId { get; set; }
        public string InterestStatus { get; set; }
    }
}
