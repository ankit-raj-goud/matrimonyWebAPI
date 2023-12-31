using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatrimonyWebApi.Models
{
    public class CityMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CityId { get; set; }
        public string? CityName{ get; set; }

        //state master ref
        public int StateIdRef { get; set; }
        public StateMaster StateMaster { get; set; }

    }
}
