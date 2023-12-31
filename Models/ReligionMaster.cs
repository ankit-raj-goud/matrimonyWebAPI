using System.ComponentModel.DataAnnotations;

namespace MatrimonyWebApi.Models
{
    public class ReligionMaster
    {
        [Key]
        public Guid ReligionId { get; set; }
        public string? ReligionName { get; set; }

        public ICollection<CasteMaster> Castes { get; set; }
    }
}
