using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatrimonyWebApi.Models
{
    public class CasteMaster
    {
        [Key]
        public Guid CasteId { get; set; }
        public string? CasteName { get; set; }

        //religion master ref
        [Required]        
        public Guid ReligionIdRef { get; set; }
        public ReligionMaster?  ReligionMaster{ get; set; }
    }
}
