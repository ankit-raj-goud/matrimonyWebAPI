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
        public int CountryIdRef { get; set; }
        public CountryMaster Country { get; set; }

        public ICollection<CityMaster>Cities { get; set; }
        
    }
}
