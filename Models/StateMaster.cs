using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatrimonyWebApi.Models
{
    public class StateMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StateId { get; set; }

        public string? StateName { get; set; }

        //country master ref
        [Required]        
        public int CoutnryId { get; set; }
        public Country Country { get; set; }
    }
}
